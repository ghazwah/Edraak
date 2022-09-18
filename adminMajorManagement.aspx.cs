using EdraakProject1.App_Code;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EdraakProject1
{
    public partial class adminMajorManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddMajor_Click(object sender, EventArgs e)
        {


            CRUD myCrud = new CRUD();
            string mySql = @"insert into major(major)
               values(@major)";
            Dictionary<string, object> myPara = new Dictionary<string, object>();

            myPara.Add("@major", txtMajorName.Text);




            int rtn = myCrud.InsertUpdateDelete(mySql, myPara);
            if (rtn >= 1)
            { Response.Write("<script>alert('Successful ');</script>"); }
            else
            { Response.Write("<script>alert('Failed  Try Agin ');</script>"); }
        }



        protected void btnUpdateMajor_Click(object sender, EventArgs e)
        {

            int PK = int.Parse(txtMajorId.Text);
            string strMajorName = txtMajorName.Text;

            CRUD myCrud = new CRUD();
            string mySql = @"  update major set major = @major 
                        where majorId=@majorId";

            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("majorId", PK);
            myPara.Add("@major", strMajorName);



            int rtn = myCrud.InsertUpdateDelete(mySql, myPara);
            if (rtn >= 1)
            { Response.Write("<script>alert('Successful ');</script>"); }
            else
            { Response.Write("<script>alert('Failed  Try Agin ');</script>"); }



        }




        protected void btnDeleteMajor_Click(object sender, EventArgs e)
        {
            CRUD myCrud = new CRUD();
            string mySql = @"  delete major where majorId=@majorId";

            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("majorId", int.Parse(txtMajorId.Text));


            int rtn = myCrud.InsertUpdateDelete(mySql, myPara);
            if (rtn >= 1)


            { Response.Write("<script>alert('Success Operation');</script>"); }
            else
            {
                Response.Write("<script>alert('Failed Operation');</script>");

            }



        }




        protected void btnGv_Click(object sender, EventArgs e)
        {
            CRUD myCrud = new CRUD();
            string mySql = @"select * from major ";
            SqlDataReader dr = myCrud.getDrPassSql(mySql);
            gvMajor.DataSource = dr;
            gvMajor.DataBind();
        }


        protected void btnGv_Click()
        {
            CRUD myCrud = new CRUD();
            string mySql = @"select * from major ";
            SqlDataReader dr = myCrud.getDrPassSql(mySql);
            gvMajor.DataSource = dr;
            gvMajor.DataBind();
        }



        protected void btnExportToWord_Click(object sender, EventArgs e)
        {
            ExportGridToword();
        }

        protected void btnExportToExle_Click(object sender, EventArgs e)
        {
            ExportGridToExcel(gvMajor);
        }

        protected void btnExportToPDF_Click(object sender, EventArgs e)
        {
            ExportGridToPDF();
        }




        //pdf
        public void ExportGridToPDF()
        {

            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            gvMajor.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            iTextSharp.text.html.simpleparser.HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();
            gvMajor.AllowPaging = true;
            gvMajor.DataBind();
        }


        //word
        public void ExportGridToword()
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            //string FileName = "Vithal" + DateTime.Now + ".doc";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/msword";
            Response.AddHeader("Content-Disposition", "attachment;filename=GridViewExport.doc");
            gvMajor.GridLines = GridLines.Both;
            gvMajor.HeaderStyle.Font.Bold = true;
            gvMajor.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            Response.End();

        }


        public override void VerifyRenderingInServerForm(Control control)
        {

        }
        
        //Excel
        public void ExportGridToExcel(GridView grd)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            grd.AllowPaging = false;
            btnGv_Click();
            grd.RenderControl(hw);
            string style = @"<style> .textmode { mso-number-format:\@; } </style>";
            Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }

        
    }
    }
