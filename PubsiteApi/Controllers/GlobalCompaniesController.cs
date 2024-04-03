using PubsiteApi.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PubsiteApi.Controllers
{
    public class GlobalCompaniesController : ApiController
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
        public IHttpActionResult GetAllGlobalCompanies(string siteName, int pageNumber)
        {
            string SiteName = string.Empty;
            siteName = siteName.Replace("test.", "");
            IList<GolbalCompaniesModel> objCompaniesModel = null;
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
                sqlCmd.Parameters.AddWithValue("@PageNumber", pageNumber);
                sqlCmd.CommandText = "PubsiteAPI_Global_GetAllGlobalCompanies";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                objCompaniesModel = new List<GolbalCompaniesModel>(dt.Rows.Count);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow data in dt.Rows)
                    {
                        objCompaniesModel.Add(new GolbalCompaniesModel
                        {
                            ID = Convert.ToInt32(data["ID"]),
                            CompanyName = data["Company_Name"].ToString(),
                            Logo = data["Logo"].ToString(),
                            DomainName = data["Domain_Name"].ToString(),
                            //DomainURL = data["Domain_Url"].ToString(),
                            EntryDate = data["EntryDate"].ToString(),
                            Description = Utils.HtmlDecode(data["Description"].ToString()),
                            RouteURL = data["RouteURL"].ToString(),
                            TotalDataCount = Convert.ToInt32(data["TotalDataCount"])
                        });
                    }

                }
                if (objCompaniesModel == null || objCompaniesModel.Count == 0)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(objCompaniesModel);
        }
        [HttpGet]
        public IHttpActionResult GetGlobalCompanyTOP4CSuiteOnDeck(string siteName)
        {
            string SiteName = string.Empty;
            siteName = siteName.Replace("test.", "");
            IList<GlobalCompanyCSuiteOnDecModel> objGlobalCompanyCSuiteOnDecModel = null;
            try
            {
               
                Connection();
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                if (SiteName == string.Empty)
                {
                    SiteName = siteName;

                    if (SiteName.Contains("."))
                        SiteName = siteName.ToLower();
                    SiteName = SiteName.Replace(".", "_");
                }
                sqlCmd.Parameters.AddWithValue("@SiteName", SiteName);
                sqlCmd.CommandText = "NewPubsiteAPI_Global_Company_TOP4CSuiteOnDeck";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                objGlobalCompanyCSuiteOnDecModel = new List<GlobalCompanyCSuiteOnDecModel>(dt.Rows.Count);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow data in dt.Rows)
                    {
                        objGlobalCompanyCSuiteOnDecModel.Add(new GlobalCompanyCSuiteOnDecModel
                        {
                            InterviewID = Convert.ToInt32(data["InterviewID"]),
                            Name = data["Name"].ToString(),
                            InterviewDate = data["InterviewDate"].ToString(),
                            InterviewDetails = data["InterviewDetails"].ToString(),
                            InterviewImage = data["InterviewImage"].ToString(),
                            InterviewTitle = data["InterviewTitle"].ToString(),
                            PublishedSite = data["PublishedSite"].ToString(),
                            RouteURL = data["RouteURL"].ToString()
                        });
                    }

                }
                if (objGlobalCompanyCSuiteOnDecModel == null || objGlobalCompanyCSuiteOnDecModel.Count == 0)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(objGlobalCompanyCSuiteOnDecModel);
        }


        [HttpGet]
        public IHttpActionResult GetAllGlobalCompanyCSuiteOnDeck(string siteName, string pageNumber)
        {
            string SiteName = string.Empty;
            siteName = siteName.Replace("test.", "");
            IList<GlobalCompanyCSuiteOnDecModel> objGlobalCompanyCSuiteOnDecModel = null;
            try
            {
               
                Connection();
               
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                if (SiteName == string.Empty)
                {
                    SiteName = siteName;

                    if (SiteName.Contains("."))
                        SiteName = siteName.ToLower();
                    SiteName = SiteName.Replace(".", "_");
                }
                sqlCmd.Parameters.AddWithValue("@SiteName", SiteName);
                sqlCmd.Parameters.AddWithValue("@PageNumber", pageNumber);
                sqlCmd.CommandText = "NewPubsiteAPI_Global_Company_GetAllGlobalCompanyCSuiteOnDeck";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                objGlobalCompanyCSuiteOnDecModel = new List<GlobalCompanyCSuiteOnDecModel>(dt.Rows.Count);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow data in dt.Rows)
                    {
                        objGlobalCompanyCSuiteOnDecModel.Add(new GlobalCompanyCSuiteOnDecModel
                        {
                            InterviewID = Convert.ToInt32(data["InterviewID"]),
                            Name = data["Name"].ToString(),
                            InterviewDate = data["InterviewDate"].ToString(),
                            InterviewDetails = data["InterviewDetails"].ToString(),
                            InterviewImage = data["InterviewImage"].ToString(),
                            InterviewTitle = data["InterviewTitle"].ToString(),
                            PublishedSite = data["PublishedSite"].ToString(),
                            TotalDataCount = Convert.ToInt32(data["TotalDataCount"]),
                            RouteURL = data["RouteURL"].ToString()
                        });
                    }

                }
                if (objGlobalCompanyCSuiteOnDecModel == null || objGlobalCompanyCSuiteOnDecModel.Count == 0)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(objGlobalCompanyCSuiteOnDecModel);
        }

        [HttpGet]
        public IHttpActionResult GetAllGlobalCompanyCSuiteOnDeckData(string siteName)
        {
            string SiteName = string.Empty;
            siteName = siteName.Replace("test.", "");
            IList<GlobalCompanyCSuiteOnDecModel> objGlobalCompanyCSuiteOnDecModel = null;
            try
            {
               
                Connection();
               
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                if (SiteName == string.Empty)
                {
                    SiteName = siteName;

                    if (SiteName.Contains("."))
                        SiteName = siteName.ToLower();
                    SiteName = SiteName.Replace(".", "_");
                }
                sqlCmd.Parameters.AddWithValue("@SiteName", SiteName);
                //sqlCmd.Parameters.AddWithValue("@PageNumber", pageNumber);
                sqlCmd.CommandText = "NewPubsiteAPI_Global_Company_GetAllGlobalCompanyCSuiteOnDeck_data";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                objGlobalCompanyCSuiteOnDecModel = new List<GlobalCompanyCSuiteOnDecModel>(dt.Rows.Count);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow data in dt.Rows)
                    {
                        objGlobalCompanyCSuiteOnDecModel.Add(new GlobalCompanyCSuiteOnDecModel
                        {
                            InterviewID = Convert.ToInt32(data["InterviewID"]),
                            Name = data["Name"].ToString(),
                            InterviewDate = data["InterviewDate"].ToString(),
                            InterviewDetails = data["InterviewDetails"].ToString(),
                            InterviewImage = data["InterviewImage"].ToString(),
                            InterviewTitle = data["InterviewTitle"].ToString(),
                            PublishedSite = data["PublishedSite"].ToString(),
                            TotalDataCount = Convert.ToInt32(data["TotalDataCount"]),
                            RouteURL = data["RouteURL"].ToString()
                        });
                    }

                }
                if (objGlobalCompanyCSuiteOnDecModel == null || objGlobalCompanyCSuiteOnDecModel.Count == 0)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(objGlobalCompanyCSuiteOnDecModel);
        }

        public IHttpActionResult GetMoreCSuiteOnDeckDatabyCategory(string siteName, string Categorytag, string Routeurl)
        {
            string SiteName = string.Empty;
            siteName = siteName.Replace("test.", "");
            IList<GlobalCompanyCSuiteOnDecModel> objGlobalCompanyCSuiteOnDecModel = null;
            try
            {
               
                Connection();
               
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                if (SiteName == string.Empty)
                {
                    SiteName = siteName;

                    if (SiteName.Contains("."))
                        SiteName = siteName.ToLower();
                    SiteName = SiteName.Replace(".", "_");
                }
                sqlCmd.Parameters.AddWithValue("@SiteName", SiteName);
                sqlCmd.Parameters.AddWithValue("@Categorytag", Categorytag);
                sqlCmd.Parameters.AddWithValue("@Routeurl", Routeurl);

                //sqlCmd.Parameters.AddWithValue("@PageNumber", pageNumber);
                sqlCmd.CommandText = "NewPubsiteAPI_more3_CSuiteOnDeck_data_byCategory";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                objGlobalCompanyCSuiteOnDecModel = new List<GlobalCompanyCSuiteOnDecModel>(dt.Rows.Count);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow data in dt.Rows)
                    {
                        objGlobalCompanyCSuiteOnDecModel.Add(new GlobalCompanyCSuiteOnDecModel
                        {
                            InterviewID = Convert.ToInt32(data["InterviewID"]),
                            Name = data["Name"].ToString(),
                            InterviewDate = data["InterviewDate"].ToString(),
                            InterviewDetails = data["InterviewDetails"].ToString(),
                            InterviewImage = data["InterviewImage"].ToString(),
                            InterviewTitle = data["InterviewTitle"].ToString(),
                            PublishedSite = data["PublishedSite"].ToString(),
                            TotalDataCount = Convert.ToInt32(data["TotalDataCount"]),
                            RouteURL = data["RouteURL"].ToString(),
                            Categorytag = data["Categorytag"].ToString()
                        });
                    }

                }
                if (objGlobalCompanyCSuiteOnDecModel == null || objGlobalCompanyCSuiteOnDecModel.Count == 0)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(objGlobalCompanyCSuiteOnDecModel);
        }

        public IHttpActionResult GetMoreCSuiteOnDeckDatabyKeyword(string siteName, string Keywords, string Routeurl)
        {
            string SiteName = string.Empty;
            siteName = siteName.Replace("test.", "");
            IList<GlobalCompanyCSuiteOnDecModel> objGlobalCompanyCSuiteOnDecModel = null;
            try
            {
               
                Connection();
               
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                if (SiteName == string.Empty)
                {
                    SiteName = siteName;

                    if (SiteName.Contains("."))
                        SiteName = siteName.ToLower();
                    SiteName = SiteName.Replace(".", "_");
                }
                sqlCmd.Parameters.AddWithValue("@SiteName", SiteName);
                sqlCmd.Parameters.AddWithValue("@Keywords", Keywords);
                sqlCmd.Parameters.AddWithValue("@Routeurl", Routeurl);

                //sqlCmd.Parameters.AddWithValue("@PageNumber", pageNumber);
                sqlCmd.CommandText = "NewPubsiteAPI_more3_CSuiteOnDeck_data_bykeywords";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                objGlobalCompanyCSuiteOnDecModel = new List<GlobalCompanyCSuiteOnDecModel>(dt.Rows.Count);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow data in dt.Rows)
                    {
                        objGlobalCompanyCSuiteOnDecModel.Add(new GlobalCompanyCSuiteOnDecModel
                        {
                            InterviewID = Convert.ToInt32(data["InterviewID"]),
                            Name = data["Name"].ToString(),
                            InterviewDate = data["InterviewDate"].ToString(),
                            InterviewDetails = data["InterviewDetails"].ToString(),
                            InterviewImage = data["InterviewImage"].ToString(),
                            InterviewTitle = data["InterviewTitle"].ToString(),
                            PublishedSite = data["PublishedSite"].ToString(),
                            TotalDataCount = Convert.ToInt32(data["TotalDataCount"]),
                            RouteURL = data["RouteURL"].ToString()
                        });
                    }

                }
                if (objGlobalCompanyCSuiteOnDecModel == null || objGlobalCompanyCSuiteOnDecModel.Count == 0)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(objGlobalCompanyCSuiteOnDecModel);
        }


        [HttpGet]
        public IHttpActionResult GetGlobalCompanyTOP3Events(string siteName)
        {
            string SiteName = string.Empty;
            siteName = siteName.Replace("test.", "");
            IList<GlobalCompanyEventsModel> objGlobalCompanyEventsModel = null;
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
                sqlCmd.CommandText = "NewPubsiteAPI_Global_Company_TOP3Events";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                objGlobalCompanyEventsModel = new List<GlobalCompanyEventsModel>(dt.Rows.Count);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow data in dt.Rows)
                    {
                        objGlobalCompanyEventsModel.Add(new GlobalCompanyEventsModel
                        {
                            EventId = Convert.ToInt32(data["EventId"]),
                            Name = data["Name"].ToString(),
                            Details = data["Details"].ToString(),
                            ImageUrl = data["ImageUrl"].ToString(),
                            IsSponcered = Convert.ToInt32(data["IsSponcered"]),
                            Keywords = data["Keywords"].ToString(),
                            URL = data["URL"].ToString(),
                            RouteURL = data["RouteURL"].ToString(),
                            EventType = data["EventType"].ToString(),

                        });
                    }

                }
                if (objGlobalCompanyEventsModel == null || objGlobalCompanyEventsModel.Count == 0)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(objGlobalCompanyEventsModel);
        }

        [HttpGet]
        public IHttpActionResult GetGlobalCompanyTOP1SpotLight(string siteName)
        {
            string SiteName = string.Empty;
            siteName = siteName.Replace("test.", "");
            IList<GlobalCompanySpotLightModel> objGlobalCompanySpotLightModel = null;
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
                sqlCmd.CommandText = "NewPubsiteAPI_Global_Company_TOP1SpotLight";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                objGlobalCompanySpotLightModel = new List<GlobalCompanySpotLightModel>(dt.Rows.Count);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow data in dt.Rows)
                    {
                        objGlobalCompanySpotLightModel.Add(new GlobalCompanySpotLightModel
                        {
                            ID = Convert.ToInt32(data["ID"]),
                            Name = data["Name"].ToString(),
                            Description = data["Description"].ToString(),
                            ImageUrl = data["ImageUrl"].ToString(),
                            RouteURL = data["RouteURL"].ToString()
                        });
                    }

                }
                if (objGlobalCompanySpotLightModel == null || objGlobalCompanySpotLightModel.Count == 0)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(objGlobalCompanySpotLightModel);
        }

        [HttpGet]
        public IHttpActionResult GetAllGlobalCompanyThoughtLeaders(string siteName, string pageNumber)
        {
            string SiteName = string.Empty;
            siteName = siteName.Replace("test.", "");
            IList<GlobalCompanyCSuiteOnDecModel> objGlobalCompanyCSuiteOnDecModel = null;
            try
            {
                    Connection();
               
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                if (SiteName == string.Empty)
                {
                    SiteName = siteName;

                    if (SiteName.Contains("."))
                        SiteName = siteName.ToLower();
                    SiteName = SiteName.Replace(".", "_");
                }
                sqlCmd.Parameters.AddWithValue("@SiteName", SiteName);
                sqlCmd.Parameters.AddWithValue("@PageNumber", pageNumber);
                sqlCmd.CommandText = "NewPubsiteAPI_Global_Company_GetAllGlobalCompanyThoughtLeaders";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                objGlobalCompanyCSuiteOnDecModel = new List<GlobalCompanyCSuiteOnDecModel>(dt.Rows.Count);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow data in dt.Rows)
                    {
                        objGlobalCompanyCSuiteOnDecModel.Add(new GlobalCompanyCSuiteOnDecModel
                        {
                            InterviewID = Convert.ToInt32(data["InterviewID"]),
                            Name = data["Name"].ToString(),
                            InterviewDate = data["InterviewDate"].ToString(),
                            InterviewDetails = data["InterviewDetails"].ToString(),
                            InterviewImage = data["InterviewImage"].ToString(),
                            InterviewTitle = data["InterviewTitle"].ToString(),
                            PublishedSite = data["PublishedSite"].ToString(),
                            RouteURL = data["RouteURL"].ToString(),
                            TotalDataCount = Convert.ToInt32(data["TotalDataCount"]),
                        });
                    }

                }
                if (objGlobalCompanyCSuiteOnDecModel == null || objGlobalCompanyCSuiteOnDecModel.Count == 0)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(objGlobalCompanyCSuiteOnDecModel);
        }

        [HttpGet]
        public IHttpActionResult GetAllGlobalCompanyThoughtLeadersData(string siteName)
        {
            string SiteName = string.Empty;
            IList<GlobalCompanyCSuiteOnDecModel> objGlobalCompanyCSuiteOnDecModel = null;
            try
            {
                    Connection();
               
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                if (SiteName == string.Empty)
                {
                    SiteName = siteName;

                    if (SiteName.Contains("."))
                        SiteName = siteName.ToLower();
                    SiteName = SiteName.Replace(".", "_");
                }
                sqlCmd.Parameters.AddWithValue("@SiteName", SiteName);
                //sqlCmd.Parameters.AddWithValue("@PageNumber", pageNumber);
                sqlCmd.CommandText = "NewPubsiteAPI_Global_Company_GetAllGlobalCompanyThoughtLeaders_data";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                objGlobalCompanyCSuiteOnDecModel = new List<GlobalCompanyCSuiteOnDecModel>(dt.Rows.Count);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow data in dt.Rows)
                    {
                        objGlobalCompanyCSuiteOnDecModel.Add(new GlobalCompanyCSuiteOnDecModel
                        {
                            InterviewID = Convert.ToInt32(data["InterviewID"]),
                            Name = data["Name"].ToString(),
                            InterviewDate = data["InterviewDate"].ToString(),
                            InterviewDetails = data["InterviewDetails"].ToString(),
                            InterviewImage = data["InterviewImage"].ToString(),
                            InterviewTitle = data["InterviewTitle"].ToString(),
                            PublishedSite = data["PublishedSite"].ToString(),
                            RouteURL = data["RouteURL"].ToString(),
                            TotalDataCount = Convert.ToInt32(data["TotalDataCount"]),
                        });
                    }

                }
                if (objGlobalCompanyCSuiteOnDecModel == null || objGlobalCompanyCSuiteOnDecModel.Count == 0)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(objGlobalCompanyCSuiteOnDecModel);
        }

        [HttpGet]
        public IHttpActionResult GetMoreThoughtLeadersDatabyCategory(string siteName, string Categorytag, string Routeurl)
        {
            string SiteName = string.Empty;
            IList<GlobalCompanyCSuiteOnDecModel> objGlobalCompanyCSuiteOnDecModel = null;
            try
            {
                Connection();

                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                if (SiteName == string.Empty)
                {
                    SiteName = siteName;

                    if (SiteName.Contains("."))
                        SiteName = siteName.ToLower();
                    SiteName = SiteName.Replace(".", "_");
                }
                sqlCmd.Parameters.AddWithValue("@SiteName", SiteName);
                sqlCmd.Parameters.AddWithValue("@Categorytag", Categorytag);
                sqlCmd.Parameters.AddWithValue("@Routeurl", Routeurl);

                //sqlCmd.Parameters.AddWithValue("@PageNumber", pageNumber);
                sqlCmd.CommandText = "NewPubsiteAPI_more3_ThoughtLeaders_data_byCategory";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                objGlobalCompanyCSuiteOnDecModel = new List<GlobalCompanyCSuiteOnDecModel>(dt.Rows.Count);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow data in dt.Rows)
                    {
                        objGlobalCompanyCSuiteOnDecModel.Add(new GlobalCompanyCSuiteOnDecModel
                        {
                            InterviewID = Convert.ToInt32(data["InterviewID"]),
                            Name = data["Name"].ToString(),
                            InterviewDate = data["InterviewDate"].ToString(),
                            InterviewDetails = data["InterviewDetails"].ToString(),
                            InterviewImage = data["InterviewImage"].ToString(),
                            InterviewTitle = data["InterviewTitle"].ToString(),
                            PublishedSite = data["PublishedSite"].ToString(),
                            RouteURL = data["RouteURL"].ToString(),
                            Categorytag = data["Categorytag"].ToString(),
                            TotalDataCount = Convert.ToInt32(data["TotalDataCount"]),
                        });
                    }

                }
                if (objGlobalCompanyCSuiteOnDecModel == null || objGlobalCompanyCSuiteOnDecModel.Count == 0)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(objGlobalCompanyCSuiteOnDecModel);
        }

        [HttpGet]
        public IHttpActionResult GetMoreThoughtLeadersDataKeywords(string siteName, string Keywords, string Routeurl)
        {
            string SiteName = string.Empty;
            IList<GlobalCompanyCSuiteOnDecModel> objGlobalCompanyCSuiteOnDecModel = null;
            try
            {
                Connection();

                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                if (SiteName == string.Empty)
                {
                    SiteName = siteName;

                    if (SiteName.Contains("."))
                        SiteName = siteName.ToLower();
                    SiteName = SiteName.Replace(".", "_");
                }
                sqlCmd.Parameters.AddWithValue("@SiteName", SiteName);
                sqlCmd.Parameters.AddWithValue("@Keywords", Keywords);
                sqlCmd.Parameters.AddWithValue("@Routeurl", Routeurl);

                //sqlCmd.Parameters.AddWithValue("@PageNumber", pageNumber);
                sqlCmd.CommandText = "NewPubsiteAPI_more3_ThoughtLeaders_data_byKeywords";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                objGlobalCompanyCSuiteOnDecModel = new List<GlobalCompanyCSuiteOnDecModel>(dt.Rows.Count);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow data in dt.Rows)
                    {
                        objGlobalCompanyCSuiteOnDecModel.Add(new GlobalCompanyCSuiteOnDecModel
                        {
                            InterviewID = Convert.ToInt32(data["InterviewID"]),
                            Name = data["Name"].ToString(),
                            InterviewDate = data["InterviewDate"].ToString(),
                            InterviewDetails = data["InterviewDetails"].ToString(),
                            InterviewImage = data["InterviewImage"].ToString(),
                            InterviewTitle = data["InterviewTitle"].ToString(),
                            PublishedSite = data["PublishedSite"].ToString(),
                            RouteURL = data["RouteURL"].ToString(),
                            TotalDataCount = Convert.ToInt32(data["TotalDataCount"]),
                        });
                    }

                }
                if (objGlobalCompanyCSuiteOnDecModel == null || objGlobalCompanyCSuiteOnDecModel.Count == 0)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(objGlobalCompanyCSuiteOnDecModel);
        }


        [HttpGet]
        public IHttpActionResult GetAllGlobalCompaniesForSearch(string siteName, string SearchChar, int pageNumber)
        {
            string SiteName = string.Empty;
            siteName = siteName.Replace("test.", "");
            IList<GolbalCompaniesModel> objCompaniesModel = null;
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
                sqlCmd.Parameters.AddWithValue("@SearchChar", SearchChar);
                sqlCmd.Parameters.AddWithValue("@pageNumber", pageNumber);

                sqlCmd.CommandText = "PubsiteAPI_Global_GetAllGlobalCompaniesForSearch";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                objCompaniesModel = new List<GolbalCompaniesModel>(dt.Rows.Count);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow data in dt.Rows)
                    {
                        objCompaniesModel.Add(new GolbalCompaniesModel
                        {
                            ID = Convert.ToInt32(data["ID"]),
                            CompanyName = data["Company_Name"].ToString(),
                            Logo = data["Logo"].ToString(),
                            DomainName = data["Domain_Name"].ToString(),
                            DomainURL = data["Domain_Url"].ToString(),
                            EntryDate = data["EntryDate"].ToString(),
                            Description = data["Description"].ToString(),
                            RouteURL = data["RouteURL"].ToString(),
                            TotalDataCount = Convert.ToInt32(data["TotalDataCount"])
                        });
                    }
                }
                if (objCompaniesModel == null || objCompaniesModel.Count == 0)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(objCompaniesModel);
        }

    }
}
