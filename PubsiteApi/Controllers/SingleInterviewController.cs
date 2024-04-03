using PubsiteApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Http;
using static PubsiteApi.Models.SingleInterviewModel;

namespace PubsiteApi.Controllers
{
    public class SingleInterviewController : ApiController
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

        //Get Single Interview By ID
        [HttpGet]
        public IHttpActionResult GetSingleInterviewCSuitONDeckByID(string sitename, string RouteURL)
        {
            Interview SingleInterviewListByID = null;
            string SiteName = "";
            try
            {
                //if (sitename == "pharmaceutical.report" || sitename == "smallbusiness.report")
                //{
                //    PharmaSmallConnection();
                //}
                //else
                //{
                    Connection();
               // }
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                if (SiteName == string.Empty)
                {
                    SiteName = sitename;

                    if (SiteName.Contains("."))
                        SiteName = sitename.ToLower();
                    SiteName = SiteName.Replace(".", "_");
                }
                sqlCmd.Parameters.AddWithValue("@SiteName", SiteName);
                sqlCmd.Parameters.AddWithValue("@RouteURL", RouteURL);
                sqlCmd.CommandText = "NewPubsiteAPI_Single_Interview_CSuiteOnDeckByRouteURL";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();

                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                SingleInterviewListByID = new Interview();
                if (dt.Rows.Count > 0)
                {

                    SingleInterviewListByID.InterviewId = Convert.ToInt32(dt.Rows[0]["InterviewID"]);
                    SingleInterviewListByID.InterviewTitle = dt.Rows[0]["InterviewTitle"].ToString();
                    SingleInterviewListByID.Designation = dt.Rows[0]["Designation"].ToString();
                    SingleInterviewListByID.InterviewDetails = dt.Rows[0]["InterviewDetails"].ToString();
                    SingleInterviewListByID.IntervieweePerson = dt.Rows[0]["IntervieweePerson"].ToString();
                    SingleInterviewListByID.InterviewImage = dt.Rows[0]["InterviewImage"].ToString();
                    SingleInterviewListByID.MobileImage = dt.Rows[0]["MobileImage"].ToString();
                    SingleInterviewListByID.InterviewDate = dt.Rows[0]["InterviewDate"].ToString();
                    SingleInterviewListByID.CompanyID = Convert.ToInt32(dt.Rows[0]["CompanyID"]);
                    SingleInterviewListByID.InterviewType = dt.Rows[0]["InterviewType"].ToString();
                    SingleInterviewListByID.MainImage = dt.Rows[0]["InterviewImage"].ToString();
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
                    SingleInterviewListByID.InterviewPDFImage = dt.Rows[0]["InterviewPDFImage"].ToString();
                    SingleInterviewListByID.CompanyLogo = dt.Rows[0]["CompanyLogo"].ToString();
                    SingleInterviewListByID.RouteURL = dt.Rows[0]["RouteURL"].ToString();
                    SingleInterviewListByID.ISINDEX = Convert.ToInt32(dt.Rows[0]["ISINDEX"]);
                    SingleInterviewListByID.IsFollow = Convert.ToInt32(dt.Rows[0]["IsFollow"]);
                    SingleInterviewListByID.ManualCanonical = dt.Rows[0]["ManualCanonical"].ToString();
                    SingleInterviewListByID.MetaTitle = Utils.HtmlDecode(dt.Rows[0]["MetaTitle"].ToString());
                    SingleInterviewListByID.MetaDescription = Utils.HtmlDecode(dt.Rows[0]["MetaDescription"].ToString());
                    SingleInterviewListByID.KeyWords = dt.Rows[0]["Keywords"].ToString();
                    SingleInterviewListByID.ImageAltTag = dt.Rows[0]["ImageAltTag"].ToString();
                    SingleInterviewListByID.CategoryTag = dt.Rows[0]["CategoryTag"].ToString();
                    SingleInterviewListByID.KeyWords = Utils.HtmlDecode(dt.Rows[0]["KeyWords"].ToString());
                    SingleInterviewListByID.Read_time = dt.Rows[0]["Read_time"].ToString();

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

        public IHttpActionResult GetSingleInterviewPreviewCSuitONDeckByID(string sitename, string RouteURL)
        {
            Interview SingleInterviewListByID = null;
            string SiteName = "";
            try
            {
                //if (sitename == "pharmaceutical.report" || sitename == "smallbusiness.report")
                //{
                //    PharmaSmallConnection();
                //}
                //else
                //{
                    Connection();
               // }
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                if (SiteName == string.Empty)
                {
                    SiteName = sitename;

                    if (SiteName.Contains("."))
                        SiteName = sitename.ToLower();
                    SiteName = SiteName.Replace(".", "_");
                }
                sqlCmd.Parameters.AddWithValue("@SiteName", SiteName);
                sqlCmd.Parameters.AddWithValue("@RouteURL", RouteURL);
                sqlCmd.CommandText = "NewPubsiteAPI_Single_Interview_Preview_CSuiteOnDeckByRouteURL";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();

                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                SingleInterviewListByID = new Interview();
                if (dt.Rows.Count > 0)
                {

                    SingleInterviewListByID.InterviewId = Convert.ToInt32(dt.Rows[0]["InterviewID"]);
                    SingleInterviewListByID.InterviewTitle = dt.Rows[0]["InterviewTitle"].ToString();
                    SingleInterviewListByID.Designation = dt.Rows[0]["Designation"].ToString();
                    SingleInterviewListByID.InterviewDetails = dt.Rows[0]["InterviewDetails"].ToString();
                    SingleInterviewListByID.IntervieweePerson = dt.Rows[0]["IntervieweePerson"].ToString();
                    SingleInterviewListByID.InterviewImage = dt.Rows[0]["InterviewImage"].ToString();
                    SingleInterviewListByID.MobileImage = dt.Rows[0]["MobileImage"].ToString();
                    SingleInterviewListByID.InterviewDate = dt.Rows[0]["InterviewDate"].ToString();
                    SingleInterviewListByID.CompanyID = Convert.ToInt32(dt.Rows[0]["CompanyID"]);
                    SingleInterviewListByID.InterviewType = dt.Rows[0]["InterviewType"].ToString();
                    SingleInterviewListByID.MainImage = dt.Rows[0]["InterviewImage"].ToString();
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
                    SingleInterviewListByID.InterviewPDFImage = dt.Rows[0]["InterviewPDFImage"].ToString();
                    SingleInterviewListByID.CompanyLogo = dt.Rows[0]["CompanyLogo"].ToString();
                    SingleInterviewListByID.RouteURL = dt.Rows[0]["RouteURL"].ToString();
                    SingleInterviewListByID.ISINDEX = Convert.ToInt32(dt.Rows[0]["ISINDEX"]);
                    SingleInterviewListByID.IsFollow = Convert.ToInt32(dt.Rows[0]["IsFollow"]);
                    SingleInterviewListByID.ManualCanonical = dt.Rows[0]["ManualCanonical"].ToString();
                    SingleInterviewListByID.MetaTitle = Utils.HtmlDecode(dt.Rows[0]["MetaTitle"].ToString());
                    SingleInterviewListByID.MetaDescription = Utils.HtmlDecode(dt.Rows[0]["MetaDescription"].ToString());
                    SingleInterviewListByID.ImageAltTag = dt.Rows[0]["ImageAltTag"].ToString();
                    SingleInterviewListByID.CategoryTag = dt.Rows[0]["CategoryTag"].ToString();
                    SingleInterviewListByID.KeyWords = Utils.HtmlDecode(dt.Rows[0]["KeyWords"].ToString());
                    SingleInterviewListByID.Read_time = dt.Rows[0]["Read_time"].ToString();

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

        [HttpGet]
        public IHttpActionResult GetSingleInterviewThoughtLeaderByID(string siteName, string RouteURL)
        {
            Interview SingleInterviewListByID = null;
            string SiteName = "";
            try
            {

                //if (siteName == "pharmaceutical.report" || siteName == "smallbusiness.report")
                //{
                //    PharmaSmallConnection();
                //}
                //else
                //{
                    Connection();
              //  }
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                if (SiteName == string.Empty)
                {
                    SiteName = siteName.Trim();

                    if (SiteName.Contains("."))
                        SiteName = siteName.ToLower();
                    SiteName = SiteName.Replace(".", "_");
                }
                sqlCmd.Parameters.AddWithValue("@SiteName", SiteName);
                sqlCmd.Parameters.AddWithValue("@RouteURL", RouteURL);
                sqlCmd.CommandText = "NewPubsiteAPI_Single_Interview_ThoughtLeaders";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();

                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                SingleInterviewListByID = new Interview();
                if (dt.Rows.Count > 0)
                {

                    SingleInterviewListByID.InterviewId = Convert.ToInt32(dt.Rows[0]["InterviewID"]);
                    SingleInterviewListByID.InterviewTitle = dt.Rows[0]["InterviewTitle"].ToString();
                    SingleInterviewListByID.Designation = dt.Rows[0]["Designation"].ToString();
                    SingleInterviewListByID.InterviewDetails = dt.Rows[0]["InterviewDetails"].ToString();
                    SingleInterviewListByID.IntervieweePerson = dt.Rows[0]["IntervieweePerson"].ToString();
                    SingleInterviewListByID.InterviewImage = dt.Rows[0]["InterviewImage"].ToString();
                    SingleInterviewListByID.MobileImage = dt.Rows[0]["MobileImage"].ToString();
                    SingleInterviewListByID.InterviewDate = dt.Rows[0]["InterviewDate"].ToString();
                    SingleInterviewListByID.CompanyID = Convert.ToInt32(dt.Rows[0]["CompanyID"]);
                    SingleInterviewListByID.InterviewType = dt.Rows[0]["InterviewType"].ToString();
                    SingleInterviewListByID.MainImage = dt.Rows[0]["InterviewImage"].ToString();
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
                    SingleInterviewListByID.InterviewPDFImage = dt.Rows[0]["InterviewPDFImage"].ToString();
                    SingleInterviewListByID.CompanyLogo = dt.Rows[0]["CompanyLogo"].ToString();
                    SingleInterviewListByID.ISINDEX = Convert.ToInt32(dt.Rows[0]["ISINDEX"]);
                    SingleInterviewListByID.IsFollow = Convert.ToInt32(dt.Rows[0]["IsFollow"]);
                    SingleInterviewListByID.ManualCanonical = dt.Rows[0]["ManualCanonical"].ToString();
                    SingleInterviewListByID.MetaTitle = Utils.HtmlDecode(dt.Rows[0]["MetaTitle"].ToString());
                    SingleInterviewListByID.MetaDescription = Utils.HtmlDecode(dt.Rows[0]["MetaDescription"].ToString());
                    SingleInterviewListByID.KeyWords = Utils.HtmlDecode(dt.Rows[0]["KeyWords"].ToString());
                    SingleInterviewListByID.ImageAltTag = dt.Rows[0]["ImageAltTag"].ToString();
                    SingleInterviewListByID.CategoryTag = dt.Rows[0]["CategoryTag"].ToString();
                    SingleInterviewListByID.KeyWords = dt.Rows[0]["KeyWords"].ToString();
                    SingleInterviewListByID.Read_time = dt.Rows[0]["Read_time"].ToString();
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

        [HttpGet]
        public IHttpActionResult GetSingleInterviewThoughtLeaderPreviewByID(string siteName, string RouteURL)
        {
            Interview SingleInterviewListByID = null;
            string SiteName = "";
            try
            {

                //if (siteName == "pharmaceutical.report" || siteName == "smallbusiness.report")
                //{
                //    PharmaSmallConnection();
                //}
                //else
                //{
                    Connection();
              //  }
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                if (SiteName == string.Empty)
                {
                    SiteName = siteName.Trim();

                    if (SiteName.Contains("."))
                        SiteName = siteName.ToLower();
                    SiteName = SiteName.Replace(".", "_");
                }
                sqlCmd.Parameters.AddWithValue("@SiteName", SiteName);
                sqlCmd.Parameters.AddWithValue("@RouteURL", RouteURL);
                sqlCmd.CommandText = "NewPubsiteAPI_Single_Interview_ThoughtLeaders_preview";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();

                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                SingleInterviewListByID = new Interview();
                if (dt.Rows.Count > 0)
                {

                    SingleInterviewListByID.InterviewId = Convert.ToInt32(dt.Rows[0]["InterviewID"]);
                    SingleInterviewListByID.InterviewTitle = dt.Rows[0]["InterviewTitle"].ToString();
                    SingleInterviewListByID.Designation = dt.Rows[0]["Designation"].ToString();
                    SingleInterviewListByID.InterviewDetails = dt.Rows[0]["InterviewDetails"].ToString();
                    SingleInterviewListByID.IntervieweePerson = dt.Rows[0]["IntervieweePerson"].ToString();
                    SingleInterviewListByID.InterviewImage = dt.Rows[0]["InterviewImage"].ToString();
                    SingleInterviewListByID.MobileImage = dt.Rows[0]["MobileImage"].ToString();
                    SingleInterviewListByID.InterviewDate = dt.Rows[0]["InterviewDate"].ToString();
                    SingleInterviewListByID.CompanyID = Convert.ToInt32(dt.Rows[0]["CompanyID"]);
                    SingleInterviewListByID.InterviewType = dt.Rows[0]["InterviewType"].ToString();
                    SingleInterviewListByID.MainImage = dt.Rows[0]["InterviewImage"].ToString();
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
                    SingleInterviewListByID.InterviewPDFImage = dt.Rows[0]["InterviewPDFImage"].ToString();
                    SingleInterviewListByID.CompanyLogo = dt.Rows[0]["CompanyLogo"].ToString();
                    SingleInterviewListByID.ISINDEX = Convert.ToInt32(dt.Rows[0]["ISINDEX"]);
                    SingleInterviewListByID.IsFollow = Convert.ToInt32(dt.Rows[0]["IsFollow"]);
                    SingleInterviewListByID.ManualCanonical = dt.Rows[0]["ManualCanonical"].ToString();
                    SingleInterviewListByID.MetaTitle = Utils.HtmlDecode(dt.Rows[0]["MetaTitle"].ToString());
                    SingleInterviewListByID.MetaDescription = Utils.HtmlDecode(dt.Rows[0]["MetaDescription"].ToString());
                    SingleInterviewListByID.ImageAltTag = dt.Rows[0]["ImageAltTag"].ToString();
                    SingleInterviewListByID.CategoryTag = dt.Rows[0]["CategoryTag"].ToString();
                    SingleInterviewListByID.KeyWords = Utils.HtmlDecode(dt.Rows[0]["KeyWords"].ToString());
                    SingleInterviewListByID.Read_time = dt.Rows[0]["Read_time"].ToString();
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

        [HttpGet]
        public IHttpActionResult GetSingleInterviewSpotlight(string SiteName, string DomainName)
        {

            Spotlite SpotlightList = null;
            string sitename = "";
            try
            {
                if (SiteName == "pharmaceutical.report" || SiteName == "smallbusiness.report")
                {
                    PharmaSmallConnection();
                }
                else
                {
                    Connection();
                }
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                if (sitename == string.Empty)
                {
                    sitename = SiteName;

                    if (sitename.Contains("."))
                        sitename = sitename.Split('.')[0].Trim();
                }
                sqlCmd.Parameters.AddWithValue("@SiteName", sitename.Trim());
                sqlCmd.Parameters.AddWithValue("@companyDomain", DomainName.Trim());
                sqlCmd.CommandText = "NewPubsiteAPI_Single_Interview_GetTop1Spotlight";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                SpotlightList = new Spotlite();
                if (dt.Rows.Count > 0)
                {

                    SpotlightList.id = Convert.ToInt32(dt.Rows[0]["id"]);
                    SpotlightList.company_name = dt.Rows[0]["NAME"].ToString();
                    SpotlightList.description = dt.Rows[0]["description"].ToString();
                    SpotlightList.logo = dt.Rows[0]["ImageUrl"].ToString();
                    SpotlightList.domain_name = dt.Rows[0]["domain_name"].ToString();
                    SpotlightList.RouteURL = dt.Rows[0]["RouteURL"].ToString();




                }
                if (SpotlightList == null)
                {
                    return NotFound();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }



            return Ok(SpotlightList);

        }
        [HttpGet]
        public IHttpActionResult GetSingleInterviewEvent(string SiteName)
        {
            SingleInterviewEvent EventList = null;
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
                sqlCmd.Parameters.AddWithValue("@SiteName", SiteName.Trim());
                sqlCmd.CommandText = "PubsiteAPI_Single_Interview_Gettop3Event";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                EventList = new SingleInterviewEvent();
                if (dt.Rows.Count > 0)
                {

                    EventList.EventID = Convert.ToInt32(dt.Rows[0]["EventID"]);
                    //Name = data["Name"].ToString(),
                    EventList.EventType = Convert.ToInt32(dt.Rows[0]["EventType"]);
                    EventList.ImageUrl = dt.Rows[0]["ImageUrl"].ToString();
                    EventList.IsSponcered = Convert.ToInt32(dt.Rows[0]["IsSponcered"]);
                    EventList.Sponsors = dt.Rows[0]["Sponsors"].ToString();
                    //StartEndDate = data["StartEndDate"].ToString()



                }
                if (EventList == null)
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
        public IHttpActionResult GetSingleInterviewResources(string SiteName)

        {
            Resources ResourcesList = null;
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
                sqlCmd.Parameters.AddWithValue("@SiteName", SiteName.Trim());
                sqlCmd.CommandText = "PubsiteAPI_Single_Interview_GetTop3Resources";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                ResourcesList = new Resources();
                if (dt.Rows.Count > 0)
                {

                    ResourcesList.ID = Convert.ToInt32(dt.Rows[0]["ID"]);
                    ResourcesList.ImageURL = dt.Rows[0]["ImageURL"].ToString();
                    ResourcesList.Description = dt.Rows[0]["Description"].ToString();
                    ResourcesList.ResourceType = dt.Rows[0]["ResourceType"].ToString();
                    ResourcesList.WhitePaperTitle = dt.Rows[0]["WhitePaperTitle"].ToString();



                }
                if (ResourcesList == null)
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




    }
}
