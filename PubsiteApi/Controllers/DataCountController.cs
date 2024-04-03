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
    public class DataCountController : ApiController
    {
        private SqlConnection scon = null;

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


        [HttpGet]
        public IHttpActionResult GetPubSiteDataCount(string siteName)
        {
            IList<PubsiteDataCountModel> objpubsiteDataCountModels = null;
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
                SqlCommand sql = new SqlCommand();
                sql.CommandType = CommandType.StoredProcedure;
                if (SiteName == string.Empty)
                {
                    SiteName = siteName;

                    if (SiteName.Contains("."))
                        SiteName = SiteName.Split('.')[0].Trim();
                }
                sql.Parameters.AddWithValue("@SiteName", SiteName);
                sql.CommandText = "GetPubsiteDataCount";
                sql.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sql);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                objpubsiteDataCountModels = new List<PubsiteDataCountModel>(dt.Rows.Count);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow data in dt.Rows)
                    {
                        objpubsiteDataCountModels.Add(new PubsiteDataCountModel
                        {
                            UpcommingConferencesCount = data["UpcommingConference"].ToString(),
                            PastConferencesCount = data["PastConference"].ToString(),
                            TotalLivewebinarCount = data["TotalLiveWebinar"].ToString(),
                            UpcommingLivewebinarCount = data["UpcomingLiveWebinar"].ToString(),
                            OndemandwebinarCount = data["OnDemandWebinar"].ToString(),
                            WhitepaperCount = data["WhitePaper"].ToString(),
                            VideoCount = data["Video"].ToString(),
                            InfographicsCount = data["Infographic"].ToString(),
                            ArticleCount = data["BlogArticle"].ToString(),
                            FeaturedNewsCount = data["FeaturedNews"].ToString(),
                            TrendingNewsCount = data["TrendingNews"].ToString(),
                            CompanyCount = data["Company"].ToString(),

                        });
                    }

                }
                if (objpubsiteDataCountModels == null || objpubsiteDataCountModels.Count == 0)
                {
                    return NotFound();
                }

            }
            catch (Exception ex)
            {

            }

            return Ok(objpubsiteDataCountModels);
        }



        //[HttpGet]
        //IHttpActionResult GetPubsiteInterviewDataCount(string siteName)
        //{
        //    IList<PubsiteInterviewDataCountModel> objpubsiteDataCountModels = null;
        //    string SiteName = "";
        //    siteName = siteName.Replace("test.", "");
        //    try
        //    {
        //        //if (siteName == "pharmaceutical.report" || siteName == "smallbusiness.report")
        //        //{
        //        //    PharmaSmallConnection();
        //        //}
        //        //else
        //        //{
        //        Connection();
        //        //}
        //        SqlCommand sql = new SqlCommand();
        //        sql.CommandType = CommandType.StoredProcedure;
        //        if (SiteName == string.Empty)
        //        {
        //            SiteName = siteName;

        //            if (SiteName.Contains("."))
        //                SiteName = SiteName.Split('.')[0].Trim();
        //        }
        //        sql.Parameters.AddWithValue("@SiteName", SiteName);
        //        sql.CommandText = "GetPubsiteInterviewCount";
        //        sql.Connection = scon;

        //        SqlDataAdapter sda = new SqlDataAdapter(sql);
        //        DataSet ds = new DataSet();
        //        sda.Fill(ds);
        //        DataTable dt = new DataTable();
        //        dt = ds.Tables[0];
        //        objpubsiteDataCountModels = new List<PubsiteInterviewDataCountModel>(dt.Rows.Count);
        //        if (dt.Rows.Count > 0)
        //        {
        //            foreach (DataRow data in dt.Rows)
        //            {
        //                objpubsiteDataCountModels.Add(new PubsiteInterviewDataCountModel
        //                {
        //                    CSuiteOnDeck = data["C-SuiteOnDeck"].ToString(),
        //                    ThoughtLeaders = data["ThoughtLeaders"].ToString(),
        //                });
        //            }

        //        }
        //        if (objpubsiteDataCountModels == null || objpubsiteDataCountModels.Count == 0)
        //        {
        //            return NotFound();
        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //    }

        //    return Ok(objpubsiteDataCountModels);
        //}

        //[HttpGet]
        public IHttpActionResult GetPubsiteInterviewDataCount(string siteName)
        {
            IList<PubsiteInterviewDataCountModel> objpubsiteDataCountModels = null;
            string SiteName = "";
            siteName = siteName.Replace("test.", "");
            try
            {
                //if (siteName == "pharmaceutical.report" || siteName == "smallbusiness.report")
                //{
                //    PharmaSmallConnection();
                //}
                //else
                //{
                Connection();
                //}
                SqlCommand sql = new SqlCommand();
                sql.CommandType = CommandType.StoredProcedure;
                if (SiteName == string.Empty)
                {
                    SiteName = siteName;

                    if (SiteName.Contains("."))
                        SiteName = SiteName.Split('.')[0].Trim();
                }
                sql.Parameters.AddWithValue("@SiteName", SiteName);
                sql.CommandText = "GetPubsiteInterviewCount";
                sql.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sql);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                objpubsiteDataCountModels = new List<PubsiteInterviewDataCountModel>(dt.Rows.Count);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow data in dt.Rows)
                    {
                        objpubsiteDataCountModels.Add(new PubsiteInterviewDataCountModel
                        {
                            CSuiteOnDeck = data["CSuiteOnDeck"].ToString(),
                            ThoughtLeaders = data["ThoughtLeaders"].ToString(),
                        });
                    }

                }
                if (objpubsiteDataCountModels == null || objpubsiteDataCountModels.Count == 0)
                {
                    return NotFound();
                }

            }
            catch (Exception ex)
            {

            }

            return Ok(objpubsiteDataCountModels);
        }
    }
}
