<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="adminStudentManagement.aspx.cs" Inherits="EdraakProject1.adminStudentManagement" %>
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

    

    <div class="container-fluid">
        <div class="row">
            <div class="col-md-5">

                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                        <h4>Student Details</h4>
                                    </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                        
                                          <img width="100px" src="imge/Illustration.png" />
                                       
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
                                <label>Student ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="txtStudentId" runat="server" placeholder="ID"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-8">
                                <label>Student Name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtStudentName" runat="server" placeholder="Student Name"></asp:TextBox>

                                </div>
                            </div>
                        </div>



                         <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                         <ContentTemplate>
                             

                        <div class="row">
                            
                            
                            <div class="col-6">
                                <asp:Button ID="btnUpdateStudent" class="btn btn-lg btn-block btn-warning" runat="server" Text="Update" OnClick="btnUpdateStudent_Click"  />
                            </div>
                            <div class="col-6">
                                <asp:Button ID="btnDeletStudent" class="btn btn-lg btn-block btn-danger" runat="server" Text="Delete" OnClick="btnDeletStudent_Click"  />
                            </div>
                          </div>

                             </ContentTemplate>
                             </asp:UpdatePanel>


                        <br />

                        <div class="row">
                       <div class="col">

                          
                           <asp:Button class="btn btn-info btn-block btn-lg" ID="btnGv" runat="server" Text="Show Grid View" OnClick="btnGv_Click" />
                       </div>
                   </div>

              

                    </div>
                </div>
                
                <a href="../homepage.aspx"><< Back to Home</a><br>
                <br>
            </div>

            <div class="col-md-7 ">

                <div class="card">
                    <div class="card-body">



                        <div class="row">
                            <div class="col">
                                <center>
                                        <h4>Student List</h4>
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
                                <asp:GridView class="table table-striped table-bordered" AutoGenerateColumns="false" ID="gvStudent" runat="server">
                                    <Columns>
                                        <asp:BoundField DataField="studentId" HeaderText="student Id"  />
                                        <asp:BoundField DataField="student" HeaderText="student Name"  />
                                        <asp:BoundField DataField="email" HeaderText="email"  />
                                        <asp:BoundField DataField="gender" HeaderText="gender"  />
                                        <asp:BoundField DataField="country" HeaderText="country"  />
                                      
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Receipt
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Image ID="Image1" ImageUrl='<%# "~/Receipt/"+Eval("Receipt") %>' Width="150" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
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
