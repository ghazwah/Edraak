using EdraakProject1.App_Code;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Threading;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EdraakProject1
{
    public partial class studentSignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                populatecountryCombo();
                populategenderCombo();

            }


        }
        private void populategenderCombo()
        {
            CRUD myCrud = new CRUD();
            string mySql = @"select genderId, gender  from gender";
            SqlDataReader dr = myCrud.getDrPassSql(mySql);
            ddlGender.DataTextField = "gender";
            ddlGender.DataValueField = "genderId";
            ddlGender.DataSource = dr;
            ddlGender.DataBind();
            myCrud.con.Close();
        }
        private void populatecountryCombo()
        {
            CRUD myCrud = new CRUD();
            string mySql = @"select countryId, country  from country";
            SqlDataReader dr = myCrud.getDrPassSql(mySql);
            ddlStudentCountry.DataTextField = "country";
            ddlStudentCountry.DataValueField = "countryId";
            ddlStudentCountry.DataSource = dr;
            ddlStudentCountry.DataBind();
            myCrud.con.Close();
        }
        protected void btnStudentSignup_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtContactNoStudent.Text) && int.TryParse(txtContactNoStudent.Text, out int n))
            {
                CRUD myCrud = new CRUD();
                string Email = txtEmailStudent.Text;
                string Username = txtUser.Text;
                string Phone = txtContactNoStudent.Text;
                string mySql = @"select Email,studentUser from student where Email = @Email OR studentUser = @studentUser OR contactNo=@contactNo";
                Dictionary<string, object> myPara = new Dictionary<string, object>();
                myPara.Add("@Email", Email);
                myPara.Add("@studentUser", Username);
                myPara.Add("@contactNo", Phone);
                SqlDataReader rd = myCrud.getDrPassSql(mySql, myPara);
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        if (rd[0].ToString() == Email)
                        {
                            lblError.Text = "Email already available";
                        }
                        if (rd[1].ToString() == Username)
                        {
                            lblError.Text = "User Id already available";
                        }
                        if (rd[2].ToString() == Phone)
                        {
                            lblError.Text = "Phone Number already available";
                        }
                        lblError.Visible = true;

                        lblError.ForeColor = System.Drawing.Color.Red;
                    }
                }
                else
                {
                    myCrud.con.Close();
                    insertStudent();
                }
            }
            else
            {
                Response.Write("<script>alert('incorrect Phone Number');</script>");
            }



           
            string uname = HttpContext.Current.User.Identity.Name.ToString();
             string userEmail = txtEmailStudent.Text;
            string emailSubject = "Thank you for signing up on Edraak";
            string emailBody = "Your account has been registered and authenticated. Thank you for signing up!";
            sendEmailViaGmail(userEmail, emailSubject, emailBody);
        }


        public void insertStudent()
            {
            CRUD myCrud = new CRUD();
            string mySql = @"insert into student (student ,contactNo,email ,countryId  ,genderId ,studentUser,password) 
                                            values (@student ,@contactNo,@email ,@countryId ,@genderId ,@studentUser,@password)";
                    Dictionary<string, object> myParaInsert = new Dictionary<string, object>();

        myParaInsert.Add("@student", txtStudent.Text);
                    myParaInsert.Add("@contactNo", txtContactNoStudent.Text);
                    myParaInsert.Add("@email", txtEmailStudent.Text);
                    myParaInsert.Add("@countryId", ddlStudentCountry.SelectedValue);
                    myParaInsert.Add("@genderId", ddlGender.SelectedValue);
                    myParaInsert.Add("@studentUser", txtUser.Text);
                    myParaInsert.Add("@password", txtPassword.Text);



                    int rtn = myCrud.InsertUpdateDelete(mySql, myParaInsert);
                    if (rtn >= 1)
                    {
                        Response.Write("<script>alert('Sign Up Successful . Go to User Login to Login');</script>");

                    }

                    else
                    {
                        Response.Write("<script>alert('Failed Sign Up Try Agin ');</script>");
                    }
            Server.Transfer("studentLogin.aspx");
        }
        public string sendEmailViaGmail(string userEmail, string emailSubject, string emailBody)
        {
            //throw new NotImplementedException();

            string myFrom = "edraak.project.1@gmail.com";
            string myTo = userEmail;
            string mySubject = emailSubject;
            string myBody = emailBody;

            string myHostsmtpAddress = "smtp.gmail.com";//
            int myPortNumber = 587;
            bool myEnableSSL = true;
            string myUserName = "edraak.project.1@gmail.com";//
            string myPassword = "EdraakProject5-";//




            //string visitorUserName = Page.User.Identity.Name;
            using (MailMessage m = new MailMessage(myFrom, myTo, mySubject, myBody)) // .............................1
            {
                SmtpClient sc = new SmtpClient(myHostsmtpAddress, myPortNumber); //..................................2
                try
                {
                    sc.Credentials = new System.Net.NetworkCredential(myUserName, myPassword);  //.................3
                    sc.EnableSsl = true;
                    sc.Send(m);
                    return "Email Send successfully";
                    //lblMsg.Text = ("Email Send successfully");
                    //lblMsg.ForeColor = Color.Green; // using System.Drawing above 2/2018
                }
                catch (SmtpFailedRecipientException ex)
                {
                    SmtpStatusCode statusCode = ex.StatusCode;
                    if (statusCode == SmtpStatusCode.MailboxBusy || statusCode == SmtpStatusCode.MailboxUnavailable || statusCode == SmtpStatusCode.TransactionFailed)
                    {   // wait 5 seconds, try a second time
                        Thread.Sleep(5000);
                        sc.Send(m);
                        return ex.Message.ToString();
                    }
                    else
                    {
                        throw;
                    }
                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }
                finally
                {
                    m.Dispose();
                }
            }
        }

    }
}


        
