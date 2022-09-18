using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EdraakProject1
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (Session["role"].Equals(""))
                {

                    linkBtnLogin.Visible = true; //user login link button
                    linkBtnSignup.Visible = true; //sign up link button

                    linkBtnLogout.Visible = false; //logout link button
                    LinkHello.Visible = false; //hello user

                    LinkHello.Visible = false;
                    linkAdminLogin.Visible = true; //login admin 
                    
                    linkTeacherManagement.Visible = false;
                    linkStudentManagement.Visible = false;
                    linkCourseManagement.Visible = false;
                    linkMajorManagemet.Visible = false;


                }

                else if (Session["role"].Equals("user"))
                {

                    linkBtnLogin.Visible = false; //user login link button
                    linkBtnSignup.Visible = false; //sign up link button

                    linkBtnLogout.Visible = true; //logout link button
                    linkBtsHelloUser.Visible = false; //hello user
                    LinkHello.Visible = true;
                    LinkHello.Text = "Hello " +Session["username"].ToString();

                    linkAdminLogin.Visible = true; //login admin 
                    
                    linkTeacherManagement.Visible = false;
                    linkStudentManagement.Visible = false;
                    linkCourseManagement.Visible = false;
                    linkMajorManagemet.Visible = false;

                }
                else if (Session["role"].Equals("Teacher"))
                {

                    linkBtnLogin.Visible = false; //user login link button
                    linkBtnSignup.Visible = false; //sign up link button

                    linkBtnLogout.Visible = true; //logout link button
                    linkBtsHelloUser.Visible = false; //hello user
                    LinkHello.Visible = true;
                    LinkHello.Text = "Hello " + Session["username"].ToString();

                    linkAdminLogin.Visible = true; //login admin 

                    linkTeacherManagement.Visible = false;
                    linkStudentManagement.Visible = false;
                    linkCourseManagement.Visible = false;
                    linkMajorManagemet.Visible = false;

                }


                else if (Session["role"].Equals("admin"))
                {

                    linkBtnLogin.Visible = false; //user login link button
                    linkBtnSignup.Visible = false; //sign up link button

                    linkBtnLogout.Visible = true; //logout link button
                    linkBtsHelloUser.Visible = false; //hello user
                    LinkHello.Visible = true;
                    LinkHello.Text = "Hello Admin " + Session["username"].ToString();

                    linkAdminLogin.Visible = false; //login admin 
                     
                    linkTeacherManagement.Visible = true;
                    linkStudentManagement.Visible = true;
                    linkCourseManagement.Visible = true;
                    linkMajorManagemet.Visible = true;

                }
            }
            catch (Exception ex)
            {


            }

        }

        protected void linkAdminLogin_Click(object sender, EventArgs e)
        {

            Response.Redirect("adminLogin.aspx");
        }
        

        protected void linkTeacherManagement_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminTeacherManagement.aspx");
        }

        protected void linkStudentManagement_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminStudentManagement.aspx");
        }

        protected void linkCourseManagement_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminCourseManagement.aspx");
        }

        protected void linkMajorManagemet_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminMajorManagement.aspx");
        }







        

        protected void linkBtnUserLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }

        protected void linkBtnSignup_Click(object sender, EventArgs e)
        {
            Response.Redirect("signupHomepage.aspx");
        }

        protected void linkBtnLogout_Click(object sender, EventArgs e)
        {
            Session["username"] = "";
            Session["fullname"] = "";
            Session["role"] = "";

            linkBtnLogin.Visible = true; //user login link button
            linkBtnSignup.Visible = true; //sign up link button

            linkBtnLogout.Visible = false; //logout link button
            linkBtsHelloUser.Visible = false; //hello user


            linkAdminLogin.Visible = true; //login admin 
            
            linkTeacherManagement.Visible = false;
            linkStudentManagement.Visible = false;
            linkCourseManagement.Visible = false;
            linkMajorManagemet.Visible = false;

            Response.Redirect("Homepage.aspx");

        }

        protected void linkHello_Click(object sender, EventArgs e)
        {
            
        }

        protected void linkBtnViewTeacher_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewTeacher.aspx");
        }

        protected void LinkHello_Click1(object sender, EventArgs e)
        {
            if (Session["role"].Equals("Teacher"))
            {
                Response.Redirect("teacherProfile.aspx");
            }

            else if (Session["role"].Equals("user"))
            {
                Response.Redirect("studentProfile.aspx");
            }
        }

        protected void linkBtsHelloUser_Click(object sender, EventArgs e)
        {

        }
    }
}
