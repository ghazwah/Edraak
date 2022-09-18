<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="teacherLogin.aspx.cs" Inherits="EdraakProject1.teacherLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-md-6 mx-auto">

                <br />
                <br />

                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                           
                              <img  width="150px" src="imge/generaluser.png" />
                        </center>
                            </div>
                        </div>



                        <div class="row">
                            <div class="col">
                                <center>
                           <h3> Teacher Login </h3>
                        </center>
                            </div>
                        </div>



                       <%--horizinal line--%>
                         <div class="row">
                            <div class="col">
                               <hr >
                            </div>
                        </div>

                        <%--text box--%>
                         <div class="row">
                            <div class="col">
                                <label>Member ID</label>
                             <div class="form-group">  
                                 <asp:TextBox CssClass="form-control" ID="txtLogin" runat="server" 
                                     placeholder="Member ID"></asp:TextBox>
                             </div>

                                 <label>Password</label>
                             <div class="form-group">  
                                 <asp:TextBox CssClass="form-control" ID="txtPassword" runat="server" 
                                     placeholder="Password" TextMode="Password"></asp:TextBox>
                             </div>

                             <div class="form-group">  
                                 <asp:Button class="btn btn-success btn-block btn-lg" ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click"  />

                             </div>

                                <%--sign up--%>
                                 <div class="form-group">  
                                      <a href="signupHomepage.aspx"><input class="btn btn-info btn-block btn-lg" id="btnSignup" type="button" value="Sign Up" />

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
