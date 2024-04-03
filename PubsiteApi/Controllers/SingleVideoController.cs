using PubsiteApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PubsiteApi.Controllers
{
    public class SingleVideosController : ApiController
    {
        private SqlConnection scon = null;

        private void Connection()
        {
            try
            {
                scon = new SqlConnection("Data Source=3.108.12.178;User ID=theiotrep1;Initial Catalog=theiotrep; Password=8g)mB9w3");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void PharmaSmallConnection()
        {
            try
            {
                scon = new SqlConnection("Data Source=3.108.12.178;User ID=GeneReport1;Initial Catalog=GeneReport; Password=75j]G)sC");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public IHttpActionResult GetSingleVideos(string siteName, string RouteURL)
        {
            SingleVideosModel objSingleVideosModel = null;
            string SiteName = "";
            siteName = siteName.Replace("test.", "");
            try
            {
                if (siteName == "pharmaceutical.report" || siteName == "smallbusiness.report")
                {
                    PharmaSmallConnection();
                }
                else
                {
                    Connection();
                }

                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                if (SiteName == string.Empty)
                {
                    SiteName = siteName;

                    if (SiteName.Contains("."))
                        SiteName = SiteName.Split('.')[0].Trim();
                }
                sqlCmd.Parameters.AddWithValue("@SiteName", SiteName);
                sqlCmd.Parameters.AddWithValue("@RouteURL", RouteURL);


                sqlCmd.CommandText = "NewPubsiteAPI_Single_Videos_GetSingleVideos";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                objSingleVideosModel = new SingleVideosModel();
                if (dt.Rows.Count > 0)
                {

                    objSingleVideosModel.ID = Convert.ToInt32(dt.Rows[0]["ID"]);
                    objSingleVideosModel.WhitePaperTitle = dt.Rows[0]["WhitePaperTitle"].ToString();
                    objSingleVideosModel.Description = dt.Rows[0]["Description"].ToString();
                    objSingleVideosModel.PublishingDate1 = dt.Rows[0]["PublishingDate1"].ToString();
                    objSingleVideosModel.ResourceType = dt.Rows[0]["ResourceType"].ToString();
                    objSingleVideosModel.ImageUrl = dt.Rows[0]["ImageUrl"].ToString();
                    objSingleVideosModel.RouteURL = dt.Rows[0]["RouteURL"].ToString();
                    objSingleVideosModel.WebPageURL = dt.Rows[0]["WebPageURL"].ToString();
                    objSingleVideosModel.EntryDate = dt.Rows[0]["EntryDate"].ToString();
                    objSingleVideosModel.VideoType = dt.Rows[0]["VideoType"].ToString();
                    objSingleVideosModel.EmbededVideoURL = dt.Rows[0]["EmbadedVideoURL"].ToString();
                    objSingleVideosModel.VideoURL = dt.Rows[0]["video_url"].ToString();
                    objSingleVideosModel.IsSponcered = Convert.ToBoolean(dt.Rows[0]["IsSponcered"]);
                    objSingleVideosModel.Tag = dt.Rows[0]["Tag"].ToString();
                    objSingleVideosModel.ISINDEX = Convert.ToInt32(dt.Rows[0]["ISINDEX"]);
                    objSingleVideosModel.IsFollow = Convert.ToInt32(dt.Rows[0]["IsFollow"]);
                    objSingleVideosModel.ManualCanonical = dt.Rows[0]["ManualCanonical"].ToString();
                    objSingleVideosModel.MetaTitle = Utils.HtmlDecode(dt.Rows[0]["MetaTitle"].ToString());
                    objSingleVideosModel.MetaDescription = Utils.HtmlDecode(dt.Rows[0]["MetaDescription"].ToString());
                    objSingleVideosModel.ImageAltTag = dt.Rows[0]["ImageAltTag"].ToString();
                    objSingleVideosModel.Keywords = Utils.HtmlDecode(dt.Rows[0]["Keywords"].ToString());
                }
                if (objSingleVideosModel == null)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(objSingleVideosModel);
        }

        public IHttpActionResult GetTop4SingleOtherVideos(string siteName, string RouteURL)
        {
            IList<SingleVideosModel> videosModelData = null;
            string SiteName = string.Empty;
            siteName = siteName.Replace("test.", "");
            try
            {
                if (siteName == "pharmaceutical.report" || siteName == "smallbusiness.report")
                {
                    PharmaSmallConnection();
                }
                else
                {
                    Connection();
                }




                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                if (SiteName == string.Empty)
                {
                    SiteName = siteName;

                    if (SiteName.Contains("."))
                        SiteName = SiteName.Split('.')[0].Trim();
                }
                sqlCmd.Parameters.AddWithValue("@SiteName", SiteName);
                sqlCmd.Parameters.AddWithValue("@RouteURL", RouteURL);
                sqlCmd.CommandText = "NewPubsiteAPI_Single_Videos_GetTop4SingleOtherVideos";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                videosModelData = new List<SingleVideosModel>(dt.Rows.Count);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow data in dt.Rows)
                    {
                        videosModelData.Add(new SingleVideosModel
                        {
                            ID = Convert.ToInt32(data["ID"]),
                            //Author = data["Author"].ToString(),
                            WhitePaperTitle = data["WhitePaperTitle"].ToString(),
                            PublishingDate1 = data["Date"].ToString(),
                            ImageUrl = data["ImageUrl"].ToString(),
                            Description = data["Description"].ToString(),
                            EmbededVideoURL = data["EmbadedVideoURL"].ToString(),
                            RouteURL = data["RouteURL"].ToString(),
                            IsSponcered = Convert.ToBoolean(data["IsSponcered"]),
                            VideoType = data["VideoType"].ToString(),
                            ResourceType = data["ResourceType"].ToString()
                        });
                    }

                }
                if (videosModelData == null || videosModelData.Count == 0)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Ok(videosModelData);
        }


        protected string GetYouTubeScript(string id)
        {
            if (id.Contains("https://youtu.be/"))
                id = id.Replace("https://youtu.be/", "");
            string scr = @"<object width='600' height='340'> ";
            scr = scr + @"<param name='movie' value='https://www.youtube.com/v/" + id + "'></param> ";
            scr = scr + @"<param name='allowFullScreen' value='true'></param> ";
            scr = scr + @"<param name='allowscriptaccess' value='always'></param> ";
            scr = scr + @"<emb ed src='https://www.youtube.com/v/" + id + "' ";
            scr = scr + @"type='application/x-shockwave-flash' allowscriptaccess='always' ";
            scr = scr + @"allowfullscreen='true' width='100%' height='350' > ";
            scr = scr + @"</embed></object>";
            return scr;
        }

    }
}
