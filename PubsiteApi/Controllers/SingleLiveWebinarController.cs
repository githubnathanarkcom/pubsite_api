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
    public class SingleLiveWebinarController : ApiController
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
        //Single Live Webinar API
        [HttpGet]
        public IHttpActionResult GetSingleLiveWebinarById(string SiteName, string RouteURL)
        {
            GlobalEventWebinarsModel LiveWebinarList = null;
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
                sqlCmd.CommandText = "NewPubsiteAPI_Single_LiveWebinarGetByTitle";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                LiveWebinarList = new GlobalEventWebinarsModel();
                if (dt.Rows.Count > 0)
                {

                    LiveWebinarList.EventID = Convert.ToInt32(dt.Rows[0]["EventID"]);
                    LiveWebinarList.Details = dt.Rows[0]["Details"].ToString();
                    LiveWebinarList.Name = dt.Rows[0]["Name"].ToString();
                    LiveWebinarList.ImageUrl = dt.Rows[0]["ImageUrl"].ToString();
                    LiveWebinarList.URL = dt.Rows[0]["URL"].ToString();
                    LiveWebinarList.IsSponcered = Convert.ToBoolean(dt.Rows[0]["IsSponcered"]);
                    LiveWebinarList.DateWithStartTime = dt.Rows[0]["DateWithStartTime"].ToString();
                    LiveWebinarList.StartDate = dt.Rows[0]["StartDate"].ToString();
                    LiveWebinarList.EndDate = dt.Rows[0]["EndDate"].ToString();
                    LiveWebinarList.Sponsors = dt.Rows[0]["Sponsors"].ToString();
                    LiveWebinarList.EventDifferentType = dt.Rows[0]["EventDifferentType"].ToString();
                    LiveWebinarList.IsActive = Convert.ToInt32(dt.Rows[0]["IsActive"]);
                    LiveWebinarList.Country = dt.Rows[0]["Country"].ToString();
                    LiveWebinarList.Company = dt.Rows[0]["Company"].ToString();
                    LiveWebinarList.ISINDEX = Convert.ToInt32(dt.Rows[0]["ISINDEX"]);
                    LiveWebinarList.IsFollow = Convert.ToInt32(dt.Rows[0]["IsFollow"]);
                    LiveWebinarList.ManualCanonical = dt.Rows[0]["ManualCanonical"].ToString();
                    LiveWebinarList.MetaTitle = Utils.HtmlDecode(dt.Rows[0]["MetaTitle"].ToString());
                    LiveWebinarList.MetaDescription = Utils.HtmlDecode(dt.Rows[0]["MetaDescription"].ToString());
                    LiveWebinarList.Keywords = Utils.HtmlDecode(dt.Rows[0]["Keywords"].ToString());
                    LiveWebinarList.ImageAltTag = dt.Rows[0]["ImageAltTag"].ToString();
                    LiveWebinarList.EventTypeSchema = dt.Rows[0]["EventTypeSchema"].ToString();
                    LiveWebinarList.location_Name = dt.Rows[0]["location_Name"].ToString();
                    LiveWebinarList.StreetAddress = dt.Rows[0]["StreetAddress"].ToString();
                    LiveWebinarList.AddressLocality = dt.Rows[0]["AddressLocality"].ToString();
                    LiveWebinarList.PostalCode = dt.Rows[0]["PostalCode"].ToString();
                    LiveWebinarList.Performer_Name = dt.Rows[0]["Performer_Name"].ToString();
                    LiveWebinarList.Organizer_Url = dt.Rows[0]["Organizer_Url"].ToString();
                    LiveWebinarList.Region = dt.Rows[0]["Region"].ToString();

                }
                if (LiveWebinarList == null)
                {
                    return NotFound();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }



            return Ok(LiveWebinarList);

        }


        [HttpGet]
        public IHttpActionResult GetSingleLiveWebinarTop4(string siteName, string RouteURL)
        {
            IList<GlobalEventWebinarsModel> LiveWebinarList = null;
            string SiteName = string.Empty;
            SiteName = SiteName.Replace("test.", "");
            try
            {
                if (siteName == "pharmaceutical" || siteName == "smallbusiness")
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
                sqlCmd.CommandText = "NewPubsiteAPI_Single_LiveWebinarGet4Webinar";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                LiveWebinarList = new List<GlobalEventWebinarsModel>(dt.Rows.Count);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow data in dt.Rows)
                    {
                        LiveWebinarList.Add(new GlobalEventWebinarsModel
                        {
                            EventID = Convert.ToInt32(data["EventID"]),
                            Details = data["Details"].ToString(),
                            DateWithStartTime = data["DateWithStartTime"].ToString(),
                            Name = data["Name"].ToString(),
                            ImageUrl = data["ImageUrl"].ToString(),
                            URL = data["URl"].ToString(),
                            Sponsors = data["Sponsors"].ToString(),
                            EventDifferentType = data["EventDifferentType"].ToString(),
                            RouteURL = data["RouteURL"].ToString(),
                            IsSponcered = Convert.ToBoolean(data["IsSponcered"]),
                        });
                    }

                }
                if (LiveWebinarList == null || LiveWebinarList.Count == 0)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Ok(LiveWebinarList);
        }

        [HttpGet]

        public IHttpActionResult GetSingleLiveWebinarSpotlight(string siteName)
        {

            SpotLightModel conferenceSpotlightList = null;
            string sitename = "";
            try
            {
                Connection();
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                if (siteName == string.Empty)
                {
                    siteName = sitename;

                    if (siteName.Contains("."))
                        siteName = siteName.Split('.')[0].Trim();
                }
                sqlCmd.Parameters.AddWithValue("@SiteName", siteName.Trim());
                sqlCmd.CommandText = "PubsiteAPI_Single_LiveWebinar_GetTop1Spotlight";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                conferenceSpotlightList = new SpotLightModel();
                if (dt.Rows.Count > 0)
                {

                    conferenceSpotlightList.EventID = Convert.ToInt32(dt.Rows[0]["EventID"]);
                    conferenceSpotlightList.Name = dt.Rows[0]["Name"].ToString();
                    conferenceSpotlightList.ImageUrl = dt.Rows[0]["ImageUrl"].ToString();
                    conferenceSpotlightList.IsSponcered = Convert.ToInt32(dt.Rows[0]["IsSponcered"]);
                    conferenceSpotlightList.Description = dt.Rows[0]["Description"].ToString();


                }
                if (conferenceSpotlightList == null)
                {
                    return NotFound();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }



            return Ok(conferenceSpotlightList);

        }

        [HttpGet]

        public IHttpActionResult GetSingleLiveWebinarResources(string SiteName)
        {
            Resources LiveWebinarResourcesList = null;
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
                sqlCmd.CommandText = "PubsiteAPI_Single_LiveWebinar_GetTop3Resources";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                LiveWebinarResourcesList = new Resources();
                if (dt.Rows.Count > 0)
                {

                    LiveWebinarResourcesList.ID = Convert.ToInt32(dt.Rows[0]["ID"]);
                    LiveWebinarResourcesList.ImageURL = dt.Rows[0]["ImageURL"].ToString();
                    LiveWebinarResourcesList.Description = dt.Rows[0]["Description"].ToString();
                    LiveWebinarResourcesList.ResourceType = dt.Rows[0]["ResourceType"].ToString();
                    LiveWebinarResourcesList.WhitePaperTitle = dt.Rows[0]["WhitePaperTitle"].ToString();



                }
                if (LiveWebinarResourcesList == null)
                {
                    return NotFound();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }



            return Ok(LiveWebinarResourcesList);


        }

        //Single Live Webinar API End

        public IHttpActionResult GETSingleGetOnDemandWebinarByID(string SiteName, string RouteURL)
        {
            GlobalEventWebinarsModel OnDemandWebinarList = null;
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
                sqlCmd.CommandText = "NewPubsiteAPI_Single_Event_GetOnDemandWebinarByRouteURL";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                OnDemandWebinarList = new GlobalEventWebinarsModel();
                if (dt.Rows.Count > 0)
                {

                    OnDemandWebinarList.EventID = Convert.ToInt32(dt.Rows[0]["EventID"]);
                    OnDemandWebinarList.Details = dt.Rows[0]["Details"].ToString();
                    OnDemandWebinarList.Name = dt.Rows[0]["Name"].ToString();
                    OnDemandWebinarList.ImageUrl = dt.Rows[0]["ImageUrl"].ToString();
                    OnDemandWebinarList.URL = dt.Rows[0]["URL"].ToString();
                    OnDemandWebinarList.IsSponcered = Convert.ToBoolean(dt.Rows[0]["IsSponcered"]);
                    OnDemandWebinarList.DateWithStartTime = dt.Rows[0]["DateWithStartTime"].ToString();
                    OnDemandWebinarList.Sponsors = dt.Rows[0]["Sponsors"].ToString();
                    OnDemandWebinarList.EventDifferentType = dt.Rows[0]["EventDifferentType"].ToString();
                    OnDemandWebinarList.IsActive = Convert.ToInt32(dt.Rows[0]["IsActive"]);
                    // Company= data["Company"].ToString(),
                    OnDemandWebinarList.ISINDEX = Convert.ToInt32(dt.Rows[0]["ISINDEX"]);
                    OnDemandWebinarList.IsFollow = Convert.ToInt32(dt.Rows[0]["IsFollow"]);
                    OnDemandWebinarList.ManualCanonical = dt.Rows[0]["ManualCanonical"].ToString();
                    OnDemandWebinarList.MetaTitle = Utils.HtmlDecode(dt.Rows[0]["MetaTitle"].ToString());
                    OnDemandWebinarList.MetaDescription = Utils.HtmlDecode(dt.Rows[0]["MetaDescription"].ToString());
                    OnDemandWebinarList.Keywords = Utils.HtmlDecode(dt.Rows[0]["Keywords"].ToString());
                    OnDemandWebinarList.ImageAltTag = dt.Rows[0]["ImageAltTag"].ToString();
                    OnDemandWebinarList.EventTypeSchema = dt.Rows[0]["EventTypeSchema"].ToString();
                    OnDemandWebinarList.location_Name = dt.Rows[0]["location_Name"].ToString();
                    OnDemandWebinarList.StreetAddress = dt.Rows[0]["StreetAddress"].ToString();
                    OnDemandWebinarList.AddressLocality = dt.Rows[0]["AddressLocality"].ToString();
                    OnDemandWebinarList.PostalCode = dt.Rows[0]["PostalCode"].ToString();
                    OnDemandWebinarList.Performer_Name = dt.Rows[0]["Performer_Name"].ToString();
                    OnDemandWebinarList.Organizer_Url = dt.Rows[0]["Organizer_Url"].ToString();
                    OnDemandWebinarList.Company = dt.Rows[0]["Company"].ToString();

                }
                if (OnDemandWebinarList == null)
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
        public IHttpActionResult GetSingleOnDemandWebinarTop4(string siteName, string RouteURL)
        {
            IList<GlobalEventWebinarsModel> OnDemandWebinarList = null;
            string SiteName = string.Empty;
            SiteName = SiteName.Replace("test.", "");
            try
            {
                if (siteName == "pharmaceutical" || siteName == "smallbusiness")
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
                sqlCmd.CommandText = "NewPubsiteAPI_Single_Event-GetTop4OnDemandWebinar";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                OnDemandWebinarList = new List<GlobalEventWebinarsModel>(dt.Rows.Count);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow data in dt.Rows)
                    {
                        OnDemandWebinarList.Add(new GlobalEventWebinarsModel
                        {
                            EventID = Convert.ToInt32(data["EventID"]),
                            Details = data["Details"].ToString(),
                            DateWithStartTime = data["DateWithStartTime"].ToString(),
                            Name = data["Name"].ToString(),
                            ImageUrl = data["ImageUrl"].ToString(),
                            URL = data["URl"].ToString(),
                            Sponsors = data["Sponsors"].ToString(),
                            EventDifferentType = data["EventDifferentType"].ToString(),
                            RouteURL = data["RouteURL"].ToString(),
                            IsSponcered = Convert.ToBoolean(data["IsSponcered"]),
                            Keywords = data["Keywords"].ToString(),

                        });
                    }

                }
                if (OnDemandWebinarList == null || OnDemandWebinarList.Count == 0)
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






    }
}
