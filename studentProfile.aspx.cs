using EdraakProject1.App_Code;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EdraakProject1
{
    public partial class studentProfile : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                populatecountryCombo();
                populategenderCombo();

                try
                {
                    if (Session["username"].ToString() == "" || Session["username"] == null)
                    {
                        Response.Write("<script>alert('Session Expired Login Again');</script>");
                        Response.Redirect("userlogin.aspx");
                    }
                    else
                    {

                        string Username = Session["username"].ToString();
                        getUserData(Username);
                    }

                }
                catch (Exception ex)
                {

                    Response.Write("<script>alert('Session Expired Login Again');</script>");
                    Response.Redirect("userlogin.aspx");
                }
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
        }
        protected void btnStudentUpdate_Click(object sender, EventArgs e)
        {
            studentUpdate();
        }
        protected void studentUpdate()
        {

            int PK = int.Parse(txtStudentId.Text);
            string strStudentName = txtStudent.Text;
            string strStudentNO = txtPhoneStudent.Text;
            string strStudentEmail = txtStudentEmail.Text;
            string strStudentGender = ddlGender.SelectedValue;
            string strStudentCountry = ddlStudentCountry.SelectedValue;
            //string strStudentPassword = txtOldStudentPassword.Text;
            string Receipt = lblRecipt.Text;

            CRUD myCrud = new CRUD();
            string mySql = @" update student set student = @student , contactNo = @contactNo , email =@email , genderId =@genderId ,
                                                 countryId = @countryId , password = @password
                                                ,Receipt=@Receipt
                              where studentId= @studentId";
            //
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            string Password = txtOldStudentPassword.Text;
            myPara.Add("@studentId", PK);
            myPara.Add("@student", strStudentName);
            myPara.Add("@contactNo", strStudentNO);
            myPara.Add("@email", strStudentEmail);
            myPara.Add("@genderId", strStudentGender);
            myPara.Add("@countryId", strStudentCountry);
            if (txtNewStudentPassword.Text != "")
                Password = txtNewStudentPassword.Text;
            myPara.Add("@password", Password);

            if (FileUpload1.HasFile)
            {
                string Extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
                string FileName = "img_" + PK.ToString() + Extension;
                string FilePath = Server.MapPath(@"~/Receipt/" + FileName);
                Receipt = FileName;
                FileUpload1.SaveAs(FilePath);
            }
            myPara.Add("@Receipt", Receipt);
            int rtn = myCrud.InsertUpdateDelete(mySql, myPara);
            if (rtn >= 1)
            {
                Response.Write("<script>alert('Successful ');</script>");
            }
            else
            { Response.Write("<script>alert('Failed  Try Agin ');</script>"); }
        }

        void getUserData(string username)
        {
            CRUD myCrud = new CRUD();
            string mySql = @"  select * from student where studentUser = @studentUser ";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@studentUser", username);
            SqlDataReader dr = myCrud.getDrPassSql(mySql, myPara);
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    txtStudentId.Text = dr[0].ToString();
                    txtStudent.Text = dr[1].ToString();
                    txtPhoneStudent.Text = dr[2].ToString();
                    txtStudentEmail.Text = dr[3].ToString();
                    ddlGender.SelectedValue = dr[5].ToString();
                    ddlStudentCountry.SelectedValue = dr[6].ToString();
                    txtNewStudentPassword.Text = dr[7].ToString();
                    lblRecipt.Text = dr[8].ToString();
                }
            }
            int PK = int.Parse(txtStudentId.Text);
            string strStudentName = txtStudent.Text;
            string strStudentNO = txtPhoneStudent.Text;
            string strStudentEmail = txtStudentEmail.Text;
            string strStudentGender = ddlGender.SelectedValue;
            string strStudentCountry = ddlStudentCountry.SelectedValue;
            string strStudentPassword = txtNewStudentPassword.Text;


        }
    }
}