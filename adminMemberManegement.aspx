<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="adminMemberManegement.aspx.cs" Inherits="EdraakProject1.adminMemberManegement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


   <div class="container-fluid">
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
                           <img width="100px" src="imgs/generaluser.png" />
                        </center>
                     </div>
                  </div>


                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>


                  <div class="row">
                     <div class="col-md-6">
                        <label>Teacher ID</label>
                        <div class="form-group">
                           <div class="input-group">
                              <asp:TextBox CssClass="form-control" ID="txtTeacherId2" runat="server" placeholder="Teacher ID"></asp:TextBox>
                              <asp:LinkButton class="btn btn-primary" ID="LinkButton4" runat="server"><i class="fas fa-check-circle"></i></asp:LinkButton>
                           </div>
                        </div>
                     </div>
                     


                     <div class="col-md-6">
                        <label>Full Name</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Full Name" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>
                    </div>

                    <%-- <div class="col-md-5">
                        <label>Account Status</label>
                        <div class="form-group">
                           <div class="input-group">
                              <asp:TextBox CssClass="form-control mr-1" ID="TextBox7" runat="server" placeholder="Account Status" ReadOnly="True"></asp:TextBox>
                              <asp:LinkButton class="btn btn-success mr-1" ID="LinkButton1" runat="server"><i class="fas fa-check-circle"></i></asp:LinkButton>
                              <asp:LinkButton class="btn btn-warning mr-1" ID="LinkButton2" runat="server"><i class="far fa-pause-circle"></i></asp:LinkButton>
                              <asp:LinkButton class="btn btn-danger mr-1" ID="LinkButton3" runat="server"><i class="fas fa-times-circle"></i></asp:LinkButton>
                           </div>
                        </div>
                     </div>
                  </div>--%>


                  <div class="row">
                     <div class="col-md-3">
                        <label>DOB</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="txtDateTeacher" runat="server" placeholder="DOB" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-4">
                        <label>Contact No</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Contact No" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-5">
                        <label>Email ID</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Email ID" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>
                  </div>

                  <div class="row">
                     <div class="col">
                        <label>Note</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="txtNote" runat="server" placeholder="Note" TextMode="MultiLine" Rows="3" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>
                  </div>


                  <div class="row">
                     <div class="col-10 mx-auto">
                        <asp:Button ID="Button2" class="btn btn-lg btn-block btn-danger" runat="server" Text="Delete User Permanently" />
                     </div>
                  </div>
               </div>
            </div>

            
         </div>



          <div class="col-md-7">
              <div class="card">
                  <div class="card-body">
                      <div class="row">
                          <div class="col">
                              <center>
                           <h4>Teachers List</h4>
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
                              <asp:gridview class="table table-striped table-bordered" id="GridViewTeacher1" runat="server"></asp:gridview>
                          </div>
                      </div>
                  </div>
              </div>
          </div>

                 <a href="homepage.aspx"><< Back to Home</a><br>
             <br>

            </div>
         </div>
     
</asp:Content>