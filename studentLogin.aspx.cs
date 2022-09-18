using EdraakProject1.App_Code;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EdraakProject1
{
    public partial class studentLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string strUserName = txtLogin.Text;
            string strUserPassword = txtPassword.Text;
            CRUD myCrud = new CRUD();
            string mySql = @"select * from student where studentUser = @studentUser and password=@Password";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@studentUser", strUserName);
            myPara.Add("@Password", strUserPassword);
            SqlDataReader dr = myCrud.getDrPassSql(mySql, myPara);
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Response.Write("<script>alert('Login Successful');</script>");
                    Session["username"] = dr.GetValue(4).ToString();
                    Session["fullname"] = dr.GetValue(1).ToString();
                    Session["role"] = "user";
                }
                Response.Redirect("homepage.aspx");
            }


            else
            {
                Response.Write("<script>alert('Invalid credentials');</script>");
            }


        }
    }
}