using PubsiteApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Security;
using System.Globalization;
using System.Text;

namespace PubsiteApi.Controllers
{
    public class AllFormsController : ApiController
    {
        private SqlConnection scon = null;
        private SqlConnection m7con = null;
        private SqlConnection genecon = null;

        public string siteLogo;
        public string siteURL;
        public string pubsiteName;
        public string smtpHost;

         
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

        private void M7Connection()
        {
            try
            {
                m7con = new SqlConnection("Data Source=3.108.12.178;User ID=NAMEDIA7io1;Initial Catalog=NAMEDIA7io; Password=L/[BBe9D");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void GeneConnection()
        {
            try
            {
                genecon = new SqlConnection("Data Source=3.108.12.178;User ID=GeneReport1;Initial Catalog=GeneReport; Password=75j]G)sC");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void AllSites(string Sitename)
        {
            try
            {
                #region switch

                switch (Sitename.ToLower())
                {
                    case "abm.report":
                        siteLogo = "https://ABM.Report/images/ABM.PNG";
                        siteURL = "https://abm.report";
                        pubsiteName = "The ABM Report";
                        smtpHost = "smtp-relay.abm.report";

                        break;

                    case "advertising.report":
                        siteLogo = "https://advertising.Report/images/advertising.PNG";
                        siteURL = "https://advertising.report";
                        pubsiteName = "The Advertising Report";
                        smtpHost = "smtp-relay.advertising.report";

                        break;

                    case "aviation.report":
                        siteLogo = "https://aviation.Report/images/aviation.PNG";
                        siteURL = "https://aviation.report";
                        pubsiteName = "The Aviation Report";
                        smtpHost = "smtp-relay.aviation.report";

                        break;

                    case "biotechnology.report":
                        siteLogo = "https://biotechnology.Report/images/biotechnology.PNG";
                        siteURL = "https://biotechnology.report";
                        pubsiteName = "The Biotechnology Report";
                        smtpHost = "smtp-relay.biotechnology.report";

                        break;

                    case "biotech.report":
                        siteLogo = "https://biotech.Report/images/biotech.PNG";
                        siteURL = "https://biotech.report";
                        pubsiteName = "The Biotech Report";
                        smtpHost = "smtp-relay.biotech.report";

                        break;

                    case "capital.report":
                        siteLogo = "https://capital.Report/images/capital.PNG";
                        siteURL = "https://capital.report";
                        pubsiteName = "The Capital Report";
                        smtpHost = "smtp-relay.capital.report";

                        break;

                    case "channel.report":
                        siteLogo = "https://channel.Report/images/channel.PNG";
                        siteURL = "https://channel.report";
                        pubsiteName = "The Channel Report";
                        smtpHost = "smtp-relay.channel.report";

                        break;


                    case "chemical.report":
                        siteLogo = "https://chemical.Report/images/chemical.PNG";
                        siteURL = "https://chemical.report";
                        pubsiteName = "The Chemical Report";
                        smtpHost = "smtp-relay.chemical.report";

                        break;

                    case "cloud.report":
                        siteLogo = "https://cloud.Report/images/cloud.PNG";
                        siteURL = "https://cloud.report";
                        pubsiteName = "The Cloud Report";
                        smtpHost = "smtp-relay.cloud.report";

                        break;

                    case "dataanalytics.report":
                        siteLogo = "https://dataanalytics.Report/images/dataanalytics.PNG";
                        siteURL = "https://dataanalytics.report";
                        pubsiteName = "The Data Analytics Report";
                        smtpHost = "smtp-relay.dataanalytics.report";

                        break;

                    case "engineering.report":
                        siteLogo = "https://engineering.Report/images/engineering.PNG";
                        siteURL = "https://engineering.report";
                        pubsiteName = "The Engineering Report";
                        smtpHost = "smtp-relay.engineering.report";

                        break;

                    case "government.report":
                        siteLogo = "https://government.Report/images/government.PNG";
                        siteURL = "https://government.report";
                        pubsiteName = "The Government Report";
                        smtpHost = "smtp-relay.government.report";

                        break;

                    case "greenenergy.report":
                        siteLogo = "https://greenenergy.Report/images/greenenergy.PNG";
                        siteURL = "https://greenenergy.report";
                        pubsiteName = "The Green Energy Report";
                        smtpHost = "smtp-relay.greenenergy.report";

                        break;

                    case "healthcare.report":
                        siteLogo = "https://healthcare.Report/images/healthcare.PNG";
                        siteURL = "https://healthcare.report";
                        pubsiteName = "The Healthcare Report";
                        smtpHost = "smtp-relay.healthcare.report";

                        break;

                    case "humanresources.report":
                        siteLogo = "https://humanresources.Report/images/humanresources.PNG";
                        siteURL = "https://humanresources.report";
                        pubsiteName = "The Human Resources Report";
                        smtpHost = "smtp-relay.humanresources.report";

                        break;

                    case "informationsecurity.report":
                        siteLogo = "https://informationsecurity.Report/images/informationsecurity.PNG";
                        siteURL = "https://informationsecurity.report";
                        pubsiteName = "The Information Security Report";
                        smtpHost = "smtp-relay.informationsecurity.report";

                        break;

                    case "infotech.report":
                        siteLogo = "https://infotech.Report/images/infotech.PNG";
                        siteURL = "https://infotech.report";
                        pubsiteName = "The Infotech Report";
                        smtpHost = "smtp-relay.infotech.report";

                        break;

                    case "itinfrastructure.report":
                        siteLogo = "https://itinfrastructure.Report/images/itinfrastructure.PNG";
                        siteURL = "https://itinfrastructure.report";
                        pubsiteName = "The IT Infrastructure Report";
                        smtpHost = "smtp-relay.itinfrastructure.report";

                        break;

                    case "manufacturing.report":
                        siteLogo = "https://manufacturing.Report/images/manufacturing.PNG";
                        siteURL = "https://manufacturing.report";
                        pubsiteName = "The Manufacturing Report";
                        smtpHost = "smtp-relay.manufacturing.report";

                        break;

                    case "networking.report":
                        siteLogo = "https://networking.Report/images/networking.PNG";
                        siteURL = "https://networking.report";
                        pubsiteName = "The Networking Report";
                        smtpHost = "smtp-relay.networking.report";

                        break;

                    case "nonprofit.report":
                        siteLogo = "https://nonprofit.Report/images/nonprofit.PNG";
                        siteURL = "https://nonprofit.report";
                        pubsiteName = "The NonProfit Report";
                        smtpHost = "smtp-relay.nonprofit.report";

                        break;

                    case "pharmaceutical.report":
                        siteLogo = "https://pharmaceutical.Report/images/pharmaceutical.PNG";
                        siteURL = "https://pharmaceutical.report";
                        pubsiteName = "The Pharmaceutical Report";
                        smtpHost = "smtp-relay.pharmaceutical.report";

                        break;

                    case "re.report":
                        siteLogo = "https://re.Report/images/re.PNG";
                        siteURL = "https://re.report";
                        pubsiteName = "The RE Report";
                        smtpHost = "smtp-relay.re.report";

                        break;

                    case "smallbusiness.report":
                        siteLogo = "https://smallbusiness.Report/images/smallbusiness.PNG";
                        siteURL = "https://smallbusiness.report";
                        pubsiteName = "The Small Business Report";
                        smtpHost = "smtp-relay.smallbusiness.report";

                        break;

                    case "virtualization.network":
                        siteLogo = "https://virtualization.network/images/virtualization.PNG";
                        siteURL = "https://virtualization.network";
                        pubsiteName = "The Virtualization Report";
                        smtpHost = "smtp-relay.virtualization.report";

                        break;

                    case "wheels.report":
                        siteLogo = "https://wheels.Report/images/wheels.PNG";
                        siteURL = "https://wheels.report";
                        pubsiteName = "The Wheels Report";
                        smtpHost = "smtp-relay.wheels.report";

                        break;

                    case "theinternetofthings.report":
                        siteLogo = "https://theinternetofthings.Report/images/theinternetofthings.PNG";
                        siteURL = "https://theinternetofthings.report";
                        pubsiteName = "The Internet of Things Report";
                        smtpHost = "smtp-relay.theinternetofthings.report";

                        break;

                    case "policy.report":
                        siteLogo = "https://policy.Report/images/policy.PNG";
                        siteURL = "https://policy.report";
                        pubsiteName = "The Policy Report";
                        smtpHost = "smtp-relay.policy.report";

                        break;


                    case "entertainment.report":
                        siteLogo = "https://entertainment.Report/images/entertainment.PNG";
                        siteURL = "https://entertainment.report";
                        pubsiteName = "The Entertainment Report";
                        smtpHost = "smtp-relay.entertainment.report";

                        break;

                    case "travel.report":
                        siteLogo = "https://travel.Report/images/travel.PNG";
                        siteURL = "https://travel.report";
                        pubsiteName = "The Travel Report";
                        smtpHost = "smtp-relay.travel.report";

                        break;

                    case "pos.report":
                        siteLogo = "https://pos.Report/images/pos.PNG";
                        siteURL = "https://pos.report";
                        pubsiteName = "The POS Report";
                        smtpHost = "smtp-relay.pos.report";

                        break;

                    case "education.report":
                        siteLogo = "https://education.Report/images/education.PNG";
                        siteURL = "https://education.report";
                        pubsiteName = "The Education Report";
                        smtpHost = "smtp-relay.education.report";

                        break;

                    default:

                        break;
                }

                #endregion
            }
            catch (Exception ex)
            {

            }

        }

        private void AdminEmailSent(string Email, string siteName)
        {
            try
            {
                #region EmailCommentedCode
                string concateString = string.Empty;

                string msg = string.Empty;
                string body = string.Empty;
                MailMessage message = new MailMessage();

                AutoRespondEmailParametersModel objEmail = new AutoRespondEmailParametersModel();
                string DomainName = "abm.report"; //HttpContext.Current.Request.Url.Host;
                string SiteName = siteName.Trim().ToLower(); //DomainName.ToLower();
                concateString = String.Concat(SiteName, ".report");
                //DataSet dsEmail = AutoRespondMail.GetAutoRespondEmailIDs(SiteName);
                AllSites(concateString.Trim());
                //if (dsEmail.Tables.Count > 0 && dsEmail.Tables[0].Rows.Count > 0 && dsEmail != null)
                //{
                //    objEmail.From = dsEmail.Tables[0].Rows[0]["Email"].ToString();
                //    objEmail.Password = AutoRespondMail.Decrypt(dsEmail.Tables[0].Rows[0]["Password"].ToString());
                //}
                string path = HttpContext.Current.Server.MapPath("~/HtmlTemplateAutoRespond/AdminNewsletterSubscriptionEmail.htm");

                using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("~/HtmlTemplateAutoRespond/AdminNewsletterSubscriptionEmail.htm")))
                {
                    body = reader.ReadToEnd();
                }
                //body = body.Replace("{Email}", " " + Email);//
                body = body.Replace("{Email}", " "+ "ankit@nathanark.com");
                body = body.Replace("{Pubsite}", " " + DomainName);

                #region Admin-1 email
                string mssg1 = string.Empty;
                SmtpClient smtpClient = new SmtpClient();

                //// Now lets create an email message
                try
                {

                    #region With-htmltemplate
                    objEmail.From = "ankit@nathanark.com";
                   // objEmail.Password = AutoRespondMail.Decrypt(dsEmail.Tables[0].Rows[0]["Password"].ToString());
                  //  objEmail.From = ;
                    MailAddress fromAddress = new MailAddress(objEmail.From, pubsiteName);
                    message.From = fromAddress;
                    message.To.Add("ankit@nathanark.com");
                  //  message.To.Add("micah@media7.io");
                    message.Subject = DomainName + " | " + Email + " registered for Newsletter Subscription";
                    message.IsBodyHtml = true;
                    AlternateView htmlView = AlternateView.CreateAlternateViewFromString(body, null, "text/html");
                    message.AlternateViews.Add(htmlView);
                    smtpClient.Host = smtpHost;
                    smtpClient.Port = 25;
                    smtpClient.EnableSsl = false;
                    smtpClient.UseDefaultCredentials = true;
                   // smtpClient.Credentials = new System.Net.NetworkCredential(objEmail.From, objEmail.Password);
                    smtpClient.Credentials = new System.Net.NetworkCredential(objEmail.From,"ABC232323");
                    smtpClient.Send(message);
                    msg = "Successful";
                    #endregion
                }
                catch (Exception ex)
                {
                    mssg1 = ex.Message;
                }
                #endregion

                #endregion
            }
            catch (Exception ex)
            {

            }
        }


        private void NewsletterMailService(string Email, string Sitename)
        {
            try
            {
                //TextBox password = (TextBox)FindControl("Password123");
                string username = Email;
               

                #region NewRegistrationMail

                string Name = Email;
                string msg = string.Empty;
                string from = "members@media7.io";
                MailMessage message = new MailMessage();
                SmtpClient smtpClient = new SmtpClient();

                //string userName = txt_Name.Text.Trim();
                ////  Get the user's id
                //Guid userId = (Guid)Membership.GetUser(userName).ProviderUserKey;
                string Subject = "News Letter Subscription " + Sitename;
                TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
                //userName = textInfo.ToTitleCase(userName);
                #region Message Body

                string body = string.Empty;
                //using streamreader for reading my htmltemplate   

                using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("~/HtmlTemplates/NewsletterPubsite.htm")))
                {
                    body = reader.ReadToEnd();
                }

                 

                body = body.Replace("{UserName}", Email);

                #region switch

                switch (Sitename.ToLower())
                {
                    case "abm.report":
                        body = body.Replace("{SiteName}", "ABM Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "");
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "ABM Report");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/ABM.report/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/abm-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/101910112412726385876");
                        body = body.Replace("http://tw.com", "https://twitter.com/report_abm");

                        break;

                    case "advertising.report":
                        body = body.Replace("{SiteName}", "Advertising Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "");
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Advertising Report");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Advertising.Report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/advertising.report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/111655297844529108876?hl=en");
                        body = body.Replace("http://tw.com", "https://twitter.com/advertisingrep3");

                        break;

                    case "aviation.report":
                        body = body.Replace("{SiteName}", "Aviation Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "");
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Aviation Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");
                        
                        body = body.Replace("http://fb.com", "https://www.facebook.com/The.Aviation.report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/aviation.report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/114280654416467366288");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "biotechnology.report":
                        body = body.Replace("{SiteName}", "Biotechnology Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "");
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Biotechnology Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Biotechnology.report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/the-biotechnology-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/114330393539843196461");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "biotech.report":
                        body = body.Replace("{SiteName}", "Biotech Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "");
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Biotech Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Biotechnology.report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/the-biotechnology-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/114330393539843196461");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "capital.report":
                        body = body.Replace("{SiteName}", "Capital Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "");
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Capital Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Capital.Report/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/the-capital-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/107769852942524763370");
                        body = body.Replace("http://tw.com", "https://twitter.com/CapitalReport2");

                        break;

                    case "channel.report":
                        body = body.Replace("{SiteName}", "Channel Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "");
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Channel Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/channel.report/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/the-channel-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/113549242602470470843");
                        body = body.Replace("http://tw.com", "");

                        break;


                    case "chemical.report":
                        body = body.Replace("{SiteName}", "Chemical Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "");
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Chemical Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/TheChemicalReport/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/chemical-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/116230049211920401445");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "cloud.report":
                        body = body.Replace("{SiteName}", "Cloud Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "");
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Cloud Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Cloud.Computing.Report/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/cloud-report1");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/104795079924552291803");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "dataanalytics.report":
                        body = body.Replace("{SiteName}", "Data Analytics Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "");
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Data Analytics Report");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/DataAnalytics.Report/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/dataanalytics-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/109579208390025894184");
                        body = body.Replace("http://tw.com", "https://twitter.com/DataAnalyticsR2");

                        break;

                    case "engineering.report":
                        body = body.Replace("{SiteName}", "Engineering Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "");
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Engineering Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Engineering.report/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/engineering.report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/111873872000949600820");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "government.report":
                        body = body.Replace("{SiteName}", "Government Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "");
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Government Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/government.report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/governmentreport");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/116648347583223320296");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "greenenergy.report":
                        body = body.Replace("{SiteName}", "Green Energy Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "");
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Green Energy Report");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/GreenEnergy.report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/greenenergy-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/113290459189685686116");
                        body = body.Replace("http://tw.com", "https://twitter.com/GreenenergyRpt");

                        break;

                    case "healthcare.report":
                        body = body.Replace("{SiteName}", "Healthcare Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "");
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Healthcare Report");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Healthcare.report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/the-healthcare-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/102740252830492716604");
                        body = body.Replace("http://tw.com", "https://twitter.com/HealthcareRepo3");

                        break;

                    case "humanresources.report":
                        body = body.Replace("{SiteName}", "Human Resources Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "");
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Human Resources Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/HumanResources.Report/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/the-humanresources-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/100109770568281030209?hl=en");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "informationsecurity.report":
                        body = body.Replace("{SiteName}", "Information Security Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "");
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Information Security Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/InfoSec.report/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/informationsecurity-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/105616685142612477389?hl=en");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "infotech.report":
                        body = body.Replace("{SiteName}", "Infotech Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "");
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Infotech Report");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/TheInfotechReport/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/the-infotech-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/106513072017905681069?hl=en");
                        body = body.Replace("http://tw.com", "https://twitter.com/infotechreport1");

                        break;

                    case "itinfrastructure.report":
                        body = body.Replace("{SiteName}", "IT Infrastructure Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "");
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "IT Infrastructure Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/ITInfrastructure.report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/itinfrastructure.report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/108767760557877157552");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "manufacturing.report":
                        body = body.Replace("{SiteName}", "Manufacturing Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "");
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Manufacturing Report");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Manufacturing.report/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/manufacturing.report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/106669125275878359478");
                        body = body.Replace("http://tw.com", "https://twitter.com/manufactringre1");

                        break;

                    case "networking.report":
                        body = body.Replace("{SiteName}", "Networking Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".png");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "");
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Networking Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Networking.Report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/networking.report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/106717057722806432373?hl=en");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "nonprofit.report":
                        body = body.Replace("{SiteName}", "Nonprofit Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "");
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Nonprofit Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Nonprofit.report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/nonprofit.report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/108697591802812816511");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "pharmaceutical.report":
                        body = body.Replace("{SiteName}", "Pharmaceutical Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "");
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Pharmaceutical Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Pharmaceutical.Report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/pharmaceutical.report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/101913904421328496543");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "re.report":
                        body = body.Replace("{SiteName}", "Re Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "");
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Re Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/REindustry/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/re.report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/117037258095616008539");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "smallbusiness.report":
                        body = body.Replace("{SiteName}", "Small Business Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "");
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Small Business Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/SmallBusinessReport/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/small-business.report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/100798315370811914608");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "virtualization.network":
                        body = body.Replace("{SiteName}", "Virtualization Network");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "");
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Virtualization Network");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Virtualization.Network");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/virtualization.network");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/105732599757951132641");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "wheels.report":
                        body = body.Replace("{SiteName}", "Wheels Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".png");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "");
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Wheels Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Wheels.report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/wheels-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/u/0/b/107965575776548533362/107965575776548533362/about");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "theinternetofthings.report":
                        body = body.Replace("{SiteName}", "Internet of Things Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "");
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/TheInternetofThings.Report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/theinternetofthings-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/b/102236961973983653868/102236961973983653868/about?gmbpt=Y&hl=en");
                        body = body.Replace("http://tw.com", "https://twitter.com/TheInternetofT3");
                        break;

                    case "policy.report":
                        body = body.Replace("{SiteName}", "Policy Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "");
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Policy Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/policyreport/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/policy-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/100211751164866148397");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "entertainment.report":
                        body = body.Replace("{SiteName}", "Entertainment Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "");
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Entertainment Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/The.Entertainment.Report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/entertainment-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/103395655859112296888");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "travel.report":
                        body = body.Replace("{SiteName}", "Travel Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "");
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Travel Report");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/TheTravelReport/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/travel.report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/102425791186500234009");
                        body = body.Replace("http://tw.com", "https://twitter.com/Travelreport2");

                        break;

                    case "pos.report":
                        body = body.Replace("{SiteName}", "POS Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "");
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "POS Report");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/POSReport");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/pos.report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/111653842294237696457");
                        body = body.Replace("http://tw.com", "https://twitter.com/ReportPos");

                        break;

                    case "education.report":
                        body = body.Replace("{SiteName}", "Education Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "");
                        body = body.Replace("Internet of Things Report", "Education Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Education.report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/education.report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/108088234985181110758");
                        body = body.Replace("http://tw.com", "");
                        

                        break;

                    default:
                        body = body.Replace("http://fb.com", "https://www.facebook.com/TheInternetofThings.Report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/theinternetofthings-report%C2%A0");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/b/102236961973983653868/102236961973983653868/about?gmbpt=Y&hl=en");
                        body = body.Replace("http://tw.com", "https://twitter.com/InternetofThe");

                        //body = body.Replace("{SiteName}", "Internet of Things Report");
                        //body = body.Replace("http://media7.io/new/Login.aspx", "http://theinternetofthings.report/Home.aspx?user=" + userId);
                        body = body.Replace("{SiteName}", "Internet of Things Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "");
                        break;
                }
                #endregion

                //body = body.Replace("http://media7.io/new/Login.aspx", "http://localhost:5400/media7.io/new/Login.aspx?user=" + userId);
                //string url = "http://localhost:5400/media7.io/new/Login.aspx?user=" + userId;
                //body = body.Replace("{Password}", password); //replacing the required things  
                //body = body.Replace("{Title}", "Thank you for reaching out to us and giving Deck 7 the opportunity to enhance your digital marketing outreach. Within 24 hours, one of our account managers or specialists will be reaching back to you either by email or phone regarding your requested information. For immediate questions or requests feel free to call our home office at 1.619.900.9595 or 1.844.900.9595 Toll Free between 9am and 5pm PST.");
                //body = body.Replace("{message}", "<br />Looking forward to speaking soon!");
                //body = body.Replace("{EmailId}", txt_Email.Text.Trim());
                #endregion

                try
                {
                    string displayName = Sitename + " NewsLetter";
                    displayName = textInfo.ToTitleCase(displayName);
                    displayName = displayName.Replace(".Report", ".report");
                    MailAddress fromAddress = new MailAddress(from, displayName);
                    message.From = fromAddress;
                    //message.To.Add("ankit@nathanark.com");
                    //message.To.Add("micah@media7.io");
                    message.To.Add("madhav.shevde@machintel.net");
                    message.To.Add("bhushan.salkar@machintel.net");
                    #region Hardcoded
                    message.Subject = Subject;
                    message.IsBodyHtml = true;

                    AlternateView htmlView = AlternateView.CreateAlternateViewFromString(body, null, "text/html");
                    message.AlternateViews.Add(htmlView);

                    smtpClient.Host = "smtp-relay.sendinblue.com";
                    smtpClient.Port = 587;
                    smtpClient.EnableSsl = false;
                    smtpClient.UseDefaultCredentials = true;
                    smtpClient.Credentials = new System.Net.NetworkCredential("manju@deck7marketing.com", "1sqWbrZjMaTpzRHx");
                    //smtpClient.Credentials = new System.Net.NetworkCredential("suraj@deck7.io", "qIHZDcpAftj0XROU");
                    smtpClient.Send(message);
                    msg = "Successful";
                    #endregion
                }
                catch (Exception ex)
                {
                    msg = ex.Message;
                }
                #endregion
            }
            catch (Exception ex)
            { }
        }


        [HttpPost]
        public string NewsLetterSignUp(NewsLetterSignup objNewsLetterSignup)
        {
            string Check = "error";
            string SiteName = string.Empty; int terms = 0;
           try
            {               
                Connection();
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                if (SiteName == string.Empty )
                {                   
                    if (objNewsLetterSignup.siteName.Contains("."))
                    {
                        SiteName = objNewsLetterSignup.siteName.Split('.')[0].Trim();
                    }
                    if (objNewsLetterSignup.acceptTerms == true)
                    { terms = 1; }

                    sqlCmd.Parameters.AddWithValue("@SiteName", SiteName);
                    sqlCmd.Parameters.AddWithValue("@Email", objNewsLetterSignup.email);
                    sqlCmd.Parameters.AddWithValue("@ActiveTermsandPolicy", terms);
                    sqlCmd.Parameters.AddWithValue("@IP", objNewsLetterSignup.IP);
                    sqlCmd.CommandText = "PubsiteAPI_News_AddNewsletterSubscriptions";
                    sqlCmd.Connection = scon;
                    scon.Open();
                    int result = (int)sqlCmd.ExecuteScalar();//sqlCmd.ExecuteNonQuery();
                    scon.Close();
                    Check = "Created";
                    NewsletterMailService(objNewsLetterSignup.email, objNewsLetterSignup.siteName);
                }                               
            }
            catch (Exception ex)
            {
                
            }                        
            return Check;
        }

        [HttpPost]
        public string Login(LoginModel onjLoginModel)
        {
            string check = "";


            int siteid = GetSiteId(onjLoginModel.sitename);

            if (Membership.ValidateUser(onjLoginModel.email, onjLoginModel.password))
            {
                MembershipUser mu = Membership.GetUser(onjLoginModel.email);
                string userId = mu.ProviderUserKey.ToString();

                if (Roles.IsUserInRole(onjLoginModel.email, "Advertiser"))
                {
                    check = "Advertiser";
                }
                else if (Roles.IsUserInRole(onjLoginModel.email, "Publisher"))
                {

                    DataSet set = CheckUserActivation(userId, siteid);
                    if (set.Tables.Count > 0 && set.Tables[0].Rows.Count > 0 && set != null)
                    {
                        if (set.Tables[0].Rows[0][0].ToString().ToLower() == "exist")
                        {
                            if (set.Tables.Count > 0 && set.Tables[1].Rows.Count > 0 && set != null)
                            {
                                check = "Publisher";
                            }
                            else
                            {
                                check = "not active";
                            }
                        }
                        else
                        {
                            check = "not exist";
                        }
                    }

                }
                else if (Roles.IsUserInRole(onjLoginModel.email, "GuestAuthor"))
                {

                    DataSet set = CheckUserActivation(userId, siteid);
                    if (set.Tables.Count > 0 && set.Tables[0].Rows.Count > 0 && set != null)
                    {
                        if (set.Tables[0].Rows[0][0].ToString().ToLower() == "exist")
                        {
                            if (set.Tables.Count > 0 && set.Tables[1].Rows.Count > 0 && set != null)
                            {
                                check = "GuestAuthor";
                            }
                            else
                            {
                                check = "not active";
                            }
                        }
                        else
                        {
                            check = "not exist";
                        }
                    }
                }
                else if (Roles.IsUserInRole(onjLoginModel.email, "Agency"))
                {
                    check = "Agency";
                }
                else if (Roles.IsUserInRole(onjLoginModel.email, "Other"))
                {
                    check = "Other";
                }
            }
            else
            {
                check = "Invalid";
            }

            return check;
        }
        //Dummy API for testing purpose
        //[HttpPost]
        //public string DummyAPI([FromBody] DummyData objDummyDataModel)
        ////public IHttpActionResult SignUp(string firstName, string lastName, string email, string password, string role, int acceptTerms, string siteName)
        //{
        //    string check = "";
        //    try
        //    {

        //        check = DummyAPI(objDummyDataModel.Email);

        //        //check = SignupWithTermsPolicy(firstName, lastName, email, password, siteName, acceptTerms, role);

        //    }
        //    catch (Exception ex)
        //    {
        //        check = ex.Message;
        //    }
        //    return check;
        //}

        [HttpPost]        
        public string SignUp([FromBody] SignUpModel objSignUpModel)
        //public IHttpActionResult SignUp(string firstName, string lastName, string email, string password, string role, int acceptTerms, string siteName)
        {
            string check = "";int terms = 0;
            try
            {
                if(objSignUpModel.acceptTerms==true)
                { terms = 1; }

                check = SignupWithTermsPolicy(objSignUpModel.firstName, objSignUpModel.lastName, objSignUpModel.email, objSignUpModel.password, objSignUpModel.siteName, terms, objSignUpModel.role);

                //check = SignupWithTermsPolicy(firstName, lastName, email, password, siteName, acceptTerms, role);

                if (check == "New User")
                {
                    check = "An email has been sent to you with your sign up confirmation. Click on the link in the email to verify your email address.";
                }
                else if (check == "Pubsite User")
                {
                   check = "An email has been sent to you with your sign up confirmation. Click on the link in the email to verify your email address.";
                }
                else if (check == "Advertiser" || check == "Agency")
                {
                    check = "You already signed up using this email id as an " + check + " on Media 7";
                }
                else
                {
                    check = "Please use a different username. An account with this username already exist.";
                }
            }
            catch (Exception ex)
            {
                check = ex.Message;
            }
            return check;
        }


        [HttpPost]        
        public string AdvertiseMainSignUp([FromBody] SignUpModel objSignUpModel)
        //public IHttpActionResult SignUp(string firstName, string lastName, string email, string password, string role, int acceptTerms, string siteName)
        {
            string check = "";int terms = 0;
            try
            {
                if(objSignUpModel.acceptTerms==true)
                { terms = 1; }

                check = SignupWithAdvertiseTermsPolicy(objSignUpModel.firstName, objSignUpModel.lastName, objSignUpModel.email, objSignUpModel.password, objSignUpModel.siteName, terms, objSignUpModel.role);

                //check = SignupWithTermsPolicy(firstName, lastName, email, password, siteName, acceptTerms, role);

                if (check == "New User")
                {
                    check = "An email has been sent to you with your sign up confirmation. Click on the link in the email to verify your email address.";
                }
                else if (check == "Pubsite User")
                {
                   check = "An email has been sent to you with your sign up confirmation. Click on the link in the email to verify your email address.";
                }
                else if (check == "Advertiser" || check == "Agency")
                {
                    check = "You already signed up using this email id as an " + check + " on Media 7";
                }
                else
                {
                    check = "Please use a different username. An account with this username already exist.";
                }
            }
            catch (Exception ex)
            {
                check = ex.Message;
            }
            return check;
        }


        [HttpPost]        
        public string AdvertiseSignUp([FromBody] AdvertiseSignUpModel objadvertiseSignUpModel)
        //public IHttpActionResult SignUp(string firstName, string lastName, string email, string password, string role, int acceptTerms, string siteName)
        {
            string check = "";int terms = 0;
            try
            {

                check = SignupWithAdvertiseTermsPolicy(objadvertiseSignUpModel.Name, objadvertiseSignUpModel.Company, objadvertiseSignUpModel.Email, objadvertiseSignUpModel.Phone);

                //check = SignupWithTermsPolicy(firstName, lastName, email, password, siteName, acceptTerms, role);

                //if (check == "New User")
                //{
                    check = "Thank you for requesting the MEDIA 7 kit.We will send it over to you shortly";
                //}
                //else if (check == "Pubsite User")
                //{
                //   check = "An email has been sent to you with your sign up confirmation. Click on the link in the email to verify your email address.";
                //}
                //else if (check == "Advertiser" || check == "Agency")
                //{
                //    check = "You already signed up using this email id as an " + check + " on Media 7";
                //}
                //else
                //{
                //    check = "Please use a different username. An account with this username already exist.";
                //}
            }
            catch (Exception ex)
            {
                check = ex.Message;
            }
            return check;
        }


        private DataSet CheckUserActivation(string UserId, int siteid)
        {
            DataSet ds = new DataSet();
            try
            {                
                M7Connection();
                SqlCommand sqlCmd1 = new SqlCommand();
                sqlCmd1.CommandType = CommandType.StoredProcedure;
                sqlCmd1.Parameters.AddWithValue("@UserId", UserId);
                sqlCmd1.Parameters.AddWithValue("@siteid", siteid);
                sqlCmd1.CommandText = "SpCheckSiteUserActivation";
                sqlCmd1.Connection = m7con;
                SqlDataAdapter sda1 = new SqlDataAdapter(sqlCmd1);
                sda1.Fill(ds);
            }
            catch (Exception ex)
            {

            }
            return ds;
        }

        private string SignupWithTermsPolicy(string FName, string LName, string Email, string Password,string SiteName, int Terms, string Role)
        {
            string check = "";
             
            string userId = "";
            userId = Membership.GetUserNameByEmail(Email.ToLower());

            int siteid = GetSiteId(SiteName);
            
            if (userId != "" && userId != null)
            {
                if (Roles.IsUserInRole(Email, "Publisher") || Roles.IsUserInRole(Email, "Other") || Roles.IsUserInRole(Email, "GuestAuthor"))
                {
                    DataSet set = CheckUserForPubsite(Email, siteid);

                    if (set.Tables.Count > 0 && set.Tables[0].Rows.Count > 0 && set != null)
                    {
                        check = "Already Exist";
                    }
                    else
                    {
                        ExistingUserMailService(Email, FName, Password, siteid, SiteName, Terms);
                        check = "Pubsite User";
                        ClaimUserDomainCompany(Email, SiteName);
                    }
                }
                else
                {
                    if (Roles.IsUserInRole(Email, "Advertiser"))
                    {
                        check = "Advertiser";
                    }
                    else if (Roles.IsUserInRole(Email, "Agency"))
                    {
                        check = "Agency";
                    }
                    else
                    {
                        check = "other";
                    }
                }
            }
            else
            {
                MailService(Email, FName, Password, siteid, SiteName, Terms, Role);
                check = "New User";
                AddUserSignupDetails(FName, LName, Email, "", "", "", Role, "", Terms);
                ClaimUserDomainCompany(Email, SiteName);
            }
            return check;
        }

        private string SignupWithAdvertiseTermsPolicy(string FName, string LName, string Email, string Password,string SiteName, int Terms, string Role)
        {
            string check = "";
             
            string userId = "";
            userId = Membership.GetUserNameByEmail(Email.ToLower());

            int siteid = GetSiteId(SiteName);
            
            if (userId != "" && userId != null)
            {
                if (Roles.IsUserInRole(Email, "Publisher") || Roles.IsUserInRole(Email, "Other") || Roles.IsUserInRole(Email, "Agency") || Roles.IsUserInRole(Email, "Advertiser"))
                {
                    DataSet set = CheckUserForPubsite(Email, siteid);

                    if (set.Tables.Count > 0 && set.Tables[0].Rows.Count > 0 && set != null)
                    {
                        check = "Already Exist";
                    }
                    else
                    {
                        ExistingUserMailService(Email, FName, Password, siteid, SiteName, Terms);
                        check = "Pubsite User";
                        ClaimUserDomainCompany(Email, SiteName);
                    }
                }
                else
                {
                    if (Roles.IsUserInRole(Email, "Advertiser"))
                    {
                        check = "Advertiser";
                    }
                    else if (Roles.IsUserInRole(Email, "Agency"))
                    {
                        check = "Agency";
                    }
                    else
                    {
                        check = "other";
                    }
                }
            }
            else
            {
                AdvertiseMailService(Email, FName, Password, siteid, SiteName, Terms, Role);
                //AdminEmailSent(Email, SiteName);
                check = "New User";
                AddUserSignupDetails(FName, LName, Email, "", "", "", Role, "", Terms);
                ClaimUserDomainCompany(Email, SiteName);
            }
            return check;
        }


        private string SignupWithAdvertiseTermsPolicy(string Name, string Company, string Email, string Phone)
        {
            string check = "";
             
            string userId = "";
            //userId = Membership.GetUserNameByEmail(Email.ToLower());

            //int siteid = GetSiteId(SiteName);
            
            //if (userId != "" && userId != null)
            //{
            //    if (Roles.IsUserInRole(Email, "Publisher") || Roles.IsUserInRole(Email, "Other") || Roles.IsUserInRole(Email, "GuestAuthor"))
            //    {
            //        DataSet set = CheckUserForPubsite(Email, siteid);

            //        if (set.Tables.Count > 0 && set.Tables[0].Rows.Count > 0 && set != null)
            //        {
            //            check = "Already Exist";
            //        }
            //        else
            //        {
            //            ExistingUserMailService(Email, FName, Password, siteid, SiteName, Terms);
            //            check = "Pubsite User";
            //            ClaimUserDomainCompany(Email, SiteName);
            //        }
            //    }
            //    else
            //    {
            //        if (Roles.IsUserInRole(Email, "Advertiser"))
            //        {
            //            check = "Advertiser";
            //        }
            //        else if (Roles.IsUserInRole(Email, "Agency"))
            //        {
            //            check = "Agency";
            //        }
            //        else
            //        {
            //            check = "other";
            //        }
            //    }
            //}
            //else
            //{
                AdvertiseMailService(Name, Company, Email, Phone);
                //check = "New User";
                AddUserDownloadDetails(Name, Company, Email, Phone);
                //ClaimUserDomainCompany(Email, SiteName);
            //}
            return check;
        }

        private void ClaimUserDomainCompany(string Username, string siteName)
        {
            string SiteName = string.Empty;
            if (SiteName == string.Empty)
            {
                SiteName = siteName;

                if (SiteName.Contains("."))
                    SiteName = SiteName.Split('.')[0].Trim();
            }

            Guid uniqueToken = new Guid();
            uniqueToken = Guid.NewGuid();

            //d7dmediaLogin.WebService service = new d7dmediaLogin.WebService();
            //GeneCompanyService.WebServiceCompany GeneService = new GeneCompanyService.WebServiceCompany();


            string domain = Username.Substring(Username.LastIndexOf("@") + 1, Username.Length - Username.LastIndexOf("@") - 1);

            DataSet set = GetPubsiteList(Username);


            DataSet setTokenGet = new DataSet();
            if (set.Tables[0].Rows.Count == 1)
            {
                ClaimUserDomainCompany(SiteName, domain, Username, (domain + uniqueToken.ToString()));
            }
            else
            {
                if (set.Tables[0].Rows[0]["sitename"].ToString() == "smallbusiness.report" || set.Tables[0].Rows[0]["sitename"].ToString() == "pharmaceutical.report")
                {
                    setTokenGet = GetUniqueAnkTokenM7(set.Tables[0].Rows[0]["sitename"].ToString().ToLower().Replace(".report", "").Replace(".network", ""), domain, Username);
                                   
                }
                else
                {
                    setTokenGet = Get_UniqueAnkTokenM7(set.Tables[0].Rows[0]["sitename"].ToString().ToLower().Replace(".report", "").Replace(".network", ""), domain, Username);
                }

                if (setTokenGet.Tables.Count > 0 && setTokenGet.Tables[0].Rows.Count > 0 && setTokenGet != null)
                {
                    ClaimUserDomainCompany("infotech", domain, Username, setTokenGet.Tables[0].Rows[0]["UniqueAnkTokenM7"].ToString());
                }

            }
        }

        private DataSet Get_UniqueAnkTokenM7(string sitename, string domain, string username)
        {           
            DataSet set = new DataSet();
            try
            {                
                M7Connection();
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@SiteName", sitename);
                sqlCmd.Parameters.AddWithValue("@Domain", domain);
                sqlCmd.Parameters.AddWithValue("@UserName", username);
                sqlCmd.CommandText = "WebService_Get_UniqueAnkTokenM7";
                sqlCmd.Connection = m7con;
                SqlDataAdapter sda1 = new SqlDataAdapter(sqlCmd);
                sda1.Fill(set);
            }
            catch (Exception ex)
            {

            }
            return set;
        }

        private DataSet GetUniqueAnkTokenM7(string sitename, string domain, string username)
        {
            DataSet set = new DataSet();
            try
            {
                GeneConnection();
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@SiteName", sitename);
                sqlCmd.Parameters.AddWithValue("@Domain", domain);
                sqlCmd.Parameters.AddWithValue("@UserName", username);
                sqlCmd.CommandText = "WebService_Get_UniqueAnkTokenM7";
                sqlCmd.Connection = genecon;
                SqlDataAdapter sda1 = new SqlDataAdapter(sqlCmd);
                sda1.Fill(set);
            }
            catch (Exception ex)
            {

            }
            return set;
        }

        private DataSet GetPubsiteList(string UserName)
        {
            DataSet set = new DataSet();
            try
            {                               
                M7Connection();
                SqlCommand sqlCmd1 = new SqlCommand();
                sqlCmd1.CommandType = CommandType.StoredProcedure;
                sqlCmd1.Parameters.AddWithValue("@UserName", UserName);
                sqlCmd1.CommandText = "SPGetPubsiteForUser";
                sqlCmd1.Connection = m7con;
                SqlDataAdapter sda1 = new SqlDataAdapter(sqlCmd1);
                sda1.Fill(set);
            }
            catch (Exception ex)
            {

            }
            return set; 
        }

        private void ClaimUserDomainCompany(string sitename, string domain, string username, string uniqueToken)
        {
            
            try
            {               
                Connection();
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;                
                sqlCmd.Parameters.AddWithValue("@sitename", sitename);
                sqlCmd.Parameters.AddWithValue("@domain", domain);
                sqlCmd.Parameters.AddWithValue("@username", username);
                sqlCmd.Parameters.AddWithValue("@UniqueAnkTokenM7", uniqueToken);
                sqlCmd.CommandText = "WebService_Updating_Domain_Owner";
                sqlCmd.Connection = scon;
                sqlCmd.Connection.Open();
                sqlCmd.ExecuteNonQuery();
                sqlCmd.Connection.Close();
            }
            catch (Exception ex)
            { }

        }


        private void AddUserSignupDetails(string FName, string LName, string Email, string Company, string Phone, string Country, string Role, string Other)
        {
            try
            {
                MembershipUser mu = Membership.GetUser(Email);
                string userId = mu.ProviderUserKey.ToString();                
                M7Connection();               
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;      
                sqlCmd.Parameters.AddWithValue("@FName", FName);
                sqlCmd.Parameters.AddWithValue("@LName", LName);
                sqlCmd.Parameters.AddWithValue("@Email", Email);
                sqlCmd.Parameters.AddWithValue("@Company", Company);
                sqlCmd.Parameters.AddWithValue("@Phone", Phone);
                sqlCmd.Parameters.AddWithValue("@Country", Country);
                sqlCmd.Parameters.AddWithValue("@Role", Role);
                sqlCmd.Parameters.AddWithValue("@Other", Other);
                sqlCmd.Parameters.AddWithValue("@userid", userId);
                sqlCmd.CommandText = "SPAddUserSignupDetailsWebReference";
                sqlCmd.Connection = m7con;
                sqlCmd.Connection.Open();
                sqlCmd.ExecuteNonQuery();
                sqlCmd.Connection.Close();

            }
            catch (Exception ex)
            {

            }
        }

        private void AddUserDownloadDetails(string FName, string Company, string Email, string Phone)
        {
            try
            {
                //MembershipUser mu = Membership.GetUser(Email);
                //string userId = mu.ProviderUserKey.ToString();
                M7Connection();
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@FName", FName);
                sqlCmd.Parameters.AddWithValue("@Email", Email);
                sqlCmd.Parameters.AddWithValue("@Company", Company);
                sqlCmd.Parameters.AddWithValue("@Phone", Phone);
                sqlCmd.CommandText = "SPAddUserDownloadDetails";
                sqlCmd.Connection = m7con;
                sqlCmd.Connection.Open();
                sqlCmd.ExecuteNonQuery();
                sqlCmd.Connection.Close();

                //DBAccess db = new DBAccess();
                //db.AddParameter("@FName", FName);
                //db.AddParameter("@Email", Email);
                //db.AddParameter("@Company", Company);
                //db.AddParameter("@Phone", Phone);

                //db.ExecuteNonQuery("SPAddUserDownloadDetails");
            }
            catch (Exception ex)
            { }
        }

        private void AddUserSignupDetails(string FName, string LName, string Email, string Company, string Phone, string Country, string Role, string Other, int Bit)
        {
            try
            {
                MembershipUser mu = Membership.GetUser(Email);
                string userId = mu.ProviderUserKey.ToString();
                M7Connection();
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@FName", FName);
                sqlCmd.Parameters.AddWithValue("@LName", LName);
                sqlCmd.Parameters.AddWithValue("@Email", Email);
                sqlCmd.Parameters.AddWithValue("@Company", Company);
                sqlCmd.Parameters.AddWithValue("@Phone", Phone);
                sqlCmd.Parameters.AddWithValue("@Country", Country);
                sqlCmd.Parameters.AddWithValue("@Role", Role);
                sqlCmd.Parameters.AddWithValue("@Other", Other);
                sqlCmd.Parameters.AddWithValue("@userid", userId);
                sqlCmd.Parameters.AddWithValue("@ActiveTermsandPolicy", Bit);

                sqlCmd.CommandText = "SPAddUserSignupDetails";
                sqlCmd.Connection = m7con;
                sqlCmd.Connection.Open();
                sqlCmd.ExecuteNonQuery();
                sqlCmd.Connection.Close();
            }
            catch (Exception ex)
            {

            }
        }


        private void MailServiceForGuestAuthor(string Email, string Fname, string password, int siteid, string Sitename, int terms, string Role)
        {
            try
            {
                //TextBox password = (TextBox)FindControl("Password123");
                string username = Email;
                // string password = GeneratePassword(Fname);
                MembershipCreateStatus createStatus;
                Membership.CreateUser(Email, password, Email, "nick name", "ok", false, out createStatus);
                 
                Roles.AddUserToRole(Email, Role);

                #region NewRegistrationMail

                string Name = Email;
                string msg = string.Empty;
                string from = "members@media7.io";
                MailMessage message = new MailMessage();
                SmtpClient smtpClient = new SmtpClient();

                //string userName = txt_Name.Text.Trim();
                ////  Get the user's id
                //Guid userId = (Guid)Membership.GetUser(userName).ProviderUserKey;
                string Subject = "Welcome to the " + Sitename;
                TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
                //userName = textInfo.ToTitleCase(userName);
                #region Message Body

                string body = string.Empty;
                //using streamreader for reading my htmltemplate   

                using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("~/HtmlTemplates/ThankyouPubsite.htm")))
                {
                    body = reader.ReadToEnd();
                }

                //TextBox password = (TextBox)FindControl("Password123");

                MembershipUser mu = Membership.GetUser(Email);
                string userId = mu.ProviderUserKey.ToString();

                if (userId != "" || userId != null)
                {
                    StorePubsiteUsers(Email, siteid, terms, userId);
                }

                //Common com = new Common();
                //com.ClaimUserDomainCompany(Email, Sitename, userId);

                body = body.Replace("{UserName}", Fname);

                #region switch

                switch (Sitename.ToLower())
                {
                    case "abm.report":
                        body = body.Replace("{SiteName}", "ABM Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://ABM.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "ABM Report");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/ABM.report/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/abm-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/101910112412726385876");
                        body = body.Replace("http://tw.com", "https://twitter.com/report_abm");

                        break;

                    case "advertising.report":
                        body = body.Replace("{SiteName}", "Advertising Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://advertising.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Advertising Report");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Advertising.Report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/advertising.report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/111655297844529108876?hl=en");
                        body = body.Replace("http://tw.com", "https://twitter.com/advertisingrep3");

                        break;

                    case "aviation.report":
                        body = body.Replace("{SiteName}", "Aviation Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://aviation.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Aviation Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/The.Aviation.report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/aviation.report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/114280654416467366288");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "biotechnology.report":
                        body = body.Replace("{SiteName}", "Biotechnology Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://biotechnology.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Biotechnology Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Biotechnology.report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/the-biotechnology-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/114330393539843196461");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "biotech.report":
                        body = body.Replace("{SiteName}", "Biotech Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://biotech.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Biotech Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Biotechnology.report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/the-biotechnology-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/114330393539843196461");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "capital.report":
                        body = body.Replace("{SiteName}", "Capital Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://capital.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Capital Report");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Capital.Report/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/the-capital-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/107769852942524763370");
                        body = body.Replace("http://tw.com", "https://twitter.com/CapitalReport2");

                        break;

                    case "channel.report":
                        body = body.Replace("{SiteName}", "Channel Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://channel.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Channel Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/channel.report/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/the-channel-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/113549242602470470843");
                        body = body.Replace("http://tw.com", "");

                        break;


                    case "chemical.report":
                        body = body.Replace("{SiteName}", "Chemical Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://chemical.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Chemical Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/TheChemicalReport/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/chemical-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/116230049211920401445");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "cloud.report":
                        body = body.Replace("{SiteName}", "Cloud Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://cloud.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Cloud Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Cloud.Computing.Report/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/cloud-report1");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/104795079924552291803");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "dataanalytics.report":
                        body = body.Replace("{SiteName}", "Data Analytics Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://dataanalytics.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Data Analytics Report");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/DataAnalytics.Report/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/dataanalytics-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/109579208390025894184");
                        body = body.Replace("http://tw.com", "https://twitter.com/DataAnalyticsR2");

                        break;

                    case "engineering.report":
                        body = body.Replace("{SiteName}", "Engineering Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://engineering.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Engineering Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Engineering.report/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/engineering.report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/111873872000949600820");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "government.report":
                        body = body.Replace("{SiteName}", "Government Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://government.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Government Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/government.report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/governmentreport");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/116648347583223320296");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "greenenergy.report":
                        body = body.Replace("{SiteName}", "Green Energy Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://greenenergy.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Green Energy Report");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/GreenEnergy.report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/greenenergy-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/113290459189685686116");
                        body = body.Replace("http://tw.com", "https://twitter.com/GreenenergyRpt");

                        break;

                    case "healthcare.report":
                        body = body.Replace("{SiteName}", "Healthcare Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://healthcare.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Healthcare Report");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Healthcare.report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/the-healthcare-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/102740252830492716604");
                        body = body.Replace("http://tw.com", "https://twitter.com/HealthcareRepo3");

                        break;

                    case "humanresources.report":
                        body = body.Replace("{SiteName}", "Human Resources Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://humanresources.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Human Resources Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/HumanResources.Report/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/the-humanresources-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/100109770568281030209?hl=en");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "informationsecurity.report":
                        body = body.Replace("{SiteName}", "Information Security Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://informationsecurity.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Information Security Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/InfoSec.report/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/informationsecurity-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/105616685142612477389?hl=en");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "infotech.report":
                        body = body.Replace("{SiteName}", "Infotech Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://infotech.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Infotech Report");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/TheInfotechReport/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/the-infotech-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/106513072017905681069?hl=en");
                        body = body.Replace("http://tw.com", "https://twitter.com/infotechreport1");

                        break;

                    case "itinfrastructure.report":
                        body = body.Replace("{SiteName}", "IT Infrastructure Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://itinfrastructure.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "IT Infrastructure Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/ITInfrastructure.report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/itinfrastructure.report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/108767760557877157552");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "manufacturing.report":
                        body = body.Replace("{SiteName}", "Manufacturing Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://manufacturing.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Manufacturing Report");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Manufacturing.report/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/manufacturing.report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/106669125275878359478");
                        body = body.Replace("http://tw.com", "https://twitter.com/manufactringre1");

                        break;

                    case "networking.report":
                        body = body.Replace("{SiteName}", "Networking Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".png");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://networking.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Networking Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Networking.Report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/networking.report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/106717057722806432373?hl=en");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "nonprofit.report":
                        body = body.Replace("{SiteName}", "Nonprofit Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://nonprofit.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Nonprofit Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Nonprofit.report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/nonprofit.report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/108697591802812816511");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "pharmaceutical.report":
                        body = body.Replace("{SiteName}", "Pharmaceutical Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://pharmaceutical.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Pharmaceutical Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Pharmaceutical.Report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/pharmaceutical.report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/101913904421328496543");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "re.report":
                        body = body.Replace("{SiteName}", "Re Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://re.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Re Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/REindustry/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/re.report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/117037258095616008539");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "smallbusiness.report":
                        body = body.Replace("{SiteName}", "Small Business Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://smallbusiness.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Small Business Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/SmallBusinessReport/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/small-business.report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/100798315370811914608");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "virtualization.network":
                        body = body.Replace("{SiteName}", "Virtualization Network");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://virtualization.network/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Virtualization Network");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Virtualization.Network");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/virtualization.network");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/105732599757951132641");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "wheels.report":
                        body = body.Replace("{SiteName}", "Wheels Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".png");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://wheels.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Wheels Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Wheels.report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/wheels-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/u/0/b/107965575776548533362/107965575776548533362/about");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "theinternetofthings.report":
                        body = body.Replace("{SiteName}", "Internet of Things Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://theinternetofthings.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());

                        body = body.Replace("http://fb.com", "https://www.facebook.com/TheInternetofThings.Report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/theinternetofthings-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/b/102236961973983653868/102236961973983653868/about?gmbpt=Y&hl=en");
                        body = body.Replace("http://tw.com", "https://twitter.com/TheInternetofT3");
                        break;

                    case "policy.report":
                        body = body.Replace("{SiteName}", "Policy Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://policy.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Policy Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/policyreport/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/policy-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/100211751164866148397");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "entertainment.report":
                        body = body.Replace("{SiteName}", "Entertainment Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://entertainment.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Entertainment Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/The.Entertainment.Report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/entertainment-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/103395655859112296888");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "travel.report":
                        body = body.Replace("{SiteName}", "Travel Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://travel.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Travel Report");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/TheTravelReport/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/travel.report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/102425791186500234009");
                        body = body.Replace("http://tw.com", "https://twitter.com/Travelreport2");

                        break;

                    case "pos.report":
                        body = body.Replace("{SiteName}", "POS Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://pos.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "POS Report");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/POSReport");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/pos.report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/111653842294237696457");
                        body = body.Replace("http://tw.com", "https://twitter.com/ReportPos");

                        break;

                    case "education.report":
                        body = body.Replace("{SiteName}", "Education Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://education.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("Internet of Things Report", "Education Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Education.report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/education.report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/108088234985181110758");
                        body = body.Replace("http://tw.com", "");

                        break;

                    default:
                        body = body.Replace("http://fb.com", "https://www.facebook.com/TheInternetofThings.Report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/theinternetofthings-report%C2%A0");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/b/102236961973983653868/102236961973983653868/about?gmbpt=Y&hl=en");
                        body = body.Replace("http://tw.com", "https://twitter.com/InternetofThe");

                        //body = body.Replace("{SiteName}", "Internet of Things Report");
                        //body = body.Replace("http://media7.io/new/Login.aspx", "http://theinternetofthings.report/Home.aspx?user=" + userId);
                        body = body.Replace("{SiteName}", "Internet of Things Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://theinternetofthings.report/Home.aspx?user=" + userId);
                        break;
                }
                #endregion

                //body = body.Replace("http://media7.io/new/Login.aspx", "http://localhost:5400/media7.io/new/Login.aspx?user=" + userId);
                //string url = "http://localhost:5400/media7.io/new/Login.aspx?user=" + userId;
                //body = body.Replace("{Password}", password); //replacing the required things  
                //body = body.Replace("{Title}", "Thank you for reaching out to us and giving Deck 7 the opportunity to enhance your digital marketing outreach. Within 24 hours, one of our account managers or specialists will be reaching back to you either by email or phone regarding your requested information. For immediate questions or requests feel free to call our home office at 1.619.900.9595 or 1.844.900.9595 Toll Free between 9am and 5pm PST.");
                //body = body.Replace("{message}", "<br />Looking forward to speaking soon!");
                //body = body.Replace("{EmailId}", txt_Email.Text.Trim());
                #endregion

                try
                {
                    string displayName = Sitename + " Membership Signup";
                    displayName = textInfo.ToTitleCase(displayName);
                    displayName = displayName.Replace(".Report", ".report");
                    MailAddress fromAddress = new MailAddress(from, displayName);
                    message.From = fromAddress;
                    message.To.Add(Email);
                    #region Hardcoded
                    message.Subject = Subject;
                    message.IsBodyHtml = true;

                    AlternateView htmlView = AlternateView.CreateAlternateViewFromString(body, null, "text/html");
                    message.AlternateViews.Add(htmlView);

                    smtpClient.Host = "smtp-relay.sendinblue.com";
                    smtpClient.Port = 587;
                    smtpClient.EnableSsl = false;
                    smtpClient.UseDefaultCredentials = true;
                    smtpClient.Credentials = new System.Net.NetworkCredential("manju@deck7marketing.com", "1sqWbrZjMaTpzRHx");
                    //smtpClient.Credentials = new System.Net.NetworkCredential("suraj@deck7.io", "qIHZDcpAftj0XROU");
                    smtpClient.Send(message);
                    msg = "Successful";
                    #endregion
                }
                catch (Exception ex)
                {
                    msg = ex.Message;
                }
                #endregion
            }
            catch (Exception ex)
            { }
        }

        private void MailService(string Email, string Fname, string password, int siteid, string Sitename, string Role)
        {
            try
            {
                //TextBox password = (TextBox)FindControl("Password123");
                string username = Email;
                // string password = GeneratePassword(Fname);
                MembershipCreateStatus createStatus;
                Membership.CreateUser(Email, password, Email, "nick name", "ok", false, out createStatus);

                //switch (createStatus)
                //{
                //    //This Case Occured whenver User Created Successfully in database
                //    case MembershipCreateStatus.Success:

                //        break;
                //}

                Roles.AddUserToRole(Email, Role);

                #region NewRegistrationMail

                string Name = Email;
                string msg = string.Empty;
                string from = "members@media7.io";
                MailMessage message = new MailMessage();
                SmtpClient smtpClient = new SmtpClient();

                //string userName = txt_Name.Text.Trim();
                ////  Get the user's id
                //Guid userId = (Guid)Membership.GetUser(userName).ProviderUserKey;
                string Subject = "Welcome to the " + Sitename;
                TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
                //userName = textInfo.ToTitleCase(userName);
                #region Message Body

                string body = string.Empty;
                //using streamreader for reading my htmltemplate   

                using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("~/HtmlTemplates/ThankyouPubsite.htm")))
                {
                    body = reader.ReadToEnd();
                }

                //TextBox password = (TextBox)FindControl("Password123");

                MembershipUser mu = Membership.GetUser(Email);
                string userId = mu.ProviderUserKey.ToString();

                if (userId != "" || userId != null)
                {
                    StorePubsiteUsers(Email, siteid, userId);
                }

                body = body.Replace("{UserName}", Fname);

                #region switch

                switch (Sitename.ToLower())
                {
                    case "abm.report":
                        body = body.Replace("{SiteName}", "ABM Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://ABM.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "ABM Report");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/ABM.report/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/abm-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/101910112412726385876");
                        body = body.Replace("http://tw.com", "https://twitter.com/report_abm");

                        break;

                    case "advertising.report":
                        body = body.Replace("{SiteName}", "Advertising Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://advertising.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Advertising Report");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Advertising.Report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/advertising.report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/111655297844529108876?hl=en");
                        body = body.Replace("http://tw.com", "https://twitter.com/advertisingrep3");

                        break;

                    case "aviation.report":
                        body = body.Replace("{SiteName}", "Aviation Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://aviation.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Aviation Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/The.Aviation.report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/aviation.report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/114280654416467366288");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "biotechnology.report":
                        body = body.Replace("{SiteName}", "Biotechnology Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://biotechnology.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Biotechnology Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Biotechnology.report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/the-biotechnology-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/114330393539843196461");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "biotech.report":
                        body = body.Replace("{SiteName}", "Biotech Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://biotech.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Biotech Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Biotechnology.report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/the-biotechnology-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/114330393539843196461");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "capital.report":
                        body = body.Replace("{SiteName}", "Capital Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://capital.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Capital Report");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Capital.Report/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/the-capital-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/107769852942524763370");
                        body = body.Replace("http://tw.com", "https://twitter.com/CapitalReport2");

                        break;

                    case "channel.report":
                        body = body.Replace("{SiteName}", "Channel Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://channel.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Channel Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/channel.report/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/the-channel-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/113549242602470470843");
                        body = body.Replace("http://tw.com", "");

                        break;


                    case "chemical.report":
                        body = body.Replace("{SiteName}", "Chemical Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://chemical.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Chemical Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/TheChemicalReport/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/chemical-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/116230049211920401445");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "cloud.report":
                        body = body.Replace("{SiteName}", "Cloud Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://cloud.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Cloud Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Cloud.Computing.Report/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/cloud-report1");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/104795079924552291803");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "dataanalytics.report":
                        body = body.Replace("{SiteName}", "Data Analytics Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://dataanalytics.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Data Analytics Report");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/DataAnalytics.Report/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/dataanalytics-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/109579208390025894184");
                        body = body.Replace("http://tw.com", "https://twitter.com/DataAnalyticsR2");

                        break;

                    case "engineering.report":
                        body = body.Replace("{SiteName}", "Engineering Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://engineering.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Engineering Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Engineering.report/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/engineering.report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/111873872000949600820");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "government.report":
                        body = body.Replace("{SiteName}", "Government Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://government.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Government Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/government.report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/governmentreport");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/116648347583223320296");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "greenenergy.report":
                        body = body.Replace("{SiteName}", "Green Energy Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://greenenergy.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Green Energy Report");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/GreenEnergy.report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/greenenergy-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/113290459189685686116");
                        body = body.Replace("http://tw.com", "https://twitter.com/GreenenergyRpt");

                        break;

                    case "healthcare.report":
                        body = body.Replace("{SiteName}", "Healthcare Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://healthcare.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Healthcare Report");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Healthcare.report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/the-healthcare-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/102740252830492716604");
                        body = body.Replace("http://tw.com", "https://twitter.com/HealthcareRepo3");

                        break;

                    case "humanresources.report":
                        body = body.Replace("{SiteName}", "Human Resources Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://humanresources.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Human Resources Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/HumanResources.Report/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/the-humanresources-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/100109770568281030209?hl=en");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "informationsecurity.report":
                        body = body.Replace("{SiteName}", "Information Security Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://informationsecurity.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Information Security Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/InfoSec.report/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/informationsecurity-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/105616685142612477389?hl=en");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "infotech.report":
                        body = body.Replace("{SiteName}", "Infotech Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://infotech.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Infotech Report");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/TheInfotechReport/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/the-infotech-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/106513072017905681069?hl=en");
                        body = body.Replace("http://tw.com", "https://twitter.com/infotechreport1");

                        break;

                    case "itinfrastructure.report":
                        body = body.Replace("{SiteName}", "IT Infrastructure Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://itinfrastructure.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "IT Infrastructure Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/ITInfrastructure.report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/itinfrastructure.report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/108767760557877157552");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "manufacturing.report":
                        body = body.Replace("{SiteName}", "Manufacturing Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://manufacturing.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Manufacturing Report");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Manufacturing.report/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/manufacturing.report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/106669125275878359478");
                        body = body.Replace("http://tw.com", "https://twitter.com/manufactringre1");

                        break;

                    case "networking.report":
                        body = body.Replace("{SiteName}", "Networking Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".png");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://networking.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Networking Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Networking.Report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/networking.report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/106717057722806432373?hl=en");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "nonprofit.report":
                        body = body.Replace("{SiteName}", "Nonprofit Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://nonprofit.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Nonprofit Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Nonprofit.report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/nonprofit.report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/108697591802812816511");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "pharmaceutical.report":
                        body = body.Replace("{SiteName}", "Pharmaceutical Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://pharmaceutical.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Pharmaceutical Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Pharmaceutical.Report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/pharmaceutical.report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/101913904421328496543");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "re.report":
                        body = body.Replace("{SiteName}", "Re Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://re.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Re Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/REindustry/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/re.report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/117037258095616008539");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "smallbusiness.report":
                        body = body.Replace("{SiteName}", "Small Business Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://smallbusiness.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Small Business Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/SmallBusinessReport/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/small-business.report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/100798315370811914608");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "virtualization.network":
                        body = body.Replace("{SiteName}", "Virtualization Network");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://virtualization.network/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Virtualization Network");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Virtualization.Network");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/virtualization.network");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/105732599757951132641");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "wheels.report":
                        body = body.Replace("{SiteName}", "Wheels Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".png");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://wheels.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Wheels Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Wheels.report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/wheels-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/u/0/b/107965575776548533362/107965575776548533362/about");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "theinternetofthings.report":
                        body = body.Replace("{SiteName}", "Internet of Things Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://theinternetofthings.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());

                        body = body.Replace("http://fb.com", "https://www.facebook.com/TheInternetofThings.Report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/theinternetofthings-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/b/102236961973983653868/102236961973983653868/about?gmbpt=Y&hl=en");
                        body = body.Replace("http://tw.com", "https://twitter.com/TheInternetofT3");
                        break;

                    case "policy.report":
                        body = body.Replace("{SiteName}", "Policy Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://policy.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Policy Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/policyreport/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/policy-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/100211751164866148397");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "entertainment.report":
                        body = body.Replace("{SiteName}", "Entertainment Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://entertainment.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Entertainment Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/The.Entertainment.Report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/entertainment-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/103395655859112296888");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "travel.report":
                        body = body.Replace("{SiteName}", "Travel Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://travel.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Travel Report");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/TheTravelReport/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/travel.report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/102425791186500234009");
                        body = body.Replace("http://tw.com", "https://twitter.com/Travelreport2");

                        break;

                    case "pos.report":
                        body = body.Replace("{SiteName}", "POS Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://pos.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "POS Report");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/POSReport");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/pos.report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/111653842294237696457");
                        body = body.Replace("http://tw.com", "https://twitter.com/ReportPos");

                        break;

                    case "education.report":
                        body = body.Replace("{SiteName}", "Education Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://education.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("Internet of Things Report", "Education Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Education.report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/education.report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/108088234985181110758");
                        body = body.Replace("http://tw.com", "");

                        break;

                    default:
                        body = body.Replace("http://fb.com", "https://www.facebook.com/TheInternetofThings.Report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/theinternetofthings-report%C2%A0");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/b/102236961973983653868/102236961973983653868/about?gmbpt=Y&hl=en");
                        body = body.Replace("http://tw.com", "https://twitter.com/InternetofThe");

                        //body = body.Replace("{SiteName}", "Internet of Things Report");
                        //body = body.Replace("http://media7.io/new/Login.aspx", "http://theinternetofthings.report/Home.aspx?user=" + userId);
                        body = body.Replace("{SiteName}", "Internet of Things Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://theinternetofthings.report/Home.aspx?user=" + userId);
                        break;
                }
                #endregion

                //body = body.Replace("http://media7.io/new/Login.aspx", "http://localhost:5400/media7.io/new/Login.aspx?user=" + userId);
                //string url = "http://localhost:5400/media7.io/new/Login.aspx?user=" + userId;
                //body = body.Replace("{Password}", password); //replacing the required things  
                //body = body.Replace("{Title}", "Thank you for reaching out to us and giving Deck 7 the opportunity to enhance your digital marketing outreach. Within 24 hours, one of our account managers or specialists will be reaching back to you either by email or phone regarding your requested information. For immediate questions or requests feel free to call our home office at 1.619.900.9595 or 1.844.900.9595 Toll Free between 9am and 5pm PST.");
                //body = body.Replace("{message}", "<br />Looking forward to speaking soon!");
                //body = body.Replace("{EmailId}", txt_Email.Text.Trim());
                #endregion

                try
                {
                    string displayName = Sitename + " Membership Signup";
                    displayName = textInfo.ToTitleCase(displayName);
                    displayName = displayName.Replace(".Report", ".report");
                    MailAddress fromAddress = new MailAddress(from, displayName);
                    message.From = fromAddress;
                    message.To.Add(Email);
                    #region Hardcoded
                    message.Subject = Subject;
                    message.IsBodyHtml = true;

                    AlternateView htmlView = AlternateView.CreateAlternateViewFromString(body, null, "text/html");
                    message.AlternateViews.Add(htmlView);

                    smtpClient.Host = "smtp-relay.sendinblue.com";
                    smtpClient.Port = 587;
                    smtpClient.EnableSsl = false;
                    smtpClient.UseDefaultCredentials = true;
                    smtpClient.Credentials = new System.Net.NetworkCredential("manju@deck7marketing.com", "1sqWbrZjMaTpzRHx");
                    //smtpClient.Credentials = new System.Net.NetworkCredential("suraj@deck7.io", "qIHZDcpAftj0XROU");
                    smtpClient.Send(message);
                    msg = "Successful";
                    #endregion
                }
                catch (Exception ex)
                {
                    msg = ex.Message;
                }
                #endregion
            }
            catch (Exception ex)
            { }
        }


        private void AdvertiseMailService(string Name, string Company, string Email, string Phone)
        {
            try
            {
                #region NewRegistrationMail

                string Namee = Email;
                string msg = string.Empty;
                string from = "members@media7.io";
                MailMessage message = new MailMessage();
                SmtpClient smtpClient = new SmtpClient();

                //string userName = txt_Name.Text.Trim();
                ////  Get the user's id
                //Guid userId = (Guid)Membership.GetUser(userName).ProviderUserKey;
                string Subject = "";
                //if (hide.Value == "1")
                //{
                    Subject = "Request for MEDIA 7 kit";
                //}
                //else
                //{
                //    Subject = "Request for deck7 media kit";
                //}
                TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
                //userName = textInfo.ToTitleCase(userName);
                #region Message Body

                string body = string.Empty;
                //using streamreader for reading my htmltemplate   

                string username = textInfo.ToTitleCase(Name);
                using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("~/HtmlTemplates/MediaKit.htm")))
                {
                    body = reader.ReadToEnd();
                }
                body = body.Replace("{UserName}", "Hello " + username);
                //if (hide.Value == "1")
                //{
                    body = body.Replace("{Title}", "Thank you for requesting the MEDIA 7 kit. You can download it <a href=\"https://media7.io/Advertise/PubSite/Pdf/MEDIA7QuickFacts2022.pdf\">here</a>.");
                //}
                //else
                //{
                //    body = body.Replace("{Title}", "Thank you for requesting the DECK 7 MEDIA kit. You can download it <a href=\"https://media7.io/Advertise/PubSite/Pdf/DECK7-MEDIA-KIT-2019.pdf\">here</a>.");
                //}
                #endregion

                try
                {
                    MailAddress fromAddress = new MailAddress(from);
                    message.From = fromAddress;
                    message.To.Add(Email);
                    #region Hardcoded
                    message.Subject = Subject;
                    message.IsBodyHtml = true;

                    AlternateView htmlView = AlternateView.CreateAlternateViewFromString(body, null, "text/html");
                    message.AlternateViews.Add(htmlView);

                    smtpClient.Host = "smtp-relay.sendinblue.com";
                    smtpClient.Port = 587;
                    smtpClient.EnableSsl = false;
                    smtpClient.UseDefaultCredentials = true;
                    smtpClient.Credentials = new System.Net.NetworkCredential("manju@deck7marketing.com", "1sqWbrZjMaTpzRHx");
                    smtpClient.Send(message);
                    msg = "Successful";
                    #endregion
                }
                catch (Exception ex)
                {
                    msg = ex.Message;
                }
                #endregion

                #region Admin email

                string emailAddress = "info@media7.io";

                string mssg = string.Empty;
                SmtpClient client = new SmtpClient();

                //// Now lets create an email message
                try
                {
                    StringBuilder emailMessage = new StringBuilder();
                    emailMessage.Append("Hello,");
                    emailMessage.Append("<br/><br/>");
                    emailMessage.Append("This user has contacted for Media Kit");
                    emailMessage.Append("<br/><br/>");

                    emailMessage.Append("<br/><br /> Name: " + username);
                    emailMessage.Append("<br/>Company: " + Company);
                    emailMessage.Append("<br/>Email: " + Email);
                    emailMessage.Append("<br/>Phone No: " + Phone);

                    emailMessage.Append("<br/><br/>Regards,<br/><br/>");
                    emailMessage.Append("Admin MEDIA 7 Network");
                    MailMessage email = new MailMessage();
                    email.From = new MailAddress("members@media7.io");
                    email.To.Add(new MailAddress(emailAddress));
                    //if (hide.Value == "1")
                    //{
                        email.Subject = "" + Email + " has contacted for Media Kit on MEDIA 7";
                    //}
                    //else
                    //{
                    //    email.Subject = "" + txtEmailId.Text.Trim() + " has contacted for Media Kit on DECK7 MEDIA";
                    //}
                    email.Body = emailMessage.ToString();
                    email.IsBodyHtml = true;
                    //Send the email
                    client.Host = "smtp-relay.sendinblue.com";
                    client.Port = 587;
                    client.EnableSsl = false;
                    client.UseDefaultCredentials = true;
                    client.Credentials = new System.Net.NetworkCredential("manju@deck7marketing.com", "1sqWbrZjMaTpzRHx");

                    client.Send(email);
                    mssg = "Successfull";
                }
                catch (Exception ex)
                {
                    mssg = ex.Message;
                }
                #endregion

                #region Admin-1 email

                // string emailAddress = "info@deck7.io";////  // //// // 

                //string emailAddress1 = "Suraj@deck7.io";////  // //// // 
               
                string emailAddress1 = "micah@media7.com";

                string mssg1 = string.Empty;
                SmtpClient client1 = new SmtpClient();

                //// Now lets create an email message
                try
                {
                    StringBuilder emailMessage = new StringBuilder();
                    emailMessage.Append("Hello,");
                    emailMessage.Append("<br/><br/>");
                    emailMessage.Append("This user has signed up for Media Kit <br/><br/>");
                    emailMessage.Append("Name: " + username);
                    emailMessage.Append("<br/>Company: " + Company);
                    emailMessage.Append("<br/>Email: " + Email);
                    emailMessage.Append("<br/>Phone No: " + Phone);
                    emailMessage.Append("<br/><br/>");

                    //emailMessage.Append("<br/><br/><br/><br/>");
                    emailMessage.Append("Regards,<BR/>");
                    //if (hide.Value == "1")
                    //{
                        emailMessage.Append("Admin MEDIA 7 Network");
                    //}
                    //else
                    //{
                    //    emailMessage.Append("Admin DECK7 Media Network");
                    //}

                    MailMessage email = new MailMessage();
                    email.From = new MailAddress("members@media7.io");
                    email.To.Add(new MailAddress(emailAddress1));
                    email.Subject = "" + Email + " has requested for Media Kit";
                    email.Body = emailMessage.ToString();
                    email.IsBodyHtml = true;

                    //Send the email
                    client1.Host = "smtp-relay.sendinblue.com";
                    client1.Port = 587;
                    client1.EnableSsl = false;
                    client1.UseDefaultCredentials = true;
                    client1.Credentials = new System.Net.NetworkCredential("manju@deck7marketing.com", "1sqWbrZjMaTpzRHx");


                    client1.Send(email);
                    mssg1 = "Successfull";
                }
                catch (Exception ex)
                {
                    mssg = ex.Message;
                }
                #endregion

            }
            catch (Exception ex)
            { }
        }

        private void MailService(string Email, string Fname, string password, int siteid, string Sitename, int terms, string Role)
        {
            try
            {
                //TextBox password = (TextBox)FindControl("Password123");
                string username = Email;
                // string password = GeneratePassword(Fname);
                MembershipCreateStatus createStatus;
                Membership.CreateUser(Email, password, Email, "nick name", "ok", false, out createStatus);

  

                Roles.AddUserToRole(Email, Role);

                ///Add Uset To Roles Need to do Manually
                ///Ankit
                ///Stauts: Pending
                ///


                #region NewRegistrationMail

                string Name = Email;
                string msg = string.Empty;
                string from = "members@media7.io";
                MailMessage message = new MailMessage();
                SmtpClient smtpClient = new SmtpClient();

                //string userName = txt_Name.Text.Trim();
                ////  Get the user's id
                //Guid userId = (Guid)Membership.GetUser(userName).ProviderUserKey;
                string Subject = "Welcome to the " + Sitename;
                TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
                //userName = textInfo.ToTitleCase(userName);
                #region Message Body

                string body = string.Empty;
                //using streamreader for reading my htmltemplate   

                using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("~/HtmlTemplates/ThankyouPubsite.htm")))
                {
                    body = reader.ReadToEnd();
                }

                //TextBox password = (TextBox)FindControl("Password123");

                MembershipUser mu = Membership.GetUser(Email);
                string userId = mu.ProviderUserKey.ToString();

                if (userId != "" || userId != null)
                {
                    StorePubsiteUsers(Email, siteid, terms, userId);
                }

                //Common com = new Common();
                //com.ClaimUserDomainCompany(Email, Sitename, userId);

                body = body.Replace("{UserName}", Fname);

                #region switch

                switch (Sitename.ToLower())
                {
                    case "abm.report":
                        body = body.Replace("{SiteName}", "ABM Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://ABM.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "ABM Report");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/ABM.report/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/abm-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/101910112412726385876");
                        body = body.Replace("http://tw.com", "https://twitter.com/report_abm");

                        break;

                    case "advertising.report":
                        body = body.Replace("{SiteName}", "Advertising Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://advertising.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Advertising Report");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Advertising.Report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/advertising.report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/111655297844529108876?hl=en");
                        body = body.Replace("http://tw.com", "https://twitter.com/advertisingrep3");

                        break;

                    case "aviation.report":
                        body = body.Replace("{SiteName}", "Aviation Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://aviation.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Aviation Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/The.Aviation.report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/aviation.report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/114280654416467366288");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "biotechnology.report":
                        body = body.Replace("{SiteName}", "Biotechnology Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://biotechnology.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Biotechnology Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Biotechnology.report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/the-biotechnology-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/114330393539843196461");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "biotech.report":
                        body = body.Replace("{SiteName}", "Biotech Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://biotech.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Biotech Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Biotechnology.report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/the-biotechnology-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/114330393539843196461");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "capital.report":
                        body = body.Replace("{SiteName}", "Capital Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://capital.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Capital Report");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Capital.Report/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/the-capital-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/107769852942524763370");
                        body = body.Replace("http://tw.com", "https://twitter.com/CapitalReport2");

                        break;

                    case "channel.report":
                        body = body.Replace("{SiteName}", "Channel Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://channel.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Channel Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/channel.report/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/the-channel-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/113549242602470470843");
                        body = body.Replace("http://tw.com", "");

                        break;


                    case "chemical.report":
                        body = body.Replace("{SiteName}", "Chemical Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://chemical.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Chemical Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/TheChemicalReport/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/chemical-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/116230049211920401445");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "cloud.report":
                        body = body.Replace("{SiteName}", "Cloud Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://cloud.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Cloud Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Cloud.Computing.Report/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/cloud-report1");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/104795079924552291803");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "dataanalytics.report":
                        body = body.Replace("{SiteName}", "Data Analytics Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://dataanalytics.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Data Analytics Report");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/DataAnalytics.Report/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/dataanalytics-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/109579208390025894184");
                        body = body.Replace("http://tw.com", "https://twitter.com/DataAnalyticsR2");

                        break;

                    case "engineering.report":
                        body = body.Replace("{SiteName}", "Engineering Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://engineering.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Engineering Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Engineering.report/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/engineering.report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/111873872000949600820");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "government.report":
                        body = body.Replace("{SiteName}", "Government Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://government.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Government Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/government.report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/governmentreport");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/116648347583223320296");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "greenenergy.report":
                        body = body.Replace("{SiteName}", "Green Energy Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://greenenergy.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Green Energy Report");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/GreenEnergy.report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/greenenergy-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/113290459189685686116");
                        body = body.Replace("http://tw.com", "https://twitter.com/GreenenergyRpt");

                        break;

                    case "healthcare.report":
                        body = body.Replace("{SiteName}", "Healthcare Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://healthcare.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Healthcare Report");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Healthcare.report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/the-healthcare-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/102740252830492716604");
                        body = body.Replace("http://tw.com", "https://twitter.com/HealthcareRepo3");

                        break;

                    case "humanresources.report":
                        body = body.Replace("{SiteName}", "Human Resources Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://humanresources.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Human Resources Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/HumanResources.Report/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/the-humanresources-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/100109770568281030209?hl=en");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "informationsecurity.report":
                        body = body.Replace("{SiteName}", "Information Security Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://informationsecurity.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Information Security Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/InfoSec.report/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/informationsecurity-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/105616685142612477389?hl=en");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "infotech.report":
                        body = body.Replace("{SiteName}", "Infotech Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://infotech.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Infotech Report");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/TheInfotechReport/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/the-infotech-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/106513072017905681069?hl=en");
                        body = body.Replace("http://tw.com", "https://twitter.com/infotechreport1");

                        break;

                    case "itinfrastructure.report":
                        body = body.Replace("{SiteName}", "IT Infrastructure Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://itinfrastructure.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "IT Infrastructure Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/ITInfrastructure.report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/itinfrastructure.report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/108767760557877157552");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "manufacturing.report":
                        body = body.Replace("{SiteName}", "Manufacturing Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://manufacturing.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Manufacturing Report");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Manufacturing.report/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/manufacturing.report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/106669125275878359478");
                        body = body.Replace("http://tw.com", "https://twitter.com/manufactringre1");

                        break;

                    case "networking.report":
                        body = body.Replace("{SiteName}", "Networking Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".png");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://networking.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Networking Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Networking.Report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/networking.report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/106717057722806432373?hl=en");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "nonprofit.report":
                        body = body.Replace("{SiteName}", "Nonprofit Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://nonprofit.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Nonprofit Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Nonprofit.report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/nonprofit.report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/108697591802812816511");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "pharmaceutical.report":
                        body = body.Replace("{SiteName}", "Pharmaceutical Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://pharmaceutical.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Pharmaceutical Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Pharmaceutical.Report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/pharmaceutical.report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/101913904421328496543");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "re.report":
                        body = body.Replace("{SiteName}", "Re Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://re.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Re Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/REindustry/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/re.report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/117037258095616008539");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "smallbusiness.report":
                        body = body.Replace("{SiteName}", "Small Business Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://smallbusiness.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Small Business Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/SmallBusinessReport/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/small-business.report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/100798315370811914608");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "virtualization.network":
                        body = body.Replace("{SiteName}", "Virtualization Network");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://virtualization.network/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Virtualization Network");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Virtualization.Network");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/virtualization.network");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/105732599757951132641");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "wheels.report":
                        body = body.Replace("{SiteName}", "Wheels Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".png");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://wheels.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Wheels Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Wheels.report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/wheels-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/u/0/b/107965575776548533362/107965575776548533362/about");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "theinternetofthings.report":
                        body = body.Replace("{SiteName}", "Internet of Things Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://theinternetofthings.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());

                        body = body.Replace("http://fb.com", "https://www.facebook.com/TheInternetofThings.Report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/theinternetofthings-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/b/102236961973983653868/102236961973983653868/about?gmbpt=Y&hl=en");
                        body = body.Replace("http://tw.com", "https://twitter.com/TheInternetofT3");
                        break;

                    case "policy.report":
                        body = body.Replace("{SiteName}", "Policy Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://policy.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Policy Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/policyreport/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/policy-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/100211751164866148397");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "entertainment.report":
                        body = body.Replace("{SiteName}", "Entertainment Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://entertainment.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Entertainment Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/The.Entertainment.Report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/entertainment-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/103395655859112296888");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "travel.report":
                        body = body.Replace("{SiteName}", "Travel Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://travel.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Travel Report");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/TheTravelReport/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/travel.report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/102425791186500234009");
                        body = body.Replace("http://tw.com", "https://twitter.com/Travelreport2");

                        break;

                    case "pos.report":
                        body = body.Replace("{SiteName}", "POS Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://pos.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "POS Report");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/POSReport");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/pos.report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/111653842294237696457");
                        body = body.Replace("http://tw.com", "https://twitter.com/ReportPos");

                        break;

                    case "education.report":
                        body = body.Replace("{SiteName}", "Education Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://education.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("Internet of Things Report", "Education Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Education.report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/education.report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/108088234985181110758");
                        body = body.Replace("http://tw.com", "");

                        break;

                    default:
                        body = body.Replace("http://fb.com", "https://www.facebook.com/TheInternetofThings.Report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/theinternetofthings-report%C2%A0");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/b/102236961973983653868/102236961973983653868/about?gmbpt=Y&hl=en");
                        body = body.Replace("http://tw.com", "https://twitter.com/InternetofThe");

                        //body = body.Replace("{SiteName}", "Internet of Things Report");
                        //body = body.Replace("http://media7.io/new/Login.aspx", "http://theinternetofthings.report/Home.aspx?user=" + userId);
                        body = body.Replace("{SiteName}", "Internet of Things Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://theinternetofthings.report/Home.aspx?user=" + userId);
                        break;
                }
                #endregion

                //body = body.Replace("http://media7.io/new/Login.aspx", "http://localhost:5400/media7.io/new/Login.aspx?user=" + userId);
                //string url = "http://localhost:5400/media7.io/new/Login.aspx?user=" + userId;
                //body = body.Replace("{Password}", password); //replacing the required things  
                //body = body.Replace("{Title}", "Thank you for reaching out to us and giving Deck 7 the opportunity to enhance your digital marketing outreach. Within 24 hours, one of our account managers or specialists will be reaching back to you either by email or phone regarding your requested information. For immediate questions or requests feel free to call our home office at 1.619.900.9595 or 1.844.900.9595 Toll Free between 9am and 5pm PST.");
                //body = body.Replace("{message}", "<br />Looking forward to speaking soon!");
                //body = body.Replace("{EmailId}", txt_Email.Text.Trim());
                #endregion

                try
                {
                    string displayName = Sitename + " Membership Signup";
                    displayName = textInfo.ToTitleCase(displayName);
                    displayName = displayName.Replace(".Report", ".report");
                    MailAddress fromAddress = new MailAddress(from, displayName);
                    message.From = fromAddress;
                    message.To.Add(Email);
                    #region Hardcoded
                    message.Subject = Subject;
                    message.IsBodyHtml = true;

                    AlternateView htmlView = AlternateView.CreateAlternateViewFromString(body, null, "text/html");
                    message.AlternateViews.Add(htmlView);

                    smtpClient.Host = "smtp-relay.sendinblue.com";
                    smtpClient.Port = 587;
                    smtpClient.EnableSsl = false;
                    smtpClient.UseDefaultCredentials = true;
                    smtpClient.Credentials = new System.Net.NetworkCredential("manju@deck7marketing.com", "1sqWbrZjMaTpzRHx");
                    //smtpClient.Credentials = new System.Net.NetworkCredential("suraj@deck7.io", "qIHZDcpAftj0XROU");
                    smtpClient.Send(message);
                    msg = "Successful";
                    #endregion
                }
                catch (Exception ex)
                {
                    msg = ex.Message;
                }
                #endregion
            }
            catch (Exception ex)
            { }
        }

        private void AdvertiseMailService(string Email, string Fname, string password, int siteid, string Sitename, int terms, string Role)
        {
            try
            {
                //TextBox password = (TextBox)FindControl("Password123");
                string username = Email;
                // string password = GeneratePassword(Fname);
                MembershipCreateStatus createStatus;
                Membership.CreateUser(Email, password, Email, "nick name", "ok", false, out createStatus);

  

                Roles.AddUserToRole(Email, Role);

                ///Add Uset To Roles Need to do Manually
                ///Ankit
                ///Stauts: Pending
                ///


                #region NewRegistrationMail

                string Name = Email;
                string msg = string.Empty;
                string from = "members@media7.io";
                MailMessage message = new MailMessage();
                SmtpClient smtpClient = new SmtpClient();

                //string userName = txt_Name.Text.Trim();
                ////  Get the user's id
                //Guid userId = (Guid)Membership.GetUser(userName).ProviderUserKey;
                string Subject = "Welcome to the " + Sitename;
                TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
                //userName = textInfo.ToTitleCase(userName);
                #region Message Body

                string body = string.Empty;
                //using streamreader for reading my htmltemplate   

                using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("~/HtmlTemplates/ThankyouPubsite.htm")))
                {
                    body = reader.ReadToEnd();
                }

                //TextBox password = (TextBox)FindControl("Password123");

                MembershipUser mu = Membership.GetUser(Email);
                string userId = mu.ProviderUserKey.ToString();

                if (userId != "" || userId != null)
                {
                    StorePubsiteUsers(Email, siteid, terms, userId);
                }

                //Common com = new Common();
                //com.ClaimUserDomainCompany(Email, Sitename, userId);

                body = body.Replace("{UserName}", Fname);

                #region switch

                switch (Sitename.ToLower())
                {
                    case "abm.report":
                        body = body.Replace("{SiteName}", "ABM Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://ABM.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "ABM Report");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/ABM.report/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/abm-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/101910112412726385876");
                        body = body.Replace("http://tw.com", "https://twitter.com/report_abm");

                        break;

                    case "advertising.report":
                        body = body.Replace("{SiteName}", "Advertising Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://advertising.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Advertising Report");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Advertising.Report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/advertising.report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/111655297844529108876?hl=en");
                        body = body.Replace("http://tw.com", "https://twitter.com/advertisingrep3");

                        break;

                    case "aviation.report":
                        body = body.Replace("{SiteName}", "Aviation Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://aviation.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Aviation Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/The.Aviation.report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/aviation.report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/114280654416467366288");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "biotechnology.report":
                        body = body.Replace("{SiteName}", "Biotechnology Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://biotechnology.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Biotechnology Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Biotechnology.report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/the-biotechnology-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/114330393539843196461");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "biotech.report":
                        body = body.Replace("{SiteName}", "Biotech Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://biotech.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Biotech Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Biotechnology.report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/the-biotechnology-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/114330393539843196461");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "capital.report":
                        body = body.Replace("{SiteName}", "Capital Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://capital.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Capital Report");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Capital.Report/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/the-capital-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/107769852942524763370");
                        body = body.Replace("http://tw.com", "https://twitter.com/CapitalReport2");

                        break;

                    case "channel.report":
                        body = body.Replace("{SiteName}", "Channel Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://channel.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Channel Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/channel.report/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/the-channel-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/113549242602470470843");
                        body = body.Replace("http://tw.com", "");

                        break;


                    case "chemical.report":
                        body = body.Replace("{SiteName}", "Chemical Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://chemical.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Chemical Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/TheChemicalReport/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/chemical-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/116230049211920401445");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "cloud.report":
                        body = body.Replace("{SiteName}", "Cloud Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://cloud.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Cloud Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Cloud.Computing.Report/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/cloud-report1");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/104795079924552291803");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "dataanalytics.report":
                        body = body.Replace("{SiteName}", "Data Analytics Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://dataanalytics.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Data Analytics Report");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/DataAnalytics.Report/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/dataanalytics-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/109579208390025894184");
                        body = body.Replace("http://tw.com", "https://twitter.com/DataAnalyticsR2");

                        break;

                    case "engineering.report":
                        body = body.Replace("{SiteName}", "Engineering Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://engineering.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Engineering Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Engineering.report/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/engineering.report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/111873872000949600820");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "government.report":
                        body = body.Replace("{SiteName}", "Government Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://government.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Government Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/government.report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/governmentreport");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/116648347583223320296");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "greenenergy.report":
                        body = body.Replace("{SiteName}", "Green Energy Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://greenenergy.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Green Energy Report");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/GreenEnergy.report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/greenenergy-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/113290459189685686116");
                        body = body.Replace("http://tw.com", "https://twitter.com/GreenenergyRpt");

                        break;

                    case "healthcare.report":
                        body = body.Replace("{SiteName}", "Healthcare Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://healthcare.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Healthcare Report");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Healthcare.report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/the-healthcare-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/102740252830492716604");
                        body = body.Replace("http://tw.com", "https://twitter.com/HealthcareRepo3");

                        break;

                    case "humanresources.report":
                        body = body.Replace("{SiteName}", "Human Resources Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://humanresources.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Human Resources Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/HumanResources.Report/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/the-humanresources-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/100109770568281030209?hl=en");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "informationsecurity.report":
                        body = body.Replace("{SiteName}", "Information Security Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://informationsecurity.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Information Security Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/InfoSec.report/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/informationsecurity-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/105616685142612477389?hl=en");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "infotech.report":
                        body = body.Replace("{SiteName}", "Infotech Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://infotech.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Infotech Report");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/TheInfotechReport/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/the-infotech-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/106513072017905681069?hl=en");
                        body = body.Replace("http://tw.com", "https://twitter.com/infotechreport1");

                        break;

                    case "itinfrastructure.report":
                        body = body.Replace("{SiteName}", "IT Infrastructure Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://itinfrastructure.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "IT Infrastructure Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/ITInfrastructure.report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/itinfrastructure.report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/108767760557877157552");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "manufacturing.report":
                        body = body.Replace("{SiteName}", "Manufacturing Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://manufacturing.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Manufacturing Report");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Manufacturing.report/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/manufacturing.report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/106669125275878359478");
                        body = body.Replace("http://tw.com", "https://twitter.com/manufactringre1");

                        break;

                    case "networking.report":
                        body = body.Replace("{SiteName}", "Networking Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".png");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://networking.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Networking Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Networking.Report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/networking.report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/106717057722806432373?hl=en");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "nonprofit.report":
                        body = body.Replace("{SiteName}", "Nonprofit Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://nonprofit.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Nonprofit Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Nonprofit.report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/nonprofit.report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/108697591802812816511");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "pharmaceutical.report":
                        body = body.Replace("{SiteName}", "Pharmaceutical Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://pharmaceutical.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Pharmaceutical Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Pharmaceutical.Report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/pharmaceutical.report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/101913904421328496543");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "re.report":
                        body = body.Replace("{SiteName}", "Re Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://re.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Re Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/REindustry/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/re.report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/117037258095616008539");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "smallbusiness.report":
                        body = body.Replace("{SiteName}", "Small Business Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://smallbusiness.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Small Business Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/SmallBusinessReport/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/small-business.report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/100798315370811914608");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "virtualization.network":
                        body = body.Replace("{SiteName}", "Virtualization Network");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://virtualization.network/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Virtualization Network");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Virtualization.Network");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/virtualization.network");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/105732599757951132641");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "wheels.report":
                        body = body.Replace("{SiteName}", "Wheels Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".png");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://wheels.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Wheels Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Wheels.report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/wheels-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/u/0/b/107965575776548533362/107965575776548533362/about");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "theinternetofthings.report":
                        body = body.Replace("{SiteName}", "Internet of Things Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://theinternetofthings.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());

                        body = body.Replace("http://fb.com", "https://www.facebook.com/TheInternetofThings.Report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/theinternetofthings-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/b/102236961973983653868/102236961973983653868/about?gmbpt=Y&hl=en");
                        body = body.Replace("http://tw.com", "https://twitter.com/TheInternetofT3");
                        break;

                    case "policy.report":
                        body = body.Replace("{SiteName}", "Policy Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://policy.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Policy Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/policyreport/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/policy-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/100211751164866148397");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "entertainment.report":
                        body = body.Replace("{SiteName}", "Entertainment Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://entertainment.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Entertainment Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/The.Entertainment.Report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/entertainment-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/103395655859112296888");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "travel.report":
                        body = body.Replace("{SiteName}", "Travel Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://travel.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Travel Report");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/TheTravelReport/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/travel.report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/102425791186500234009");
                        body = body.Replace("http://tw.com", "https://twitter.com/Travelreport2");

                        break;

                    case "pos.report":
                        body = body.Replace("{SiteName}", "POS Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://pos.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "POS Report");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/POSReport");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/pos.report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/111653842294237696457");
                        body = body.Replace("http://tw.com", "https://twitter.com/ReportPos");

                        break;

                    case "education.report":
                        body = body.Replace("{SiteName}", "Education Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://education.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("Internet of Things Report", "Education Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Education.report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/education.report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/108088234985181110758");
                        body = body.Replace("http://tw.com", "");

                        break;

                    default:
                        body = body.Replace("http://fb.com", "https://www.facebook.com/TheInternetofThings.Report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/theinternetofthings-report%C2%A0");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/b/102236961973983653868/102236961973983653868/about?gmbpt=Y&hl=en");
                        body = body.Replace("http://tw.com", "https://twitter.com/InternetofThe");

                        //body = body.Replace("{SiteName}", "Internet of Things Report");
                        //body = body.Replace("http://media7.io/new/Login.aspx", "http://theinternetofthings.report/Home.aspx?user=" + userId);
                        body = body.Replace("{SiteName}", "Internet of Things Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://theinternetofthings.report/Home.aspx?user=" + userId);
                        break;
                }
                #endregion

                //body = body.Replace("http://media7.io/new/Login.aspx", "http://localhost:5400/media7.io/new/Login.aspx?user=" + userId);
                //string url = "http://localhost:5400/media7.io/new/Login.aspx?user=" + userId;
                //body = body.Replace("{Password}", password); //replacing the required things  
                //body = body.Replace("{Title}", "Thank you for reaching out to us and giving Deck 7 the opportunity to enhance your digital marketing outreach. Within 24 hours, one of our account managers or specialists will be reaching back to you either by email or phone regarding your requested information. For immediate questions or requests feel free to call our home office at 1.619.900.9595 or 1.844.900.9595 Toll Free between 9am and 5pm PST.");
                //body = body.Replace("{message}", "<br />Looking forward to speaking soon!");
                //body = body.Replace("{EmailId}", txt_Email.Text.Trim());
                #endregion

                try
                {
                    string displayName = Sitename + " Membership Signup";
                    displayName = textInfo.ToTitleCase(displayName);
                    displayName = displayName.Replace(".Report", ".report");
                    MailAddress fromAddress = new MailAddress(from, displayName);
                    message.From = fromAddress;
                    message.To.Add(Email);
                    #region Hardcoded
                    message.Subject = Subject;
                    message.IsBodyHtml = true;

                    AlternateView htmlView = AlternateView.CreateAlternateViewFromString(body, null, "text/html");
                    message.AlternateViews.Add(htmlView);

                    smtpClient.Host = "smtp-relay.sendinblue.com";
                    smtpClient.Port = 587;
                    smtpClient.EnableSsl = false;
                    smtpClient.UseDefaultCredentials = true;
                    smtpClient.Credentials = new System.Net.NetworkCredential("manju@deck7marketing.com", "1sqWbrZjMaTpzRHx");
                    //smtpClient.Credentials = new System.Net.NetworkCredential("suraj@deck7.io", "qIHZDcpAftj0XROU");
                    smtpClient.Send(message);
                    msg = "Successful";
                    #endregion
                }
                catch (Exception ex)
                {
                    msg = ex.Message;
                }
                #endregion


                #region Admin-1 email

                // string emailAddress = "info@deck7.io";////  // //// // 

                //string emailAddress1 = "Suraj@deck7.io";////  // //// // 

                string emailAddress1 = "micah@media7.com";

                string mssg1 = string.Empty;
                SmtpClient client1 = new SmtpClient();

                //// Now lets create an email message
                try
                {
                    StringBuilder emailMessage = new StringBuilder();
                    emailMessage.Append("Hello,");
                    emailMessage.Append("<br/><br/>");
                    emailMessage.Append("This user has signed up for Media Kit <br/><br/>");
                    emailMessage.Append("First Name: " + Fname);
                    emailMessage.Append("<br/>Email: " + Email);
                    emailMessage.Append("<br/>Site Name: " + Sitename);
                    emailMessage.Append("<br/>Role: " + Role);
                    emailMessage.Append("<br/><br/>");

                    //emailMessage.Append("<br/><br/><br/><br/>");
                    emailMessage.Append("Regards,<BR/>");
                    //if (hide.Value == "1")
                    //{
                    emailMessage.Append("Admin MEDIA 7 Network");
                    //}
                    //else
                    //{
                    //    emailMessage.Append("Admin DECK7 Media Network");
                    //}

                    MailMessage email = new MailMessage();
                    email.From = new MailAddress("members@media7.io");
                    email.To.Add(new MailAddress("micah@media7.com,ankit@nathanark.com,saurabh@deck7.com,girish@media7.com"));
                    email.Subject = "" + Email + " has requested for Media Kit";
                    email.Body = emailMessage.ToString();
                    email.IsBodyHtml = true;

                    //Send the email
                    client1.Host = "smtp-relay.sendinblue.com";
                    client1.Port = 587;
                    client1.EnableSsl = false;
                    client1.UseDefaultCredentials = true;
                    client1.Credentials = new System.Net.NetworkCredential("manju@deck7marketing.com", "1sqWbrZjMaTpzRHx");


                    client1.Send(email);
                    mssg1 = "Successfull";
                }
                catch (Exception ex)
                {
                    mssg1 = ex.Message;
                }
                #endregion
            }
            catch (Exception ex)
            { }
        }

        private DataSet CheckUserForPubsite(string email, int siteid)
        {
            DataSet dsCheckUserForPubsite = new DataSet();
            try
            {                
                M7Connection();
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserName", email);
                sqlCmd.Parameters.AddWithValue("@siteid", siteid);
                sqlCmd.CommandText = "spCheckUserForPubsite";
                sqlCmd.Connection = m7con;
                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                sda.Fill(dsCheckUserForPubsite);
            }
            catch (Exception e)
            {

            }
            return dsCheckUserForPubsite;
        }

        private DataSet CheckUserForIOTSignUp(string email)
        {
            DataSet dsUser = new DataSet();
            try
            {
                 
                M7Connection();
                
                SqlCommand sqlCmd1 = new SqlCommand();
                sqlCmd1.CommandType = CommandType.StoredProcedure;
                sqlCmd1.Parameters.AddWithValue("@email", email);
                sqlCmd1.CommandText = "spCheckUserForIOTSignUp";
                sqlCmd1.Connection = m7con;
                SqlDataAdapter sda1 = new SqlDataAdapter(sqlCmd1);
                sda1.Fill(dsUser);

            }
            catch (Exception e)
            {

            }
            return dsUser;
        }

        private int  GetSiteId(string siteName)
        {
            int Siteid = 0;
            try
            {
                M7Connection();

                DataSet dssiteID = new DataSet();

                SqlCommand sqlCmd1 = new SqlCommand();
                sqlCmd1.CommandType = CommandType.StoredProcedure;
                sqlCmd1.Parameters.AddWithValue("@SiteName", siteName);
                sqlCmd1.CommandText = "SpGetSiteId";
                sqlCmd1.Connection = m7con;
                SqlDataAdapter sda1 = new SqlDataAdapter(sqlCmd1);
                sda1.Fill(dssiteID);

                if (dssiteID.Tables.Count > 0 && dssiteID.Tables[0].Rows.Count > 0 && dssiteID != null)
                {
                    Siteid = Convert.ToInt32(dssiteID.Tables[0].Rows[0]["SiteId"]);

                }
            }
            catch(Exception ex)
            {

            }
            return Siteid;
        }

        private void ExistingUserMailService(string Email, string Fname, string password, int siteid, string Sitename)
        {
            try
            {

                #region NewRegistrationMail

                string Name = Email;
                string msg = string.Empty;
                string from = "members@media7.io";
                MailMessage message = new MailMessage();
                SmtpClient smtpClient = new SmtpClient();

                string Subject = "Welcome to the " + Sitename;
                TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
                #region Message Body

                string body = string.Empty;

                using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("~/HtmlTemplates/ThankyouPubsiteUser.htm")))
                {
                    body = reader.ReadToEnd();
                }

                MembershipUser mu = Membership.GetUser(Email);

                string userId = mu.ProviderUserKey.ToString();

                StorePubsiteUsers(Email, siteid, userId);

                DataSet dsPass = new DataSet();

                dsPass = GetPassword(userId);

                body = body.Replace("{UserName}", Fname);
                if (dsPass.Tables.Count > 0 && dsPass != null && dsPass.Tables[0].Rows.Count > 0)
                {
                    body = body.Replace("{Password}", dsPass.Tables[0].Rows[0]["Password"].ToString());
                }

                #region switch

                switch (Sitename.ToLower())
                {
                    case "abm.report":
                        body = body.Replace("{SiteName}", "ABM Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://ABM.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "ABM Report");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/ABM.report/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/abm-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/101910112412726385876");
                        body = body.Replace("http://tw.com", "https://twitter.com/report_abm");

                        break;

                    case "advertising.report":
                        body = body.Replace("{SiteName}", "Advertising Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://advertising.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Advertising Report");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Advertising.Report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/advertising.report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/111655297844529108876?hl=en");
                        body = body.Replace("http://tw.com", "https://twitter.com/advertisingrep3");

                        break;

                    case "aviation.report":
                        body = body.Replace("{SiteName}", "Aviation Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://aviation.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Aviation Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/The.Aviation.report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/aviation.report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/114280654416467366288");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "biotechnology.report":
                        body = body.Replace("{SiteName}", "Biotechnology Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://biotechnology.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Biotechnology Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Biotechnology.report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/the-biotechnology-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/114330393539843196461");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "biotech.report":
                        body = body.Replace("{SiteName}", "Biotech Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://biotech.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Biotech Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Biotechnology.report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/the-biotechnology-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/114330393539843196461");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "capital.report":
                        body = body.Replace("{SiteName}", "Capital Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://capital.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Capital Report");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Capital.Report/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/the-capital-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/107769852942524763370");
                        body = body.Replace("http://tw.com", "https://twitter.com/CapitalReport2");

                        break;

                    case "channel.report":
                        body = body.Replace("{SiteName}", "Channel Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://channel.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Channel Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/channel.report/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/the-channel-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/113549242602470470843");
                        body = body.Replace("http://tw.com", "");

                        break;


                    case "chemical.report":
                        body = body.Replace("{SiteName}", "Chemical Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://chemical.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Chemical Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/TheChemicalReport/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/chemical-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/116230049211920401445");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "cloud.report":
                        body = body.Replace("{SiteName}", "Cloud Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://cloud.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Cloud Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Cloud.Computing.Report/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/cloud-report1");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/104795079924552291803");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "dataanalytics.report":
                        body = body.Replace("{SiteName}", "Data Analytics Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://dataanalytics.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Data Analytics Report");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/DataAnalytics.Report/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/dataanalytics-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/109579208390025894184");
                        body = body.Replace("http://tw.com", "https://twitter.com/DataAnalyticsR2");

                        break;

                    case "engineering.report":
                        body = body.Replace("{SiteName}", "Engineering Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://engineering.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Engineering Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Engineering.report/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/engineering.report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/111873872000949600820");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "government.report":
                        body = body.Replace("{SiteName}", "Government Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://government.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Government Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/government.report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/governmentreport");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/116648347583223320296");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "greenenergy.report":
                        body = body.Replace("{SiteName}", "Green Energy Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://greenenergy.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Green Energy Report");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/GreenEnergy.report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/greenenergy-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/113290459189685686116");
                        body = body.Replace("http://tw.com", "https://twitter.com/GreenenergyRpt");

                        break;

                    case "healthcare.report":
                        body = body.Replace("{SiteName}", "Healthcare Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://healthcare.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Healthcare Report");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Healthcare.report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/the-healthcare-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/102740252830492716604");
                        body = body.Replace("http://tw.com", "https://twitter.com/HealthcareRepo3");

                        break;

                    case "humanresources.report":
                        body = body.Replace("{SiteName}", "Human Resources Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://humanresources.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Human Resources Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/HumanResources.Report/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/the-humanresources-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/100109770568281030209?hl=en");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "informationsecurity.report":
                        body = body.Replace("{SiteName}", "Information Security Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://informationsecurity.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Information Security Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/InfoSec.report/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/informationsecurity-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/105616685142612477389?hl=en");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "infotech.report":
                        body = body.Replace("{SiteName}", "Infotech Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://infotech.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Infotech Report");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/TheInfotechReport/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/the-infotech-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/106513072017905681069?hl=en");
                        body = body.Replace("http://tw.com", "https://twitter.com/infotechreport1");

                        break;

                    case "itinfrastructure.report":
                        body = body.Replace("{SiteName}", "IT Infrastructure Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://itinfrastructure.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "IT Infrastructure Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/ITInfrastructure.report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/itinfrastructure.report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/108767760557877157552");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "manufacturing.report":
                        body = body.Replace("{SiteName}", "Manufacturing Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://manufacturing.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Manufacturing Report");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Manufacturing.report/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/manufacturing.report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/106669125275878359478");
                        body = body.Replace("http://tw.com", "https://twitter.com/manufactringre1");

                        break;

                    case "networking.report":
                        body = body.Replace("{SiteName}", "Networking Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".png");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://networking.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Networking Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Networking.Report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/networking.report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/106717057722806432373?hl=en");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "nonprofit.report":
                        body = body.Replace("{SiteName}", "Nonprofit Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://nonprofit.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Nonprofit Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Nonprofit.report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/nonprofit.report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/108697591802812816511");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "pharmaceutical.report":
                        body = body.Replace("{SiteName}", "Pharmaceutical Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://pharmaceutical.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Pharmaceutical Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Pharmaceutical.Report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/pharmaceutical.report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/101913904421328496543");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "re.report":
                        body = body.Replace("{SiteName}", "Re Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://re.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Re Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/REindustry/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/re.report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/117037258095616008539");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "smallbusiness.report":
                        body = body.Replace("{SiteName}", "Small Business Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://smallbusiness.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Small Business Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/SmallBusinessReport/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/small-business.report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/100798315370811914608");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "virtualization.network":
                        body = body.Replace("{SiteName}", "Virtualization Network");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://virtualization.network/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Virtualization Network");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Virtualization.Network");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/virtualization.network");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/105732599757951132641");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "wheels.report":
                        body = body.Replace("{SiteName}", "Wheels Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".png");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://wheels.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Wheels Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Wheels.report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/wheels-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/u/0/b/107965575776548533362/107965575776548533362/about");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "theinternetofthings.report":
                        body = body.Replace("{SiteName}", "Internet of Things Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://theinternetofthings.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());

                        body = body.Replace("http://fb.com", "https://www.facebook.com/TheInternetofThings.Report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/theinternetofthings-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/b/102236961973983653868/102236961973983653868/about?gmbpt=Y&hl=en");
                        body = body.Replace("http://tw.com", "https://twitter.com/TheInternetofT3");
                        break;

                    case "policy.report":
                        body = body.Replace("{SiteName}", "Policy Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://policy.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Policy Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/policyreport/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/policy-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/100211751164866148397");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "entertainment.report":
                        body = body.Replace("{SiteName}", "Entertainment Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://entertainment.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Entertainment Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/The.Entertainment.Report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/entertainment-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/103395655859112296888");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "travel.report":
                        body = body.Replace("{SiteName}", "Travel Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://travel.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Travel Report");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/TheTravelReport/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/travel.report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/102425791186500234009");
                        body = body.Replace("http://tw.com", "https://twitter.com/Travelreport2");

                        break;

                    case "pos.report":
                        body = body.Replace("{SiteName}", "POS Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://pos.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "POS Report");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/POSReport");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/pos.report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/111653842294237696457");
                        body = body.Replace("http://tw.com", "https://twitter.com/ReportPos");

                        break;

                    case "education.report":
                        body = body.Replace("{SiteName}", "Education Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://education.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("Internet of Things Report", "Education Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Education.report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/education.report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/108088234985181110758");
                        body = body.Replace("http://tw.com", "");

                        break;

                    default:
                        body = body.Replace("http://fb.com", "https://www.facebook.com/TheInternetofThings.Report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/theinternetofthings-report%C2%A0");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/b/102236961973983653868/102236961973983653868/about?gmbpt=Y&hl=en");
                        body = body.Replace("http://tw.com", "https://twitter.com/InternetofThe");

                        //body = body.Replace("{SiteName}", "Internet of Things Report");
                        //body = body.Replace("http://media7.io/new/Login.aspx", "http://theinternetofthings.report/Home.aspx?user=" + userId);
                        body = body.Replace("{SiteName}", "Internet of Things Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://theinternetofthings.report/Home.aspx?user=" + userId);
                        break;
                }
                #endregion

                #endregion

                try
                {
                    string displayName = Sitename + " Membership Signup";
                    displayName = textInfo.ToTitleCase(displayName);
                    displayName = displayName.Replace(".Report", ".report");
                    MailAddress fromAddress = new MailAddress(from, displayName);
                    message.From = fromAddress;
                    message.To.Add(Email);
                    #region Hardcoded
                    message.Subject = Subject;
                    message.IsBodyHtml = true;

                    AlternateView htmlView = AlternateView.CreateAlternateViewFromString(body, null, "text/html");
                    message.AlternateViews.Add(htmlView);

                    smtpClient.Host = "smtp-relay.sendinblue.com";
                    smtpClient.Port = 587;
                    smtpClient.EnableSsl = false;
                    smtpClient.UseDefaultCredentials = true;
                    smtpClient.Credentials = new System.Net.NetworkCredential("manju@deck7marketing.com", "1sqWbrZjMaTpzRHx");
                    //mtpClient.Credentials = new System.Net.NetworkCredential("suraj@deck7.io", "qIHZDcpAftj0XROU");
                    smtpClient.Send(message);
                    msg = "Successful";
                    #endregion
                }
                catch (Exception ex)
                {
                    msg = ex.Message;
                }
                #endregion
            }
            catch (Exception ex)
            { }
        }

        private void ExistingUserMailService(string Email, string Fname, string password, int siteid, string Sitename, int terms)
        {
            try
            {

                #region NewRegistrationMail

                string Name = Email;
                string msg = string.Empty;
                string from = "members@media7.io";
                MailMessage message = new MailMessage();
                SmtpClient smtpClient = new SmtpClient();

                string Subject = "Welcome to the " + Sitename;
                TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
                #region Message Body

                string body = string.Empty;

                using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("~/HtmlTemplates/ThankyouPubsiteUser.htm")))
                {
                    body = reader.ReadToEnd();
                }

                MembershipUser mu = Membership.GetUser(Email);

                string userId = mu.ProviderUserKey.ToString();

                StorePubsiteUsers(Email, siteid, terms, userId);

                //Common com = new Common();
                //com.ClaimUserDomainCompany(Email, Sitename, userId);

                DataSet dsPass = new DataSet();

                dsPass = GetPassword(userId);

                body = body.Replace("{UserName}", Fname);
                if (dsPass.Tables.Count > 0 && dsPass != null && dsPass.Tables[0].Rows.Count > 0)
                {
                    body = body.Replace("{Password}", dsPass.Tables[0].Rows[0]["Password"].ToString());
                }

                #region switch

                switch (Sitename.ToLower())
                {
                    case "abm.report":
                        body = body.Replace("{SiteName}", "ABM Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://ABM.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "ABM Report");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/ABM.report/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/abm-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/101910112412726385876");
                        body = body.Replace("http://tw.com", "https://twitter.com/report_abm");

                        break;

                    case "advertising.report":
                        body = body.Replace("{SiteName}", "Advertising Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://advertising.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Advertising Report");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Advertising.Report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/advertising.report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/111655297844529108876?hl=en");
                        body = body.Replace("http://tw.com", "https://twitter.com/advertisingrep3");

                        break;

                    case "aviation.report":
                        body = body.Replace("{SiteName}", "Aviation Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://aviation.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Aviation Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/The.Aviation.report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/aviation.report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/114280654416467366288");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "biotechnology.report":
                        body = body.Replace("{SiteName}", "Biotechnology Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://biotechnology.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Biotechnology Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Biotechnology.report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/the-biotechnology-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/114330393539843196461");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "biotech.report":
                        body = body.Replace("{SiteName}", "Biotech Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://biotech.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Biotech Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Biotechnology.report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/the-biotechnology-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/114330393539843196461");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "capital.report":
                        body = body.Replace("{SiteName}", "Capital Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://capital.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Capital Report");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Capital.Report/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/the-capital-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/107769852942524763370");
                        body = body.Replace("http://tw.com", "https://twitter.com/CapitalReport2");

                        break;

                    case "channel.report":
                        body = body.Replace("{SiteName}", "Channel Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://channel.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Channel Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/channel.report/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/the-channel-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/113549242602470470843");
                        body = body.Replace("http://tw.com", "");

                        break;


                    case "chemical.report":
                        body = body.Replace("{SiteName}", "Chemical Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://chemical.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Chemical Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/TheChemicalReport/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/chemical-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/116230049211920401445");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "cloud.report":
                        body = body.Replace("{SiteName}", "Cloud Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://cloud.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Cloud Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Cloud.Computing.Report/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/cloud-report1");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/104795079924552291803");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "dataanalytics.report":
                        body = body.Replace("{SiteName}", "Data Analytics Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://dataanalytics.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Data Analytics Report");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/DataAnalytics.Report/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/dataanalytics-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/109579208390025894184");
                        body = body.Replace("http://tw.com", "https://twitter.com/DataAnalyticsR2");

                        break;

                    case "engineering.report":
                        body = body.Replace("{SiteName}", "Engineering Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://engineering.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Engineering Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Engineering.report/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/engineering.report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/111873872000949600820");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "government.report":
                        body = body.Replace("{SiteName}", "Government Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://government.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Government Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/government.report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/governmentreport");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/116648347583223320296");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "greenenergy.report":
                        body = body.Replace("{SiteName}", "Green Energy Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://greenenergy.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Green Energy Report");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/GreenEnergy.report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/greenenergy-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/113290459189685686116");
                        body = body.Replace("http://tw.com", "https://twitter.com/GreenenergyRpt");

                        break;

                    case "healthcare.report":
                        body = body.Replace("{SiteName}", "Healthcare Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://healthcare.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Healthcare Report");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Healthcare.report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/the-healthcare-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/102740252830492716604");
                        body = body.Replace("http://tw.com", "https://twitter.com/HealthcareRepo3");

                        break;

                    case "humanresources.report":
                        body = body.Replace("{SiteName}", "Human Resources Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://humanresources.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Human Resources Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/HumanResources.Report/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/the-humanresources-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/100109770568281030209?hl=en");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "informationsecurity.report":
                        body = body.Replace("{SiteName}", "Information Security Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://informationsecurity.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Information Security Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/InfoSec.report/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/informationsecurity-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/105616685142612477389?hl=en");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "infotech.report":
                        body = body.Replace("{SiteName}", "Infotech Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://infotech.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Infotech Report");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/TheInfotechReport/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/the-infotech-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/106513072017905681069?hl=en");
                        body = body.Replace("http://tw.com", "https://twitter.com/infotechreport1");

                        break;

                    case "itinfrastructure.report":
                        body = body.Replace("{SiteName}", "IT Infrastructure Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://itinfrastructure.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "IT Infrastructure Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/ITInfrastructure.report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/itinfrastructure.report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/108767760557877157552");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "manufacturing.report":
                        body = body.Replace("{SiteName}", "Manufacturing Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://manufacturing.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Manufacturing Report");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Manufacturing.report/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/manufacturing.report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/106669125275878359478");
                        body = body.Replace("http://tw.com", "https://twitter.com/manufactringre1");

                        break;

                    case "networking.report":
                        body = body.Replace("{SiteName}", "Networking Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".png");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://networking.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Networking Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Networking.Report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/networking.report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/106717057722806432373?hl=en");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "nonprofit.report":
                        body = body.Replace("{SiteName}", "Nonprofit Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://nonprofit.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Nonprofit Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Nonprofit.report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/nonprofit.report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/108697591802812816511");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "pharmaceutical.report":
                        body = body.Replace("{SiteName}", "Pharmaceutical Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://pharmaceutical.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Pharmaceutical Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Pharmaceutical.Report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/pharmaceutical.report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/101913904421328496543");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "re.report":
                        body = body.Replace("{SiteName}", "Re Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://re.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Re Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/REindustry/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/re.report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/117037258095616008539");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "smallbusiness.report":
                        body = body.Replace("{SiteName}", "Small Business Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://smallbusiness.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Small Business Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/SmallBusinessReport/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/small-business.report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/100798315370811914608");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "virtualization.network":
                        body = body.Replace("{SiteName}", "Virtualization Network");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://virtualization.network/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Virtualization Network");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Virtualization.Network");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/virtualization.network");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/105732599757951132641");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "wheels.report":
                        body = body.Replace("{SiteName}", "Wheels Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".png");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://wheels.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Wheels Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Wheels.report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/wheels-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/u/0/b/107965575776548533362/107965575776548533362/about");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "theinternetofthings.report":
                        body = body.Replace("{SiteName}", "Internet of Things Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://theinternetofthings.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());

                        body = body.Replace("http://fb.com", "https://www.facebook.com/TheInternetofThings.Report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/theinternetofthings-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/b/102236961973983653868/102236961973983653868/about?gmbpt=Y&hl=en");
                        body = body.Replace("http://tw.com", "https://twitter.com/TheInternetofT3");
                        break;

                    case "policy.report":
                        body = body.Replace("{SiteName}", "Policy Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://policy.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Policy Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/policyreport/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/policy-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/100211751164866148397");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "entertainment.report":
                        body = body.Replace("{SiteName}", "Entertainment Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://entertainment.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Entertainment Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/The.Entertainment.Report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/entertainment-report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/103395655859112296888");
                        body = body.Replace("http://tw.com", "");

                        break;

                    case "travel.report":
                        body = body.Replace("{SiteName}", "Travel Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://travel.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "Travel Report");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/TheTravelReport/");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/travel.report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/102425791186500234009");
                        body = body.Replace("http://tw.com", "https://twitter.com/Travelreport2");

                        break;

                    case "pos.report":
                        body = body.Replace("{SiteName}", "POS Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://pos.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("Internet of Things Report", "POS Report");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/POSReport");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/pos.report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/111653842294237696457");
                        body = body.Replace("http://tw.com", "https://twitter.com/ReportPos");

                        break;

                    case "education.report":
                        body = body.Replace("{SiteName}", "Education Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("theinternetofthings.report", Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://education.report/User-Email-Verifier.aspx?user=" + userId);
                        body = body.Replace("Internet of Things Report", "Education Report");
                        body = body.Replace("color:#444444;text-decoration:none;", "display:none");

                        body = body.Replace("http://fb.com", "https://www.facebook.com/Education.report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/education.report");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/108088234985181110758");
                        body = body.Replace("http://tw.com", "");

                        break;

                    default:
                        body = body.Replace("http://fb.com", "https://www.facebook.com/TheInternetofThings.Report");
                        body = body.Replace("http://li.com", "https://www.linkedin.com/company/theinternetofthings-report%C2%A0");
                        body = body.Replace("http://gplus.com", "https://plus.google.com/b/102236961973983653868/102236961973983653868/about?gmbpt=Y&hl=en");
                        body = body.Replace("http://tw.com", "https://twitter.com/InternetofThe");

                        //body = body.Replace("{SiteName}", "Internet of Things Report");
                        //body = body.Replace("http://media7.io/new/Login.aspx", "http://theinternetofthings.report/Home.aspx?user=" + userId);
                        body = body.Replace("{SiteName}", "Internet of Things Report");
                        body = body.Replace("http://media7.io/Advertise/Pubsite/Logos/theinternetofthings.report.jpg", "http://media7.io/Advertise/Pubsite/MailLogos/" + Sitename.ToLower() + ".jpg");
                        body = body.Replace("http://Pubsite.com", "http://" + Sitename.ToLower());
                        body = body.Replace("http://media7.io/new/Login.aspx", "http://theinternetofthings.report/Home.aspx?user=" + userId);
                        break;
                }
                #endregion

                #endregion

                try
                {
                    string displayName = Sitename + " Membership Signup";
                    displayName = textInfo.ToTitleCase(displayName);
                    displayName = displayName.Replace(".Report", ".report");
                    MailAddress fromAddress = new MailAddress(from, displayName);
                    message.From = fromAddress;
                    message.To.Add(Email);
                    #region Hardcoded
                    message.Subject = Subject;
                    message.IsBodyHtml = true;

                    AlternateView htmlView = AlternateView.CreateAlternateViewFromString(body, null, "text/html");
                    message.AlternateViews.Add(htmlView);

                    smtpClient.Host = "smtp-relay.sendinblue.com";
                    smtpClient.Port = 587;
                    smtpClient.EnableSsl = false;
                    smtpClient.UseDefaultCredentials = true;
                    smtpClient.Credentials = new System.Net.NetworkCredential("manju@deck7marketing.com", "1sqWbrZjMaTpzRHx");
                    //smtpClient.Credentials = new System.Net.NetworkCredential("suraj@deck7.io", "qIHZDcpAftj0XROU");
                    smtpClient.Send(message);
                    msg = "Successful";
                    #endregion
                }
                catch (Exception ex)
                {
                    msg = ex.Message;
                }
                #endregion
            }
            catch (Exception ex)
            { }
        }

        private DataSet GetPassword(string UserId)
        {
            DataSet dsGetPassword = new DataSet();
            try
            {
                M7Connection(); 
                SqlCommand sqlCmd1 = new SqlCommand();
                sqlCmd1.CommandType = CommandType.StoredProcedure;
                sqlCmd1.Parameters.AddWithValue("@UserId", UserId);
                sqlCmd1.CommandText = "SPGetPassword";
                sqlCmd1.Connection = m7con;
                SqlDataAdapter sda1 = new SqlDataAdapter(sqlCmd1);
                sda1.Fill(dsGetPassword);
            }
            catch (Exception ex)
            {

            }
            return dsGetPassword;             
        }

        private void StorePubsiteUsers(string username, int siteid, string userid)
        {
            try
            {                
                M7Connection();
                
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@username", username);
                sqlCmd.Parameters.AddWithValue("@siteid", siteid);
                sqlCmd.Parameters.AddWithValue("@userid", userid);
                sqlCmd.CommandText = "SpInsertPubsiteUsers";
                sqlCmd.Connection = m7con;
                sqlCmd.Connection.Open();
                sqlCmd.ExecuteNonQuery();
                sqlCmd.Connection.Close();
            }
            catch (Exception ex)
            { }
        }

        private void StorePubsiteUsers(string username, int siteid, int terms, string userid)
        {
            try
            {                 
                M7Connection();

                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;                 
                sqlCmd.Parameters.AddWithValue("@username", username);
                sqlCmd.Parameters.AddWithValue("@siteid", siteid);
                sqlCmd.Parameters.AddWithValue("@ActiveTermsandPolicy", terms);
                sqlCmd.Parameters.AddWithValue("@userid", userid);
                 
                sqlCmd.CommandText = "SpInsertPubsiteUsersWithTermsandCondition";
                sqlCmd.Connection = m7con;
                sqlCmd.Connection.Open();
                sqlCmd.ExecuteNonQuery();
                sqlCmd.Connection.Close();

            }
            catch (Exception ex)
            { }
        }

        private void StorePubsiteUsers(string username, int siteid, int terms, string userid, int active)
        {
            try
            {                
                M7Connection();

                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@username", username);
                sqlCmd.Parameters.AddWithValue("@siteid", siteid);
                sqlCmd.Parameters.AddWithValue("@ActiveTermsandPolicy", terms);
                sqlCmd.Parameters.AddWithValue("@userid", userid);
                sqlCmd.Parameters.AddWithValue("@Active", active);

                sqlCmd.CommandText = "SpInsertPubsiteUsersWithTermsandConditionAndSite";
                sqlCmd.Connection = m7con;
                sqlCmd.Connection.Open();
                sqlCmd.ExecuteNonQuery();
                sqlCmd.Connection.Close();
            }
            catch (Exception ex)
            { }
        }

    }
}



