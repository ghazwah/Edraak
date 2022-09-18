using EdraakProject1.App_Code;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EdraakProject1
{
    public partial class adminLogin : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }



        protected void btnAdminLogin_Click(object sender, EventArgs e)
        {

            string strUserName = txtAdmin.Text;
            string strUserPassword = txtPasswordAdmin.Text;
            CRUD myCrud = new CRUD();
            string mySql = @"  select * from adminLogin where adminUser = @adminUser and adminPassword=@adminPassword";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@adminUser", strUserName);
            myPara.Add("@adminPassword", strUserPassword);
            SqlDataReader dr = myCrud.getDrPassSql(mySql, myPara);

            if (dr.HasRows)
            {

                while (dr.Read())
                {

                    Response.Write("<script>alert('Login Successful');</script>");
                    Session["username"] = dr.GetValue(1).ToString();
                    Session["fullname"] = dr.GetValue(3).ToString();
                    Session["role"] = "admin";
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



                    

        
    
