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
    public class SingleInfographicsController : ApiController
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
        public IHttpActionResult GetSingleInfographicById(string siteName, string RouteURL)
        {
           SingleInfographicsModel objSingleInfographicsModel = null;
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
                sqlCmd.CommandText = "NewPubsiteAPI_Single_Infographics_GetSingleInfographicByRouteURL";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                objSingleInfographicsModel = new SingleInfographicsModel();
                if (dt.Rows.Count > 0)
                {

                    objSingleInfographicsModel.ID = Convert.ToInt32(dt.Rows[0]["ID"]);
                    objSingleInfographicsModel.Description = dt.Rows[0]["description"].ToString();
                    objSingleInfographicsModel.ResourceType = dt.Rows[0]["ResourceType"].ToString();
                    objSingleInfographicsModel.ImageUrl = dt.Rows[0]["ImageUrl"].ToString();
                    objSingleInfographicsModel.IsSponcered = Convert.ToBoolean(dt.Rows[0]["IsSponcered"]);
                    objSingleInfographicsModel.RouteURL = dt.Rows[0]["RouteURL"].ToString();
                    objSingleInfographicsModel.EntryDate = Convert.ToDateTime(dt.Rows[0]["EntryDate"]);
                    objSingleInfographicsModel.WhitePaperTitle = dt.Rows[0]["WhitePaperTitle"].ToString();
                    objSingleInfographicsModel.PublishingDate = Convert.ToDateTime(dt.Rows[0]["PublishingDate"]);
                    objSingleInfographicsModel.PublishingDate1 = dt.Rows[0]["PublishingDate1"].ToString();
                    objSingleInfographicsModel.WebPageURL = dt.Rows[0]["WebPageURL"].ToString();
                    objSingleInfographicsModel.PDFUrl = dt.Rows[0]["PDFUrl"].ToString();
                    objSingleInfographicsModel.tag = dt.Rows[0]["Tag"].ToString();
                    //TotalDataCount = Convert.ToInt32(data["TotalDataCount"])
                    objSingleInfographicsModel.ISINDEX = Convert.ToInt32(dt.Rows[0]["ISINDEX"]);
                    objSingleInfographicsModel.IsFollow = Convert.ToInt32(dt.Rows[0]["IsFollow"]);
                    objSingleInfographicsModel.ManualCanonical = dt.Rows[0]["ManualCanonical"].ToString();
                    objSingleInfographicsModel.MetaTitle = Utils.HtmlDecode(dt.Rows[0]["MetaTitle"].ToString());
                    objSingleInfographicsModel.MetaDescription = Utils.HtmlDecode(dt.Rows[0]["MetaDescription"].ToString());
                    objSingleInfographicsModel.ImageAltTag = dt.Rows[0]["ImageAltTag"].ToString();
                    objSingleInfographicsModel.Keywords = Utils.HtmlDecode(dt.Rows[0]["Keywords"].ToString());

                }
                if (objSingleInfographicsModel == null )
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(objSingleInfographicsModel);
        }

        [HttpGet]
        public IHttpActionResult GetTop6SingleInfographics(string siteName, string RouteURL)
        {
            IList<SingleInfographicsModel> objSingleInfographicsModel = null;
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
                sqlCmd.CommandText = "NewPubsiteAPI_Single_Infographics_GetTop6SingleInfographics";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                objSingleInfographicsModel = new List<SingleInfographicsModel>(dt.Rows.Count);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow data in dt.Rows)
                    {
                        objSingleInfographicsModel.Add(new SingleInfographicsModel
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
                            PDFUrl = data["PDFUrl"].ToString()
                        });
                    }

                }
                if (objSingleInfographicsModel == null || objSingleInfographicsModel.Count == 0)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(objSingleInfographicsModel);
        }

        [HttpGet]
        public IHttpActionResult GetSingleInfographicsSpotLight(string siteName)
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
                sqlCmd.CommandText = "NewPubsiteAPI_Single_Infographics_TOP1SpotLight";
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
                if (objSingleWhitePaperSpotLightModel == null )
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
        public IHttpActionResult GetSingleInfographicsTop3Events(string siteName)
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
                sqlCmd.CommandText = "NewPubsiteAPI_Single_Infographics_GetSingleInfographicsTop3Events";
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
