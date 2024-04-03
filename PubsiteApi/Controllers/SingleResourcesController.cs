using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using PubsiteApi.Models;

namespace PubsiteApi.Controllers
{
    public class SingleResourcesController : ApiController
    {
        private SqlConnection scon = null;
        private SqlConnection scon1 = null;
        private void Connection()
        {
            try
            {
                scon = new SqlConnection("Data Source=3.108.12.178;User ID=theiotrep1;Initial Catalog=theiotrep; Password=8g)mB9w3");
            }
            catch(Exception ex)
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

        private void ConnectionMedia7()
        {
            try
            {
                scon1 = new SqlConnection("Data Source=3.108.12.178;User ID=NAMEDIA7io1;Initial Catalog=NAMEDIA7io; Password=L/[BBe9D");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpGet]
        public IHttpActionResult GetSingleResources(string siteName, string RouteURL)
        {
           SingleResourcesModel objTop1SingleResourcesModel = null;

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

                sqlCmd.CommandText = "NewPubsiteAPI_Single_Resources_GetSingleResources";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                objTop1SingleResourcesModel = new SingleResourcesModel();
                if (dt.Rows.Count > 0)
                {

                    objTop1SingleResourcesModel.ID = Convert.ToInt32(dt.Rows[0]["ID"]);
                            objTop1SingleResourcesModel.WhitePaperTitle = dt.Rows[0]["WhitePaperTitle"].ToString();
                            objTop1SingleResourcesModel.Description = dt.Rows[0]["Description"].ToString();
                            objTop1SingleResourcesModel.description2 = dt.Rows[0]["description2"].ToString();
                            objTop1SingleResourcesModel.description3 = dt.Rows[0]["description3"].ToString();
                            objTop1SingleResourcesModel.description4 = dt.Rows[0]["description4"].ToString();
                            objTop1SingleResourcesModel.author = dt.Rows[0]["author"].ToString();
                            objTop1SingleResourcesModel.authorName = dt.Rows[0]["author"].ToString().Replace(" ","-").Trim();
                            objTop1SingleResourcesModel.author_description = dt.Rows[0]["author_description"].ToString();
                            objTop1SingleResourcesModel.author_ImageURL = dt.Rows[0]["author_ImageURL"].ToString();
                            objTop1SingleResourcesModel.webpageurl = dt.Rows[0]["webpageurl"].ToString();
                            objTop1SingleResourcesModel.pdfurl = dt.Rows[0]["pdfurl"].ToString();
                            objTop1SingleResourcesModel.imageurl = dt.Rows[0]["imageurl"].ToString();
                            objTop1SingleResourcesModel.imageurl2 = dt.Rows[0]["imageurl2"].ToString();
                            objTop1SingleResourcesModel.imageurl3 = dt.Rows[0]["imageurl3"].ToString();
                            objTop1SingleResourcesModel.imageurl4 = dt.Rows[0]["imageurl4"].ToString();
                            objTop1SingleResourcesModel.ResourceType = dt.Rows[0]["ResourceType"].ToString();
                            objTop1SingleResourcesModel.EmbadedVideoUrl = dt.Rows[0]["EmbadedVideoUrl"] == DBNull.Value ? "" : dt.Rows[0]["EmbadedVideoUrl"].ToString();
                            objTop1SingleResourcesModel.VideoType = dt.Rows[0]["VideoType"] == DBNull.Value ? "" : dt.Rows[0]["VideoType"].ToString();
                            objTop1SingleResourcesModel.EmbedVideoCode = dt.Rows[0]["EmbedVideoCode"] == DBNull.Value ? "" : dt.Rows[0]["EmbedVideoCode"].ToString();
                            objTop1SingleResourcesModel.AuthorReal = dt.Rows[0]["AuthorReal"].ToString();
                            objTop1SingleResourcesModel.keywords = dt.Rows[0]["keywords"].ToString();
                            objTop1SingleResourcesModel.PublishingDate = Convert.ToDateTime(dt.Rows[0]["PublishingDate"]);
                            objTop1SingleResourcesModel.PublishingDate1 = dt.Rows[0]["PublishingDate1"].ToString();
                            objTop1SingleResourcesModel.IsSponcered = Convert.ToBoolean(dt.Rows[0]["IsSponcered"]);
                            objTop1SingleResourcesModel.DisplayPreviewImage = dt.Rows[0]["DisplayPreviewImage"].ToString();
                            objTop1SingleResourcesModel.tag = dt.Rows[0]["tag"].ToString();
                            objTop1SingleResourcesModel.UserName = dt.Rows[0]["UserName"].ToString();
                            objTop1SingleResourcesModel.SourcceType = dt.Rows[0]["SourcceType"] == DBNull.Value? 0: Convert.ToInt32(dt.Rows[0]["SourcceType"]);
                            objTop1SingleResourcesModel.RouteURL = dt.Rows[0]["RouteURL"].ToString();
                            objTop1SingleResourcesModel.ISINDEX = Convert.ToInt32(dt.Rows[0]["ISINDEX"]);
                            objTop1SingleResourcesModel.IsFollow = Convert.ToInt32(dt.Rows[0]["IsFollow"]);
                            objTop1SingleResourcesModel.ManualCanonical = dt.Rows[0]["ManualCanonical"].ToString();
                            objTop1SingleResourcesModel.MetaTitle = Utils.HtmlDecode(dt.Rows[0]["MetaTitle"].ToString());
                            objTop1SingleResourcesModel.MetaDescription = Utils.HtmlDecode(dt.Rows[0]["MetaDescription"].ToString());
                            objTop1SingleResourcesModel.ImageAltTag = dt.Rows[0]["ImageAltTag"].ToString();
                            objTop1SingleResourcesModel.Hit_Counter = Convert.ToInt32(dt.Rows[0]["Hit_Counter"]);
                            objTop1SingleResourcesModel.Read_time = dt.Rows[0]["Read_time"].ToString();
                            objTop1SingleResourcesModel.TagURL = dt.Rows[0]["TagURL"].ToString();

                }
                if (objTop1SingleResourcesModel == null )
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            List<int> strList = new List<int>();
            int userId = 0;
            try
            {
                ConnectionMedia7();
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                if (SiteName == string.Empty)
                {
                    SiteName = siteName;

                    if (SiteName.Contains("."))
                        SiteName = SiteName.Split('.')[0].Trim();
                }

                sqlCmd.Parameters.AddWithValue("@Email", objTop1SingleResourcesModel.UserName.Trim());
              
                sqlCmd.CommandText = "PubsiteAPI_Single_Resources_GetSingleResourcesIdByEmail";
                sqlCmd.Connection = scon1;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                strList = new List<int>(dt.Rows.Count);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow data in dt.Rows)
                    {
                        strList.Add(
                           
                                userId = Convert.ToInt32(data["userdetails_id"])

                            );
                        
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


            objTop1SingleResourcesModel.UserId = userId;

            return Ok(objTop1SingleResourcesModel);
        }

        [HttpGet]
        public IHttpActionResult GetTop1SingleResourceSpotlight(string siteName)
        {
            SpotLightModel objGetSingleResourceSpotlightModel = null;
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
                        SiteName = SiteName.Split('.')[0].Trim();
                }
                sqlCmd.Parameters.AddWithValue("@SiteName", SiteName);
                sqlCmd.CommandText = "PubsiteAPI_Single_Resources_GetTop1SingleResourceSpotlight";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                objGetSingleResourceSpotlightModel = new SpotLightModel();
                if (dt.Rows.Count > 0)
                {

                    objGetSingleResourceSpotlightModel.EventID = Convert.ToInt32(dt.Rows[0]["EventID"]);
                    objGetSingleResourceSpotlightModel.Name = dt.Rows[0]["Name"].ToString();
                    objGetSingleResourceSpotlightModel.ImageUrl = dt.Rows[0]["ImageUrl"].ToString();
                    objGetSingleResourceSpotlightModel.IsSponcered = Convert.ToInt32(dt.Rows[0]["IsSponcered"]);
                    // RouteURL = data["RouteURL"].ToString(),
                    objGetSingleResourceSpotlightModel.Description = dt.Rows[0]["Description"].ToString();
                       

                }
                if (objGetSingleResourceSpotlightModel == null )
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(objGetSingleResourceSpotlightModel);

        }

        [HttpGet]
        public IHttpActionResult GetTop3SingleResourcesEvents(string siteName)
        {
            IList<NewsEventModel> objTop3SingleResourcesEventsModel = null;
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
                        SiteName = SiteName.Split('.')[0].Trim();
                }
                sqlCmd.Parameters.AddWithValue("@SiteName", SiteName);
                sqlCmd.CommandText = "PubsiteAPI_Single_Resources_GetTop3SingleResourcesEvents";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                objTop3SingleResourcesEventsModel = new List<NewsEventModel>(dt.Rows.Count);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow data in dt.Rows)
                    {
                        objTop3SingleResourcesEventsModel.Add(new NewsEventModel
                        {
                            EventID = Convert.ToInt32(data["EventID"]),
                            Name = data["Name"].ToString(),
                            ImageUrl = data["ImageUrl"].ToString(),
                            IsSponcered = Convert.ToInt32(data["IsSponcered"]),
                            //RouteURL = data["RouteURL"].ToString(),
                            Description = data["Description"].ToString()
                        });
                    }

                }
                if (objTop3SingleResourcesEventsModel == null || objTop3SingleResourcesEventsModel.Count == 0)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(objTop3SingleResourcesEventsModel);

        }

