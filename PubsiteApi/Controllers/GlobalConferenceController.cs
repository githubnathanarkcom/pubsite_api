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
    public class GlobalConferenceController : ApiController
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
        [HttpGet]
        public IHttpActionResult GetAllGlobalFutureConference(string siteName)
        {
            string SiteName = string.Empty;
            IList<ConferenceModel> objConferenceModel = null;
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
                sqlCmd.CommandText = "PubsiteAPI_Global_GetAllGlobalFutureConference";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                objConferenceModel = new List<ConferenceModel>(dt.Rows.Count);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow data in dt.Rows)
                    {
                        objConferenceModel.Add(new ConferenceModel
                        {
                            EventID = Convert.ToInt32(data["EventID"]),
                            Country = data["Country"].ToString(),
                            StartEndDate = data["StartEndDate"].ToString(),
                            Details = data["Details"].ToString(),
                            Name = data["Name"].ToString(),
                            ImageUrl = data["ImageUrl"].ToString(),
                            IsSponcered = Convert.ToInt32(data["IsSponcered"]),
                            EventDifferentType= data["EventDifferentType"].ToString(),
                            RouteURL = data["RouteURL"].ToString()

                        });
                    }

                }
                if (objConferenceModel == null || objConferenceModel.Count == 0)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(objConferenceModel);
        }
        [HttpGet]
        public IHttpActionResult GetAllGlobalPastConference(string siteName)
        {
            string SiteName = string.Empty;
            IList<ConferenceModel> objConferenceModel = null;
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
                sqlCmd.CommandText = "PubsiteAPI_Global_GetAllGlobalPastConference";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                objConferenceModel = new List<ConferenceModel>(dt.Rows.Count);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow data in dt.Rows)
                    {
                        objConferenceModel.Add(new ConferenceModel
                        {
                            EventID = Convert.ToInt32(data["EventID"]),
                            Country = data["Country"].ToString(),
                            StartEndDate = data["StartEndDate"].ToString(),
                            Details = data["Details"].ToString(),
                            Name = data["Name"].ToString(),
                            ImageUrl = data["ImageUrl"].ToString(),
                            IsSponcered = Convert.ToInt32(data["IsSponcered"]),
                            EventDifferentType = data["EventDifferentType"].ToString(),
                            RouteURL = data["RouteURL"].ToString()
                        });
                    }

                }
                if (objConferenceModel == null || objConferenceModel.Count == 0)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(objConferenceModel);
        }
        [HttpGet]
        public IHttpActionResult GetAllGlobalConferenceResources(string siteName)
        {
            IList<ResourceConferenceModel> objResources = null;
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
                sqlCmd.CommandText = "PubsiteAPI_Global_Top2ConferenceResources";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                objResources = new List<ResourceConferenceModel>(dt.Rows.Count);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow data in dt.Rows)
                    {
                        objResources.Add(new ResourceConferenceModel
                        {
                            ID = Convert.ToInt32(data["ID"]),
                            keywords = data["keywords"].ToString(),
                            ResourceType = data["ResourceType"].ToString(),
                            ImageUrl = data["ImageUrl"].ToString(),
                            IsSponcered = Convert.ToInt32(data["IsSponcered"]),
                            RouteURL = data["RouteURL"].ToString(),
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
        public IHttpActionResult GetGlobalConferenceSpotLight(string siteName)
        {
            IList<SpotLightModel> objSpotLight = null;
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
                sqlCmd.CommandText = "PubsiteAPI_Global_GetGlobalConferenceSpotLight";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                objSpotLight = new List<SpotLightModel>(dt.Rows.Count);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow data in dt.Rows)
                    {
                        objSpotLight.Add(new SpotLightModel
                        {
                            EventID = Convert.ToInt32(data["EventID"]),
                            Name = data["Name"].ToString(),
                            ImageUrl = data["ImageUrl"].ToString(),
                            IsSponcered = Convert.ToInt32(data["IsSponcered"]),
                            RouteURL = data["RouteURL"].ToString(),
                            Description = data["Description"].ToString(),
                            
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
    }
}
