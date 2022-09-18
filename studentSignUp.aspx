<%@ Page Title="Student Sign up" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="studentSignUp.aspx.cs" Inherits="EdraakProject1.studentSignUp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
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
                           <img width="100px" src="imge/generaluser.png" class="auto-style1" /><span class="auto-style1"> </span>

                        </center>

                            </div>
                        </div>





                        <div class="row">
                            <div class="col">
                                <center>
                           <h4 class="auto-style1"> Student Sign Up </h4>
                        </center>
                            </div>
                        </div>

                        <%--horizinal line--%>
                        <div class="row">
                            <div class="auto-style2">
                                <hr>
                            </div>
                        </div>



                        <div class="row">


                            <div class="col-md-6">
                                <label><span class="auto-style1">Full Name </span></label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtStudent" runat="server"
                                        placeholder="Full Name"></asp:TextBox>
                                </div>


                            </div>

                            <div class="col-md-6">
                                <label><span class="auto-style1">Contact No </span></label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtContactNoStudent" runat="server"
                                        placeholder="Contact No"></asp:TextBox>
                                </div>


                            </div>
                        </div>
               



                        <div class="row">
                            <div class="col">
                                <label><span class="auto-style1">Email</span></label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtEmailStudent" runat="server"
                                        placeholder="Email ID" TextMode="Email"></asp:TextBox>
                                </div>
                            </div>
                        </div>


                        <div class="row">

                            <%-- drop down list for country--%>
                            <div class="col-md-6">
                                <label><span class="auto-style1">Country</span></label>
                                <div class="form-group">
                                    <asp:DropDownList class="form-control" ID="ddlStudentCountry"
                                        runat="server">
                                    </asp:DropDownList>

                                </div>
                            </div>


                            <%-- drop down list for jender--%>
                            <div class="col-md-6">
                                <label><span class="auto-style1">Gender</span></label>
                                <div class="form-group">
                                    <asp:DropDownList class="form-control" ID="ddlGender"
                                        runat="server">
                                    </asp:DropDownList>

                                </div>
                            </div>


                        </div>



                        <%--text box user --%>

                        <div class="row">

                            <div class="col-md-6">
                                <label><span class="auto-style1">User ID </span></label>
                                <div class="form-group">
                                    <asp:TextBox Class="form-control" ID="txtUser" runat="server"
                                        placeholder="User ID"></asp:TextBox>
                                </div>
                            </div>



                            <div class="col-md-6">
                                <label><span class="auto-style1">Password </span>
                                   
                                </label>
                                <div class="form-group">
                                    <asp:TextBox Class="form-control" ID="txtPassword" runat="server"
                                        placeholder="Password" TextMode="Password"></asp:TextBox>
                                </div>
                            </div>

                        </div>

                   

                         

                        <div class="row">
                            <div class="col-md-12 ">
                                 <asp:Label ID="lblError" runat="server"></asp:Label>
                                <div class="form-group">
                                    
                                    <br />
                                    <asp:Button class="btn btn-success btn-block btn-lg" ID="btnStudentSignup" 
                                        runat="server" Text="Sign up" OnClick="btnStudentSignup_Click" />
                                    <br />


                                </div>
                            </div>

                        </div>


                        

                    </div>
                </div>

                <a href="homepage.aspx"><span class="auto-style1"><< Back to Home</span></a><br class="auto-style1">
                <br class="auto-style1">
            </div>
        </div>

    </div>

 
   

</asp:Content>
