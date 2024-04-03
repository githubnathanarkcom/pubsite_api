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
    public class SingleCompaniesController : ApiController
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
        public IHttpActionResult GetTop1SingleCompanyById(string siteName, string routeURL)
        {
            string SiteName = string.Empty;
            siteName = siteName.Replace("test.", "");
            GolbalCompaniesModel objCompaniesModel = null;
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
                sqlCmd.Parameters.AddWithValue("@RouteURL", routeURL);


                sqlCmd.CommandText = "NewPubsiteAPI_Single_Companies_GetSingleCompanyByTitle";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                objCompaniesModel = new GolbalCompaniesModel();
                if (dt.Rows.Count > 0)
                {

                    objCompaniesModel.ID = Convert.ToInt32(dt.Rows[0]["ID"]);
                    objCompaniesModel.CompanyName = dt.Rows[0]["Company_Name"].ToString();
                    objCompaniesModel.Logo = dt.Rows[0]["Logo"].ToString();
                    objCompaniesModel.DomainName = dt.Rows[0]["Domain_Name"].ToString();
                    objCompaniesModel.DomainURL = dt.Rows[0]["Domain_Url"].ToString();
                    objCompaniesModel.EntryDate = dt.Rows[0]["EntryDate"].ToString();
                    objCompaniesModel.Description = dt.Rows[0]["Description"].ToString();
                    objCompaniesModel.RouteURL = dt.Rows[0]["RouteURL"].ToString();
                    objCompaniesModel.ISINDEX = Convert.ToInt32(dt.Rows[0]["ISINDEX"]);
                    objCompaniesModel.IsFollow = Convert.ToInt32(dt.Rows[0]["IsFollow"]);
                    objCompaniesModel.ManualCanonical = dt.Rows[0]["ManualCanonical"].ToString();
                    objCompaniesModel.MetaTitle = Utils.HtmlDecode(dt.Rows[0]["MetaTitle"].ToString());
                    objCompaniesModel.MetaDescription = Utils.HtmlDecode(dt.Rows[0]["MetaDescription"].ToString());
                    objCompaniesModel.ImageAltTag = dt.Rows[0]["ImageAltTag"].ToString();
                    //objCompaniesModel.Keywords = dt.Rows[0]["Keywords"].ToString();

                }
                if (objCompaniesModel == null )
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
        public IHttpActionResult GetTop1SingleCompaniesCSuiteOnDeck(string siteName, string CompanyDomian)
        {
            string SiteName = string.Empty;
            siteName = siteName.Replace("test.", "");
            GlobalCompanyCSuiteOnDecModel objCSuiteOnDecModel = null;
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
                sqlCmd.Parameters.AddWithValue("@CompanyDomian", CompanyDomian);

                sqlCmd.CommandText = "NewPubsiteAPI_Single_Companies_GetTop1SingleCompaniesCSuiteOnDeck";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                objCSuiteOnDecModel = new GlobalCompanyCSuiteOnDecModel();
                if (dt.Rows.Count > 0)
                {

                    objCSuiteOnDecModel.InterviewID = Convert.ToInt32(dt.Rows[0]["InterviewID"]);
                    objCSuiteOnDecModel.InterviewDetails = dt.Rows[0]["InterviewDetails"].ToString();
                    objCSuiteOnDecModel.InterviewImage = dt.Rows[0]["InterviewImage"].ToString();
                    objCSuiteOnDecModel.InterviewTitle = dt.Rows[0]["InterviewTitle"].ToString();
                    objCSuiteOnDecModel.InterviewDate = dt.Rows[0]["Interview_Date"].ToString();
                    objCSuiteOnDecModel.Name = dt.Rows[0]["Name"].ToString();
                    objCSuiteOnDecModel.PublishedSite = dt.Rows[0]["PublishedSite"].ToString();
                    objCSuiteOnDecModel.RouteURL = dt.Rows[0]["RouteURL"].ToString();
                      

                }
                if (objCSuiteOnDecModel == null )
                {
                    return Ok(objCSuiteOnDecModel);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(objCSuiteOnDecModel);
        }


        [HttpGet]
        public IHttpActionResult GetTop6SingleCompaniesEvents(string siteName)
        {
            string SiteName = string.Empty;
            siteName = siteName.Replace("test.", "");
            IList<GlobalCompanyEventsModel> objCompaniesModel = null;
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
                sqlCmd.CommandText = "NewPubsiteAPI_Single_Companies_GetTop6SingleCompaniesEvents";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                objCompaniesModel = new List<GlobalCompanyEventsModel>(dt.Rows.Count);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow data in dt.Rows)
                    {
                        objCompaniesModel.Add(new GlobalCompanyEventsModel
                        {
                            EventId = Convert.ToInt32(data["EventId"]),
                            Name = data["Name"].ToString(),
                            Details = data["Details"].ToString(),
                            ImageUrl = data["ImageUrl"].ToString(),
                            IsSponcered = Convert.ToInt32(data["IsSponcered"]),
                            Keywords = data["Keywords"].ToString(),
                            URL = data["URL"].ToString(),
                            RouteURL = data["RouteURL"].ToString(),
                            EventType = data["EventType"].ToString()
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
        public IHttpActionResult GetTop6EventsforSingleCompanies(string siteName, string companyname)
        {
            string SiteName = string.Empty;
            siteName = siteName.Replace("test.", "");
            IList<GlobalCompanyEventsModel> objCompaniesModel = null;
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
                sqlCmd.Parameters.AddWithValue("@Companyname", companyname);
                sqlCmd.CommandText = "NewPubsiteAPI_Single_Companies_GetTop6EventsforSingleCompanies";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                objCompaniesModel = new List<GlobalCompanyEventsModel>(dt.Rows.Count);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow data in dt.Rows)
                    {
                        objCompaniesModel.Add(new GlobalCompanyEventsModel
                        {
                            EventId = Convert.ToInt32(data["EventId"]),
                            Name = data["Name"].ToString(),
                            Details = data["Details"].ToString(),
                            ImageUrl = data["ImageUrl"].ToString(),
                            IsSponcered = Convert.ToInt32(data["IsSponcered"]),
                            Keywords = data["Keywords"].ToString(),
                            URL = data["URL"].ToString(),
                            RouteURL = data["RouteURL"].ToString(),
                            EventType = data["EventType"].ToString()
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
        public IHttpActionResult GetTop4SingleCompaniesResources(string siteName, string CompanyName)
        {
            IList<NewsReourceModel> objResources = null;
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
                sqlCmd.Parameters.AddWithValue("@CompanyName", CompanyName);

                sqlCmd.CommandText = "NewPubsiteAPI_Single_Companies_GetTop4SingleCompaniesResources";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                objResources = new List<NewsReourceModel>(dt.Rows.Count);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow data in dt.Rows)
                    {
                        objResources.Add(new NewsReourceModel
                        {
                            ID = Convert.ToInt32(data["ID"]),
                            //keywords = data["keywords"].ToString(),
                            ResourceType = data["ResourceType"].ToString(),
                            ImageUrl = data["ImageUrl"].ToString(),
                            // IsSponcered = Convert.ToInt32(data["IsSponcered"]),
                            RouteURL = data["RouteURL"].ToString(),
                            Description = data["Description"].ToString(),
                            WhitePaperTitle = data["WhitePaperTitle"].ToString(),
                            Tag = data["tag"].ToString()
                        });
                    }

                }
                if (objResources == null || objResources.Count == 0)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(objResources);
        }


        [HttpGet]
        public IHttpActionResult GetTop4SingleCompaniesResources(string siteName, string CompanyName, string CategoryTag)
        {
            IList<NewsReourceModel> objResources = null;
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
                sqlCmd.Parameters.AddWithValue("@CompanyName", CompanyName);
                sqlCmd.Parameters.AddWithValue("@CategoryTag", CategoryTag);

                sqlCmd.CommandText = "NewPubsiteAPI_Single_Companies_GetTop4SingleCompaniesResources_CategoryTag";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                objResources = new List<NewsReourceModel>(dt.Rows.Count);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow data in dt.Rows)
                    {
                        objResources.Add(new NewsReourceModel
                        {
                            ID = Convert.ToInt32(data["ID"]),
                            //keywords = data["keywords"].ToString(),
                            ResourceType = data["ResourceType"].ToString(),
                            ImageUrl = data["ImageUrl"].ToString(),
                            // IsSponcered = Convert.ToInt32(data["IsSponcered"]),
                            RouteURL = data["RouteURL"].ToString(),
                            Description = data["Description"].ToString(),
                            WhitePaperTitle = data["WhitePaperTitle"].ToString(),
                            Tag = data["tag"].ToString()
                        });
                    }

                }
                if (objResources == null || objResources.Count == 0)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(objResources);
        }


        [HttpGet]
        public IHttpActionResult GetSingleCompanyTOP3Events(string siteName, string CompanyName)
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
                sqlCmd.Parameters.AddWithValue("@CompanyName", CompanyName);
                //sqlCmd.Parameters.AddWithValue("@CategoryTag", CategoryTag);

                sqlCmd.CommandText = "NewPubsiteAPI_Single_Companies_TOP3Events";
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
        public IHttpActionResult GetSingleCompanyTOP3Events(string siteName, string CompanyName, string CategoryTag)
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
                sqlCmd.Parameters.AddWithValue("@CompanyName", CompanyName);
                sqlCmd.Parameters.AddWithValue("@CategoryTag", CategoryTag);

                sqlCmd.CommandText = "NewPubsiteAPI_Single_Companies_TOP3Events_CategoryTag";
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
        public IHttpActionResult GetSingleCompanyRelatedNewsByCompany(string siteName, string companyName, int pageNumber)
        {
            string SiteName = string.Empty;
            siteName = siteName.Replace("test.", "");
            IList<SingleRelateNewsModel> objSingleRelateNewsModel = null;
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
                sqlCmd.Parameters.AddWithValue("@CompanyName", companyName);
                sqlCmd.Parameters.AddWithValue("@PageNumber", pageNumber);
                sqlCmd.CommandText = "NewPubsiteAPI_Single_Companies_GetAllRelatedNew";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                objSingleRelateNewsModel = new List<SingleRelateNewsModel>(dt.Rows.Count);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow data in dt.Rows)
                    {
                        objSingleRelateNewsModel.Add(new SingleRelateNewsModel
                        {
                            ID = Convert.ToInt32(data["ID"]),
                            ImageUrl = data["ImageUrl"].ToString(),
                            Title = data["Title"].ToString(),
                            Date = data["Date"].ToString(),
                            EventDifferentType = data["EventDifferentType"].ToString(),
                            CompanyName = data["CompanyName"].ToString(),
                            Description = data["Description"].ToString(),
                            RouteURL = data["RouteURL"].ToString(),
                            TotalDataCount = data["TotalDataCount"].ToString(),
                            Source = data["Source"].ToString(),
                            Tag = data["Tag"].ToString(),


                        });
                    }

                }
                if (objSingleRelateNewsModel == null || objSingleRelateNewsModel.Count == 0)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(objSingleRelateNewsModel);
        }


        [HttpGet]
        public IHttpActionResult GetSingleCompanyRelatedTop4NewsByCompany(string siteName, string companyName)
        {
            string SiteName = string.Empty;
            siteName = siteName.Replace("test.", "");
            IList<SingleRelateNewsModel> objSingleRelateNewsModel = null;
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
                sqlCmd.Parameters.AddWithValue("@CompanyName", companyName);
                //sqlCmd.Parameters.AddWithValue("@PageNumber", pageNumber);
                sqlCmd.CommandText = "NewPubsiteAPI_Single_Companies_GetTop4RelatedNew";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                objSingleRelateNewsModel = new List<SingleRelateNewsModel>(dt.Rows.Count);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow data in dt.Rows)
                    {
                        objSingleRelateNewsModel.Add(new SingleRelateNewsModel
                        {
                            ID = Convert.ToInt32(data["ID"]),
                            ImageUrl = data["ImageUrl"].ToString(),
                            Title = data["Title"].ToString(),
                            Date = data["Date"].ToString(),
                            EventDifferentType = data["EventDifferentType"].ToString(),
                            CompanyName = data["CompanyName"].ToString(),
                            Description = data["Description"].ToString(),
                            RouteURL = data["RouteURL"].ToString(),
                            //TotalDataCount = data["TotalDataCount"].ToString(),
                            Source = data["Source"].ToString(),
                            Tag = data["Tag"].ToString(),


                        });
                    }

                }
                if (objSingleRelateNewsModel == null || objSingleRelateNewsModel.Count == 0)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(objSingleRelateNewsModel);
        }



    }
}
