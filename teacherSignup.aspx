<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="teacherSignup.aspx.cs" Inherits="EdraakProject1.teacherSignup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <asp:Label ID="lblOutput" runat="server" Text=""></asp:Label>
    <br />

    <div class="container">
        <div class="row">
            <div class="col-md-8 mx-auto">

                <br />
                <br />

                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                           
                                 <img width ="100px" src="imge/generaluser.png" />
                        </center>
                            </div>
                        </div>

                         <div class="row">
                            <div class="col">
                                <center>
                           <h4> Teacher Sign Up </h4>
                        </center>
                            </div>
                        </div>





                            <div class="row">
                            <div class="col">
                                <center>
                                <asp:Label ID="lblError" runat="server" Visible="False"></asp:Label>
                                    </center>
                            </div>
                        </div>



                       <%--line --%>
                         <div class="row">
                            <div class="col">
                               <hr >
                            </div>
                        </div>


                    



                        <div class="row">


                            <div class="col-md-6">
                               <label>Full Name </label>
                             <div class="form-group">  
                                 <asp:TextBox CssClass="form-control" ID="txtTeacher" runat="server" 
                                     placeholder="Full Name"></asp:TextBox>
                             </div>


                            </div>
                             <div class="col-md-6">
                              <label>Date of Birth</label>
                             <div class="form-group">  
                                 <asp:TextBox CssClass="form-control" ID="txtBirthTeacher" runat="server" 
                                     placeholder="Date of Birth" TextMode="Date"></asp:TextBox>
                             </div> 
                            </div>
                            </div>


                            <div class="row">

                            <div class="col-md-6">
                               <label>Contact No </label>
                             <div class="form-group">  
                                 <asp:TextBox CssClass="form-control" ID="txtContactNoTeacher" runat="server" 
                                     placeholder="Contact No" TextMode="Phone"></asp:TextBox>
                             </div>


                            </div>
                             <div class="col-md-6">
                              <label>Email</label>
                             <div class="form-group">  
                                 <asp:TextBox CssClass="form-control" ID="txtEmailTeacher" runat="server" 
                                     placeholder="Email ID" TextMode="Email"></asp:TextBox>
                             </div> 
                            </div>
                            </div>


                            <div class="row">

                           <%-- drop down list for country--%>
                            <div class="col-md-4">
                              <label>Country</label>
                             <div class="form-group">
                                 <asp:DropDownList class="form-control" ID="ddlTeacherCountry" 
                                     runat="server"></asp:DropDownList>

                                  </div>
                                 </div>


                            <%-- drop down list for jender--%>
                            <div class="col-md-4">
                              <label>Gender</label>
                             <div class="form-group">
                                 <asp:DropDownList class="form-control" ID="ddlGender" 
                                     runat="server"></asp:DropDownList>

                                  </div>
                                 </div>

                            <%-- drop down list for major--%>
                            <div class="col-md-4">
                              <label>Major</label>
                             <div class="form-group">
                                 <asp:DropDownList class="form-control" ID="ddlMajor" 
                                     runat="server"></asp:DropDownList>

                                  </div>
                                 </div>


                            <div class="col-md-4">
                              <label>Cource</label>
                             <div class="form-group">
                                
                                 <asp:CheckBoxList ID="cblCourse" runat="server"  >  </asp:CheckBoxList>

                                  </div>
                                 </div>
                             
                        </div>


                       


                        <div class="row">

                            <div class="col">
                               <label>Experience </label>
                             <div class="form-group">  
                                 <asp:TextBox CssClass="form-control" ID="txtExperience" runat="server" 
                                     placeholder="Experience" TextMode="MultiLine" Rows="3"></asp:TextBox>
                             </div>
                            </div>
                            </div>



                          <div class="row">

                            <div class="col">
                               <label>Note </label>
                             <div class="form-group">  
                                 <asp:TextBox CssClass="form-control" ID="txtNote" runat="server" 
                                     placeholder="Note" TextMode="MultiLine" Rows="3"></asp:TextBox>
                             </div>
                            </div>
                            </div>



                        <%--text box user --%>
                         
                        <div class="row">

                            <div class="col-md-4">
                               <label>User ID </label>
                             <div class="form-group">  
                                 <asp:TextBox Class="form-control" ID="txtTescherUser" runat="server" 
                                     placeholder="User ID" ></asp:TextBox>
                             </div>
                            </div>


                       
                            <div class="col-md-6">
                                <label>Password </label>
                                <div class="form-group">
                                    <asp:TextBox Class="form-control" ID="txtPassword" runat="server"
                                        placeholder="Password" TextMode="Password"></asp:TextBox>
                                </div>
                            </div>

                            </div>


                      

                        <div class="row">
                           
                            <div class="col-md-12">

                                <div class="form-group">
                                    <asp:Button class="btn btn-success btn-block btn-lg" ID="btnTeacherSignup"
                                        runat="server" Text="Sign up" OnClick="btnTeacherSignup_Click"  />
                                    <br />
                                    

                                </div>
                            </div>

                        </div>

                          

                    </div>
                    </div>

                    <a href="homepage.aspx"><< Back to Home</a><br><br>
                        
                    </div>
        </div>

 </div>
                
       
</asp:Content>
