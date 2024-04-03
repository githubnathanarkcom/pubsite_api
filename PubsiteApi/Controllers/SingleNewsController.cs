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
    public class SingleNewsController : ApiController
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
        public IHttpActionResult GetSingleNews(string siteName, string RouteURL)
        {
            FutureNewsModel objSingleNewsModel = null;
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
               

                sqlCmd.CommandText = "NewPubsiteAPI_Single_News_GetSingleNews";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                objSingleNewsModel = new FutureNewsModel();
                if (dt.Rows.Count > 0)
                {


                    objSingleNewsModel.ID = Convert.ToInt32(dt.Rows[0]["ID"]);
                    objSingleNewsModel.Author = Utils.HtmlDecode(dt.Rows[0]["Author"].ToString());
                    //objSingleNewsModel.Date = dt.Rows[0]["Date"].ToString();
                    objSingleNewsModel.PublishingDate = dt.Rows[0]["PublishingDate"].ToString();
                    objSingleNewsModel.Description = Utils.HtmlDecode(dt.Rows[0]["Description"].ToString());
                    objSingleNewsModel.Title = Utils.HtmlDecode(dt.Rows[0]["Title"].ToString());
                    objSingleNewsModel.ImageUrl = dt.Rows[0]["ImageUrl"].ToString();
                    objSingleNewsModel.URL = dt.Rows[0]["URl"].ToString();
                    //RouteURL = data["RouteURL"].ToString(),
                    objSingleNewsModel.IsSponcered = Convert.ToInt32(dt.Rows[0]["IsSponcered"]);
                    objSingleNewsModel.NewsTypeName = dt.Rows[0]["NewsTypeName"].ToString();
                    objSingleNewsModel.NewsType = Convert.ToInt32(dt.Rows[0]["NewsType"]);
                    objSingleNewsModel.EventDifferentType = dt.Rows[0]["EventDifferentType"].ToString();
                    objSingleNewsModel.SourceType = Convert.ToInt32(dt.Rows[0]["SourceType"]);
                    objSingleNewsModel.Tag = dt.Rows[0]["Tag"].ToString();
                    objSingleNewsModel.ISINDEX = Convert.ToInt32(dt.Rows[0]["ISINDEX"]);
                    objSingleNewsModel.IsFollow = Convert.ToInt32(dt.Rows[0]["IsFollow"]);
                    objSingleNewsModel.ManualCanonical = dt.Rows[0]["ManualCanonical"].ToString();
                    objSingleNewsModel.CompanyName = Utils.HtmlDecode(dt.Rows[0]["CompanyName"].ToString());
                    objSingleNewsModel.MetaTitle = Utils.HtmlDecode(dt.Rows[0]["MetaTitle"].ToString());
                    objSingleNewsModel.MetaDescription = Utils.HtmlDecode(dt.Rows[0]["MetaDescription"].ToString());
                    objSingleNewsModel.ImageAltTag = dt.Rows[0]["ImageAltTag"].ToString();
                    objSingleNewsModel.Keywords = Utils.HtmlDecode(dt.Rows[0]["Keywords"].ToString());
                    objSingleNewsModel.Read_time = dt.Rows[0]["Read_time"].ToString();

                }
                if (objSingleNewsModel == null )
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(objSingleNewsModel);
        }


        [HttpGet]
        public IHttpActionResult GetTop1SingleNewsSpotLight(string siteName, string domainName)
        {
            NewsSpotLightModel objSpotLight = null;
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
                // sqlCmd.Parameters.AddWithValue("@companyDomain", domainName.Trim());
                sqlCmd.Parameters.AddWithValue("@SiteName", SiteName);
                
                sqlCmd.CommandText = "PubsiteAPI_Single_News_GetTop1SingleNewsSpotLight";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                objSpotLight = new NewsSpotLightModel();
                if (dt.Rows.Count > 0)
                {


                    objSpotLight.ID = Convert.ToInt32(dt.Rows[0]["ID"]);
                    objSpotLight.WhitePaperTitle = dt.Rows[0]["WhitePaperTitle"].ToString();
                    objSpotLight.ImageUrl = dt.Rows[0]["ImageUrl"].ToString();
                    objSpotLight.Description = dt.Rows[0]["Description"].ToString();

                       

                }
                if (objSpotLight == null )
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
        public IHttpActionResult GetTop3SingleNewsResources(string siteName)
        {
            IList<NewsReourceModel> objResources = null;
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
                sqlCmd.CommandText = "PubsiteAPI_Single_News_GetTop3SingleNewsResources";
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
                          //  RouteURL = data["RouteURL"].ToString(),
                            Description = data["Description"].ToString(),
                            WhitePaperTitle = data["WhitePaperTitle"].ToString(),

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
        public IHttpActionResult GetTop4SingleOtherNews(string siteName, string RouteURL, string typeName)
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
                string type = typeName.Split('-')[0].Trim();
                sqlCmd.Parameters.AddWithValue("@SiteName", SiteName);
                 sqlCmd.Parameters.AddWithValue("@RouteURL", RouteURL);
                sqlCmd.Parameters.AddWithValue("@TypeName", type);
                sqlCmd.CommandText = "NewPubsiteAPI_Single_News_GetTop4SingleOtherNews";
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
                            NewsTypeName = data["NewsTypeName"].ToString(),
                            EventDifferentType = data["EventDifferentType"].ToString(),
                            Tag = data["Tag"].ToString(),
                            CompanyName = data["CompanyName"].ToString()

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

        public IHttpActionResult GetTop3SingleRelatedNewsCategoryTag(string siteName, string CategoryTag)
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
                sqlCmd.Parameters.AddWithValue("@CategoryTag", CategoryTag);

                sqlCmd.CommandText = "NewPubsiteAPI_Single_Article_GetTop3_RelatedNews__CategoryTag";
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
                            NewsTypeName = data["NewsTypeName"].ToString(),
                            EventDifferentType = data["EventDifferentType"].ToString(),
                            Tag = data["Tag"].ToString(),
                            CompanyName = data["CompanyName"].ToString()

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

        public IHttpActionResult GetTop3SingleRelatedNewsCompanyCategoryTag(string siteName,string CompanyName, string CategoryTag)
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
                sqlCmd.Parameters.AddWithValue("@CompanyName", CompanyName);
                sqlCmd.Parameters.AddWithValue("@Tag", CategoryTag);

                sqlCmd.CommandText = "NewPubsiteAPI_Single_Article_GetTop3_RelatedNews_Company_CategoryTag";
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
                            NewsTypeName = data["NewsTypeName"].ToString(),
                            EventDifferentType = data["EventDifferentType"].ToString(),
                            Tag = data["Tag"].ToString(),
                            CompanyName = data["CompanyName"].ToString()

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

        public IHttpActionResult GetTop3SingleRelatedNews_CategoryTag_Keywords(string siteName, string CategoryTag, string Keywords)
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
                sqlCmd.Parameters.AddWithValue("@CategoryTag", CategoryTag);
                sqlCmd.Parameters.AddWithValue("@Keywords", Keywords);

                sqlCmd.CommandText = "NewPubsiteAPI_Single_Article_GetTop3_RelatedNews__CategoryTag_keywords";
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
                            NewsTypeName = data["NewsTypeName"].ToString(),
                            EventDifferentType = data["EventDifferentType"].ToString(),
                            Tag = data["Tag"].ToString(),
                            CompanyName = data["CompanyName"].ToString()

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


        public IHttpActionResult GetTop3SingleRelatedNewsKeywords(string siteName, string keywords)
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
                sqlCmd.Parameters.AddWithValue("@keywords", keywords);

                sqlCmd.CommandText = "NewPubsiteAPI_Single_Article_GetTop3_RelatedNews_keywords";
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
                            NewsTypeName = data["NewsTypeName"].ToString(),
                            EventDifferentType = data["EventDifferentType"].ToString(),
                            Tag = data["Tag"].ToString(),
                            CompanyName = data["CompanyName"].ToString()

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
