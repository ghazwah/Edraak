<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="adminTeacherManagement.aspx.cs" Inherits="EdraakProject1.adminTeacherManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

 <script type="text/javascript">
      
     $(document).ready(function () {

         
          $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
         // $('.table1').DataTable();
      });
 </script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />
    <br/>

        


    <div class="container">
        <div class="row">
            <div class="col-md-5">

                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                        <h4>Teacher Details</h4>
                                    </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                        <img width="100px"   src="imge/favpng_computer-icons-teacher.png" />
                                       
                                    </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <label>Teacher ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="txtTeacherId" runat="server" placeholder="ID"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-8">
                                <label>Teacher Name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtTeacherName" runat="server" placeholder="Teacher Name"></asp:TextBox>

                                </div>
                            </div>
                        </div>

                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                         <ContentTemplate>


                        <div class="row">
                            
                            <div class="col-6">
                                <asp:Button ID="txtUpdateTeacher" class="btn btn-lg btn-block btn-warning" runat="server" Text="Update" OnClick="txtUpdateTeacher_Click" />
                            </div>
                            <div class="col-6">
                                <asp:Button ID="txtDeletTeacher" class="btn btn-lg btn-block btn-danger" runat="server" Text="Delete" OnClick="txtDeletTeacher_Click" />
                            </div>
                        </div>

                               </ContentTemplate>
                             </asp:UpdatePanel>


                             <br />

                   <div class="row">
                       <div class="col">

                          
                           <asp:Button  class="btn btn-info btn-block btn-lg" ID="btnGv" runat="server" Text="Show Grid View" OnClick="btnGv_Click"  />
                       </div>
                   </div>
 

                    </div>
                </div>
                
                <a href="../homepage.aspx"><< Back to Home</a><br>
                <br>
            </div>

            <div class="col-md-7">

                <div class="card">
                    <div class="card-body">



                        <div class="row">
                            <div class="col">
                                <center>
                                        <h4>Teacher List</h4>
                                    </center>
                            </div>
                        </div>



                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>
                          
                        <div class="row">
                            <div class="col">
                                <asp:GridView class="table table-striped table-bordered" ID="gvTeacher" runat="server" ></asp:GridView>
                            </div>
                        </div>


                        <br />
                        <br />



                        <div class="row">
                     <div class="col-4">
                        <asp:Button ID="btnExportToWord" class="btn btn-lg btn-block btn-success" runat="server" Text="Export To Word" OnClick="btnExportToWord_Click"   />
                     </div>
                     <div class="col-4">
                        <asp:Button ID="btnExportToExcel" class="btn btn-lg btn-block btn-warning" runat="server" Text="Export To Excel" OnClick="btnExportToExcel_Click"  />
                     </div>
                     <div class="col-4">
                        <asp:Button ID="btnExportToPDF" class="btn btn-lg btn-block btn-danger" runat="server" Text="Export To PDF" OnClick="btnExportToPDF_Click"  />
                     </div>
                  </div>

               </div>
            </div>

             <br />
             <br />

                


            </div>

        </div>
    </div>
                             
</asp:Content>
