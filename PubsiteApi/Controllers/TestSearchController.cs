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
    public class TestSearchController : ApiController
    {
        private SqlConnection scon = null;
        private void Connection()
        {
            try
            {
                scon = new SqlConnection("Data Source=3.108.12.178;User ID=testtheiotrep;Initial Catalog=test-theiotrep; Password=PD7E)gsv");
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
                scon = new SqlConnection("Data Source=3.108.12.178;User ID=testGeneReport;Initial Catalog=testGeneReport;Password=3+TAQRmL");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public IHttpActionResult GetSearchEvents(string siteName,string Keyword)
        {
            IList<SearchModel> objSearchEventModel = null;
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
                sqlCmd.Parameters.AddWithValue("@Keyword", Keyword);

               
                    sqlCmd.CommandText = "PubsiteAPI_GetSearchEvents";
               
                    
                    

                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                objSearchEventModel = new List<SearchModel>(dt.Rows.Count);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow data in dt.Rows)
                    {
                        objSearchEventModel.Add(new SearchModel
                        {
                            EventID = Convert.ToInt32(data["EventID"]),
                            Name = data["Name"].ToString(),
                            RouteURL = data["RouteURL"].ToString(),
                            ImageUrl = data["ImageUrl"].ToString(),
                            Details = data["Details"].ToString(),
                            Keywords = data["Keywords"].ToString(),
                            Country = data["Country"].ToString(),

                            StartEndDate = (data["StartEndDate"]).ToString(),

                            EventDifferentType=data["EventDifferentType"].ToString()

                            //EndDate = (data["EndDate"]).ToString(),
                            //Sponsors = data["Sponsors"].ToString(),

                        });
                    }

                }
                if (objSearchEventModel == null || objSearchEventModel.Count == 0)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(objSearchEventModel);
        }



        [HttpGet]
        public IHttpActionResult GetSearchPastEventsResult(string siteName, string Keyword)
        {
            IList<SearchModel> objSearchEventModel = null;
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
                sqlCmd.Parameters.AddWithValue("@Keyword", Keyword);


                sqlCmd.CommandText = "PubsiteAPI_GetSearchPastEventsResult";




                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                objSearchEventModel = new List<SearchModel>(dt.Rows.Count);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow data in dt.Rows)
                    {
                        objSearchEventModel.Add(new SearchModel
                        {
                            EventID = Convert.ToInt32(data["EventID"]),
                            Name = data["Name"].ToString(),
                            RouteURL = data["RouteURL"].ToString(),
                            ImageUrl = data["ImageUrl"].ToString(),
                            Details = data["Details"].ToString(),
                            Keywords = data["Keywords"].ToString(),
                            Country = data["Country"].ToString(),
                            EventDifferentType = data["EventDifferentType"].ToString(),

                        StartEndDate = (data["StartEndDate"]).ToString()

                            //EndDate = (data["EndDate"]).ToString(),
                            //Sponsors = data["Sponsors"].ToString(),

                        });
                    }

                }
                if (objSearchEventModel == null || objSearchEventModel.Count == 0)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(objSearchEventModel);
        }
        [HttpGet]
        public IHttpActionResult GetSearchLiveWebinars(string siteName, string Keyword)
        {
            IList<SearchModel> objSearchEventModel = null;
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
                sqlCmd.Parameters.AddWithValue("@Keyword", Keyword);


                sqlCmd.CommandText = "PubsiteAPI_SelectSearchResultLiveWebinarHome";




                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                objSearchEventModel = new List<SearchModel>(dt.Rows.Count);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow data in dt.Rows)
                    {
                        objSearchEventModel.Add(new SearchModel
                        {
                            EventID = Convert.ToInt32(data["EventID"]),
                            Name = data["Name"].ToString(),
                            RouteURL = data["RouteURL"].ToString(),
                            ImageUrl = data["ImageUrl"].ToString(),
                            Details = data["Details"].ToString(),
                            Keywords = data["Keywords"].ToString(),
                            Country = data["Country"].ToString(),
                            Timezone = data["Timezone"].ToString(),
                            StartEndDate = (data["StartEndDate"]).ToString(),
                            EventDifferentType = data["EventDifferentType"].ToString()

                            //EndDate = (data["EndDate"]).ToString(),
                            //Sponsors = data["Sponsors"].ToString(),

                        });
                    }

                }
                if (objSearchEventModel == null || objSearchEventModel.Count == 0)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(objSearchEventModel);
        }
        [HttpGet]
        public IHttpActionResult GetSearchOnDemandWebinars(string siteName, string Keyword)
        {
            IList<SearchOnDemandWebinar> objSearchOnDemandWebinarModel = null;
            string SiteName = "";
            siteName = siteName.Replace("test.", "");
            try
            {
                if(siteName == "pharmaceutical.report" || siteName == "smallbusiness.report")
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
                sqlCmd.Parameters.AddWithValue("@Keyword", Keyword);


                sqlCmd.CommandText = "NewPubsiteAPI_GetSearchOnDemandWebinars";




                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                objSearchOnDemandWebinarModel = new List<SearchOnDemandWebinar>(dt.Rows.Count);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow data in dt.Rows)
                    {
                        objSearchOnDemandWebinarModel.Add(new SearchOnDemandWebinar
                        {
                            EventID = Convert.ToInt32(data["EventID"]),
                            Name = data["Name"].ToString(),
                             RouteURL= data["RouteURL"].ToString(),
                            ImageUrl = data["ImageUrl"].ToString(),
                            Details = data["Details"].ToString(),
                            Keywords = data["Keywords"].ToString(),
                            Country = data["Country"].ToString(),
                            Company=data["Company"].ToString(),
                            EventDifferentType=data["EventDifferentType"].ToString(),
                            StartEndDate = data["StartEndDate"].ToString()

                            //StartDate = (data["StartDate"]).ToString(),

                            //EndDate = (data["EndDate"]).ToString(),
                            //Sponsors = data["Sponsors"].ToString(),

                        });
                    }

                }
                if (objSearchOnDemandWebinarModel == null || objSearchOnDemandWebinarModel.Count == 0)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(objSearchOnDemandWebinarModel);
        }




        [HttpGet]
        public IHttpActionResult GetSearchResources(string siteName, string Keyword)
        {
            IList<SearchResouceModel> objSearchResourcesModel = null;
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
                sqlCmd.Parameters.AddWithValue("@Keyword", Keyword);


                sqlCmd.CommandText = "NewPubsiteAPI_GetSearchResources";




                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                objSearchResourcesModel = new List<SearchResouceModel>(dt.Rows.Count);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow data in dt.Rows)
                    {
                        objSearchResourcesModel.Add(new SearchResouceModel
                        {
                            ID = Convert.ToInt32(data["ID"]),
                            WhitePaperTitle = data["WhitePaperTitle"].ToString(),
                           // Keywords = data["Keywords"].ToString(),
                            Description = data["Description"].ToString(),
                            Author = data["Author"].ToString(),
                            ImageUrl=data["ImageUrl"].ToString(),
                            EntryDate = Convert.ToDateTime(data["EntryDate"]),
                           
                            PublishingDate = data["PublishingDate"].ToString(),
                            PublishingDate1 = data["PublishingDate1"].ToString(),
                            RouteURL = data["RouteURL"].ToString(),
                            ResourceType=data["ResourceType"].ToString(),
                            ResourceType2 = data["ResourceType2"].ToString()
                            // AuthorReal = data["AuthorReal"].ToString(),
                            // company_description = data["company_description"].ToString(),
                            //  author_description = data["author_description"].ToString(),
                            //  description2 = data["description2"].ToString(),
                            //  description3 = data["description3"].ToString(),
                            //  description4 = data["description4"].ToString(),
                            //Sponsors = data["Sponsors"].ToString(),

                        });
                    }

                }
                if (objSearchResourcesModel == null || objSearchResourcesModel.Count == 0)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(objSearchResourcesModel);
        }


        [HttpGet]
        public IHttpActionResult GetSearchNews(string siteName, string Keyword)
        {
            IList<SearchNewsModel> objSearchResourcesModel = null;
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
                sqlCmd.Parameters.AddWithValue("@Keyword", Keyword);


                sqlCmd.CommandText = "PubsiteAPI_GetSearchNews";




                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                objSearchResourcesModel = new List<SearchNewsModel>(dt.Rows.Count);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow data in dt.Rows)
                    {
                        objSearchResourcesModel.Add(new SearchNewsModel
                        {
                            ID = Convert.ToInt32(data["ID"]),
                            Description = data["Description"].ToString(),
                            Title = data["Title"].ToString(),
                            ImageUrl=data["ImageUrl"].ToString(),
                            Date =data["Date"].ToString(),
                            NewsTypeName = data["NewsTypeName"].ToString(),
                            //Keywords = data["Keywords"].ToString(),
                            //Industry = data["Industry"].ToString(),
                            CompanyName = data["CompanyName"].ToString(),
                            Author = data["Author"].ToString(),
                            RouteURL = data["RouteURL"].ToString(),
                           Tag = data["Tag"].ToString(),
                            //Sponsors = data["Sponsors"].ToString(),

                        });
                    }

                }
                if (objSearchResourcesModel == null || objSearchResourcesModel.Count == 0)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(objSearchResourcesModel);
        }

         [HttpGet]
        public IHttpActionResult GetSearchInterviews(string siteName, string Keyword)
        {
            IList<SearchInterviewModel> objSearchInterviewsModel = null;
            string SiteName = "";
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
                        SiteName = siteName.ToLower();
                    SiteName = SiteName.Replace(".", "_");
                }
                sqlCmd.Parameters.AddWithValue("@SiteName", SiteName);
                sqlCmd.Parameters.AddWithValue("@Keyword", Keyword);



                sqlCmd.CommandText = "NewPubsiteAPI_GetSearchInterviews";




                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                objSearchInterviewsModel = new List<SearchInterviewModel>(dt.Rows.Count);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow data in dt.Rows)
                    {
                        objSearchInterviewsModel.Add(new SearchInterviewModel
                        {
                            InterviewID = Convert.ToInt32(data["InterviewID"]),
                            InterviewTitle = data["InterviewTitle"].ToString(),
                            InterviewImage = data["InterviewImage"].ToString(),
                            InterviewDetails = data["InterviewDetails"].ToString(),
                            InterviewDate = data["InterviewDate"].ToString(),
                            IntervieweePerson = data["IntervieweePerson"].ToString(),
                            InterviewType = data["InterviewType"].ToString(),
                            Keywords = data["Keywords"].ToString(),
                            AboutCompany = data["AboutCompany"].ToString(),
                            RouteURL=data["RouteURL"].ToString(),
                            //URL=data["URL"].ToString(),
                            CompanyDomain = data["CompanyDomain"].ToString(),
                            CompanyName=data["CompanyName"].ToString(),




                            //Sponsors = data["Sponsors"].ToString(),

                        });
                    }

                }
                if (objSearchInterviewsModel == null || objSearchInterviewsModel.Count == 0)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(objSearchInterviewsModel);
        }



        public IHttpActionResult GetSearchCompanybyvalue(string siteName, string Keyword)
        {
            IList<SearchCompanyModel> objSearchCompanyModel = null;
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
                sqlCmd.Parameters.AddWithValue("@Keyword", Keyword);


                sqlCmd.CommandText = "PubsiteAPI_GetSearchCompanybyvalue";




                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                objSearchCompanyModel = new List<SearchCompanyModel>(dt.Rows.Count);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow data in dt.Rows)
                    {
                        objSearchCompanyModel.Add(new SearchCompanyModel
                        {
                            id = Convert.ToInt32(data["id"]),
                            company_name = data["company_name"].ToString(),
                            description = data["description"].ToString(),
                            logo = data["logo"].ToString(),
                            category = data["category"].ToString(),
                            //URL = data["URL"].ToString(),
                            domain_name = data["domain_name"].ToString(),
                            Domain_Url = data["Domain_Url"].ToString(),
                            RouteURL=data["RouteURL"].ToString()




                            //Sponsors = data["Sponsors"].ToString(),

                        });
                    }

                }
                if (objSearchCompanyModel == null || objSearchCompanyModel.Count == 0)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(objSearchCompanyModel);
        }
    }
}
