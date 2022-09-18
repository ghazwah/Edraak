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
    public partial class FindCourse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                populateCblCourse();
            }
        }
        protected void populateCblCourse()
        {
            CRUD myCrud = new CRUD();
            string mySql = @"select courseId ,course from course ";
            SqlDataReader dr = myCrud.getDrPassSql(mySql);
            DdlCourse.DataTextField = "course";
            DdlCourse.DataValueField = "courseId";
            DdlCourse.DataSource = dr;
            DdlCourse.DataBind();
          
        }
        protected void DdlCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            int CourseID = Convert.ToInt32(DdlCourse.SelectedValue);
            CRUD myCrud = new CRUD();
            string mySql = @"select teacher ,teacherEmail ,
                                T.contactNo, country.country country,gender.gender  
                               , major.major as major, T.experience
                                from teacherCourse TC inner join teacher T
                                on TC.teacherId =T.teacherId 
                                inner join  major 
                                on T.majorId = major.majorId
                                inner join  country 
                                on T.countryId = country.countryId 
                               inner join  gender 
                               on T.genderId =gender.genderId
where TC.courseId = @courseId
                                ";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@courseId", CourseID);
            SqlDataReader dr = myCrud.getDrPassSql(mySql, myPara);

            GVTeacher.DataSource = dr;
            GVTeacher.DataBind();
        }
    }
}