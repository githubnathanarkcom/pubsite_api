using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PubsiteApi.Models;

namespace PubsiteApi.Controllers
{
    public class SessionController : ApiController
    {
        private SqlConnection scon = null;
        private SqlCommand sqlCmd = null;
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

        [HttpPost]
        public IHttpActionResult Navigation([FromBody]SessionModel sessionModel)
        {
            //try
            //{
            //    string url = sessionModel.Url;
            //    sessionModel.Url = sessionModel.PreviousUrl;
            //    NavigationEnd(sessionModel);
            //    sessionModel.Url = url;
            //    NavigationBegin(sessionModel);
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}

            return Ok();
        }

        [HttpPost]
        public IHttpActionResult NavigationBegin([FromBody]SessionModel sessionModel)
        {
            //try
            //{
            //    Connection();
            //    sqlCmd = new SqlCommand();
            //    sqlCmd.CommandType = CommandType.StoredProcedure;
            //    sessionModel.SiteName = sessionModel.SiteName.ToLower();
            //    sessionModel.IPAddress = IpAddress;
            //    sessionModel.IPAddressConverted = Convert.ToInt64(ConvertFromIpAddressToInteger(sessionModel.IPAddress));
            //    sessionModel.Medium = Medium;
            //    if (string.IsNullOrWhiteSpace(sessionModel.Details))
            //        sessionModel.Details = null;
            //    sqlCmd.CommandType = CommandType.StoredProcedure;
            //    AddParameter("@UserID", sessionModel.UserID);
            //    AddParameter("@IPAddress", sessionModel.IPAddress);
            //    AddParameter("@IPAddressConverted", sessionModel.IPAddressConverted);
            //    AddParameter("@EmailID", sessionModel.EmailID);
            //    AddParameter("@SiteName", sessionModel.SiteName);
            //    AddParameter("@Medium", sessionModel.Medium);
            //    AddParameter("@Url", sessionModel.Url);
            //    AddParameter("@Details", sessionModel.Details);
            //    sqlCmd.CommandText = "NewPubsiteAPI_NavigationBegin";
            //    sqlCmd.Connection = scon;
            //    sqlCmd.Connection.Open();
            //    sqlCmd.ExecuteNonQuery();
            //    sqlCmd.Connection.Dispose();
            //    sqlCmd.Dispose();
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}

            return Ok();
        }

        public void AddParameter(string paramname, object paramvalue)
        {
            SqlParameter param = new SqlParameter(paramname, paramvalue);
            if (paramvalue == null)
            {
                param.Value = DBNull.Value;
            }
            sqlCmd.Parameters.Add(param);
        }


        [HttpPost]
        public IHttpActionResult NavigationEnd([FromBody]SessionModel sessionModel)
        {
            //try
            //{
            //    Connection();
            //    sqlCmd = new SqlCommand();
            //    sqlCmd.CommandType = CommandType.StoredProcedure;
            //    sessionModel.SiteName = sessionModel.SiteName.ToLower();
            //    sqlCmd.CommandType = CommandType.StoredProcedure;
            //    AddParameter("@UserID", sessionModel.UserID);
            //    AddParameter("@SiteName", sessionModel.SiteName);
            //    AddParameter("@Url", sessionModel.Url);
            //    sqlCmd.CommandText = "NewPubsiteAPI_NavigationEnd";
            //    sqlCmd.Connection = scon;
            //    sqlCmd.Connection.Open();
            //    sqlCmd.ExecuteNonQuery();
            //    sqlCmd.Connection.Dispose();
            //    sqlCmd.Dispose();
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}

            return Ok();
        }

        public static string IpAddress
        {
            get
            {
                string ipAdd = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

                if (string.IsNullOrEmpty(ipAdd))
                {
                    ipAdd = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                }

                return ipAdd;
            }
        }

        public static string Medium
        {
            get
            {
                string medium = null;
                Uri myUrl = System.Web.HttpContext.Current.Request.UrlReferrer;
                if (myUrl != null)
                {
                    medium = myUrl.AbsoluteUri.ToString();
                }

                return medium;
            }
        }

        private uint ConvertFromIpAddressToInteger(string ipAddress)
        {
            var address = System.Net.IPAddress.Parse(ipAddress);
            byte[] bytes = address.GetAddressBytes();

            // flip big-endian(network order) to little-endian
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(bytes);
            }

            return BitConverter.ToUInt32(bytes, 0);
        }
    }
}
