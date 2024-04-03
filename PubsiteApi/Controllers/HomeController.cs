
using PubsiteApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace PubsiteApi.Controllers
{

    // [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class HomeController : ApiController

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

        //Get Api for Get InterviewList
        [HttpGet]
        public IHttpActionResult GetHomeInterview(string siteName)
        {

            IList<Interview> InterviewList = null;
            string SiteName;
            siteName = siteName.Replace("test.", "");
            try
            {
                Connection();
               // scon = new SqlConnection("Data Source=199.79.62.22;User ID=theiotrep;Initial Catalog=theiotrep; Password=S#n6dy68");
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;
               // string DomainName = ((HttpContextWrapper)Request.Properties["MS_HttpContext"]).Request.ServerVariables["HTTP_HOST"];
                SiteName = siteName.ToLower();
                SiteName = SiteName.Replace(".", "_");

               
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@SiteName", SiteName);
                sqlCmd.CommandText = "NewPubsiteAPI_HomeInterview";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[1];
                InterviewList = new List<Interview>(dt.Rows.Count);
                if (dt.Rows.Count > 0)
                {
                    Interview obj = new Interview();
                    foreach (DataRow data in dt.Rows)
                    {

                        InterviewList.Add(new Interview
                        {
                            InterviewId = Convert.ToInt32(data["InterviewId"]),
                            InterviewTitle = data["InterviewTitle"].ToString(),
                            InterviewDetails = data["InterviewDetails"].ToString(),
                            IntervieweePerson = data["IntervieweePerson"].ToString(),
                            InterviewerID = Convert.ToInt32(data["InterviewerID"]),
                            InterviewImage = data["InterviewImage"].ToString(),
                            Interviewdate = Convert.ToDateTime(data["Interviewdate"]),
                            CompanyID = Convert.ToInt32(data["CompanyID"]),
                            InterviewType = data["InterviewType"].ToString(),
                            CreatedDate = Convert.ToDateTime(data["CreatedDate"]),
                            IsActive = data["IsActive"].ToString(),
                            AudioVideoURL = data["AudioVideoURL"].ToString(),
                            KeyWords = data["KeyWords"].ToString(),
                            VideoType = data["VideoType"].ToString(),
                            ViewCount = data["ViewCount"].ToString(),
                            MainImage = data["MainImage"].ToString(),
                            MobileImage = data["Mobileimage"].ToString(),
                            Desc2 = data["Desc2"].ToString(),
                            Desc3 = data["Desc3"].ToString(),
                            Quote1 = data["Quote1"].ToString(),
                            Quote2 = data["Quote2"].ToString(),
                            Quote3 = data["Quote3"].ToString(),
                            Desc4 = data["Desc4"].ToString(),
                            AboutCompany = data["AboutCompany"].ToString(),
                            InterviewTakenBy = data["InterviewTakenBy"].ToString(),
                            CompanyDomain = data["CompanyDomain"].ToString(),
                            CompanyName = data["CompanyName"].ToString(),
                            UpdateDate = Convert.ToDateTime(data["UpdateDate"]),
                            InterviewPDFImage = data["InterviewPDFImage"].ToString(),
                            CompanyLogo = data["CompanyLogo"].ToString(),
                            RouteURL = data["RouteURL"].ToString(),
                            MetaDescription = data["MetaDescription"].ToString(),
                            IsshowonDeck7 = data["IsshowonDeck7"].ToString(),
                            Publishedsite = data["publishedsite"].ToString()
                        });
                    }

                }
                if (InterviewList == null || InterviewList.Count == 0)
                {
                    return NotFound();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }


            return Ok(InterviewList);
        }

        [HttpGet]
        public IHttpActionResult GetHomespotlight(string siteName, string domainName)
        {
            List<Spotlite> SpotliteList = null;
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
                // scon = new SqlConnection("Data Source=199.79.62.22;User ID=theiotrep;Initial Catalog=theiotrep; Password=S#n6dy68");
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                string SpotDomainName = HttpContext.Current.Request.Url.Host;
                string SpotSiteName = SpotDomainName.ToLower();
                if (siteName.Contains('.') == true)
                    //SiteName = siteName.Split('.')[0].ToString();
                SiteName = siteName.ToLower();
                SiteName = SiteName.Replace(".", "_");
                //SpotSiteName = "abm_report";   
                //SpotDomainName = "sap.com";
                sqlCmd.Parameters.AddWithValue("@companyDomain", domainName.Trim());
                sqlCmd.Parameters.AddWithValue("@SiteName", SiteName.Trim());
                sqlCmd.CommandText = "NewPubsiteAPI_HomeSpotlight";
                sqlCmd.Connection = scon;
                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);

                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                SpotliteList = new List<Spotlite>(dt.Rows.Count);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow data in dt.Rows)
                    {

                        SpotliteList.Add(new Spotlite
                        {
                            id= Convert.ToInt32(data["id"]),
                            company_name = data["NAME"].ToString(),
                            description = data["description"].ToString(),
                            logo = data["ImageUrl"].ToString(),
                            domain_name = data["domain_name"].ToString(),
                            RouteURL= data["RouteURL"].ToString(),


                        });

                    }

                }
                if (SpotliteList.Count == 0)
                {
                    return NotFound();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }



            return Ok(SpotliteList);
        }

        [HttpGet]
        public IHttpActionResult GetHomeNews(string siteName)
        {
            IList<News> NewsList = null;
            string SiteName = "";
            siteName = siteName.Replace("test.", "");
            try
            {
                scon = new SqlConnection("Data Source=3.108.12.17;User ID=theiotrep1;Initial Catalog=theiotrep; Password=8g)mB9w3");
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                string DomainName = ((HttpContextWrapper)Request.Properties["MS_HttpContext"]).Request.ServerVariables["HTTP_HOST"];
                if (SiteName == string.Empty)
                    SiteName = siteName.Split('.')[0].Trim();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@SiteName", SiteName);
                sqlCmd.CommandText = "PubsiteAPI_HomeNews";
                sqlCmd.Connection = scon;
                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                NewsList = new List<News>(dt.Rows.Count);
                if (dt.Rows.Count > 0)
                {
                    News obj = new News();
                    foreach (DataRow data in dt.Rows)
                    {
                        NewsList.Add(new News
                        {

                            ID = Convert.ToInt32(data["ID"]),
                            ImageUrl = data["ImageUrl"].ToString(),
                            Title = data["Title"].ToString(),
                            Url = data["Url"].ToString(),
                            //Date = Convert.ToDateTime(data["Date2"]),
                            Description = data["Description"].ToString(),
                            date = data["date"].ToString(),
                            Tag = data["Tag"].ToString(),
                            CompanyName = data["CompanyName"].ToString()
                            //Month = data["Month"].ToString(),
                            // SourceType = data["SourceType"].ToString(),

                        }
                        );
                    }

                }
                if (NewsList.Count == 0)
                {
                    return NotFound();
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return Ok(NewsList);
        }

        [HttpGet]
        public IHttpActionResult GetHomeEvent(string siteName)
        {
            IList<Event> EventList = null;
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
               // scon = new SqlConnection("Data Source=199.79.62.22;User ID=theiotrep;Initial Catalog=theiotrep; Password=S#n6dy68");
                SqlCommand sqlCmd = new SqlCommand();
                string DomainName = ((HttpContextWrapper)Request.Properties["MS_HttpContext"]).Request.ServerVariables["HTTP_HOST"];
                // = DomainName.ToLower();
                if (SiteName == string.Empty)
                    SiteName = siteName.Split('.')[0].Trim();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@SiteName", SiteName);
                sqlCmd.CommandText = "NewPubsiteAPI_HomeEvent";
                sqlCmd.Connection = scon;
                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                EventList = new List<Event>(dt.Rows.Count);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow data in dt.Rows)
                    {
                        EventList.Add(new Event
                        {

                            EventID = Convert.ToInt32(data["EventID"]),
                            Name = data["Name"].ToString(),
                            Details = data["Details"].ToString(),
                            Location = data["Location"].ToString(),
                            StartDate = data["StartDate"].ToString(), //Convert.ToDateTime(data["StartDate"]),
                            EndDate = Convert.ToDateTime(data["EndDate"]),
                            ImageUrl = data["ImageUrl"].ToString(),
                            Url = data["Url"].ToString(),
                            EventType = data["EventType"].ToString(),
                            Keywords = data["Keywords"].ToString(),
                            City = data["City"].ToString(),
                            Country = data["Country"].ToString(),
                            Timezone = data["Timezone"].ToString(),
                            Sponsors = data["Sponsors"].ToString(),
                            EntryDate = Convert.ToDateTime(data["EntryDate"]),
                            IsSponcered = Convert.ToBoolean( data["IsSponcered"]),
                            Username = data["Username"].ToString(),
                            isNotificationSent = data["isNotificationSent"].ToString(),
                            StartEndDate = data["StartEndDate"].ToString(),
                            EventDifferentType= data["EventDifferentType"].ToString(),
                            RouteURL = data["RouteURL"].ToString(),


                        }
                        );
                    }

                }
                if (EventList.Count == 0)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(EventList);
        }

        [HttpGet]
        public IHttpActionResult GetHomePastEvent(string siteName)
        {
            IList<Event> PastEventList = null;
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
                // scon = new SqlConnection("Data Source=199.79.62.22;User ID=theiotrep;Initial Catalog=theiotrep; Password=S#n6dy68");
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                string DomainName = ((HttpContextWrapper)Request.Properties["MS_HttpContext"]).Request.ServerVariables["HTTP_HOST"];
                //string SiteName = DomainName.ToLower();
                if (SiteName == string.Empty)
                    SiteName = siteName.Split('.')[0].Trim();
                SiteName = SiteName.Replace(".", "_");
                sqlCmd.Parameters.AddWithValue("@SiteName", SiteName);
                sqlCmd.CommandText = "NewPubsiteAPI_HomeEventPast";
                sqlCmd.Connection = scon;
                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                PastEventList = new List<Event>(dt.Rows.Count);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow data in dt.Rows)
                    {
                        PastEventList.Add(new Event
                        {

                            EventID = Convert.ToInt32(data["EventID"]),
                            Name = data["Name"].ToString(),
                            Details = data["Details"].ToString(),
                            Location = data["Location"].ToString(),
                            StartDate = data["StartDate"].ToString(), // Convert.ToDateTime(data["StartDate"]),
                            EndDate = Convert.ToDateTime(data["EndDate"]),
                            ImageUrl = data["ImageUrl"].ToString(),
                            Url = data["Url"].ToString(),
                            EventType = data["EventType"].ToString(),
                            Keywords = data["Keywords"].ToString(),
                            City = data["City"].ToString(),
                            Country = data["Country"].ToString(),
                            Timezone = data["Timezone"].ToString(),
                            Sponsors = data["Sponsors"].ToString(),
                            IsActive = data["IsActive"].ToString(),
                            EntryDate = Convert.ToDateTime(data["EntryDate"]),
                            IsSponcered = Convert.ToBoolean(data["IsSponcered"]),
                            Username = data["Username"].ToString(),
                            isNotificationSent = data["isNotificationSent"].ToString(),
                            //ApprovePending = data["ApprovePending"].ToString(),
                            RouteURL = data["RouteURL"].ToString(),
                            UniqueAnkTokenM7 = "Null",
                            NotApproved = "Null",
                            RedirectID = '0',
                            StartEndDate = data["StartEndDate"].ToString(),
                            EventDifferentType = data["EventDifferentType"].ToString(),
                            
                        }
                        );
                    }

                }
                if (PastEventList.Count == 0)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(PastEventList);
        }

        [HttpGet]
        public IHttpActionResult GetHomeLiveWebinar(string siteName)
        {
            IList<Event> LiveWebinarList = null;
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
                //scon = new SqlConnection("Data Source=199.79.62.22;User ID=theiotrep;Initial Catalog=theiotrep; Password=S#n6dy68");
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                string DomainName = ((HttpContextWrapper)Request.Properties["MS_HttpContext"]).Request.ServerVariables["HTTP_HOST"];
                // string SiteName = DomainName.ToLower();
                // SiteName = SiteName.Replace(".", "_");
                if (SiteName == string.Empty)
                    SiteName = siteName.Split('.')[0].Trim();
                SiteName = SiteName.Replace(".", "_");
                sqlCmd.Parameters.AddWithValue("@SiteName", SiteName);
                sqlCmd.CommandText = "PubsiteAPI_Home_EventLiveWebinar";
                sqlCmd.Connection = scon;
                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                LiveWebinarList = new List<Event>(dt.Rows.Count);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow data in dt.Rows)
                    {
                        LiveWebinarList.Add(new Event
                        {

                            EventID = Convert.ToInt32(data["EventID"]),
                            Name = data["Name"].ToString(),
                            Details = data["Details"].ToString(),
                            Location = data["Location"].ToString(),
                            StartDate = data["StartDate"].ToString(), //Convert.ToDateTime(data["StartDate"]),
                            EndDate = Convert.ToDateTime(data["EndDate"]),
                            ImageUrl = data["ImageUrl"].ToString(),
                           // Url = data["Url"].ToString(),
                            EventType = data["EventType"].ToString(),
                            Keywords = data["Keywords"].ToString(),
                            City = data["City"].ToString(),
                            Country = data["Country"].ToString(),
                            Timezone = data["Timezone"].ToString(),
                            Sponsors = data["Sponsors"].ToString(),
                            IsActive = data["IsActive"].ToString(),
                            EntryDate = Convert.ToDateTime(data["EntryDate"]),
                            IsSponcered = Convert.ToBoolean(data["IsSponcered"]),
                            Username = data["Username"].ToString(),
                            RedirectID = 0,
                            UniqueAnkTokenM7 = data["UniqueAnkTokenM7"].ToString(),
                            //ApprovePending = data["ApprovePending"].ToString(),
                            NotApproved = data["NotApproved"].ToString(),
                            RouteURL = data["RouteURL"].ToString(),
                            StartTime = data["StartTime"].ToString(),
                            DateWithStartTime = data["DateWithStartTime"].ToString(),
                            EventDifferentType = data["EventDifferentType"].ToString(),
                            URL=data["URL"].ToString(),

                        }
                        );
                    }

                }
                if (LiveWebinarList.Count == 0)
                {
                    return Ok(LiveWebinarList);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Ok(LiveWebinarList);
        }

        [HttpGet]
        public IHttpActionResult GetHomeOnDemandWebinar(string siteName)
        {
            IList<Event> OnDemandWebinarList = null;
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
                //scon = new SqlConnection("Data Source=199.79.62.22;User ID=theiotrep;Initial Catalog=theiotrep; Password=S#n6dy68");
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                string DomainName = ((HttpContextWrapper)Request.Properties["MS_HttpContext"]).Request.ServerVariables["HTTP_HOST"];
                //string SiteName = DomainName.ToLower();
                //SiteName = SiteName.Replace(".", "_");
                if (SiteName == string.Empty)
                    SiteName = siteName.Split('.')[0].Trim();
                SiteName = SiteName.Replace(".", "_");
                sqlCmd.Parameters.AddWithValue("@SiteName", SiteName);
                sqlCmd.CommandText = "NewPubsiteAPI_Home_EventOnDemandWebinar";
                sqlCmd.Connection = scon;
                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                OnDemandWebinarList = new List<Event>(dt.Rows.Count);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow data in dt.Rows)
                    {
                        OnDemandWebinarList.Add(new Event
                        {

                            EventID = Convert.ToInt32(data["EventID"]),
                            Name = data["Name"].ToString(),
                            Details = data["Details"].ToString(),
                            Location = data["Location"].ToString(),
                            StartDate = data["StartDate"].ToString(), // Convert.ToDateTime(data["StartDate"]),
                            EndDate = Convert.ToDateTime(data["EndDate"]),
                            ImageUrl = data["ImageUrl"].ToString(),
                            //Url = data["Url"].ToString(),
                            EventType = data["EventType"].ToString(),
                            Keywords = data["Keywords"].ToString(),
                            City = data["City"].ToString(),
                            Country = data["Country"].ToString(),
                            Timezone = data["Timezone"].ToString(),
                            Sponsors = data["Sponsors"].ToString(),
                            IsActive = data["IsActive"].ToString(),
                            EntryDate = Convert.ToDateTime(data["EntryDate"]),
                            IsSponcered = Convert.ToBoolean(data["IsSponcered"]),
                            Username = data["Username"].ToString(),
                            CompanyName = data["Company"].ToString(),
                            RedirectID = 0,
                            UniqueAnkTokenM7 = data["UniqueAnkTokenM7"].ToString(),
                            //  ApprovePending = data["ApprovePending"].ToString(),
                            NotApproved = data["NotApproved"].ToString(),
                            RouteURL = data["RouteURL"].ToString(),
                            DateWithStartTime = data["DateWithStartTime"].ToString(),
                            EventDifferentType = data["EventDifferentType"].ToString(),
                            URL = data["URL"].ToString(),
                        }
                        );
                    }

                }
                if (OnDemandWebinarList.Count == 0)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(OnDemandWebinarList);
        }

        [HttpGet]
        public IHttpActionResult GetHomeResources(string siteName)
        {
            IList<Resources> ResourcesList = null;
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
                // scon = new SqlConnection("Data Source=199.79.62.22;User ID=theiotrep;Initial Catalog=theiotrep; Password=S#n6dy68");
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                string DomainName = ((HttpContextWrapper)Request.Properties["MS_HttpContext"]).Request.ServerVariables["HTTP_HOST"];
                //string SiteName = DomainName.ToLower();
                //SiteName = SiteName.Replace(".", "_");
                if (SiteName == string.Empty)
                    SiteName = siteName.Split('.')[0].Trim();
                SiteName = SiteName.Replace(".", "_");
                sqlCmd.Parameters.AddWithValue("@SiteName", SiteName);
                sqlCmd.CommandText = "NewPubsiteAPI_HomeResources";
                sqlCmd.Connection = scon;
                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                ResourcesList = new List<Resources>(dt.Rows.Count);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow data in dt.Rows)
                    {
                        ResourcesList.Add(new Resources
                        {

                            ID = Convert.ToInt32(data["ID"]),
                            ImageURL = data["ImageURL"].ToString(),
                            Description = data["Description"].ToString(),
                            ResourceType = data["ResourceType"].ToString(),
                            WhitePaperTitle = data["WhitePaperTitle"].ToString(),
                            RouteURL=data["RouteURL"].ToString(),
                        }
                        );
                    }

                }
                if (ResourcesList.Count == 0)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(ResourcesList);
        }

        public IHttpActionResult GetHomeResourceArticles(string siteName)
        {
            IList<Resources> ResourcesList = null;
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
                // scon = new SqlConnection("Data Source=199.79.62.22;User ID=theiotrep;Initial Catalog=theiotrep; Password=S#n6dy68");
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                string DomainName = ((HttpContextWrapper)Request.Properties["MS_HttpContext"]).Request.ServerVariables["HTTP_HOST"];
                //string SiteName = DomainName.ToLower();
                //SiteName = SiteName.Replace(".", "_");
                if (SiteName == string.Empty)
                    SiteName = siteName.Split('.')[0].Trim();
                SiteName = SiteName.Replace(".", "_");
                sqlCmd.Parameters.AddWithValue("@SiteName", SiteName);
                sqlCmd.CommandText = "NewPubsiteAPI_HomeResourcesArticles";
                sqlCmd.Connection = scon;
                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                ResourcesList = new List<Resources>(dt.Rows.Count);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow data in dt.Rows)
                    {
                        ResourcesList.Add(new Resources
                        {

                            ID = Convert.ToInt32(data["ID"]),
                            ImageURL = data["ImageURL"].ToString(),
                            Description = data["Description"].ToString(),
                            ResourceType = data["ResourceType"].ToString(),
                            WhitePaperTitle = data["WhitePaperTitle"].ToString(),
                            RouteURL=data["RouteURL"].ToString(),
                            Tag=data["Tag"].ToString()
                        }
                        );
                    }

                }
                if (ResourcesList.Count == 0)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(ResourcesList);
        }

        [HttpGet]
        public IHttpActionResult GetHomeResourceWhitepapers(string siteName)
        {
            IList<Resources> ResourcesList = null;
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
                // scon = new SqlConnection("Data Source=199.79.62.22;User ID=theiotrep;Initial Catalog=theiotrep; Password=S#n6dy68");
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                string DomainName = ((HttpContextWrapper)Request.Properties["MS_HttpContext"]).Request.ServerVariables["HTTP_HOST"];
                //string SiteName = DomainName.ToLower();
                //SiteName = SiteName.Replace(".", "_");
                if (SiteName == string.Empty)
                    SiteName = siteName.Split('.')[0].Replace("test.", "");
                SiteName = SiteName.Replace(".", "_").Replace("test.","");
                sqlCmd.Parameters.AddWithValue("@SiteName", SiteName);
                sqlCmd.CommandText = "NewPubsiteAPI_HomeResourcesWhitepapers";
                sqlCmd.Connection = scon;
                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                ResourcesList = new List<Resources>(dt.Rows.Count);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow data in dt.Rows)
                    {
                        ResourcesList.Add(new Resources
                        {

                            ID = Convert.ToInt32(data["ID"]),
                            ImageURL = data["ImageURL"].ToString(),
                            Description = data["Description"].ToString(),
                            ResourceType = data["ResourceType"].ToString(),
                            WhitePaperTitle = data["WhitePaperTitle"].ToString(),
                            RouteURL=data["RouteURL"].ToString(),
                            Tag= data["Tag"].ToString()
                        }
                        );
                    }

                }
                if (ResourcesList.Count == 0)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(ResourcesList);
        }

        [HttpGet]
        public IHttpActionResult GetAllHomeResources(string siteName, int pageNumber)
        {
            IList<Resources> ResourcesList = null;
            string SiteName = "";
            siteName = siteName.Replace("test.", "");
            try
            {
                scon = new SqlConnection("Data Source=3.108.12.17;User ID=theiotrep1;Initial Catalog=theiotrep; Password=8g)mB9w3");
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                string DomainName = ((HttpContextWrapper)Request.Properties["MS_HttpContext"]).Request.ServerVariables["HTTP_HOST"];
                //string SiteName = DomainName.ToLower();
                //SiteName = SiteName.Replace(".", "_");
                if (SiteName == string.Empty)
                    SiteName = siteName.Split('.')[0].Trim();
                SiteName = SiteName.Replace(".", "_");
                sqlCmd.Parameters.AddWithValue("@SiteName", SiteName);
                sqlCmd.Parameters.AddWithValue("@PageNumber", pageNumber);
                sqlCmd.CommandText = "PubsiteAPI_GetAllHomeResources";
                sqlCmd.Connection = scon;
                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                ResourcesList = new List<Resources>(dt.Rows.Count);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow data in dt.Rows)
                    {
                        ResourcesList.Add(new Resources
                        {

                            ID = Convert.ToInt32(data["ID"]),
                            ImageURL = data["ImageURL"].ToString(),
                            Description = data["Description"].ToString(),
                            ResourceType = data["ResourceType"].ToString(),
                            WhitePaperTitle = data["WhitePaperTitle"].ToString(),
                            RouteURL = data["RouteURL"].ToString(),
                            TotalDataCount = Convert.ToInt32(data["TotalDataCount"]),
                            Tag =data["Tag"].ToString()
                        }
                        );
                    }

                }
                if (ResourcesList.Count == 0)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(ResourcesList);
        }

        [HttpGet]
        public IHttpActionResult GetAllHomeResourcesByAuthor(string siteName,string email)
        {
            IList<Resources> ResourcesList = null;
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
                    //scon = new SqlConnection("Data Source=3.108.12.178;User ID=theiotrep1;Initial Catalog=theiotrep; Password=8g)mB9w38");
                    Connection();
                }


               
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                string DomainName = ((HttpContextWrapper)Request.Properties["MS_HttpContext"]).Request.ServerVariables["HTTP_HOST"];
                //string SiteName = DomainName.ToLower();
                //SiteName = SiteName.Replace(".", "_");
                if (SiteName == string.Empty)
                    SiteName = siteName.Split('.')[0].Trim();
                SiteName = SiteName.Replace(".", "_");
                sqlCmd.Parameters.AddWithValue("@SiteName", SiteName);
                //sqlCmd.Parameters.AddWithValue("@PageNumber", pageNumber);
                sqlCmd.Parameters.AddWithValue("@Email", email);
                sqlCmd.CommandText = "New_NewPubsiteAPI_GetAllHomeResourcesByAuthor";
                sqlCmd.Connection = scon;
                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                ResourcesList = new List<Resources>(dt.Rows.Count);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow data in dt.Rows)
                    {
                        ResourcesList.Add(new Resources
                        {

                            ID = Convert.ToInt32(data["ID"]),
                            ImageURL = data["ImageURL"].ToString(),
                            Description = data["Description"].ToString(),
                            ResourceType = data["ResourceType"].ToString(),
                            WhitePaperTitle = data["WhitePaperTitle"].ToString(),
                            RouteURL = data["RouteURL"].ToString(),
                            TotalDataCount = Convert.ToInt32(data["TotalDataCount"]),
                            Tag = data["Tag"].ToString(),
                            AuthorName = data["Author"].ToString(),
                            EntryDate = data["EntryDate"].ToString()
                        }
                        );
                    }

                }
                if (ResourcesList.Count == 0)
                {
                    return Ok(ResourcesList);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(ResourcesList);
        }

        [HttpGet]
        public IHttpActionResult GetTop6FutureNewsDetails(string siteName)
        {
            IList<FutureNewsModel> newsModelData = null;
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
                sqlCmd.CommandText = "PubsiteAPI_News_NewsDetails_GetTop6FutureNewsDetails";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                newsModelData = new List<FutureNewsModel>(dt.Rows.Count);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow data in dt.Rows)
                    {

                        //DateTime? date = null;
                        //if (data["Date"].ToString() == "dd/MM/yyyy")
                        //    date = DateTime.ParseExact(data["Date"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        //else
                        //    date = DateTime.ParseExact(data["Date"].ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
                        newsModelData.Add(new FutureNewsModel
                        {
                            ID = Convert.ToInt32(data["ID"]),
                            Author = Utils.HtmlDecode(data["Author"].ToString()),
                            //Date = data["Date"].ToString(),
                            PublishingDate = data["PublishingDate"].ToString(),
                            Description = Utils.HtmlDecode(data["Description"].ToString()),
                            Title = Utils.HtmlDecode(data["Title"].ToString()),
                            ImageUrl = data["ImageUrl"].ToString(),
                            URL = data["URl"].ToString(),
                            RouteURL = data["RouteURL"].ToString(),
                            CompanyName = Utils.HtmlDecode(data["CompanyName"].ToString()),
                            NewsTypeName= Utils.HtmlDecode(data["NewsTypeName"].ToString()),
                            EventDifferentType = Utils.HtmlDecode(data["EventDifferentType"].ToString()),
                            Tag= Utils.HtmlDecode(data["Tag"].ToString()),

                        });
                    }

                }
                if (newsModelData == null || newsModelData.Count == 0)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Ok(newsModelData);
        }

        [HttpGet]
        public IHttpActionResult GetTop6TrendingNewsDetails(string siteName)
        {
            IList<TrendingNewsModel> trendingNewsModel = null;
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
                sqlCmd.CommandText = "PubsiteAPI_News_NewsDetails_GetTop6TrendingNews";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                trendingNewsModel = new List<TrendingNewsModel>(dt.Rows.Count);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow data in dt.Rows)
                    {

                        //DateTime? date2 = null;
                        //if (data["Date2"].ToString() == "dd/MM/yyyy")
                        //    date2 = DateTime.ParseExact(data["Date2"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

                        //else
                        //    date2 = DateTime.ParseExact(data["Date2"].ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
                        trendingNewsModel.Add(new TrendingNewsModel
                        {
                            ID = Convert.ToInt32(data["ID"]),
                            ImageUrl = data["ImageUrl"].ToString(),
                            Title = Utils.HtmlDecode(data["Title"].ToString()),
                            URL = data["URL"].ToString(),
                            //Date = data["Date"].ToString(),
                            Date2 = data["Date2"].ToString(),
                            PublishingDate = data["PublishingDate"].ToString(),
                            Description = Utils.HtmlDecode(data["Description"].ToString()),
                            Source = Utils.HtmlDecode(data["Source"].ToString()),
                            Author = Utils.HtmlDecode(data["Author"].ToString()),
                            CompanyName = Utils.HtmlDecode(data["CompanyName"].ToString()),
                            NewsTypeName= Utils.HtmlDecode(data["NewsTypeName"].ToString()),
                            RouteURL = data["RouteURL"].ToString(),
                            EventDifferentType = Utils.HtmlDecode(data["EventDifferentType"].ToString()),
                            Tag = Utils.HtmlDecode(data["Tag"].ToString()),
                        });
                    }

                }
                if (trendingNewsModel == null || trendingNewsModel.Count == 0)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Ok(trendingNewsModel);
        }

        [HttpGet]
        public IHttpActionResult GetTop5ArticleForMobileView(string siteName)
        {
            IList<HomeArticleModel> objHomeArticleModel = null;
            string SiteName = string.Empty;
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
                sqlCmd.CommandText = "PubsiteAPI_Home_GetTop5ArticleForMobileView";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                objHomeArticleModel = new List<HomeArticleModel>(dt.Rows.Count);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow data in dt.Rows)
                    {

                        objHomeArticleModel.Add(new HomeArticleModel
                        {
                            ID = Convert.ToInt32(data["ID"]),
                            ImageUrl = data["ImageUrl"].ToString(),
                            WhitePaperTitle = data["WhitePaperTitle"].ToString(),
                            ResourceType = data["ResourceType"].ToString(),
                            Description = data["Description"].ToString()
                        });
                    }

                }
                if (objHomeArticleModel == null || objHomeArticleModel.Count == 0)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Ok(objHomeArticleModel);
        }

        [HttpGet]
        public IHttpActionResult GetTop5WhitePaperForMobileView(string siteName)
        {
            IList<HomeArticleModel> objHomeArticleModel = null;
            string SiteName = string.Empty;
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
                sqlCmd.CommandText = "PubsiteAPI_Home_GetTop5WhitePaperForMobileView";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                objHomeArticleModel = new List<HomeArticleModel>(dt.Rows.Count);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow data in dt.Rows)
                    {

                        objHomeArticleModel.Add(new HomeArticleModel
                        {
                            ID = Convert.ToInt32(data["ID"]),
                            ImageUrl = data["ImageUrl"].ToString(),
                            WhitePaperTitle = data["WhitePaperTitle"].ToString(),
                            ResourceType = data["ResourceType"].ToString(),
                            Description = data["Description"].ToString()
                        });
                    }

                }
                if (objHomeArticleModel == null || objHomeArticleModel.Count == 0)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Ok(objHomeArticleModel);
        }

        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }

        [HttpGet]
        public IHttpActionResult GetAddCode(string siteName, string position)
        {

            AdCode objGetAddCode = new AdCode();

            StringBuilder AdHeadCode = new StringBuilder();

            StringBuilder AdBodyCode = new StringBuilder();
            try
            {
                string SiteName = string.Empty;

                if (SiteName == string.Empty)
                {
                    SiteName = siteName;

                    if (SiteName.Contains("."))
                        SiteName = SiteName.Split('.')[0].Trim();
                }
                Connection();
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@SiteName", SiteName);
                sqlCmd.Parameters.AddWithValue("@AdsLocation", position);
                sqlCmd.CommandText = "GetAdds";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0 && ds.Tables.Count > 0 && ds != null)
                {

                    if (position.Contains("top"))
                    {
                        String divId = "";
                        divId = ds.Tables[0].Rows[0]["ScriptDivId"].ToString().Replace("&#39;", "").Replace(" ", "");

                        AdBodyCode.Append(" <div id='" + divId + "' style='height:90px; '>");
                        AdBodyCode.Append(" <script> ");
                        AdBodyCode.Append(" googletag.cmd.push(function() { googletag.display('" + divId + "'); });");
                        AdBodyCode.Append(" </script> ");
                        AdBodyCode.Append(" <script> ");
                        AdBodyCode.Append(" " + ds.Tables[0].Rows[0]["Script"].ToString().Replace("&#39;", "'") + " ");
                        AdBodyCode.Append(" </script> ");
                        AdBodyCode.Append(" </div> ");
                    }
                    else
                    {
                        String divId = "";
                        divId = ds.Tables[0].Rows[0]["ScriptDivId"].ToString().Replace("&#39;", "").Replace(" ", "");

                        AdBodyCode.Append(" <div id='" + divId + "' style='height:250px; '>");
                        AdBodyCode.Append(" <script> ");
                        AdBodyCode.Append(" googletag.cmd.push(function() { googletag.display('" + divId + "'); });");
                        AdBodyCode.Append(" </script> ");
                        AdBodyCode.Append(" <script> ");
                        AdBodyCode.Append(" " + ds.Tables[0].Rows[0]["Script"].ToString().Replace("&#39;", "'") + " ");
                        AdBodyCode.Append(" </script> ");
                        AdBodyCode.Append(" </div> ");
                    }
                     
                }



                AdHeadCode.Append(" <script async='async' src='https://www.googletagservices.com/tag/js/gpt.js'></script>  <script> var googletag = googletag || {}; googletag.cmd = googletag.cmd || [];</script><script>" + ds.Tables[0].Rows[0]["Script"].ToString().Replace("&#39;", "'") + "</script>");

                 

                objGetAddCode.AddHeader = AdHeadCode.ToString();
                objGetAddCode.AddBody = AdBodyCode.ToString();
                             
                            // RouteURL = data["RouteURL"].ToString()
                  
                 
                if (AdBodyCode == null || AdBodyCode.ToString() == "")
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(objGetAddCode);
        }

        [HttpGet]
        public IHttpActionResult GetAddCodeNew(string siteName, string position)
        {

                AdCodeNew objNewGetAddCode = new AdCodeNew();

             
            try
            {
                
                Connection();
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@SiteName", siteName);
                sqlCmd.Parameters.AddWithValue("@AdsLocation", position);
                sqlCmd.CommandText = "GetAdds_New";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {

                    objNewGetAddCode.HeadScript = ds.Tables[0].Rows[0]["HeadScript"].ToString();

                    objNewGetAddCode.BodyScript = ds.Tables[0].Rows[0]["BodyScript"].ToString();
                }


                //AdHeadCode.Append(" <script async='async' src='https://www.googletagservices.com/tag/js/gpt.js'></script>  <script> var googletag = googletag || {}; googletag.cmd = googletag.cmd || [];</script><script>" + ds.Tables[0].Rows[0]["Script"].ToString().Replace("&#39;", "'") + "</script>");



                //objGetAddCode.AddHeader = AdHeadCode.ToString();
                //objGetAddCode.AddBody = AdBodyCode.ToString();

                // RouteURL = data["RouteURL"].ToString()


                //if (AdBodyCode == null || AdBodyCode.ToString() == "")
                //{
                //    return NotFound();
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(objNewGetAddCode);
        }



        public Boolean CountCheck(string url)
        {
            int count = 0, n = 0;
            while ((n = url.IndexOf('/', n) + 1) != 0) count++;
            if (count == 2)
            {
                return true;
            }
            return false;
        }
        [HttpGet]
        public IHttpActionResult GetMetaCode(string PubsiteName, string PageName)
        {
            Boolean flag = false;
            string url = "https://abm.report/events/hheded/gartner-marketing-symposium-xpo/2667";
            string[] str = url.Split(new string[] { "events" }, StringSplitOptions.None);
            if (CountCheck(str[1]))
            {
                flag = true;
            }

            string siteName = "";
            IList<GetmetaCodemodel> objGetmetaCodemodel = null;
            try
            {
                //if (PubsiteName == "pharmaceutical.report" || PubsiteName == "smallbusiness.report")
                //{
                //    PharmaSmallConnection();
                //}
                //else
                //{
                    Connection();
                //}
                if (siteName == string.Empty)
                {
                    siteName = PubsiteName;
                    if (siteName.Contains('.'))
                    {
                        siteName = siteName.Split('.')[0].Trim();
                    }
                }

                
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;

                sqlCmd.Parameters.AddWithValue("@PubsiteName", siteName);
                sqlCmd.Parameters.AddWithValue("@PageName", PageName);
                sqlCmd.CommandText = "NewPubsiteAPI__GetMetaCode";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                objGetmetaCodemodel = new List<GetmetaCodemodel>(dt.Rows.Count);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow data in dt.Rows)
                    {
                        objGetmetaCodemodel.Add(new GetmetaCodemodel
                        {
                            Dtl_id = Convert.ToInt32(data["Dtl_id"]),
                            PageName = Utils.HtmlDecode(data["PageName"].ToString()),
                           // HeaderText = data["HeaderText"].ToString(),
                            PageUrl = data["PageUrl"].ToString(),
                            OgImageURL = data["OgImageURL"].ToString(),
                            PageTitle = Utils.HtmlDecode(data["PageTitle"].ToString()),
                            OgKeyWords = Utils.HtmlDecode(data["OgKeyWords"].ToString()),
                            OgDescription = Utils.HtmlDecode(data["OgDescription"].ToString()),
                            OgTitle = Utils.HtmlDecode(data["OgTitle"].ToString()),
                           // LogoUrl = data["LogoUrl"].ToString(),
                            PubsiteName = Utils.HtmlDecode(data["PubsiteName"].ToString()),
                            PubsitePage = Utils.HtmlDecode(data["PubsitePage"].ToString()),
                            IsSponcered = Convert.ToInt32(data["IsSponcered"]),

                            // RouteURL = data["RouteURL"].ToString()
                        });
                    }

                }
                if (objGetmetaCodemodel == null || objGetmetaCodemodel.Count == 0)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(objGetmetaCodemodel);
        }

        [HttpGet]
        public IHttpActionResult GetMasterMetaCode(string PubsiteName)
        {
            IList<MasterMetaTags> objGetMasterMetaCode = null;
            try
            {
                //if (PubsiteName == "pharmaceutical.report" || PubsiteName == "smallbusiness.report")
                //{
                //    PharmaSmallConnection();
                //}
                //else
                //{
                //    Connection();
                //}
                 Connection();
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;

                sqlCmd.Parameters.AddWithValue("@PubsiteName", PubsiteName);
                sqlCmd.CommandText = "PubsiteAPI__GetMasterMetaTags";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                objGetMasterMetaCode = new List<MasterMetaTags>(dt.Rows.Count);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow data in dt.Rows)
                    {
                        objGetMasterMetaCode.Add(new MasterMetaTags
                        {
                            Masterid = Convert.ToInt32(data["Masterid"]),
                            Site_Name = data["Site_Name"].ToString(),
                            Site_Domain = data["Site_Domain"].ToString(),
                            Logo = data["Logo"].ToString(),
                            Flogo = data["Flogo"].ToString(),
                            TagManager_Head = data["TagManager_Head"].ToString(),
                            TagManager_Body = data["TagManager_Body"].ToString(),
                            GA_Code = data["GA_Code"].ToString(),
                            AdRoll_Code = data["AdRoll_Code"].ToString(),
                            FaceBook = data["FaceBook"].ToString(),
                            Twitter = data["Twitter"].ToString(),
                            LinkedIn = data["LinkedIn"].ToString(),
                            GO_sosiallink = data["GO_sosiallink"].ToString(),
                            Media7AdvertiseLink = data["Media7AdvertiseLink"].ToString(),
                            PubSiteUniqueId = data["PubSiteUniqueId"].ToString(),
                            color = data["color"].ToString(),
                            siteName = data["siteName"].ToString(),
                            ColorHover = data["ColorHover"].ToString(),
                            Headertext = data["Headertext"].ToString(),
                            PreSite = data["PreSite"].ToString(),                            
                            // RouteURL = data["RouteURL"].ToString()
                        });
                    }

                }
                if (objGetMasterMetaCode == null || objGetMasterMetaCode.Count == 0)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(objGetMasterMetaCode);
        }


        //[HttpGet]
        //public IHttpActionResult DummyData(string Sitename, string Email)
        //{
        //    IList<DummyData> objDummyData = null;
        //    try
        //    {
        //        //if (PubsiteName == "pharmaceutical.report" || PubsiteName == "smallbusiness.report")
        //        //{
        //        //    PharmaSmallConnection();
        //        //}
        //        //else
        //        //{
        //        //    Connection();
        //        //}
        //         Connection();
        //        SqlCommand sqlCmd = new SqlCommand();
        //        sqlCmd.CommandType = CommandType.StoredProcedure;
        //        sqlCmd.Parameters.AddWithValue("@Sitename", Sitename);
        //        sqlCmd.Parameters.AddWithValue("Email", Sitename);
        //        sqlCmd.CommandText = "Dummy_data_testing";
        //        sqlCmd.Connection = scon;

        //        SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
        //        DataSet ds = new DataSet();
        //        sda.Fill(ds);
        //        DataTable dt = new DataTable();
        //        dt = ds.Tables[0];
        //        objDummyData = new List<DummyData>(dt.Rows.Count);
        //        if (dt.Rows.Count > 0)
        //        {
        //            foreach (DataRow data in dt.Rows)
        //            {
        //                objDummyData.Add(new DummyData
        //                {

        //                    Sitename = data["Sitename"].ToString(),
        //                    Email = data["Email"].ToString(),
                                                       
        //                    // RouteURL = data["RouteURL"].ToString()
        //                });
        //            }

        //        }
        //        if (objDummyData == null || objDummyData.Count == 0)
        //        {
        //            return NotFound();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return Ok(objDummyData);
        //}

       
    }
}