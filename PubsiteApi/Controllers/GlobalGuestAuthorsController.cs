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
    public class GlobalGuestAuthorsController : ApiController
    {
        private SqlConnection scon = null;
        private SqlConnection scon1 = null;
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

        //private SqlConnection scon2 = null;
        //private void NewConnection()
        //{
        //    try
        //    {
        //        scon2 = new SqlConnection("Data Source=199.79.62.22;User ID=theiotrep;Initial Catalog=theiotrep; Password=S#n6dy68");
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}




        [HttpGet]
        public IHttpActionResult GetSingleGuestAuthorProfileById(string siteName, int id)
        {
            string SiteName = string.Empty;
            IList<GlobalGuestAuthorsModel> objGlobalGuestAuthorModel = null;
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
                sqlCmd.Parameters.AddWithValue("@UserID", id);
                sqlCmd.CommandText = "PubsiteAPI_Single_Author_GetSingleGuestAuthorProfileById";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                objGlobalGuestAuthorModel = new List<GlobalGuestAuthorsModel>(dt.Rows.Count);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow data in dt.Rows)
                    {
                        objGlobalGuestAuthorModel.Add(new GlobalGuestAuthorsModel
                        {
                            AuthorName = data["AuthorName"].ToString(),
                            RouteURL = data["RouteURL"].ToString(),
                            ImageUrl = data["UserImageProfile"].ToString(),
                            JobTitle = data["user_bio"].ToString(),
                            CompanyName = data["user_company"].ToString(),
                            UserDetailsId = Convert.ToInt32(data["userdetails_id"]),
                            AuthorSummary = data["AuthorSummary"].ToString()
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


        [HttpGet]
        public IHttpActionResult GetGlobalGuestAuthors(string siteName, int pageNumber)
        {
            string SiteName = string.Empty;
            string guestauthorinfo = string.Empty;
            DataTable ListOfemailss = GetListGuestAuthorEmails(siteName);
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
                            UserDetailsId = Convert.ToInt32(data["userdetails_id"]),
                            
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

        [HttpGet]
        public IHttpActionResult GetGuestAuthorsForGlobal(string siteName)
        {
            string SiteName = string.Empty;
            siteName = siteName.Replace("test.", "");
            string guestauthorinfo = string.Empty;
            DataTable ListOfemailss = GetListGuestAuthorEmails(siteName);
            DataTable DTGuestAuthor = new DataTable();
            IList<GlobalGuestAuthorsModel> objGlobalGuestAuthorModel = null;
            

            DTGuestAuthor = GetAllGuestAuthorsByEmailForGlobal(siteName, ListOfemailss);

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
                            UserDetailsId = Convert.ToInt32(data["userdetails_id"]),
                            
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

        public DataTable GetGlobalAllGuestAuthorsByEmail(string siteName, DataTable ListOfEmailids, int pageNumber)
        {
            string SiteName = string.Empty;

            DataTable dt = new DataTable();
            dt = ListOfEmailids;
            string ListOfEmails = string.Empty;
            for(int i=0;i< dt.Rows.Count; i++)
            {


                if(dt.Rows[i]["UserName"] == null)
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
            // ListOfEmailss = ListOfEmails.Rows[0]["UserName"].ToString();
          
           // int index = ListOfEmails.LastIndexOf(',');
           // ListOfEmails.Remove(index, 1);
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

        public DataTable GetAllGuestAuthorsByEmailForGlobal(string siteName, DataTable ListOfEmailids)
        {
            string SiteName = string.Empty;

            DataTable dt = new DataTable();
            dt = ListOfEmailids;
            string ListOfEmails = string.Empty;
            for(int i=0;i< dt.Rows.Count; i++)
            {


                if(dt.Rows[i]["UserName"] == null)
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
            // ListOfEmailss = ListOfEmails.Rows[0]["UserName"].ToString();
          
           // int index = ListOfEmails.LastIndexOf(',');
           // ListOfEmails.Remove(index, 1);
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
                //sqlCmd.Parameters.AddWithValue("@PageNumber", pageNumber);
                sqlCmd.CommandText = "NewPubsiteAPI_Global_GetAllGuestAuthors";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);

                dt = ds.Tables[0];

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

        public DataTable GetListGuestAuthorEmails(string siteName)
        {
            string SiteName = string.Empty;
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




                sqlCmd.CommandText = "PubsiteAPI_Global_GetListGuestAuthorEmails";
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

        [HttpGet]
        public IHttpActionResult GetAllNewsGuestAuthorProfileByName(string siteName, string authorName, int pageNumber)
        {
            string SiteName = string.Empty;
            IList<GuestAthorNewsModel> objGuestAthorNewsModel = null;
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
               
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                if (SiteName == string.Empty)
                {
                    SiteName = siteName;

                    if (SiteName.Contains("."))
                        SiteName = SiteName.Split('.')[0].Trim();
                }
                sqlCmd.Parameters.AddWithValue("@SiteName", SiteName);
                sqlCmd.Parameters.AddWithValue("@AuthorName", authorName);
                sqlCmd.Parameters.AddWithValue("@PageNumber", pageNumber);
                sqlCmd.CommandText = "PubsiteAPI_Single_Guest_GetAllNewsByName";
                sqlCmd.Connection = scon1;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                objGuestAthorNewsModel = new List<GuestAthorNewsModel>(dt.Rows.Count);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow data in dt.Rows)
                    {
                        objGuestAthorNewsModel.Add(new GuestAthorNewsModel
                        {
                            ID = Convert.ToInt32(data["id"]),
                            Author = data["Author"].ToString(),
                            ImageUrl = data["imageurl"].ToString(),
                            Title = data["Title"].ToString(), 
                            Description = data["Description"].ToString(),
                            PublishingDate = data["PublishingDate"].ToString(),
                            TotalDataCount = Convert.ToInt32(data["TotalDataCount"])
                        });
                    }
                }
                if (objGuestAthorNewsModel == null || objGuestAthorNewsModel.Count == 0)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(objGuestAthorNewsModel);

        }

        [HttpGet]
        public IHttpActionResult GetTop3GlobalGuestOtherAuthors(string siteName, int pageNumber)
        {
            string SiteName = string.Empty;
            string guestauthorinfo = string.Empty;
            DataTable ListOfemailss = GetListGuestAuthorEmails(siteName);
            DataTable DTGuestAuthor = new DataTable();
            IList<GlobalGuestAuthorsModel> objGlobalGuestAuthorModel = null;
            
            DTGuestAuthor = GetGlobalAllGuestAuthorsByEmail(siteName, ListOfemailss, pageNumber);

            try
            {




                SqlDataAdapter sda = new SqlDataAdapter();
                DataSet ds = new DataSet();
                sda.Fill(DTGuestAuthor);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];


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
                            RoleName = data["RoleName"].ToString(),
                            TotalDataCount = Convert.ToInt32(data["TotalDataCount"]),
                            UserDetailsId = Convert.ToInt32(data["userdetails_id"])
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


    }
}
