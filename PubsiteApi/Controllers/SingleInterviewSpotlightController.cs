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
    public class SingleInterviewSpotlightController : ApiController
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
        public IHttpActionResult GetInterviewSpotlight(string SiteName)
        {
            Interview SingleInterviewListByID = null;
            string sitename = "";
            try
            {
                Connection();
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                if (SiteName == string.Empty)
                {
                    SiteName = sitename;

                    if (SiteName.Contains("."))
                        SiteName = SiteName.Split('.')[0].Trim();
                }
                sqlCmd.Parameters.AddWithValue("@SiteName", SiteName);
                //sqlCmd.Parameters.AddWithValue("@InterviwID", InterviwID);
                sqlCmd.CommandText = "PubsiteAPI_Single_Interview_GetSingleInterviewbyID";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                SingleInterviewListByID = new Interview();
                if (dt.Rows.Count > 0)
                {

                    SingleInterviewListByID.InterviewId = Convert.ToInt32(dt.Rows[0]["InterviewId"]);
                    SingleInterviewListByID.InterviewTitle = dt.Rows[0]["InterviewTitle"].ToString();
                    SingleInterviewListByID.InterviewDetails = dt.Rows[0]["InterviewDetails"].ToString();
                    SingleInterviewListByID.IntervieweePerson = dt.Rows[0]["IntervieweePerson"].ToString();
                    SingleInterviewListByID.InterviewerID = Convert.ToInt32(dt.Rows[0]["InterviewerID"]);
                    SingleInterviewListByID.InterviewImage = dt.Rows[0]["InterviewImage"].ToString();
                    SingleInterviewListByID.Interviewdate = Convert.ToDateTime(dt.Rows[0]["Interviewdate"]);
                    SingleInterviewListByID.CompanyID = Convert.ToInt32(dt.Rows[0]["CompanyID"]);
                    SingleInterviewListByID.InterviewType = dt.Rows[0]["InterviewType"].ToString();
                    SingleInterviewListByID.CreatedDate = Convert.ToDateTime(dt.Rows[0]["CreatedDate"]);
                    SingleInterviewListByID.IsActive = dt.Rows[0]["IsActive"].ToString();
                    SingleInterviewListByID.AudioVideoURL = dt.Rows[0]["AudioVideoURL"].ToString();
                    SingleInterviewListByID.KeyWords = dt.Rows[0]["KeyWords"].ToString();
                    SingleInterviewListByID.VideoType = dt.Rows[0]["VideoType"].ToString();
                    SingleInterviewListByID.ViewCount = dt.Rows[0]["ViewCount"].ToString();
                    SingleInterviewListByID.MainImage = dt.Rows[0]["MainImage"].ToString();
                    SingleInterviewListByID.Desc2 = dt.Rows[0]["Desc2"].ToString();
                    SingleInterviewListByID.Desc3 = dt.Rows[0]["Desc3"].ToString();
                    SingleInterviewListByID.Quote1 = dt.Rows[0]["Quote1"].ToString();
                    SingleInterviewListByID.Quote2 = dt.Rows[0]["Quote2"].ToString();
                    SingleInterviewListByID.Quote3 = dt.Rows[0]["Quote3"].ToString();
                    SingleInterviewListByID.Desc4 = dt.Rows[0]["Desc4"].ToString();
                    SingleInterviewListByID.AboutCompany = dt.Rows[0]["AboutCompany"].ToString();
                    SingleInterviewListByID.InterviewTakenBy = dt.Rows[0]["InterviewTakenBy"].ToString();
                    SingleInterviewListByID.CompanyDomain = dt.Rows[0]["CompanyDomain"].ToString();
                    SingleInterviewListByID.CompanyName = dt.Rows[0]["CompanyName"].ToString();
                    SingleInterviewListByID.UpdateDate = Convert.ToDateTime(dt.Rows[0]["UpdateDate"]);
                    SingleInterviewListByID.InterviewPDFImage = dt.Rows[0]["InterviewPDFImage"].ToString();
                    SingleInterviewListByID.CompanyLogo = dt.Rows[0]["CompanyLogo"].ToString();
                    SingleInterviewListByID.RouteURL = dt.Rows[0]["RouteURL"].ToString();
                    SingleInterviewListByID.MetaDescription = dt.Rows[0]["MetaDescription"].ToString();
                    SingleInterviewListByID.IsshowonDeck7 = dt.Rows[0]["IsshowonDeck7"].ToString();



                }
                if (SingleInterviewListByID == null)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Ok(SingleInterviewListByID);




        }

    }
}