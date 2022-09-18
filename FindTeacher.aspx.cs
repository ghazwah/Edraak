using EdraakProject1.App_Code;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EdraakProject
{
    public partial class FindTeacher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                populateCblTeacher();
            }
        }
        protected void populateCblTeacher()
        {
            CRUD myCrud = new CRUD();
            string mySql = @"select TeacherId ,TeacherUser from Teacher ";
            SqlDataReader dr = myCrud.getDrPassSql(mySql);
            DdlTeacher.DataTextField = "TeacherUser";
            DdlTeacher.DataValueField = "TeacherId";
            DdlTeacher.DataSource = dr;
            DdlTeacher.DataBind();
          
        }
        protected void DdlCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            int TeacherId = Convert.ToInt32(DdlTeacher.SelectedValue);
            CRUD myCrud = new CRUD();
            string mySql = @"select teacher ,teacherEmail ,
                                T.contactNo, country.country country,gender.gender  
                               , major.major as major, T.experience ,C.Course Course
                                from teacherCourse TC inner join teacher T
                                on TC.teacherId =T.teacherId 
                                inner join  major 
                                on T.majorId = major.majorId
                                inner join  country 
                                on T.countryId = country.countryId 
                               inner join  gender 
                               on T.genderId =gender.genderId
inner join  Course  C
                               on TC.CourseId =C.CourseId
where TC.TeacherId = @TeacherId
                                ";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@TeacherId", TeacherId);
            SqlDataReader dr = myCrud.getDrPassSql(mySql, myPara);

            GVTeacher.DataSource = dr;
            GVTeacher.DataBind();
        }
    }
}