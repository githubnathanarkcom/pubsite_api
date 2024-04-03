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
    public class GlobalReourcesController : ApiController
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
        public IHttpActionResult GetAllGlobalReourcesArticle(string siteName,string pageNumber)
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
                // Connection();
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                if (SiteName == string.Empty)
                {
                    SiteName = siteName;

                    if (SiteName.Contains("."))
                        SiteName = SiteName.Split('.')[0].Trim();
                }
                sqlCmd.Parameters.AddWithValue("@SiteName", SiteName);
                sqlCmd.Parameters.AddWithValue("@PageNumber", pageNumber);
                sqlCmd.CommandText = "NewPubsiteAPI_Global_Resources_GetAllGlobalReourcesArticle";
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
                            Description = Utils.HtmlDecode(data["Description"].ToString()),
                            ResourceType = data["ResourceType"].ToString(),
                            ImageUrl = data["ImageUrl"].ToString(),
                            IsSponcered = Convert.ToBoolean(data["IsSponcered"]),
                            RouteURL = data["RouteURL"].ToString(),
                            EntryDate = Convert.ToDateTime(data["EntryDate"]),
                            WhitePaperTitle = data["WhitePaperTitle"].ToString(),
                            PublishingDate = Convert.ToDateTime(data["PublishingDate"]),
                            PublishingDate1 = data["PublishingDate1"].ToString(),
                            WebPageURL = data["WebPageURL"].ToString(),
                            TotalDataCount = Convert.ToInt32(data["TotalDataCount"]),
                            Tag = data["Tag"].ToString()
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
        public IHttpActionResult GetAllGlobalReourcesArticleCategoryTag(string siteName,string Tag)
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
                // Connection();
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                if (SiteName == string.Empty)
                {
                    SiteName = siteName;

                    if (SiteName.Contains("."))
                        SiteName = SiteName.Split('.')[0].Trim();
                }
                sqlCmd.Parameters.AddWithValue("@SiteName", SiteName);
                sqlCmd.Parameters.AddWithValue("@Tag", Tag);
                sqlCmd.CommandText = "NewPubsiteAPI_Global_Resources_GetAllGlobalReourcesArticleCategoryTag";
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
                            Description = data["Description"].ToString(),
                            ResourceType = data["ResourceType"].ToString(),
                            ImageUrl = data["ImageUrl"].ToString(),
                            IsSponcered = Convert.ToBoolean(data["IsSponcered"]),
                            RouteURL = data["RouteURL"].ToString(),
                            EntryDate = Convert.ToDateTime(data["EntryDate"]),
                            WhitePaperTitle = data["WhitePaperTitle"].ToString(),
                            PublishingDate = Convert.ToDateTime(data["PublishingDate"]),
                            PublishingDate1 = data["PublishingDate1"].ToString(),
                            WebPageURL = data["WebPageURL"].ToString(),
                            //TotalDataCount = Convert.ToInt32(data["TotalDataCount"]),
                            Tag = data["Tag"].ToString()
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
        public IHttpActionResult GetAllGlobalReourcesArticleCategoryTag(string siteName,string Tag, string pageNumber)
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
                // Connection();
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                if (SiteName == string.Empty)
                {
                    SiteName = siteName;

                    if (SiteName.Contains("."))
                        SiteName = SiteName.Split('.')[0].Trim();
                }
                sqlCmd.Parameters.AddWithValue("@SiteName", SiteName);
                sqlCmd.Parameters.AddWithValue("@Tag", Tag);
                sqlCmd.Parameters.AddWithValue("@PageNumber", pageNumber);
                sqlCmd.CommandText = "NewPubsiteAPI_Global_Resources_GetAllGlobalReources_Article_CategoryTag";
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
                            Description = data["Description"].ToString(),
                            ResourceType = data["ResourceType"].ToString(),
                            ImageUrl = data["ImageUrl"].ToString(),
                            IsSponcered = Convert.ToBoolean(data["IsSponcered"]),
                            RouteURL = data["RouteURL"].ToString(),
                            EntryDate = Convert.ToDateTime(data["EntryDate"]),
                            WhitePaperTitle = data["WhitePaperTitle"].ToString(),
                            PublishingDate = Convert.ToDateTime(data["PublishingDate"]),
                            PublishingDate1 = data["PublishingDate1"].ToString(),
                            WebPageURL = data["WebPageURL"].ToString(),
                            TotalDataCount = Convert.ToInt32(data["TotalDataCount"]),
                            Tag = data["Tag"].ToString()
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
        public IHttpActionResult GetAllGlobalReourcesVideos(string siteName, string pageNumber)
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
                //Connection();
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                if (SiteName == string.Empty)
                {
                    SiteName = siteName;

                    if (SiteName.Contains("."))
                        SiteName = SiteName.Split('.')[0].Trim();
                }
                sqlCmd.Parameters.AddWithValue("@SiteName", SiteName);
                sqlCmd.Parameters.AddWithValue("@PageNumber", pageNumber);
                sqlCmd.CommandText = "PubsiteAPI_Global_Resources_GetAllGlobalReourcesVideos";
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
                            Description = Utils.HtmlDecode(data["description"].ToString()),
                            ResourceType = data["ResourceType"].ToString(),
                            ImageUrl = data["ImageUrl"].ToString(),
                            IsSponcered = Convert.ToBoolean(data["IsSponcered"]),
                            RouteURL = data["RouteURL"].ToString(),
                            EntryDate = Convert.ToDateTime(data["EntryDate"]),
                            WhitePaperTitle = data["WhitePaperTitle"].ToString(),
                            PublishingDate = Convert.ToDateTime(data["PublishingDate"]),
                            PublishingDate1 = data["PublishingDate1"].ToString(),
                            WebPageURL = data["WebPageURL"].ToString(),
                            TotalDataCount = Convert.ToInt32(data["TotalDataCount"])
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
        public IHttpActionResult GetAllGlobalReourcesWhitePapers(string siteName, string pageNumber)
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
                // Connection();
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                if (SiteName == string.Empty)
                {
                    SiteName = siteName;

                    if (SiteName.Contains("."))
                        SiteName = SiteName.Split('.')[0].Trim();
                }
                sqlCmd.Parameters.AddWithValue("@SiteName", SiteName);
                sqlCmd.Parameters.AddWithValue("@PageNumber", pageNumber);
                sqlCmd.CommandText = "NewPubsiteAPI_Global_Resources_GetAllGlobalReourcesWhitePapers";
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
                            Description = Utils.HtmlDecode(data["description"].ToString()),
                            ResourceType = data["ResourceType"].ToString(),
                            ImageUrl = data["ImageUrl"].ToString(),
                            IsSponcered = Convert.ToBoolean(data["IsSponcered"]),
                            RouteURL = data["RouteURL"].ToString(),
                            EntryDate = Convert.ToDateTime(data["EntryDate"]),
                            WhitePaperTitle = data["WhitePaperTitle"].ToString(),
                            PublishingDate = Convert.ToDateTime(data["PublishingDate"]),
                            PublishingDate1 = data["PublishingDate1"].ToString(),
                            WebPageURL = data["WebPageURL"].ToString(),
                            TotalDataCount = Convert.ToInt32(data["TotalDataCount"])
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
        public IHttpActionResult GetAllGlobalReourcesInfographics(string siteName, string pageNumber)
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
                //Connection();
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                if (SiteName == string.Empty)
                {
                    SiteName = siteName;

                    if (SiteName.Contains("."))
                        SiteName = SiteName.Split('.')[0].Trim();
                }
                sqlCmd.Parameters.AddWithValue("@SiteName", SiteName);
                sqlCmd.Parameters.AddWithValue("@PageNumber", pageNumber);
                sqlCmd.CommandText = "PubsiteAPI_Global_Resources_GetAllGlobalReourcesInfographics";
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
                            Description = Utils.HtmlDecode(data["description"].ToString()),
                            ResourceType = data["ResourceType"].ToString(),
                            ImageUrl = data["ImageUrl"].ToString(),
                            IsSponcered = Convert.ToBoolean(data["IsSponcered"]),
                            RouteURL = data["RouteURL"].ToString(),
                            EntryDate = Convert.ToDateTime(data["EntryDate"]),
                            WhitePaperTitle = data["WhitePaperTitle"].ToString(),
                            PublishingDate = Convert.ToDateTime(data["PublishingDate"]),
                            PublishingDate1 = data["PublishingDate1"].ToString(),
                            WebPageURL = data["WebPageURL"].ToString(),
                            TotalDataCount = Convert.ToInt32(data["TotalDataCount"])
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
        public IHttpActionResult GetAllGlobalReourcesLiveWebinars(string siteName, string pageNumber)
        {
            IList<GlobalWebinarsModel> newsGlobalWebinarsModel = null;
            string SiteName = string.Empty;
            siteName = siteName.Replace("test.", "");
            try
            {
                Connection();
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                if (SiteName == string.Empty)
                {
                    SiteName = siteName;

                    if (SiteName.Contains("."))
                        SiteName = SiteName.Split('.')[0].Trim();
                }
                sqlCmd.Parameters.AddWithValue("@SiteName", SiteName);
                sqlCmd.Parameters.AddWithValue("@PageNumber", pageNumber);
                sqlCmd.CommandText = "PubsiteAPI_Global_Resources_GetAllGlobalLiveWebinars";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                newsGlobalWebinarsModel = new List<GlobalWebinarsModel>(dt.Rows.Count);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow data in dt.Rows)
                    {
                        newsGlobalWebinarsModel.Add(new GlobalWebinarsModel
                        {
                            EventID = Convert.ToInt32(data["EventID"]),
                            Details = data["Details"].ToString(),
                            DateWithStartTime = data["DateWithStartTime"].ToString(),
                            Name = data["Name"].ToString(),
                            ImageUrl = data["ImageUrl"].ToString(),
                            URL = data["URl"].ToString(),
                            RouteURL = data["RouteURL"].ToString(),
                            IsSponcered = Convert.ToInt32(data["IsSponcered"]),
                            eventtype = data["eventtype"].ToString(),
                            IsActive = (Boolean)data["isactive"],
                            EventDifferentType= data["EventDifferentType"].ToString(),
                            TotalDataCount = Convert.ToInt32(data["TotalDataCount"])
                        });
                    }

                }
                if (newsGlobalWebinarsModel == null || newsGlobalWebinarsModel.Count == 0)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Ok(newsGlobalWebinarsModel);
        }


        [HttpGet]
        public IHttpActionResult GetAllGlobalReourcesOnDemandWebinars(string siteName,string pageNumber)
        {
            IList<GlobalWebinarsModel> newsGlobalWebinarsModel = null;
            string SiteName = string.Empty;
            siteName = siteName.Replace("test.", "");
            try
            {
                Connection();
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                if (SiteName == string.Empty)
                {
                    SiteName = siteName;

                    if (SiteName.Contains("."))
                        SiteName = SiteName.Split('.')[0].Trim();
                }
                sqlCmd.Parameters.AddWithValue("@SiteName", SiteName); 
                sqlCmd.Parameters.AddWithValue("@PageNumber", pageNumber);

                sqlCmd.CommandText = "PubsiteAPI_Global_GetAllOnDemandWebinars";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                newsGlobalWebinarsModel = new List<GlobalWebinarsModel>(dt.Rows.Count);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow data in dt.Rows)
                    {
                        newsGlobalWebinarsModel.Add(new GlobalWebinarsModel
                        {
                            EventID = Convert.ToInt32(data["EventID"]),
                            Details = data["Details"].ToString(),
                            DateWithStartTime = data["DateWithStartTime"].ToString(),
                            Name = data["Name"].ToString(),
                            ImageUrl = data["ImageUrl"].ToString(),
                            URL = data["URl"].ToString(),
                            RouteURL = data["RouteURL"].ToString(),
                            IsSponcered = Convert.ToInt32(data["IsSponcered"]),
                            eventtype = data["eventtype"].ToString(),
                            EventDifferentType = data["EventDifferentType"].ToString(),
                            IsActive = (Boolean)data["isactive"],
                            TotalDataCount = Convert.ToInt32(data["TotalDataCount"]),
                        });
                    }

                }
                if (newsGlobalWebinarsModel == null || newsGlobalWebinarsModel.Count == 0)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Ok(newsGlobalWebinarsModel);
        }


        [HttpGet]
        public IHttpActionResult GetTop1GlobalReourcesSpotLight(string siteName)
        {
            IList<SpotLightModel> objSpotLight = null;
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
                sqlCmd.CommandText = "NewPubsiteAPI_Global_Resources_GetTop1GlobalReourcesSpotLight";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                objSpotLight = new List<SpotLightModel>(dt.Rows.Count);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow data in dt.Rows)
                    {
                        objSpotLight.Add(new SpotLightModel
                        {
                            EventID = Convert.ToInt32(data["EventID"]),
                            Name = data["Name"].ToString(),
                            ImageUrl = data["ImageUrl"].ToString(),
                            IsSponcered = Convert.ToInt32(data["IsSponcered"]),
                            URL = data["URL"].ToString(),
                            RouteURL = data["RouteURL"].ToString(),
                            Description = data["Description"].ToString(),
                            Tag= data["Tag"].ToString(),

                        });
                    }

                }
                if (objSpotLight == null || objSpotLight.Count == 0)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(objSpotLight);
        }


        [HttpGet]
        public IHttpActionResult GetTop2GlobalReourcesEvents(string siteName)
        {
            string SiteName = string.Empty;
            siteName = siteName.Replace("test.", "");
            IList<NewsEventModel> objEventModel = null;
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
                sqlCmd.CommandText = "NewPubsiteAPI_Global_Resources_GetTop2GlobalReourcesEvents";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                objEventModel = new List<NewsEventModel>(dt.Rows.Count);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow data in dt.Rows)
                    {
                        objEventModel.Add(new NewsEventModel
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
                if (objEventModel == null || objEventModel.Count == 0)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(objEventModel);
        }
    }
}
