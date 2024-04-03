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
    public class SinglwWhitePaperController : ApiController
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
        public IHttpActionResult GetTop1SingleWhitePaperById(string siteName, string RouteURL)
        {
            string SiteName = string.Empty;
            siteName = siteName.Replace("test.", "");
            SingleWhitePaperModel objSingleWhitePaperModel = null;
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
                sqlCmd.CommandText = "NewPubsiteAPI_Single_WhitePaper_GetTop1SingleWhitePaperByRouteURL";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                objSingleWhitePaperModel = new SingleWhitePaperModel();
                if (dt.Rows.Count > 0)
                {


                    objSingleWhitePaperModel.ID = Convert.ToInt32(dt.Rows[0]["ID"]);
                    objSingleWhitePaperModel.WhitePaperTitle = dt.Rows[0]["WhitePaperTitle"].ToString();
                    objSingleWhitePaperModel.RouteURL = dt.Rows[0]["RouteURL"].ToString();
                    objSingleWhitePaperModel.ImageUrl = dt.Rows[0]["ImageUrl"].ToString();
                    objSingleWhitePaperModel.PublishingDate1 = dt.Rows[0]["PublishingDate1"].ToString();
                    objSingleWhitePaperModel.Description = dt.Rows[0]["Description"].ToString();
                    objSingleWhitePaperModel.IsSponcered = Convert.ToBoolean(dt.Rows[0]["IsSponcered"]);
                    objSingleWhitePaperModel.PDFUrl = dt.Rows[0]["PDFUrl"].ToString();
                    objSingleWhitePaperModel.ResourceType = dt.Rows[0]["ResourceType"].ToString();
                    objSingleWhitePaperModel.tag = dt.Rows[0]["Tag"].ToString();
                    objSingleWhitePaperModel.ISINDEX = Convert.ToInt32(dt.Rows[0]["ISINDEX"]);
                    objSingleWhitePaperModel.IsFollow = Convert.ToInt32(dt.Rows[0]["IsFollow"]);
                    objSingleWhitePaperModel.ManualCanonical = dt.Rows[0]["ManualCanonical"].ToString();
                    objSingleWhitePaperModel.MetaTitle = Utils.HtmlDecode(dt.Rows[0]["MetaTitle"].ToString());
                    objSingleWhitePaperModel.MetaDescription = Utils.HtmlDecode(dt.Rows[0]["MetaDescription"].ToString());
                    objSingleWhitePaperModel.ImageAltTag = dt.Rows[0]["ImageAltTag"].ToString();
                    objSingleWhitePaperModel.Keywords = Utils.HtmlDecode(dt.Rows[0]["Keywords"].ToString());

                }
                if (objSingleWhitePaperModel == null)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(objSingleWhitePaperModel);
        }

        [HttpGet]
        public IHttpActionResult GetTop6SingleWhitePapers(string siteName, string RouteURL)
        {
            IList<GlobalResourcesModel> objGlobalResourcesArticleModel = null;
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
                sqlCmd.CommandText = "NewPubsiteAPI_Single_WhitePaper_GetTop6SingleWhitePapers";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                objGlobalResourcesArticleModel = new List<GlobalResourcesModel>(dt.Rows.Count);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow data in dt.Rows)
                    {
                        objGlobalResourcesArticleModel.Add(new GlobalResourcesModel
                        {
                            ID = Convert.ToInt32(data["ID"]),
                            Description = data["description"].ToString(),
                            ResourceType = data["ResourceType"].ToString(),
                            ImageUrl = data["ImageUrl"].ToString(),
                            IsSponcered = Convert.ToBoolean(data["IsSponcered"]),
                            RouteURL = data["RouteURL"].ToString(),
                            EntryDate = Convert.ToDateTime(data["EntryDate"]),
                            WhitePaperTitle = data["WhitePaperTitle"].ToString(),
                            PublishingDate = Convert.ToDateTime(data["PublishingDate"]),
                            PublishingDate1 = data["PublishingDate1"].ToString(),
                            WebPageURL = data["WebPageURL"].ToString(),
                        });
                    }

                }
                if (objGlobalResourcesArticleModel == null || objGlobalResourcesArticleModel.Count == 0)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(objGlobalResourcesArticleModel);
        }

        [HttpGet]
        public IHttpActionResult GetSingleWhitePaperSpotLight(string siteName)
        {
            string SiteName = string.Empty;
            siteName = siteName.Replace("test.", "");
            SingleWhitePaperSpotLightModel objSingleWhitePaperSpotLightModel = null;
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
                sqlCmd.CommandText = "NewPubsiteAPI_Single_WhitePaper_TOP1SpotLight";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                objSingleWhitePaperSpotLightModel = new SingleWhitePaperSpotLightModel();
                if (dt.Rows.Count > 0)
                {

                    objSingleWhitePaperSpotLightModel.ID = Convert.ToInt32(dt.Rows[0]["ID"]);
                    objSingleWhitePaperSpotLightModel.Name = dt.Rows[0]["Name"].ToString();
                    objSingleWhitePaperSpotLightModel.Description = dt.Rows[0]["Description"].ToString();
                    objSingleWhitePaperSpotLightModel.ImageUrl = dt.Rows[0]["ImageUrl"].ToString();
                    objSingleWhitePaperSpotLightModel.RouteURL = dt.Rows[0]["RouteURL"].ToString();
                    objSingleWhitePaperSpotLightModel.URL = dt.Rows[0]["URL"].ToString();


                }
                if (objSingleWhitePaperSpotLightModel == null)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(objSingleWhitePaperSpotLightModel);
        }

        [HttpGet]
        public IHttpActionResult GetSingleWhitePaperTop3Events(string siteName)
        {
            string SiteName = string.Empty;
            siteName = siteName.Replace("test.", "");
            IList<SingleWhitePaperEvetsModel> objSingleWhitePaperEvetsModel = null;
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
                sqlCmd.CommandText = "NewPubsiteAPI_Single_WhitePaper_GetSingleWhitePaperTop3Events";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                objSingleWhitePaperEvetsModel = new List<SingleWhitePaperEvetsModel>(dt.Rows.Count);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow data in dt.Rows)
                    {
                        objSingleWhitePaperEvetsModel.Add(new SingleWhitePaperEvetsModel
                        {
                            EventID = Convert.ToInt32(data["EventID"]),
                            Name = data["Name"].ToString(),
                            ImageUrl = data["ImageUrl"].ToString(),
                            IsSponcered = Convert.ToInt32(data["IsSponcered"]),
                            RouteURL = data["RouteURL"].ToString(),
                            EventType = data["EventType"].ToString(),
                            Description = data["Description"].ToString()
                        });
                    }

                }
                if (objSingleWhitePaperEvetsModel == null || objSingleWhitePaperEvetsModel.Count == 0)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(objSingleWhitePaperEvetsModel);
        }
    }
}
