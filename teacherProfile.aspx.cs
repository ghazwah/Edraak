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
    public partial class teacherProfile : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                populatecountryCombo();
                populategenderCombo();
                populatemajorCombo();
                populateCblCourse();
                if (Session["username"].ToString() == "" || Session["username"] == null)
                {
                    Response.Write("<script>alert('Session Expired Login Again');</script>");
                    Response.Redirect("Teacherlogin.aspx");
                }
                else
                {
                    string Username = Session["username"].ToString();
                    getTeacherData(Username);
                }

            }
        }

        public void getTeacherData(string Username)
        {
            CRUD myCrud = new CRUD();
            string mySql = @"select * from teacher where  teacherUser = @teacherUser";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@teacherUser", Username);

            SqlDataReader rd = myCrud.getDrPassSql(mySql, myPara);
            if (rd.HasRows)
            {

                while (rd.Read())
                {
                    txtTeacher.Text = rd[1].ToString();
                    txtEmail.Text = rd[2].ToString();
                    txtBirthTeacher.Text = rd[3].ToString();
                    txtPhoneTeacher.Text = rd[5].ToString();
                    txtUserTeacher.Text = rd[4].ToString();
                    ddlGender.SelectedValue = rd[8].ToString();
                    txtExperiance.Text = rd[7].ToString();
                    ddlMajor.SelectedValue = rd[6].ToString();
                    ddlTeacherCountry.SelectedValue = rd[9].ToString();
                    txtNote.Text = rd[10].ToString();
                    txtOldTeacherPassword.Text = rd[11].ToString();
                    HiddenFieldID.Value = rd[0].ToString();
                }
            }
            myCrud.con.Close();
            int TeacherID = Convert.ToInt32(HiddenFieldID.Value);
            getTeacherCourse(TeacherID);
        }
        protected void getTeacherCourse(int TeacherID)
        {
            CRUD myCrud = new CRUD();
            string mySql = @"select * from teacherCourse where  teacherId = @teacherId";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@teacherId", TeacherID);

            SqlDataReader rd = myCrud.getDrPassSql(mySql, myPara);
            if (rd.HasRows)
            {

                while (rd.Read())
                {

                    foreach (ListItem item in cblCourse.Items)
                    {
                        if (rd[2].ToString() == item.Value)
                            item.Selected = true;
                    }
                }
            }
        }

        protected void populateCblCourse()
        {
            CRUD myCrud = new CRUD();
            string mySql = @"select courseId ,course from course ";
            myCrud.populateCbL(cblCourse, mySql, "courseId", "course");
            myCrud.con.Close();
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

        protected void btnTeacherUpdate_Click(object sender, EventArgs e)
        {
            UpdateTeacher();
        }
        protected void UpdateTeacher()
        {
            string Username = Session["username"].ToString();
            CRUD myCrud = new CRUD();
            string mySql = @"Update teacher set  teacher=@teacher 
                                                ,contactNo =@contactNo
                                                ,teacherEmail =@teacherEmail
                                                ,countryId=@countryId
                                                ,genderId=@genderId
                                                ,teacherUser=@teacherUser
                                                ,dob=@dob 
                                                ,majorId=@majorId
                                                ,experience=@experience
                                                ,note=@note
                                                ,password = @password
                                         where TeacherID=@TeacherID";
            Dictionary<string, object> myParaInsert = new Dictionary<string, object>();
            string Password = txtOldTeacherPassword.Text;
            myParaInsert.Add("@teacher", txtTeacher.Text);
            myParaInsert.Add("@contactNo", txtPhoneTeacher.Text);
            myParaInsert.Add("@teacherEmail", txtEmail.Text);
            myParaInsert.Add("@countryId", ddlTeacherCountry.SelectedValue);
            myParaInsert.Add("@genderId", ddlGender.SelectedValue);
            myParaInsert.Add("@teacherUser", txtUserTeacher.Text);
            if (txtNewTeacherPassword.Text != "")
                Password = txtNewTeacherPassword.Text;
            myParaInsert.Add("@password", Password);
            myParaInsert.Add("@dob", txtBirthTeacher.Text);
            myParaInsert.Add("@majorId", ddlMajor.SelectedValue);
            myParaInsert.Add("@experience", txtExperiance.Text);
            myParaInsert.Add("@note", txtNote.Text);
            myParaInsert.Add("@TeacherID", HiddenFieldID.Value);

            List<string> courseList = new List<string>();
            foreach (ListItem item in cblCourse.Items)
            {
                if (item.Selected)
                {
                    courseList.Add(item.Value);
                }
            }
            int pk = myCrud.InsertUpdateDelete(mySql, myParaInsert);
            int TeacherID = Convert.ToInt32(HiddenFieldID.Value);
            insertTeacherCourse(TeacherID, courseList);
        }
        protected void insertTeacherCourse(int myTeacherId, List<string> myTeacherCourse)
        {
            CRUD myCrud = new CRUD();
            string mySql = @"delete from teacherCourse where teacherId=@teacherId";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@teacherId", myTeacherId);

            myCrud.InsertUpdateDelete(mySql, myPara);
            myCrud.con.Close();
            int myCounter = 0;
            foreach (string item in myTeacherCourse)
            {
                // call another method to insert to the db
                addNewTeacherCourse(myTeacherId, int.Parse(item));
                myCounter += 1;
            }
            if (myCounter >= 1)
            {
                Response.Write("<script>alert('Update Successful);</script>");

            }
            else
            {
                Response.Write("<script>alert('Failed  Try Agin ');</script>");

            }

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