        [HttpGet]
        public IHttpActionResult GetTop4SingleResourceOtherArticles(string siteName)
        {
            IList<GlobalResourcesModel> objTop4SingleResourceOtherArticlesModel = null;
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
                sqlCmd.CommandText = "NewPubsiteAPI_Single_Resources_GetTop4SingleResourceOtherArticles";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                objTop4SingleResourceOtherArticlesModel = new List<GlobalResourcesModel>(dt.Rows.Count);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow data in dt.Rows)
                    {
                        objTop4SingleResourceOtherArticlesModel.Add(new GlobalResourcesModel
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
                            Tag= data["Tag"].ToString()
                        });
                    }

                }
                if (objTop4SingleResourceOtherArticlesModel == null || objTop4SingleResourceOtherArticlesModel.Count == 0)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(objTop4SingleResourceOtherArticlesModel);

        }



        [HttpGet]
        public IHttpActionResult GetTop4SingleArticlesOtherArticles(string siteName,string Routeurl)
        {
            IList<GlobalResourcesModel> objTop4SingleResourceOtherArticlesModel = null;
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
                sqlCmd.Parameters.AddWithValue("@Routeurl", Routeurl);
                sqlCmd.CommandText = "NewPubsiteAPI_Single_Resources_GetTop4SingleArticlesOtherArticles";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                objTop4SingleResourceOtherArticlesModel = new List<GlobalResourcesModel>(dt.Rows.Count);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow data in dt.Rows)
                    {
                        objTop4SingleResourceOtherArticlesModel.Add(new GlobalResourcesModel
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
                            Tag= data["Tag"].ToString()
                        });
                    }

                }
                if (objTop4SingleResourceOtherArticlesModel == null || objTop4SingleResourceOtherArticlesModel.Count == 0)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(objTop4SingleResourceOtherArticlesModel);

        }

        [HttpGet]
        public IHttpActionResult GetTop3SingleArticlesOtherArticles(string siteName,string Routeurl)
        {
            IList<GlobalResourcesModel> objTop3SingleResourceOtherArticlesModel = null;
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
                sqlCmd.Parameters.AddWithValue("@Routeurl", Routeurl);

                sqlCmd.CommandText = "NewPubsiteAPI_Single_Resources_GetTop3SingleArticlesOtherArticles";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                objTop3SingleResourceOtherArticlesModel = new List<GlobalResourcesModel>(dt.Rows.Count);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow data in dt.Rows)
                    {
                        objTop3SingleResourceOtherArticlesModel.Add(new GlobalResourcesModel
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
                            Tag= data["Tag"].ToString()
                        });
                    }

                }
                if (objTop3SingleResourceOtherArticlesModel == null || objTop3SingleResourceOtherArticlesModel.Count == 0)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(objTop3SingleResourceOtherArticlesModel);

        }


        [HttpGet]
        public IHttpActionResult GetTop3SingleArticlesOtherArticles_CategoryTag(string siteName,string Routeurl,string CategoryTag)
        {
            IList<GlobalResourcesModel> objTop3SingleResourceOtherArticlesModel = null;
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
                sqlCmd.Parameters.AddWithValue("@Routeurl", Routeurl);
                sqlCmd.Parameters.AddWithValue("@CategoryTag", CategoryTag);
                sqlCmd.CommandText = "NewPubsiteAPI_Single_Resources_GetTop3SingleArticlesOtherArticles_CategoryTag";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                objTop3SingleResourceOtherArticlesModel = new List<GlobalResourcesModel>(dt.Rows.Count);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow data in dt.Rows)
                    {
                        objTop3SingleResourceOtherArticlesModel.Add(new GlobalResourcesModel
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
                            Tag= data["Tag"].ToString()
                        });
                    }

                }
                if (objTop3SingleResourceOtherArticlesModel == null || objTop3SingleResourceOtherArticlesModel.Count == 0)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(objTop3SingleResourceOtherArticlesModel);

        }


        [HttpGet]
        public IHttpActionResult GetTop1LandingPage(string siteName)
        {
            IList<GlobalResourcesModel> objTop4SingleResourceOtherArticlesModel = null;
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

                sqlCmd.CommandText = "NewPubsiteAPI_Single_Resources_GetTop1LandingPage";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                objTop4SingleResourceOtherArticlesModel = new List<GlobalResourcesModel>(dt.Rows.Count);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow data in dt.Rows)
                    {
                        objTop4SingleResourceOtherArticlesModel.Add(new GlobalResourcesModel
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

                        });
                    }

                }
                if (objTop4SingleResourceOtherArticlesModel == null || objTop4SingleResourceOtherArticlesModel.Count == 0)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(objTop4SingleResourceOtherArticlesModel);

        }




        [HttpGet]
        public IHttpActionResult GetTop6SingleResourceOtherWhitePapers(string siteName)
        {
            IList<GlobalResourcesModel> objGlobalResourcesArticleModel = null;
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
                        SiteName = SiteName.Split('.')[0].Trim();
                }
                sqlCmd.Parameters.AddWithValue("@SiteName", SiteName);
      

                sqlCmd.CommandText = "PubsiteAPI_Single_Resources_GetTop6SingleResourceOtherWhitePapers";
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
                            //TotalDataCount = Convert.ToInt32(data["TotalDataCount"])
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
        public IHttpActionResult GetTop4SingleResourceOtherVideos(string siteName)
        {
            IList<GlobalResourcesModel> objSingleResourceOtherVideosModel = null;
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
                        SiteName = SiteName.Split('.')[0].Trim();
                }
                sqlCmd.Parameters.AddWithValue("@SiteName", SiteName);
               
                sqlCmd.CommandText = "PubsiteAPI_Single_Resource_GetTop4SingleResourceOtherVideos";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                objSingleResourceOtherVideosModel = new List<GlobalResourcesModel>(dt.Rows.Count);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow data in dt.Rows)
                    {
                        objSingleResourceOtherVideosModel.Add(new GlobalResourcesModel
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
                            //TotalDataCount = Convert.ToInt32(data["TotalDataCount"])
                        });
                    }

                }
                if (objSingleResourceOtherVideosModel == null || objSingleResourceOtherVideosModel.Count == 0)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(objSingleResourceOtherVideosModel);
        }

        [HttpGet]
        public IHttpActionResult GetTop6SingleResourceInfographics(string siteName, string RouteURL)
        {
            IList<GlobalResourcesModel> objGlobalResourcesArticleModel = null;
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
                        SiteName = SiteName.Split('.')[0].Trim();
                }
                sqlCmd.Parameters.AddWithValue("@SiteName", SiteName);
                sqlCmd.Parameters.AddWithValue("@RouteURL", RouteURL);
                sqlCmd.CommandText = "NewPubsiteAPI_Single_Resources_GetTop6SingleResourceInfographics";
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
                            //TotalDataCount = Convert.ToInt32(data["TotalDataCount"])
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


        [HttpPost]
        public string SaveAssetDownload(AssetDownload objAssetDownload)
        {
            string Check = "error";
            string SiteName = string.Empty;
            try
            {
                Connection();
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                if (SiteName == string.Empty)
                {
                    if (objAssetDownload.siteName.Contains("."))
                    {
                        SiteName = objAssetDownload.siteName.Split('.')[0].Trim();
                    }

                    sqlCmd.Parameters.AddWithValue("@SiteName", SiteName);
                    sqlCmd.Parameters.AddWithValue("@ResourceType", objAssetDownload.email);
                    sqlCmd.Parameters.AddWithValue("@ResourceID", objAssetDownload.resourceID);
                    sqlCmd.Parameters.AddWithValue("@Email", objAssetDownload.email);
                    sqlCmd.Parameters.AddWithValue("@IPAddress", objAssetDownload.iPAddress);
                    sqlCmd.Parameters.AddWithValue("@AcceptTermsOnDownload", objAssetDownload.acceptTerms);

                    sqlCmd.CommandText = "PubsiteAPI_Downloads_Insert";
                    sqlCmd.Connection = scon;
                    scon.Open();
                    int result = (int)sqlCmd.ExecuteScalar();//sqlCmd.ExecuteNonQuery();
                    scon.Close();
                    Check = "Created";
                }
            }
            catch (Exception ex)
            {
                Check = ex.Message.ToString();
            }
            return Check;
        }

    }

}
