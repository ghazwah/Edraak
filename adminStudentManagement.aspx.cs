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
    public partial class adminStudentManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }




        protected void btnUpdateStudent_Click(object sender, EventArgs e)
        {
            int PK = int.Parse(txtStudentId.Text);
            string strStudentName = txtStudentName.Text;

            CRUD myCrud = new CRUD();
            string mySql = @"  update student set student = @student 
                        where studentId=@studentId";

            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("studentId", PK);
            myPara.Add("@student", strStudentName);



            int rtn = myCrud.InsertUpdateDelete(mySql, myPara);
            if (rtn >= 1)
            { Response.Write("<script>alert('Successful ');</script>"); }
            else
            { Response.Write("<script>alert('Failed  Try Agin ');</script>"); }
        }

        protected void btnDeletStudent_Click(object sender, EventArgs e)
        {
            CRUD myCrud = new CRUD();
            string mySql = @"  delete student where studentId=@studentId";

            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("studentId", int.Parse(txtStudentId.Text));


            int rtn = myCrud.InsertUpdateDelete(mySql, myPara);
            if (rtn >= 1)


            { Response.Write("<script>alert('Success Operation');</script>"); }
            else
            {
                Response.Write("<script>alert('Failed Operation');</script>");

            }
        }

       





        protected void btnExportToWord_Click(object sender, EventArgs e)
        {
            ExportGridToword();
        }

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
            gvStudent.GridLines = GridLines.Both;
            gvStudent.HeaderStyle.Font.Bold = true;
            gvStudent.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            Response.End();

        }

        protected void btnExportToExcel_Click(object sender, EventArgs e)
        {
            ExportGridToExcel(gvStudent);
        }

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

        protected void btnExportToPDF_Click(object sender, EventArgs e)
        {
            ExportGridToPDF();
        }

        public void ExportGridToPDF()
        {
            PdfPTable pdfTable = new PdfPTable(gvStudent.HeaderRow.Cells.Count);
            
                foreach (TableCell headerCell in gvStudent.HeaderRow.Cells)
                {
                    PdfPCell pdfCell = new PdfPCell(new Phrase(headerCell.Text));
                    pdfTable.AddCell(pdfCell);
                
                }

            


            foreach (GridViewRow gridViewRow in gvStudent.Rows)
            {
                foreach (TableCell tableCell in gridViewRow.Cells)
                {
                    PdfPCell pdfCell = new PdfPCell(new Phrase(tableCell.Text));
                    pdfTable.AddCell(pdfCell);


                }

            }
            Document pdfDocument = new Document(PageSize.A4, 10f, 10f, 10f, 10f);
            PdfWriter.GetInstance(pdfDocument, Response.OutputStream);
            pdfDocument.Open();
            pdfDocument.Add(pdfTable);
            pdfDocument.Close();



            Response.ContentType = "application/pdf";
            Response.AppendHeader("content-disposition", "attachment;filename=GridViewExport.pdf");
            Response.Write(pdfDocument);
            Response.Flush();
            Response.End();

            //Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //StringWriter sw = new StringWriter();
            //HtmlTextWriter hw = new HtmlTextWriter(sw);
            //gvStudent.RenderControl(hw);
            //StringReader sr = new StringReader(sw.ToString());
            //Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            //HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            //PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            //pdfDoc.Open();
            //htmlparser.Parse(sr);
            //pdfDoc.Close();
            //Response.Write(pdfDoc);
            //Response.End();
            //gvStudent.AllowPaging = true;
            //gvStudent.DataBind();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {

        }

        protected void btnGv_Click(object sender, EventArgs e)
        {
            CRUD myCrud = new CRUD();
            string mySql = @" select  student.studentId , student.student ,student.email  , gender.gender, country.country ,Receipt from 
                        ((student inner join country on student.countryId = country.countryId) inner join gender on 
						student.genderId = gender.genderId) ";
            SqlDataReader dr = myCrud.getDrPassSql(mySql);
            gvStudent.DataSource = dr;
            gvStudent.DataBind();
        }
        protected void btnGv_Click()
        {
            CRUD myCrud = new CRUD();
            string mySql = @" select  student.studentId , student.student ,student.email  , gender.gender, country.country ,Receipt from 
                        ((student inner join country on student.countryId = country.countryId) inner join gender on 
						student.genderId = gender.genderId) ";
            SqlDataReader dr = myCrud.getDrPassSql(mySql);
            gvStudent.DataSource = dr;
            gvStudent.DataBind();
        }
    }

}