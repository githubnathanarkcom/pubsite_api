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
    public class DownloadController : ApiController
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
        [HttpPost]
        public IHttpActionResult Download([FromBody] DownloadModel p)
        {
            string SiteName = string.Empty;
            DownloadModel objDownloadModel = null;
            try
            {
                Connection();
                SqlCommand sqlCmd = new SqlCommand();
                //sqlCmd.CommandType = CommandType.StoredProcedure;
                //if (SiteName == string.Empty)
                //{
                //    if (model.SiteName.Contains("."))
                //        SiteName = model.SiteName.Split('.')[0].Trim();
                //    objDownloadModel = new DownloadModel
                //    {
                //        SiteName = model.SiteName.Trim(),
                //        ResourceID = model.ResourceID,
                //        Email = model.Email.Trim(),
                //        IPAddress = model.IPAddress.Trim(),
                //        AcceptTermsOnDownload = model.AcceptTermsOnDownload,
                //        ResourceType = model.ResourceType.Trim()
                        
                //    };
                //    sqlCmd.Parameters.AddWithValue("@SiteName", objDownloadModel.SiteName);
                //    sqlCmd.Parameters.AddWithValue("@Email", objDownloadModel.Email);
                //    sqlCmd.Parameters.AddWithValue("@ActiveTermsandPolicy", objDownloadModel.AcceptTermsOnDownload);
                //    sqlCmd.Parameters.AddWithValue("@IP", objDownloadModel.IPAddress);
                //    sqlCmd.Parameters.AddWithValue("@ResourceID", objDownloadModel.ResourceID);
                //    sqlCmd.Parameters.AddWithValue("@ResourceType", objDownloadModel.ResourceType);
                //    sqlCmd.CommandText = "PubsiteAPI_Download_DownloadDetails";
                //    sqlCmd.Connection = scon;
                //    scon.Open();
                //    sqlCmd.ExecuteScalar();//sqlCmd.ExecuteNonQuery();
                //    scon.Close();
                //}


            }
            catch (Exception ex)
            {
                throw ex;
            }



            return Ok(objDownloadModel);
        }
    }
}
