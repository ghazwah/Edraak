using EdraakProject1.App_Code;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net.Mail;
using System.Net;
using System.Threading;
using System.Configuration;
using System.Web.Configuration;


namespace EdraakProject1
{
    public partial class teacherSignup : System.Web.UI.Page
    {



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                populatecountryCombo();
                populategenderCombo();
                populatemajorCombo();
                populateCblCourse();
            }

        }
        protected void populateCblCourse()
        {
            CRUD myCrud = new CRUD();
            string mySql = @"select courseId ,course from course ";
            myCrud.populateCbL(cblCourse, mySql, "courseId", "course");
        }
        private void populatemajorCombo()
        {
            CRUD myCrud = new CRUD();
            string mySql = @"select majorId, major  from major";
            SqlDataReader dr = myCrud.getDrPassSql(mySql);
            ddlMajor.DataTextField = "major";
            ddlMajor.DataValueField = "majorId";
            ddlMajor.DataSource = dr;
            ddlMajor.DataBind();
            myCrud.con.Close();

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
            ddlTeacherCountry.DataTextField = "country";
            ddlTeacherCountry.DataValueField = "countryId";
            ddlTeacherCountry.DataSource = dr;
            ddlTeacherCountry.DataBind();
            myCrud.con.Close();
        }



        protected void btnTeacherSignup_Click(object sender, EventArgs e)

        {

            if (!string.IsNullOrEmpty(txtContactNoTeacher.Text) && int.TryParse(txtContactNoTeacher.Text, out int n))
            {

                CRUD myCrud = new CRUD();
                string Email = txtEmailTeacher.Text;
                string Username = txtTescherUser.Text;
                string Phone = txtContactNoTeacher.Text;

                string mySql = @"select teacherEmail,teacherUser,contactNo from teacher where teacherEmail = @teacherEmail OR teacherUser = @teacherUser OR contactNo=@contactNo";
                Dictionary<string, object> myPara = new Dictionary<string, object>();
                myPara.Add("@teacherEmail", Email);
                myPara.Add("@teacherUser", Username);
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
                            lblError.Text = "Phone Number  already available";
                        }
                        lblError.Visible = true;

                        lblError.ForeColor = System.Drawing.Color.Red;
                    }
                }
                else
                {
                    myCrud.con.Close();
                    insertTeacher();
                  
                }
            }

            else
            {
                Response.Write("<script>alert('incorrect Phone Number');</script>");
            }
            
        }
        //void sendEmail()
        //{
        //    SmtpClient smtp = new SmtpClient();
        //    smtp.Host = "smtp.gmail.com";
        //    smtp.Port = 587;
        //    smtp.Credentials = new System.Net.NetworkCredential("edraak.project.1@gmail.com", "EdraakProject5-");
        //    smtp.EnableSsl = true;
        //    MailMessage msg = new MailMessage();
        //    msg.Subject = "Hello " + txtTeacher.Text + "  Thanks for Register at Edraak ";
        //    msg.Body = "Hi, Thanks For Your Registration at Edraak , We will Provide You The Latest Update. Thanks";
        //    string toaddress = txtEmailTeacher.Text;
        //    msg.To.Add(toaddress);
        //    string fromaddress = "Edraak  <edraak.project.1@gmail.com>";
        //    msg.From = new MailAddress(fromaddress);
        //    try
        //    {
        //        smtp.Send(msg);
        //        //Label3.Text = "Your Email Has Been Registered with Us";
        //        txtTeacher.Text = "";
        //        txtEmailTeacher.Text = "";

        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}
        /////////////////////////////
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

        protected void insertTeacher()
        {
            CRUD myCrud = new CRUD();
            string mySql = @"insert into teacher (teacher ,contactNo,teacherEmail,countryId,genderId,teacherUser,password, dob ,majorId,
                                                   experience,note) 
                                           values (@teacher ,@contactNo,@teacherEmail ,@countryId ,@genderId ,@teacherUser,@password,
                                                   @dob,@majorId,@experience,@note)
                                           SELECT CAST(scope_identity() AS int)";
            Dictionary<string, object> myParaInsert = new Dictionary<string, object>();
            myParaInsert.Add("@teacher", txtTeacher.Text);
            myParaInsert.Add("@contactNo", txtContactNoTeacher.Text);
            myParaInsert.Add("@teacherEmail", txtEmailTeacher.Text);
            myParaInsert.Add("@countryId", ddlTeacherCountry.SelectedValue);
            myParaInsert.Add("@genderId", ddlGender.SelectedValue);
            myParaInsert.Add("@teacherUser", txtTescherUser.Text);
            myParaInsert.Add("@password", txtPassword.Text);
            myParaInsert.Add("@dob", txtBirthTeacher.Text);
            myParaInsert.Add("@majorId", ddlMajor.SelectedValue);
            myParaInsert.Add("@experience", txtExperience.Text);
            myParaInsert.Add("@note", txtNote.Text);

            List<string> courseList = new List<string>();
            foreach (ListItem item in cblCourse.Items)
            {
                if (item.Selected)
                {
                    courseList.Add(item.Value);
                }
            }
            int pk = myCrud.InsertUpdateDeleteViaSqlDicRtnIdentity(mySql, myParaInsert);
            insertTeacherCourse(pk, courseList);
            lblError.Text = "";

            string userEmail = txtEmailTeacher.Text;
            string emailSubject = "Thank you for signing up on Edraak";
            string emailBody = "Your account has been registered and authenticated. Thank you for signing up!";
            sendEmailViaGmail(userEmail, emailSubject, emailBody);



        }
        protected void insertTeacherCourse(int myTeacherId, List<string> myTeacherCourse)
        {
            int myCounter = 0;
            foreach (string item in myTeacherCourse)
            {
                // call another method to insert to the db
                addNewTeacherCourse(myTeacherId, int.Parse(item));
                myCounter += 1;
            }
            if (myCounter >= 1)
            {
                Response.Write("<script>alert('Sign Up Successful . Go to User Login to Login');</script>");

            }
            else
            {
                Response.Write("<script>alert('Failed Sign Up Try Agin ');</script>");

            }
            Server.Transfer("teacherLogin.aspx");
        }
        protected void addNewTeacherCourse(int myId, int myCourseId)
        {
            CRUD myCrud = new CRUD();
            string mySql = @"insert into teacherCourse(teacherId, CourseId) values (@teacherId, @courseId)";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@teacherId", myId);
            myPara.Add("@courseId", myCourseId);
            myCrud.InsertUpdateDelete(mySql, myPara);
        }
    }
}
