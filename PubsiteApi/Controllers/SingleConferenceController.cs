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
    public class SingleConferenceController : ApiController
    {

        private SqlConnection scon = null;
        //SingleUpCommingConference API
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
        public IHttpActionResult GetSingleUpcommingConferenceById(string SiteName, string RouteURL)
        {
            GlobalEventWebinarsModel UpcommingConferencemodel = null;
            string sitename = "";
            SiteName = SiteName.Replace("test.", "");
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
                        sitename = sitename.ToLower();
                    sitename = sitename.Split('.')[0].Trim();
                }
                sqlCmd.Parameters.AddWithValue("@SiteName", sitename.Trim());
                sqlCmd.Parameters.AddWithValue("@RouteURL", RouteURL);
                sqlCmd.CommandText = "NewPubsiteAPI_Single_Conference_CommingConferenceByTitle";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                UpcommingConferencemodel = new GlobalEventWebinarsModel();
                if (dt.Rows.Count > 0)
                {



                    UpcommingConferencemodel.Details = dt.Rows[0]["Details"].ToString();
                    UpcommingConferencemodel.Name = dt.Rows[0]["Name"].ToString();
                    UpcommingConferencemodel.ImageUrl = dt.Rows[0]["ImageUrl"].ToString();
                    UpcommingConferencemodel.URL = dt.Rows[0]["URL"].ToString();
                    UpcommingConferencemodel.IsSponcered = Convert.ToBoolean(dt.Rows[0]["IsSponcered"]);
                    UpcommingConferencemodel.Sponsors = dt.Rows[0]["Sponsors"].ToString();
                    UpcommingConferencemodel.DateWithStartTime = dt.Rows[0]["StartEndDate"].ToString();
                    UpcommingConferencemodel.EventDifferentType = dt.Rows[0]["EventDifferentType"].ToString();
                    UpcommingConferencemodel.EventType = Convert.ToInt32(dt.Rows[0]["EventType"]);
                    UpcommingConferencemodel.Country = dt.Rows[0]["Country"].ToString();
                    UpcommingConferencemodel.RouteURL = dt.Rows[0]["RouteURL"].ToString();
                    UpcommingConferencemodel.EndDate = dt.Rows[0]["EndDate"].ToString();
                    UpcommingConferencemodel.StartDate = dt.Rows[0]["StartDate"].ToString();
                    UpcommingConferencemodel.ISINDEX = Convert.ToInt32(dt.Rows[0]["ISINDEX"]);
                    UpcommingConferencemodel.IsFollow = Convert.ToInt32(dt.Rows[0]["IsFollow"]);
                    UpcommingConferencemodel.ManualCanonical = dt.Rows[0]["ManualCanonical"].ToString();
                    UpcommingConferencemodel.MetaTitle = Utils.HtmlDecode(dt.Rows[0]["MetaTitle"].ToString());
                    UpcommingConferencemodel.MetaDescription = Utils.HtmlDecode(dt.Rows[0]["MetaDescription"].ToString());
                    UpcommingConferencemodel.Keywords = Utils.HtmlDecode(dt.Rows[0]["Keywords"].ToString());
                    UpcommingConferencemodel.ImageAltTag = dt.Rows[0]["ImageAltTag"].ToString();
                    UpcommingConferencemodel.EventTypeSchema = dt.Rows[0]["EventTypeSchema"].ToString();
                    UpcommingConferencemodel.location_Name = dt.Rows[0]["location_Name"].ToString();
                    UpcommingConferencemodel.StreetAddress = dt.Rows[0]["StreetAddress"].ToString();
                    UpcommingConferencemodel.AddressLocality = dt.Rows[0]["AddressLocality"].ToString();
                    UpcommingConferencemodel.PostalCode = dt.Rows[0]["PostalCode"].ToString();
                    UpcommingConferencemodel.Performer_Name = dt.Rows[0]["Performer_Name"].ToString();
                    UpcommingConferencemodel.Organizer_Url = dt.Rows[0]["Organizer_Url"].ToString();
                    UpcommingConferencemodel.Company = dt.Rows[0]["Company"].ToString();
                    UpcommingConferencemodel.Region = dt.Rows[0]["Region"].ToString();

                }
                if (UpcommingConferencemodel == null)
                {
                    return NotFound();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }



            return Ok(UpcommingConferencemodel);

        }


        [HttpGet]
        public IHttpActionResult GetSingleConferenceSpotlight(string SiteName)
        {

           SpotLightModel conferenceSpotligh = null;
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
                sqlCmd.CommandText = "PubsiteAPI_Single_Conference_GetTop1Spotlight";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                conferenceSpotligh = new SpotLightModel();
                if (dt.Rows.Count > 0)
                {

                    conferenceSpotligh.EventID = Convert.ToInt32(dt.Rows[0]["EventID"]);
                    conferenceSpotligh.Name = dt.Rows[0]["Name"].ToString();
                    conferenceSpotligh.ImageUrl = dt.Rows[0]["ImageUrl"].ToString();
                    conferenceSpotligh.IsSponcered = Convert.ToInt32(dt.Rows[0]["IsSponcered"]);
                    conferenceSpotligh.Description = dt.Rows[0]["Description"].ToString();


                      

                }
                if (conferenceSpotligh == null)
                {
                    return NotFound();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }



            return Ok(conferenceSpotligh);

        }


        [HttpGet]
        public IHttpActionResult GetSingleConferenceResources(string SiteName)

        {
            Resources conferenceResources = null;
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
                sqlCmd.CommandText = "PubsiteAPI_Single_Conference_GetTop3Resources";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                conferenceResources = new Resources();
                if (dt.Rows.Count > 0)
                {

                    conferenceResources.ID = Convert.ToInt32(dt.Rows[0]["ID"]);
                    conferenceResources.ImageURL = dt.Rows[0]["ImageURL"].ToString();
                    conferenceResources.Description = dt.Rows[0]["Description"].ToString();
                    conferenceResources.ResourceType = dt.Rows[0]["ResourceType"].ToString();
                    conferenceResources.WhitePaperTitle = dt.Rows[0]["WhitePaperTitle"].ToString();

                      

                }
                if (conferenceResources == null)
                {
                    return NotFound();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }



            return Ok(conferenceResources);

        }


        [HttpGet]
        public IHttpActionResult GetSingle4UpCommingConference(string SiteName, string RouteURL)
        {


            IList<GlobalEventWebinarsModel> top4UpcommingConferenceList = null;
            string sitename = "";
            SiteName = SiteName.Replace("test.", "");
            try
            {
                if (SiteName == "pharmaceutical" || SiteName == "smallbusiness")
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
                    SiteName = sitename;

                    if (SiteName.Contains("."))
                        SiteName = SiteName.Split('.')[0].Trim();
                }
                sqlCmd.Parameters.AddWithValue("@SiteName", SiteName.Trim());
                sqlCmd.Parameters.AddWithValue("@RouteURL", RouteURL);
                sqlCmd.CommandText = "NewPubsiteAPI_Single_Conference_GetOtherUpCommingConference";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                top4UpcommingConferenceList = new List<GlobalEventWebinarsModel>(dt.Rows.Count);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow data in dt.Rows)
                    {

                        top4UpcommingConferenceList.Add(new GlobalEventWebinarsModel
                        {
                            EventID = Convert.ToInt32(data["EventID"]),
                            Details = data["Details"].ToString(),
                            Name = data["Name"].ToString(),
                            ImageUrl = data["ImageUrl"].ToString(),
                            URL = data["URL"].ToString(),
                            IsSponcered = Convert.ToBoolean(data["IsSponcered"]),
                            Sponsors = data["Sponsors"].ToString(),
                            DateWithStartTime = data["StartEndDate"].ToString(),
                            RouteURL = data["RouteURL"].ToString(),
                            EventDifferentType = data["EventDifferentType"].ToString(),
                            EventType = Convert.ToInt32(data["EventType"]),
                            Country = data["Country"].ToString()


                        });

                    }

                }
                if (top4UpcommingConferenceList.Count == 0)
                {
                    return NotFound();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }



            return Ok(top4UpcommingConferenceList);


        }
        //SingleUpCommingConference API End


        //SinglePastConference  Start


        public IHttpActionResult GetSinglePastConferenceById(string SiteName, string RouteURL)
        {
            GlobalEventWebinarsModel PastConferencemodel = null;
            string sitename = "";
            SiteName = SiteName.Replace("test.", "");
            try
            {
                if (SiteName == "pharmaceutical" || SiteName == "smallbusiness")
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
                    SiteName = sitename;

                    if (SiteName.Contains("."))
                        SiteName = SiteName.Split('.')[0].Trim();
                }
                sqlCmd.Parameters.AddWithValue("@SiteName", SiteName.Trim());
                sqlCmd.Parameters.AddWithValue("@RouteURL", RouteURL);
                sqlCmd.CommandText = "NewPubsiteAPI_Single_Event_GetPastConferenceByRouteURL";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                PastConferencemodel = new GlobalEventWebinarsModel();
                if (dt.Rows.Count > 0)
                {

                    PastConferencemodel.EventID = Convert.ToInt32(dt.Rows[0]["EventID"]);
                    PastConferencemodel.Details = dt.Rows[0]["Details"].ToString();
                    PastConferencemodel.Name = dt.Rows[0]["Name"].ToString();
                    PastConferencemodel.ImageUrl = dt.Rows[0]["ImageUrl"].ToString();
                    PastConferencemodel.URL = dt.Rows[0]["URL"].ToString();
                    PastConferencemodel.IsSponcered = Convert.ToBoolean(dt.Rows[0]["IsSponcered"]);
                    PastConferencemodel.Sponsors = dt.Rows[0]["Sponsors"].ToString();
                    PastConferencemodel.DateWithStartTime = dt.Rows[0]["StartEndDate"].ToString();
                    PastConferencemodel.StartDate = dt.Rows[0]["StartDate"].ToString();
                    PastConferencemodel.EndDate = dt.Rows[0]["EndDate"].ToString();
                    PastConferencemodel.EventDifferentType = dt.Rows[0]["EventDifferentType"].ToString();
                    PastConferencemodel.EventType = Convert.ToInt32(dt.Rows[0]["EventType"]);
                    PastConferencemodel.Country = dt.Rows[0]["Country"].ToString();
                    PastConferencemodel.ISINDEX = Convert.ToInt32(dt.Rows[0]["ISINDEX"]);
                    PastConferencemodel.IsFollow = Convert.ToInt32(dt.Rows[0]["IsFollow"]);
                    PastConferencemodel.ManualCanonical = dt.Rows[0]["ManualCanonical"].ToString();
                    PastConferencemodel.MetaTitle = Utils.HtmlDecode(dt.Rows[0]["MetaTitle"].ToString());
                    PastConferencemodel.MetaDescription = Utils.HtmlDecode(dt.Rows[0]["MetaDescription"].ToString());
                    PastConferencemodel.Keywords = Utils.HtmlDecode(dt.Rows[0]["keywords"].ToString());
                    PastConferencemodel.ImageAltTag = dt.Rows[0]["ImageAltTag"].ToString();
                    PastConferencemodel.EventTypeSchema = dt.Rows[0]["EventTypeSchema"].ToString();
                    PastConferencemodel.location_Name = dt.Rows[0]["location_Name"].ToString();
                    PastConferencemodel.StreetAddress = dt.Rows[0]["StreetAddress"].ToString();
                    PastConferencemodel.AddressLocality = dt.Rows[0]["AddressLocality"].ToString();
                    PastConferencemodel.PostalCode = dt.Rows[0]["PostalCode"].ToString();
                    PastConferencemodel.Performer_Name = dt.Rows[0]["Performer_Name"].ToString();
                    PastConferencemodel.Organizer_Url = dt.Rows[0]["Organizer_Url"].ToString();
                    PastConferencemodel.Company = dt.Rows[0]["Company"].ToString();
                    PastConferencemodel.Region = dt.Rows[0]["Region"].ToString();

                }
                if (PastConferencemodel == null)
                {
                    return NotFound();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }



            return Ok(PastConferencemodel);

        }

        public IHttpActionResult GetSingle4PastConference(string SiteName, string RouteURL)
        {


            IList<GlobalEventWebinarsModel> top4PastConferenceListList = null;
            string sitename = "";
            SiteName = SiteName.Replace("test.", "");
            try
            {
                if (SiteName == "pharmaceutical" || SiteName == "smallbusiness")
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
                    SiteName = sitename;

                    if (SiteName.Contains("."))
                        SiteName = SiteName.Split('.')[0].Trim();
                }
                sqlCmd.Parameters.AddWithValue("@SiteName", SiteName.Trim());
                sqlCmd.Parameters.AddWithValue("@RouteURL", RouteURL);
                sqlCmd.CommandText = "NewPubsiteAPI_Single_Event-GetTop4PastConference";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                top4PastConferenceListList = new List<GlobalEventWebinarsModel>(dt.Rows.Count);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow data in dt.Rows)
                    {

                        top4PastConferenceListList.Add(new GlobalEventWebinarsModel
                        {
                            EventID = Convert.ToInt32(data["EventID"]),
                            Details = data["Details"].ToString(),
                            Name = data["Name"].ToString(),
                            ImageUrl = data["ImageUrl"].ToString(),
                            URL = data["URL"].ToString(),
                            IsSponcered = Convert.ToBoolean(data["IsSponcered"]),
                            Sponsors = data["Sponsors"].ToString(),
                            DateWithStartTime = data["StartEndDate"].ToString(),
                            RouteURL = data["RouteURL"].ToString(),
                            EventDifferentType = data["EventDifferentType"].ToString(),
                            EventType = Convert.ToInt32(data["EventType"]),
                            Country = data["Country"].ToString()


                        });

                    }

                }
                if (top4PastConferenceListList.Count == 0)
                {
                    return NotFound();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }



            return Ok(top4PastConferenceListList);


        }

    }
}
