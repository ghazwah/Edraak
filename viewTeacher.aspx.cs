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
    public partial class viewTeacher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                CRUD myCrud = new CRUD();
                string mySql = @" select   teacher.teacher ,teacher.teacherEmail ,teacher.contactNo, country.country country,gender.gender  
                                , major.major as major, teacher.experience, teacher.note 
                        from teacher 
                            inner join  major on teacher.majorId = major.majorId
                          inner join  country on teacher.countryId = country.countryId 
                               inner join  gender on teacher.genderId =gender.genderId";
                SqlDataReader dr = myCrud.getDrPassSql(mySql);
                GVTeacher.DataSource = dr;
                GVTeacher.DataBind();
            }
        }

        protected void gvTeacher_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}