<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="adminMajorManagement.aspx.cs" Inherits="EdraakProject1.adminMajorManagement" %>
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
                    <br />
    
      <div class="container">
      <div class="row">

         <div class="col-md-5">
            <div class="card">

               <div class="card-body">
                  <div class="row">

                     <div class="col">
                        <center>
                           <h4>Major Details</h4>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <center>
                           <img width="100px"  src="imge/books1.png" /> 
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>



                   <%--    ajax--%>

                         <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                         <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                             <ContentTemplate>
                          

                  <div class="row">
                     <div class="col-md-4">
                        <label>Major ID</label>
                        <div class="form-group">
                           <div class="input-group">
                              <asp:TextBox CssClass="form-control" ID="txtMajorId" runat="server" placeholder="ID"></asp:TextBox>
                            
                           </div>
                        </div>
                     </div>
                     <div class="col-md-8">
                        <label>Major Name</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="txtMajorName" runat="server" placeholder="Major Name"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-4">
                        <asp:Button ID="btnAddMajor" class="btn btn-lg btn-block btn-success" runat="server" Text="Add" OnClick="btnAddMajor_Click" />
                     </div>
                     <div class="col-4">
                        <asp:Button ID="btnUpdateMajor" class="btn btn-lg btn-block btn-warning" runat="server" Text="Update" OnClick="btnUpdateMajor_Click" />
                     </div>
                     <div class="col-4">
                        <asp:Button ID="btnDeleteMajor" class="btn btn-lg btn-block btn-danger" runat="server" Text="Delete" OnClick="btnDeleteMajor_Click" />
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
            <a href="homepage.aspx"><< Back to Home</a><br>
            <br>
         </div>



          <br />
                    <br />
         <div class="col-md-7">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                           <h4>Major List</h4>
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
 
                        <asp:GridView class="table table-striped table-bordered" ID="gvMajor" runat="server"></asp:GridView>
                     </div>
                  </div>

                   <br />
                    <br />

                     <div class="row">
                     <div class="col-4">
                        <asp:Button ID="btnExportToWord" class="btn btn-lg btn-block btn-success" runat="server" Text="Export To Word" OnClick="btnExportToWord_Click"   />
                     </div>
                     <div class="col-4">
                        <asp:Button ID="btnExportToExcel" class="btn btn-lg btn-block btn-warning" runat="server" Text="Export To Excel" OnClick="btnExportToExle_Click"  />
                     </div>
                     <div class="col-4">
                        <asp:Button ID="btnExportToPDF" class="btn btn-lg btn-block btn-danger" runat="server" Text="Export To PDF" OnClick="btnExportToPDF_Click"  />
                     </div>
                  </div>

               </div>

                 
            </div>

             <br />
             <br />

             <br />
             <br />
         </div>
      </div>
   </div>

</asp:Content>
