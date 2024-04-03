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
    public class SingleGuestAuthorProfileController : ApiController
    {
        private SqlConnection scon = null;
        private SqlConnection scon1 = null;
        private SqlConnection scon2 = null;

        private void Connection()
        {
            try
            {
                scon = new SqlConnection("Data Source=3.108.12.178;User ID=NAMEDIA7io1;Initial Catalog=NAMEDIA7io; Password=L/[BBe9D");
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
                scon1 = new SqlConnection("Data Source=3.108.12.178;User ID=GeneReport1;Initial Catalog=GeneReport; Password=75j]G)sC");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void ConnectionPubsite()
        {
            try
            {

                scon1 = new SqlConnection("Data Source=3.108.12.178;User ID=theiotrep1;Initial Catalog=theiotrep; Password=8g)mB9w3");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
         [HttpGet]
        public IHttpActionResult GetSingleGuestAuthorSpotlightByEmail(string email)
        {

            SpotLightAuthor objCompaniesModel = null;
            try
            {
                if (email != string.Empty)
                {
                    Connection();
                    SqlCommand sqlCmd = new SqlCommand();
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    // sqlCmd.Parameters.AddWithValue("@SiteName", SiteName.Trim());
                    sqlCmd.Parameters.AddWithValue("@User_Email", email);
                    sqlCmd.CommandText = "Get_AuthorCompanyDetails_Get_By_UserName";
                    sqlCmd.Connection = scon;

                    SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    DataTable dt = new DataTable();
                    dt = ds.Tables[0];
                    objCompaniesModel = new SpotLightAuthor();
                    if (dt.Rows.Count > 0)
                    {

                        objCompaniesModel.CompanyName = dt.Rows[0]["CompanyName"].ToString();
                        objCompaniesModel.CompanyNameDescription = dt.Rows[0]["CompanyNameDescription"].ToString();
                        objCompaniesModel.CompanyNameLogo = dt.Rows[0]["CompanyNameLogo"].ToString();
                        objCompaniesModel.CompanyWebsite = dt.Rows[0]["CompanyWebsite"].ToString();


                    }
                    if (objCompaniesModel == null )
                    {
                        return Ok(objCompaniesModel);
                    }

                }
                else
                {
                    return Ok(objCompaniesModel);
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(objCompaniesModel);
        }
        [HttpGet]
        public IHttpActionResult GetTop1SingleGuestAuthorProfileSpotlightBYID(string siteName, int CompanyId)
        {
            string SiteName = string.Empty;
            siteName = siteName.Replace("test.", "");
            SingleGuestAuthorProfileModel objCompaniesModel = null;
            try
            {
                if (SiteName == string.Empty)
                {
                    SiteName = siteName.Trim();

                    if (SiteName.Contains("."))
                        SiteName = SiteName.Split('.')[0].Trim();
                }
                Connection();
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;
               // sqlCmd.Parameters.AddWithValue("@SiteName", SiteName.Trim());
                sqlCmd.Parameters.AddWithValue("@CompanyId", CompanyId);
                sqlCmd.CommandText = "PubsiteAPI_Single__Guest_Author_Profile_GetTop1SingleGuestAuthorProfileSpotlightBYID";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                objCompaniesModel = new SingleGuestAuthorProfileModel();
                if (dt.Rows.Count > 0)
                {

                    objCompaniesModel.CompanyId = Convert.ToInt32(dt.Rows[0]["CompanyId"]);
                    objCompaniesModel.Comapanyname = dt.Rows[0]["Comapanyname"].ToString();
                    objCompaniesModel.ImageUrl = dt.Rows[0]["ImageUrl"].ToString();
                    objCompaniesModel.CompanyWebsite = dt.Rows[0]["CompanyWebsite"].ToString();
                    objCompaniesModel.UserName = dt.Rows[0]["UserName"].ToString();
                    objCompaniesModel.Description = dt.Rows[0]["Description"].ToString();
                    objCompaniesModel.IsSponcered = Convert.ToInt32(dt.Rows[0]["IsSponcered"]);
                           
                            // RouteURL = data["RouteURL"].ToString()
                      

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
        public IHttpActionResult GetSingleGuestAuthorProfileByID(string RouteURL)
        {

            string SiteName = string.Empty;
            SingleGuestAuthorProfile singleGuestAuthorProfileModel = null;
            try
            {

                Connection();
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                //if (SiteName == string.Empty)
                //{
                //    SiteName = siteName;

                //    if (SiteName.Contains("."))
                //        SiteName = SiteName.Split('.')[0].Trim();
                //}
               // sqlCmd.Parameters.AddWithValue("@SiteName", SiteName);

                sqlCmd.Parameters.AddWithValue("@RouteURL", RouteURL);

                
                sqlCmd.CommandText = "NewPubsiteAPI_Single__Guest_Author_Profile_GETSingleGuestAuthorProfileByUserName";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                singleGuestAuthorProfileModel = new SingleGuestAuthorProfile();
                if (dt.Rows.Count > 0)
                {


                    singleGuestAuthorProfileModel.UserDetailsId = Convert.ToInt32(dt.Rows[0]["userdetails_id"]);
                    singleGuestAuthorProfileModel.UserBio = dt.Rows[0]["user_bio"].ToString();
                    singleGuestAuthorProfileModel.UserCompany = dt.Rows[0]["user_company"].ToString();
                    singleGuestAuthorProfileModel.UserImageprofile = dt.Rows[0]["user_imageprofile"].ToString();
                    singleGuestAuthorProfileModel.AuthorName = dt.Rows[0]["AuthorName"].ToString();
                    singleGuestAuthorProfileModel.LogoNew = dt.Rows[0]["LogoNew"].ToString();
                    singleGuestAuthorProfileModel.UserJobTitle = dt.Rows[0]["User_JobTitle"].ToString();
                    singleGuestAuthorProfileModel.UserEmail = dt.Rows[0]["user_email"].ToString();
                    singleGuestAuthorProfileModel.RouteURL = dt.Rows[0]["RouteURL"].ToString();
                    singleGuestAuthorProfileModel.AuthorNameForUrl = dt.Rows[0]["AuthorName"].ToString().Replace(" ", "-").Trim();
                    singleGuestAuthorProfileModel.user_facebookLink = dt.Rows[0]["user_facebookLink"].ToString();
                    singleGuestAuthorProfileModel.user_twitterLink = dt.Rows[0]["user_twitterLink"].ToString();
                    singleGuestAuthorProfileModel.user_linkedinLink = dt.Rows[0]["user_linkedinLink"].ToString();
                            // IsSponcered = Convert.ToInt32(data["IsSponcered"]),

                    // RouteURL = data["RouteURL"].ToString()

                }
                if (singleGuestAuthorProfileModel == null )
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(singleGuestAuthorProfileModel);


        }



        [HttpGet]
        public IHttpActionResult GETSingleGuestAuthorProfileArticles(string siteName, int EmailId,int PageNumber)
        {

            string SiteName = string.Empty;
            siteName = siteName.Replace("test.", "");
            SingleGuestProfileModel objSingleGuestAuthorProfileModel = null;
            try
            {

                scon = new SqlConnection("Data Source=13.108.12.178;User ID=theiotrep1;Initial Catalog=theiotrep; Password=8g)mB9w3");
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                if (SiteName == string.Empty)
                {
                    SiteName = siteName;

                    if (SiteName.Contains("."))
                        SiteName = SiteName.Split('.')[0].Trim();
                }
                sqlCmd.Parameters.AddWithValue("@SiteName", SiteName);
                sqlCmd.Parameters.AddWithValue("@EmailId", EmailId);
                sqlCmd.Parameters.AddWithValue("@PageNumber", PageNumber);


                sqlCmd.CommandText = "PubsiteAPI_Single__Guest_Author_Profile_GETSingleGuestAuthorProfileArticles";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                objSingleGuestAuthorProfileModel =new SingleGuestProfileModel();
                if (dt.Rows.Count > 0)
                {

                    objSingleGuestAuthorProfileModel.ID = Convert.ToInt32(dt.Rows[0]["ID"]);
                    objSingleGuestAuthorProfileModel.WhitePaperTitle = dt.Rows[0]["WhitePaperTitle"].ToString();
                    objSingleGuestAuthorProfileModel.Description = dt.Rows[0]["Description"].ToString();
                    objSingleGuestAuthorProfileModel.author = dt.Rows[0]["author"].ToString();
                    objSingleGuestAuthorProfileModel.UserName = dt.Rows[0]["UserName"].ToString();
                    objSingleGuestAuthorProfileModel.ResourceType = dt.Rows[0]["ResourceType"].ToString();
                    objSingleGuestAuthorProfileModel.PublishingDate = Convert.ToDateTime(dt.Rows[0]["PublishingDate"]);
                    objSingleGuestAuthorProfileModel.IsSponcered = Convert.ToInt32(dt.Rows[0]["IsSponcered"]);
                    objSingleGuestAuthorProfileModel.TotalDataCount = Convert.ToInt32(dt.Rows[0]["TotalDataCount"]);
                         
                            // IsSponcered = Convert.ToInt32(data["IsSponcered"]),

                            // RouteURL = data["RouteURL"].ToString()
                  

                }
                if (objSingleGuestAuthorProfileModel == null )
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(objSingleGuestAuthorProfileModel);


        }




        //[HttpGet]
        //public IHttpActionResult GetTop3SingleGuestAuthorProfileOtherAuthorsOld(string siteName)
        //{
        //    string SiteName = string.Empty;
        //    IList<GolbalCompaniesModel> objCompaniesModel = null;
        //    try
        //    {

        //        scon = new SqlConnection("Data Source=199.79.62.22;User ID=theiotrep;Initial Catalog=theiotrep; Password=S#n6dy68");
        //        SqlCommand sqlCmd = new SqlCommand();
        //        sqlCmd.CommandType = CommandType.StoredProcedure;
        //        if (SiteName == string.Empty)
        //        {
        //            SiteName = siteName;

        //            if (SiteName.Contains("."))
        //                SiteName = SiteName.Split('.')[0].Trim();
        //        }
        //        sqlCmd.Parameters.AddWithValue("@SiteName", SiteName);
        //        sqlCmd.CommandText = "PubSiteApi_Single_GuestAuthor_GetTop3SingleGuestAuthorProfileOtherAuthorsOld";
        //        sqlCmd.Connection = scon;

        //        SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
        //        DataSet ds = new DataSet();
        //        sda.Fill(ds);
        //        DataTable dt = new DataTable();
        //        dt = ds.Tables[0];
        //        CopyDataTable(dt);
        //        objCompaniesModel = new List<GolbalCompaniesModel>(dt.Rows.Count);
        //        if (dt.Rows.Count > 0)
        //        {
        //            foreach (DataRow data in dt.Rows)
        //            {
        //                objCompaniesModel.Add(new GolbalCompaniesModel
        //                {
        //                    ID = Convert.ToInt32(data["ID"]),
        //                    CompanyName = data["Company_Name"].ToString(),
        //                    Logo = data["Logo"].ToString(),
        //                    DomainName = data["Domain_Name"].ToString(),
        //                    EntryDate = data["EntryDate"].ToString(),
        //                    Description = data["Description"].ToString(),
        //                    // RouteURL = data["RouteURL"].ToString()
        //                });
        //            }

        //        }
        //        if (objCompaniesModel == null || objCompaniesModel.Count == 0)
        //        {
        //            return NotFound();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return Ok();
        //}






        [HttpGet]
        public IHttpActionResult GetTop3SingleGuestAuthorProfileOtherAuthorsByExcludeId(string siteName, int ID)
        { 
            string SiteName = string.Empty;
            siteName = siteName.Replace("test.", "");
            string guestauthorinfo = string.Empty;
            DataTable ListOfemailss = GetTop3ListGuestAuthorEmails(siteName);
            DataTable DTGuestAuthor = new DataTable();
            IList<SingleGuestAuthorProfile> objSingleGuestAuthorProfile = null;
            DTGuestAuthor = GetTop3SingleGuestAuthorProfileOtherAuthorsExcludeById(siteName, ListOfemailss, ID);
            try
            {

                //SqlDataAdapter sda = new SqlDataAdapter();
                //DataSet ds = new DataSet();
                //sda.Fill(DTGuestAuthor);
                DataTable dt = new DataTable();
                dt = DTGuestAuthor;
                // dt = ds.Tables[0];


                objSingleGuestAuthorProfile = new List<SingleGuestAuthorProfile>(dt.Rows.Count);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow data in dt.Rows)
                    {
                        objSingleGuestAuthorProfile.Add(new SingleGuestAuthorProfile
                        {
                            UserDetailsId =Convert.ToInt32(data["userdetails_id"]),
                            AuthorName = data["User_FirstName"].ToString() + " " + data["User_LastName"].ToString(),
                          // RouteURL = data["RouteURL"].ToString(),
                            UserImageprofile = data["UserImageProfile"].ToString(),
                            UserJobTitle = data["User_JobTitle"].ToString(),
                            UserCompany = data["User_Company"].ToString(),
                            UserBio = data["SiteName"].ToString(),
                            UserEmail = data["User_Email"].ToString(),
                            AuthorNameForUrl = data["User_FirstName"].ToString().Replace(" ","-").Replace(".","").ToLower() + "-" + data["User_LastName"].ToString().Replace(" ","-").Replace(".","").ToLower(),

                            // UserDetailsId = Convert.ToInt32(data["userdetails_id"])
                        });
                    }
                }


                if (objSingleGuestAuthorProfile == null || objSingleGuestAuthorProfile.Count == 0)
                {
                    return Ok(objSingleGuestAuthorProfile);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(objSingleGuestAuthorProfile);
        }

        [HttpGet]
        public IHttpActionResult GetTop3SingleGuestAuthorProfileOtherAuthors(string siteName)
        { 
            string SiteName = string.Empty;
            siteName = siteName.Replace("test.", "");
            string guestauthorinfo = string.Empty;
            DataTable ListOfemailss = GetTop3ListGuestAuthorEmailsforotherAuthor(siteName);
            DataTable DTGuestAuthor = new DataTable();
            IList<SingleGuestAuthorProfile> objSingleGuestAuthorProfile = null;
            DTGuestAuthor = GetTop3SingleGuestAuthorProfileOtherAuthorsNew(siteName, ListOfemailss);
            try
            {

                //SqlDataAdapter sda = new SqlDataAdapter();
                //DataSet ds = new DataSet();
                //sda.Fill(DTGuestAuthor);
                DataTable dt = new DataTable();
                dt = DTGuestAuthor;
                // dt = ds.Tables[0];


                objSingleGuestAuthorProfile = new List<SingleGuestAuthorProfile>(dt.Rows.Count);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow data in dt.Rows)
                    {
                        objSingleGuestAuthorProfile.Add(new SingleGuestAuthorProfile
                        {
                            UserDetailsId =Convert.ToInt32(data["userdetails_id"]),
                            AuthorName = data["User_FirstName"].ToString() + " " + data["User_LastName"].ToString(),
                          // RouteURL = data["RouteURL"].ToString(),
                            UserImageprofile = data["UserImageProfile"].ToString(),
                            UserJobTitle = data["User_JobTitle"].ToString(),
                            UserCompany = data["User_Company"].ToString(),
                            UserBio = data["SiteName"].ToString(),
                            UserEmail = data["User_Email"].ToString(),
                            AuthorNameForUrl = data["User_FirstName"].ToString().Replace(" ","-").Replace(".","").ToLower() + "-" + data["User_LastName"].ToString().Replace(" ","-").Replace(".","").ToLower(),

                            // UserDetailsId = Convert.ToInt32(data["userdetails_id"])
                        });
                    }
                }


                if (objSingleGuestAuthorProfile == null || objSingleGuestAuthorProfile.Count == 0)
                {
                    return Ok(objSingleGuestAuthorProfile);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(objSingleGuestAuthorProfile);
        }

      

        [HttpGet]
        public IHttpActionResult GetTop3SingleGuestAuthorProfileOtherAuthors(string siteName, int pageNumber)
        {
            string SiteName = string.Empty;
            siteName = siteName.Replace("test.", "");
            string guestauthorinfo = string.Empty;
            DataTable ListOfemailss = GetTop3ListGuestAuthorEmails(siteName);
            DataTable DTGuestAuthor = new DataTable();
            IList<GlobalGuestAuthorsModel> objGlobalGuestAuthorModel = null;


            DTGuestAuthor = GetGlobalAllGuestAuthorsByEmail(siteName, ListOfemailss, pageNumber);

            try
            {




                //SqlDataAdapter sda = new SqlDataAdapter();
                //DataSet ds = new DataSet();
                //sda.Fill(DTGuestAuthor);
                DataTable dt = new DataTable();
                dt = DTGuestAuthor;
                // dt = ds.Tables[0];


                objGlobalGuestAuthorModel = new List<GlobalGuestAuthorsModel>(dt.Rows.Count);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow data in dt.Rows)
                    {
                        objGlobalGuestAuthorModel.Add(new GlobalGuestAuthorsModel
                        {
                            AuthorId = data["UserID"].ToString(),
                            AuthorName = data["User_FirstName"].ToString() + " " + data["User_LastName"].ToString(),
                            RouteURL = data["RouteURL"].ToString(),
                            ImageUrl = data["UserImageProfile"].ToString(),
                            JobTitle = data["User_JobTitle"].ToString(),
                            CompanyName = data["User_Company"].ToString(),
                            SiteName = data["SiteName"].ToString(),
                            Role = data["Role"].ToString(),
                            TotalDataCount = Convert.ToInt32(data["TotalDataCount"]),
                            // UserDetailsId = Convert.ToInt32(data["userdetails_id"])
                        });
                    }
                }


                if (objGlobalGuestAuthorModel == null || objGlobalGuestAuthorModel.Count == 0)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(objGlobalGuestAuthorModel);
        }

        public DataTable GetTop3SingleGuestAuthorProfileOtherAuthorsExcludeById(string siteName, DataTable ListOfEmailids, int Id)
        {
            string SiteName = string.Empty;
            siteName = siteName.Replace("test.", "");

            DataTable dt = new DataTable();
            dt = ListOfEmailids;
            string ListOfEmails = string.Empty;
            for (int i = 0; i < dt.Rows.Count; i++)
            {


                if (dt.Rows[i]["UserName"] == null)
                {
                    continue;
                }
                if (i == 0)
                {

                    ListOfEmails = "'" + dt.Rows[i]["UserName"].ToString() + "','";
                }
                else
                {
                    if (i < dt.Rows.Count - 1)
                    {


                        ListOfEmails += dt.Rows[i]["UserName"].ToString() + "','";
                    }
                    else
                    {
                        ListOfEmails += dt.Rows[i]["UserName"].ToString() + "'";
                    }
                }



                //if (i < dt.Rows.Count)
                //{
                //    ListOfEmails += (i < dt.Rows.Count) ? "','" : string.Empty;
                //}


            }

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
                sqlCmd.Parameters.AddWithValue("@ListOfEmails", ListOfEmails);
                sqlCmd.Parameters.AddWithValue("@ID", Id);
                sqlCmd.CommandText = "PubsiteAPI_Global_GetAllGuestAuthorsExcludById";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet dataSet = new DataSet();
                sda.Fill(dataSet);

                dt = dataSet.Tables[0];
                //if (ds.Tables[0].Rows.Count > 3)
                //{

                //}
                //if (dt != null)
                //{

                //}
                //        if (dt.Rows.Count > 0)
                //        {
                //}
                //{

                //}


                //dt.Rows.Add(ds.Tables[0].Rows[0]);

                //if (dt == null || dt.Rows.Count == 0)
                //{

                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable GetTop3SingleGuestAuthorProfileOtherAuthorsNew(string siteName, DataTable ListOfEmailids)
        {
            string SiteName = string.Empty;
            siteName = siteName.Replace("test.", "");

            DataTable dt = new DataTable();
            dt = ListOfEmailids;
            string ListOfEmails = string.Empty;
            for (int i = 0; i < dt.Rows.Count; i++)
            {


                if (dt.Rows[i]["UserName"] == null)
                {
                    continue;
                }
                if (i == 0)
                {

                    ListOfEmails = "'" + dt.Rows[i]["UserName"].ToString() + "','";
                }
                else
                {
                    if (i < dt.Rows.Count - 1)
                    {


                        ListOfEmails += dt.Rows[i]["UserName"].ToString() + "','";
                    }
                    else
                    {
                        ListOfEmails += dt.Rows[i]["UserName"].ToString() + "'";
                    }
                }



                //if (i < dt.Rows.Count)
                //{
                //    ListOfEmails += (i < dt.Rows.Count) ? "','" : string.Empty;
                //}


            }

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
                sqlCmd.Parameters.AddWithValue("@ListOfEmails", ListOfEmails);
                //sqlCmd.Parameters.AddWithValue("@ID", Id);
                sqlCmd.CommandText = "PubsiteAPI_SingleGuestAuthorProfile_OtherAuthor";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet dataSet = new DataSet();
                sda.Fill(dataSet);

                dt = dataSet.Tables[0];
                //if (ds.Tables[0].Rows.Count > 3)
                //{

                //}
                //if (dt != null)
                //{

                //}
                //        if (dt.Rows.Count > 0)
                //        {
                //}
                //{

                //}


                //dt.Rows.Add(ds.Tables[0].Rows[0]);

                //if (dt == null || dt.Rows.Count == 0)
                //{

                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable GetGlobalAllGuestAuthorsByEmail(string siteName, DataTable ListOfEmailids, int pageNumber)
        {
            string SiteName = string.Empty;
            siteName = siteName.Replace("test.", "");

            DataTable dt = new DataTable();
            dt = ListOfEmailids;
            string ListOfEmails = string.Empty;
            for (int i = 0; i < dt.Rows.Count; i++)
            {


                if (dt.Rows[i]["UserName"] == null)
                {
                    continue;
                }
                if (i == 0)
                {

                    ListOfEmails = "'" + dt.Rows[i]["UserName"].ToString() + "','";
                }
                else
                {
                    if (i < dt.Rows.Count - 1)
                    {


                        ListOfEmails += dt.Rows[i]["UserName"].ToString() + "','";
                    }
                    else
                    {
                        ListOfEmails += dt.Rows[i]["UserName"].ToString() + "'";
                    }
                }



                //if (i < dt.Rows.Count)
                //{
                //    ListOfEmails += (i < dt.Rows.Count) ? "','" : string.Empty;
                //}


            }
            
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
                sqlCmd.Parameters.AddWithValue("@ListOfEmails", ListOfEmails);
                sqlCmd.Parameters.AddWithValue("@PageNumber", pageNumber);
                sqlCmd.CommandText = "PubsiteAPI_Global_GetAllGuestAuthors";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);

                dt = ds.Tables[0];
                //if (ds.Tables[0].Rows.Count > 3)
                //{

                //}
                //if (dt != null)
                //{

                //}
                //        if (dt.Rows.Count > 0)
                //        {
                //}
                //{

                //}


                //dt.Rows.Add(ds.Tables[0].Rows[0]);
                       
                //if (dt == null || dt.Rows.Count == 0)
                //{

                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable GetTop3ListGuestAuthorEmails(string siteName)
        {
            string SiteName = string.Empty;
            siteName = siteName.Replace("test.", "");
            DataTable dt = new DataTable();
            try
            {
                if (siteName == "pharmaceutical.report" || siteName == "smallbusiness.report")
                {
                    PharmaSmallConnection();
                }
                else
                {
                    ConnectionPubsite();
                }
                //ConnectionPubsite();
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                if (SiteName == string.Empty)
                {
                    SiteName = siteName;

                    if (SiteName.Contains("."))
                        SiteName = SiteName.Split('.')[0].Trim();
                }
                sqlCmd.Parameters.AddWithValue("@SiteName", SiteName);




                sqlCmd.CommandText = "PubsiteAPI_SingleGuestAuthorProfile_GetListofotherAuthorEmails";
                sqlCmd.Connection = scon1;


                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);

                dt = ds.Tables[0];


            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;


        }

        public DataTable GetTop3ListGuestAuthorEmailsforotherAuthor(string siteName)
        {
            string SiteName = string.Empty;
            siteName = siteName.Replace("test.", "");
            DataTable dt = new DataTable();
            try
            {
                ConnectionPubsite();
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                if (SiteName == string.Empty)
                {
                    SiteName = siteName;

                    if (SiteName.Contains("."))
                        SiteName = SiteName.Split('.')[0].Trim();
                }
                sqlCmd.Parameters.AddWithValue("@SiteName", SiteName);




                sqlCmd.CommandText = "PubsiteAPI_SingleGuestAuthorProfile_GetListofotherAuthorEmails";
                sqlCmd.Connection = scon1;


                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);

                dt = ds.Tables[0];


            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;


        }


        //[HttpGet]
        //public IHttpActionResult GetTop8SingleGuestAuthorProfile(string siteName)
        //{
        //    //string SiteName = string.Empty;
        //    //IList<GolbalCompaniesModel> objCompaniesModel = null;
        //    //try
        //    //{

        //    //    Connection();
        //    //    SqlCommand sqlCmd = new SqlCommand();
        //    //    sqlCmd.CommandType = CommandType.StoredProcedure;
        //    //    if (SiteName == string.Empty)
        //    //    {
        //    //        SiteName = siteName;

        //    //        if (SiteName.Contains("."))
        //    //            SiteName = SiteName.Split('.')[0].Trim();
        //    //    }
        //    //    sqlCmd.Parameters.AddWithValue("@SiteName", SiteName);
        //    //    sqlCmd.CommandText = "PubsiteAPI_Single_Companies_GetTop1SingleCompaniesCSuiteOnDeck";
        //    //    sqlCmd.Connection = scon;

        //    //    SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
        //    //    DataSet ds = new DataSet();
        //    //    sda.Fill(ds);
        //    //    DataTable dt = new DataTable();
        //    //    dt = ds.Tables[0];
        //    //    objCompaniesModel = new List<GolbalCompaniesModel>(dt.Rows.Count);
        //    //    if (dt.Rows.Count > 0)
        //    //    {
        //    //        foreach (DataRow data in dt.Rows)
        //    //        {
        //    //            objCompaniesModel.Add(new GolbalCompaniesModel
        //    //            {
        //    //                ID = Convert.ToInt32(data["ID"]),
        //    //                CompanyName = data["Company_Name"].ToString(),
        //    //                Logo = data["Logo"].ToString(),
        //    //                DomainName = data["Domain_Name"].ToString(),
        //    //                EntryDate = data["EntryDate"].ToString(),
        //    //                Description = data["Description"].ToString(),
        //    //                // RouteURL = data["RouteURL"].ToString()
        //    //            });
        //    //        }

        //    //    }
        //    //    if (objCompaniesModel == null || objCompaniesModel.Count == 0)
        //    //    {
        //    //        return NotFound();
        //    //    }
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    throw ex;
        //    //}
        //    return Ok();
        //}



        public void CopyDataTable(DataTable table)
        {

            DataTable copyDataTable;
            copyDataTable = table.Copy();








        }

    }
}
