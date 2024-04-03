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
    public class GlobalEventsController : ApiController
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
        public IHttpActionResult GetTop2GlobalReourcesEvents(string siteName)
        {
            string SiteName = string.Empty;
            siteName = siteName.Replace("test.", "");
            IList<GlobalEventResourceModel> objGlobalEventResourceModel = null;
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
                sqlCmd.CommandText = "NewPubsiteAPI_Global_GlobalEvents_Top2Resources";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                objGlobalEventResourceModel = new List<GlobalEventResourceModel>(dt.Rows.Count);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow data in dt.Rows)
                    {
                        objGlobalEventResourceModel.Add(new GlobalEventResourceModel
                        {
                            ID = Convert.ToInt32(data["ID"]),
                            WhitePaperTitle = data["WhitePaperTitle"].ToString(),
                            ImageUrl = data["ImageUrl"].ToString(),
                            IsSponcered = Convert.ToInt32(data["IsSponcered"]),
                            RouteURL = data["RouteURL"].ToString(),
                            ResourceType = data["ResourceType"].ToString(),
                            Tag = data["Tag"].ToString(),
                            
                        });
                    }

                }
                if (objGlobalEventResourceModel == null || objGlobalEventResourceModel.Count == 0)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(objGlobalEventResourceModel);
        }

        public IHttpActionResult GetTop3SingleReourcesEvents(string siteName)
        {
            string SiteName = string.Empty;
            siteName = siteName.Replace("test.", "");
            IList<GlobalEventResourceModel> objGlobalEventResourceModel = null;
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
                sqlCmd.CommandText = "NewPubsiteAPI_Single_SingleEvents_Top3Resources";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                objGlobalEventResourceModel = new List<GlobalEventResourceModel>(dt.Rows.Count);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow data in dt.Rows)
                    {
                        objGlobalEventResourceModel.Add(new GlobalEventResourceModel
                        {
                            ID = Convert.ToInt32(data["ID"]),
                            WhitePaperTitle = data["WhitePaperTitle"].ToString(),
                            ImageUrl = data["ImageUrl"].ToString(),
                            IsSponcered = Convert.ToInt32(data["IsSponcered"]),
                            RouteURL = data["RouteURL"].ToString(),
                            ResourceType = data["ResourceType"].ToString(),
                            Tag = data["Tag"].ToString(),
                            
                        });
                    }

                }
                if (objGlobalEventResourceModel == null || objGlobalEventResourceModel.Count == 0)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(objGlobalEventResourceModel);
        }

        [HttpGet]
        public IHttpActionResult GetGlobalEventTop3UpCommingConferences(string siteName)
        {
            IList<GlobalEventWebinarsModel> newsGlobalEventWebinarsModel = null;
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
                sqlCmd.CommandText = "PubsiteAPI_Global_Event_GetTop3UpCommingConferences";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                newsGlobalEventWebinarsModel = new List<GlobalEventWebinarsModel>(dt.Rows.Count);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow data in dt.Rows)
                    {
                        newsGlobalEventWebinarsModel.Add(new GlobalEventWebinarsModel
                        {
                            EventID = Convert.ToInt32(data["EventID"]),
                            Details = data["Details"].ToString(),
                            Name = data["Name"].ToString(),
                            ImageUrl = data["ImageUrl"].ToString(),
                            URL = data["URL"].ToString(),
                            RouteURL = data["RouteURL"].ToString(),
                            IsSponcered = Convert.ToBoolean(data["IsSponcered"]),
                            DateWithStartTime = data["StartEndDate"].ToString(),
                            EventDifferentType= data["EventDifferentType"].ToString(),
                            Country = data["Country"].ToString()
                        });
                    }

                }
                if (newsGlobalEventWebinarsModel == null || newsGlobalEventWebinarsModel.Count == 0)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Ok(newsGlobalEventWebinarsModel);
        }

        [HttpGet]
        public IHttpActionResult GetGlobalEventTop3PastConferences(string siteName)
        {
            IList<GlobalEventWebinarsModel> newsGlobalEventWebinarsModel = null;
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
                sqlCmd.CommandText = "PubsiteAPI_Global_Event_GetTop3PastConferences";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                newsGlobalEventWebinarsModel = new List<GlobalEventWebinarsModel>(dt.Rows.Count);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow data in dt.Rows)
                    {
                        newsGlobalEventWebinarsModel.Add(new GlobalEventWebinarsModel
                        {
                            EventID = Convert.ToInt32(data["EventID"]),
                            Details = data["Details"].ToString(),
                            Name = data["Name"].ToString(),
                            ImageUrl = data["ImageUrl"].ToString(),
                            URL = data["URl"].ToString(),
                            RouteURL = data["RouteURL"].ToString(),
                            IsSponcered = Convert.ToBoolean(data["IsSponcered"]),
                            DateWithStartTime = data["StartEndDate"].ToString(),
                            EventDifferentType = data["EventDifferentType"].ToString(),
                            Country = data["Country"].ToString()
                        });
                    }

                }
                if (newsGlobalEventWebinarsModel == null || newsGlobalEventWebinarsModel.Count == 0)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Ok(newsGlobalEventWebinarsModel);
        }

        [HttpGet]
        public IHttpActionResult GetGlobalEventTop3LiveWebinars(string siteName)
        {
            IList<GlobalWebinarsModel> newsGlobalWebinarsModel = null;
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
                sqlCmd.CommandText = "PubsiteAPI_Global_Even_GetTop3LiveWebinars";
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
                            Name = data["Name"].ToString(),
                            ImageUrl = data["ImageUrl"].ToString(),
                            URL = data["URL"].ToString(),
                            RouteURL = data["RouteURL"].ToString(),
                            IsSponcered = Convert.ToInt32(data["IsSponcered"]),
                            Country = data["Country"].ToString(),
                            EventDifferentType= data["EventDifferentType"].ToString(),
                            DateWithStartTime = data["DateWithStartTime"].ToString()
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
        public IHttpActionResult GetGlobalEventTop3OnDemandWebinars(string siteName)
        {
            IList<GlobalEventWebinarsModel> newsGlobalEventWebinarsModel = null;
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
                sqlCmd.CommandText = "NewPubsiteAPI_Global_Event_GetTop3OnDemandWebinar";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                newsGlobalEventWebinarsModel = new List<GlobalEventWebinarsModel>(dt.Rows.Count);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow data in dt.Rows)
                    {
                        newsGlobalEventWebinarsModel.Add(new GlobalEventWebinarsModel
                        {
                            EventID = Convert.ToInt32(data["EventID"]),
                            Details = data["Details"].ToString(),
                            Name = data["Name"].ToString(),
                            ImageUrl = data["ImageUrl"].ToString(),
                            URL = data["URL"].ToString(),
                            RouteURL = data["RouteURL"].ToString(),
                            IsSponcered = Convert.ToBoolean(data["IsSponcered"]),
                            Country = data["Country"].ToString(),
                            EventDifferentType= data["EventDifferentType"].ToString(),
                            DateWithStartTime = data["DateWithStartTime"].ToString(),
                            Keywords = data["Keywords"].ToString(),
                            Company=data["Company"].ToString()

                        });
                    }

                }
                if (newsGlobalEventWebinarsModel == null || newsGlobalEventWebinarsModel.Count == 0)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Ok(newsGlobalEventWebinarsModel);
        }
        [HttpGet]
        public IHttpActionResult GetGlobalEventAllLiveWebinars(string siteName, string pageNumber)
        {
            IList<GlobalEventWebinarsModel> newsGlobalEventWebinarsModel = null;
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
                sqlCmd.CommandText = "PubsiteAPI_Global_Event_GetAllLiveWebinar";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                newsGlobalEventWebinarsModel = new List<GlobalEventWebinarsModel>(dt.Rows.Count);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow data in dt.Rows)
                    {
                        newsGlobalEventWebinarsModel.Add(new GlobalEventWebinarsModel
                        {
                            EventID = Convert.ToInt32(data["EventID"]),
                            Details = Utils.HtmlDecode(data["Details"].ToString()),
                            Name = data["Name"].ToString(),
                            ImageUrl = data["ImageUrl"].ToString(),
                            URL = data["URL"].ToString(),
                            RouteURL = data["RouteURL"].ToString(),
                            IsSponcered = Convert.ToBoolean(data["IsSponcered"]),
                            Country = data["Country"].ToString(),
                            DateWithStartTime = data["DateWithStartTime"].ToString(),
                            EventDifferentType= data["EventDifferentType"].ToString(),
                            TotalDataCount = Convert.ToInt32(data["TotalDataCount"])
                        });
                    }

                }
                if (newsGlobalEventWebinarsModel == null || newsGlobalEventWebinarsModel.Count == 0)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Ok(newsGlobalEventWebinarsModel);
        }

        [HttpGet]
        public IHttpActionResult GetGlobalEventAllOnDemandWebinars(string siteName, string pageNumber)
        {
            IList<GlobalEventWebinarsModel> newsGlobalEventWebinarsModel = null;
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
                sqlCmd.CommandText = "NewPubsiteAPI_Global_Event_GetAllOnDemandWebinar";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                newsGlobalEventWebinarsModel = new List<GlobalEventWebinarsModel>(dt.Rows.Count);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow data in dt.Rows)
                    {
                        newsGlobalEventWebinarsModel.Add(new GlobalEventWebinarsModel
                        {
                            EventID = Convert.ToInt32(data["EventID"]),
                            Details = Utils.HtmlDecode(data["Details"].ToString()),
                            Name = data["Name"].ToString(),
                            ImageUrl = data["ImageUrl"].ToString(),
                            URL = data["URL"].ToString(),
                            RouteURL = data["RouteURL"].ToString(),
                            IsSponcered = Convert.ToBoolean(data["IsSponcered"]),
                            Country = data["Country"].ToString(),
                            DateWithStartTime = data["DateWithStartTime"].ToString(),
                            EventDifferentType = data["EventDifferentType"].ToString(),
                            TotalDataCount = Convert.ToInt32(data["TotalDataCount"]),
                            Keywords = data["Keywords"].ToString(),
                            Company = data["Company"].ToString(),
                            Sponsors = data["Sponsors"].ToString()
                        });
                    }

                }
                if (newsGlobalEventWebinarsModel == null || newsGlobalEventWebinarsModel.Count == 0)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Ok(newsGlobalEventWebinarsModel);
        }

        [HttpGet]
        public IHttpActionResult GetGlobalEventAllPastConferences(string siteName,string pageNumber)
        {
            IList<GlobalEventWebinarsModel> newsGlobalEventWebinarsModel = null;
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
                sqlCmd.Parameters.AddWithValue("@pageNumber", pageNumber);
                
                sqlCmd.CommandText = "PubsiteAPI_Global_Event_GetAllPastConferences";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                newsGlobalEventWebinarsModel = new List<GlobalEventWebinarsModel>(dt.Rows.Count);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow data in dt.Rows)
                    {
                        newsGlobalEventWebinarsModel.Add(new GlobalEventWebinarsModel
                        {
                            EventID = Convert.ToInt32(data["EventID"]),
                            Details = Utils.HtmlDecode(data["Details"].ToString()),
                            Name = data["Name"].ToString(),
                            ImageUrl = data["ImageUrl"].ToString(),
                            URL = data["URl"].ToString(),
                            RouteURL = data["RouteURL"].ToString(),
                            IsSponcered =Convert.ToBoolean(data["IsSponcered"]),
                            DateWithStartTime = data["StartEndDate"].ToString(),
                            Country = data["Country"].ToString(),
                            EventDifferentType = data["EventDifferentType"].ToString(),
                            TotalDataCount = Convert.ToInt32(data["TotalDataCount"])

                        });
                    }

                }
                if (newsGlobalEventWebinarsModel == null || newsGlobalEventWebinarsModel.Count == 0)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Ok(newsGlobalEventWebinarsModel);
        }

        [HttpGet]
        public IHttpActionResult GetGlobalEventAllUpCommingConferences(string siteName, string pageNumber)
        {
            IList<GlobalEventWebinarsModel> newsGlobalEventWebinarsModel = null;
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
                sqlCmd.CommandText = "PubsiteAPI_Global_Event_GetAllUpCommingConferences";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                newsGlobalEventWebinarsModel = new List<GlobalEventWebinarsModel>(dt.Rows.Count);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow data in dt.Rows)
                    {
                        newsGlobalEventWebinarsModel.Add(new GlobalEventWebinarsModel
                        {
                            EventID = Convert.ToInt32(data["EventID"]),
                            Details = Utils.HtmlDecode(data["Details"].ToString()),
                            Name = data["Name"].ToString(),
                            ImageUrl = data["ImageUrl"].ToString(),
                            URL = data["URL"].ToString(),
                            RouteURL = data["RouteURL"].ToString(),
                            IsSponcered = Convert.ToBoolean(data["IsSponcered"]),
                            Country = data["Country"].ToString(),
                             DateWithStartTime = data["StartEndDate"].ToString(),
                             EventDifferentType= data["EventDifferentType"].ToString(),
                            TotalDataCount = Convert.ToInt32(data["TotalDataCount"])
                        });
                    }

                }
                if (newsGlobalEventWebinarsModel == null || newsGlobalEventWebinarsModel.Count == 0)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Ok(newsGlobalEventWebinarsModel);
        }

        [HttpGet]
        public IHttpActionResult GetGlobalEventConferenceSpotLight(string siteName)
        {
            IList<SpotLightModel> objSpotLight = null;
            string SiteName = "";
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
                sqlCmd.CommandText = "PubsiteAPI_Global_Event_GetTop1GlobalConferenceSpotLight";
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
                            RouteURL = data["RouteURL"].ToString(),
                            Description = data["Description"].ToString(),

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
    }
}
