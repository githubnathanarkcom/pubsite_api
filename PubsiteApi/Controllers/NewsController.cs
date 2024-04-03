using PubsiteApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;


namespace PubsiteApi.Controllers
{
    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    public class NewsController : ApiController
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


        //Get Top9 Future News by Site Name
        [HttpGet]
        public IHttpActionResult GetTop9FutureNewsDetails(string siteName)
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
                sqlCmd.CommandText = "PubsiteAPI_News_NewsDetails_GetTop9FutureNewsDetails";
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
                        newsModelData.Add(new FutureNewsModel
                        {
                            ID = Convert.ToInt32(data["ID"]),
                            Author = data["Author"].ToString(),
                            //Date = data["Date"].ToString(),
                            PublishingDate = data["PublishingDate"].ToString(),
                            Description = data["Description"].ToString(),
                            Title = data["Title"].ToString(),
                            ImageUrl = data["ImageUrl"].ToString(),
                            URL = data["URl"].ToString(),
                            RouteURL = data["RouteURL"].ToString(),
                            IsSponcered = Convert.ToInt32(data["IsSponcered"]),
                            EventDifferentType= data["EventDifferentType"].ToString(),
                            CompanyName = data["CompanyName"].ToString(),
                            Tag = data["Tag"].ToString()
                        });
                    }

                }
                if (newsModelData == null || newsModelData.Count == 0)
                {
                    return NotFound();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return Ok(newsModelData);
        }
       

        //Get All Future News by Site Name
        [HttpGet]
        public IHttpActionResult GetAllFutureNewsDetails(string siteName, int pageNumber)
        {
            IList<FutureNewsModel> newsModelList = null;
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
                sqlCmd.Parameters.AddWithValue("@PageNumber", pageNumber);
                sqlCmd.CommandText = "PubsiteAPI_News_NewsDetails_GetAllFutureNewsDetails";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                newsModelList = new List<FutureNewsModel>(dt.Rows.Count);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow data in dt.Rows)
                    {
                        newsModelList.Add(new FutureNewsModel
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
                            IsSponcered = Convert.ToInt32(data["IsSponcered"]),
                            TotalDataCount = Convert.ToInt32(data["TotalDataCount"]),
                            EventDifferentType = data["EventDifferentType"].ToString(),
                            CompanyName = Utils.HtmlDecode(data["CompanyName"].ToString()),
                            Tag = Utils.HtmlDecode(data["Tag"].ToString())
                        });
                    }

                }
                if (newsModelList == null || newsModelList.Count == 0)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Ok(newsModelList);
        }

        //Get Top9 Trending News by Site Name
        [HttpGet]
        public IHttpActionResult GetTop9TrendingNewsDetails(string siteName)
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
                sqlCmd.CommandText = "PubsiteAPI_News_NewsDetails_GetTop9TrendingNews";
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
                        trendingNewsModel.Add(new TrendingNewsModel
                        {
                            ID = Convert.ToInt32(data["ID"]),
                            ImageUrl = data["ImageUrl"].ToString(),
                            Title = data["Title"].ToString(),
                            URL = data["URL"].ToString(),
                            //Date = data["Date"].ToString(),
                            PublishingDate = data["PublishingDate"].ToString(),
                            Date2 =data["Date2"].ToString(),
                            Description = data["Description"].ToString(),
                            Source = data["Source"].ToString(),
                            Author = data["Author"].ToString(),
                            IsSponcered = Convert.ToInt32(data["IsSponcered"]),
                            EventDifferentType= data["EventDifferentType"].ToString(),
                            RouteURL= data["RouteURL"].ToString(),
                            CompanyName = data["CompanyName"].ToString(),
                            Tag = data["Tag"].ToString()

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
      

        //Get All Trending News by Site Name
        [HttpGet]
        public IHttpActionResult GetAllTrendingNews(string siteName,string pageNumber)
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
                sqlCmd.CommandText = "PubsiteAPI_News_NewsDetails_GetAllTrendingNews";
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
                        trendingNewsModel.Add(new TrendingNewsModel
                        {
                            ID = Convert.ToInt32(data["ID"]),
                            ImageUrl = data["ImageUrl"].ToString(),
                            Title = data["Title"].ToString(),
                            URL = data["URL"].ToString(),
                            //Date = data["Date"].ToString(),
                            PublishingDate = data["PublishingDate"].ToString(),
                            //Date2 = data["Date2"].ToString(),
                            Description = Utils.HtmlDecode(data["Description"].ToString()),
                           // Source = data["Source"].ToString(),
                            Author = data["Author"].ToString(),
                            TotalDataCount = Convert.ToInt32(data["TotalDataCount"]),
                            IsSponcered = Convert.ToInt32(data["IsSponcered"]),
                            EventDifferentType= data["EventDifferentType"].ToString(),
                            RouteURL = data["RouteURL"].ToString(),
                            CompanyName = data["CompanyName"].ToString(),
                            Tag = data["Tag"].ToString()
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

        //Get Top9 Archived News by Site Name
        [HttpGet]
        public IHttpActionResult GetTop9ArchivedNewsDetails(string siteName)
        {
            IList<ArchivedModel> archivedModel = null;
            string SiteName = string.Empty;
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
                sqlCmd.CommandText = "PubsiteAPI_News_NewsDetails_GetTop9ArchivedNewsDetails";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                archivedModel = new List<ArchivedModel>(dt.Rows.Count);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow data in dt.Rows)
                    {

                        archivedModel.Add(new ArchivedModel
                        {
                            ID = Convert.ToInt32(data["ID"]),
                            ImageUrl = data["ImageUrl"].ToString(),
                            Title = data["Title"].ToString(),
                            URL = data["URL"].ToString(),
                            Date = data["Date"].ToString(),
                            Date2 = data["Date2"].ToString(),
                            Description = data["Description"].ToString(),
                            Source = data["Source"].ToString(),
                            IsSponcered = Convert.ToInt32(data["IsSponcered"]),
                            CompanyName = data["CompanyName"].ToString()
                        });
                    }

                }
                if (archivedModel == null || archivedModel.Count == 0)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Ok(archivedModel);
        }
        

        //Get All Archived News by Site Name
        [HttpGet]
        public IHttpActionResult GetAllArchivedNewsDetails(string siteName, string pageNumber)
        {
            IList<ArchivedModel> archivedModelList = null;
            string SiteName = string.Empty;
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
                sqlCmd.CommandText = "PubsiteAPI_News_NewsDetails_GetAllArchivedNewsDetails";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                archivedModelList = new List<ArchivedModel>(dt.Rows.Count);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow data in dt.Rows)
                    {
                        archivedModelList.Add(new ArchivedModel
                        {
                            ID = Convert.ToInt32(data["ID"]),
                            ImageUrl = data["ImageUrl"].ToString(),
                            Title = data["Title"].ToString(),
                            URL = data["URL"].ToString(),
                            Date = data["Date"].ToString(),
                            Date2 = data["Date2"].ToString(),
                            Description = data["Description"].ToString(),
                            Source = data["Source"].ToString(),
                            TotalDataCount = Convert.ToInt32(data["TotalDataCount"]),
                            IsSponcered = Convert.ToInt32(data["IsSponcered"]),
                            CompanyName = data["CompanyName"].ToString()
                        });
                    }

                }
                if (archivedModelList == null || archivedModelList.Count == 0)
                {
                    return NotFound();
                }



            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Ok(archivedModelList);
        }

        [HttpGet]
        public IHttpActionResult GetNewsResources(string siteName)
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
                sqlCmd.CommandText = "NewPubsiteAPI_News_NewsDetails_Resources";
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
                            keywords = data["keywords"].ToString(),
                            ResourceType = data["ResourceType"].ToString(),
                            ImageUrl = data["ImageUrl"].ToString(),
                            IsSponcered = Convert.ToInt32(data["IsSponcered"]),
                            RouteURL = data["RouteURL"].ToString(),
                            Description = data["Description"].ToString(),
                            WhitePaperTitle = data["WhitePaperTitle"].ToString(),
                            Tag = data["Tag"].ToString()
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
        public IHttpActionResult GetNewsSpotLight(string siteName, string domainName)
        {
            IList<NewsSpotLightModel> objSpotLight = null;
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
               // sqlCmd.Parameters.AddWithValue("@companyDomain", domainName.Trim());
                sqlCmd.Parameters.AddWithValue("@SiteName", SiteName);
                sqlCmd.CommandText = "NewPubsiteAPI_News_NewDetails_Spotlight";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                objSpotLight = new List<NewsSpotLightModel>(dt.Rows.Count);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow data in dt.Rows)
                    {
                        objSpotLight.Add(new NewsSpotLightModel
                        {
                            ID = Convert.ToInt32(data["ID"]),
                            WhitePaperTitle = data["WhitePaperTitle"].ToString(),
                            ImageUrl = data["ImageUrl"].ToString(),
                            Description = data["Description"].ToString(),
                            URL = data["URL"].ToString(),
                            RouteURL = data["RouteURL"].ToString()
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
        public IHttpActionResult GetNewsEvent(string siteName)
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
                sqlCmd.CommandText = "NewPubsiteAPI_News_NewsDetails_GetNewsEvent";
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
                            EventType = data["EventType"].ToString()
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



        [HttpGet]
        public IHttpActionResult GetAllFutureNewsDetailsForTestAPI(string siteName)
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
                sqlCmd.CommandText = "PubsiteAPI_News_AllFeaturedNews";
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
                        newsModelData.Add(new FutureNewsModel
                        {
                            ID = Convert.ToInt32(data["ID"]),
                            Author = data["Author"].ToString(),
                            Date = data["Date"].ToString(),
                            Description = data["Description"].ToString(),
                            Title = data["Title"].ToString(),
                            ImageUrl = data["ImageUrl"].ToString(),
                            URL = data["URl"].ToString(),
                            RouteURL = data["RouteURL"].ToString(),
                            IsSponcered = Convert.ToInt32(data["IsSponcered"]),
                            EventDifferentType = data["EventDifferentType"].ToString(),
                            CompanyName = data["CompanyName"].ToString(),
                            Tag = data["Tag"].ToString()
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
    }
}
