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
    public class GlobalWebinarController : ApiController
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
        public IHttpActionResult GetAllLiveWebinars(string siteName)
        {
            IList<GlobalWebinarsModel> newsGlobalWebinarsModel = null;
            string SiteName = string.Empty;
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
                sqlCmd.CommandText = "PubsiteAPI_Global_GetAllLiveWebinars";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                newsGlobalWebinarsModel = new List<GlobalWebinarsModel>(dt.Rows.Count);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow data in dt.Rows)
                    {
                        newsGlobalWebinarsModel.Add(new GlobalWebinarsModel
                        {
                            EventID = Convert.ToInt32(data["EventID"]),
                            Details = data["Details"].ToString(),
                            DateWithStartTime = data["DateWithStartTime"].ToString(),
                            Name = data["Name"].ToString(),
                            ImageUrl = data["ImageUrl"].ToString(),
                            URL = data["URl"].ToString(),
                            RouteURL = data["RouteURL"].ToString(),
                            EventDifferentType= data["EventDifferentType"].ToString(),

                            IsSponcered = Convert.ToInt32(data["IsSponcered"]),
                        });
                    }

                }
                if (newsGlobalWebinarsModel == null || newsGlobalWebinarsModel.Count == 0)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Ok(newsGlobalWebinarsModel);
        }
        [HttpGet]
        public IHttpActionResult GetAllOnDemandWebinars(string siteName)
        {
            IList<GlobalWebinarsModel> newsGlobalWebinarsModel = null;
            string SiteName = string.Empty;
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
                sqlCmd.CommandText = "PubsiteAPI_Global_GetAllOnDemandWebinars";
                sqlCmd.Connection = scon;

                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                newsGlobalWebinarsModel = new List<GlobalWebinarsModel>(dt.Rows.Count);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow data in dt.Rows)
                    {
                        newsGlobalWebinarsModel.Add(new GlobalWebinarsModel
                        {
                            EventID = Convert.ToInt32(data["EventID"]),
                            Details = data["Details"].ToString(),
                            DateWithStartTime = data["DateWithStartTime"].ToString(),
                            Name = data["Name"].ToString(),
                            ImageUrl = data["ImageUrl"].ToString(),
                            URL = data["URl"].ToString(),
                            RouteURL = data["RouteURL"].ToString(),
                            EventDifferentType = data["EventDifferentType"].ToString(),
                            IsSponcered = Convert.ToInt32(data["IsSponcered"]),
                        });
                    }

                }
                if (newsGlobalWebinarsModel == null || newsGlobalWebinarsModel.Count == 0)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Ok(newsGlobalWebinarsModel);
        }
    }
}
