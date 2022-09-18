<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="studentProfile.aspx.cs" Inherits="EdraakProject1.studentProfile" %>
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
                           <img width="100px" src="imge/generaluser.png" /> 
                        </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4> Student Profile </h4>
                                </center>
                            </div>
                        </div>

                        <%--horizinal line--%>
                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>




                        <div class="row">


                            <div class="col-md-6">
                                <label>ID </label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtStudentId" runat="server"
                                        placeholder="ID"></asp:TextBox>
                                </div>


                            </div>

                            <div class="col-md-6">
                                <label>Full Name </label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtStudent" runat="server"
                                        placeholder="Full Name"></asp:TextBox>
                                </div>



                            </div>
                        </div>


                        <div class="row">

                            <div class="col-md-6">
                                <label>Contact No </label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtPhoneStudent" runat="server"
                                        placeholder="Contact No" TextMode="Number"></asp:TextBox>
                                </div>


                            </div>
                            <div class="col-md-6">
                                <label>Email</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtStudentEmail" runat="server"
                                        placeholder="Email ID" TextMode="Email"></asp:TextBox>
                                </div>
                            </div>
                        </div>




                        <div class="row">

                            <%-- drop down list for country--%>
                            <div class="col-md-6">
                                <label>Country</label>
                                <div class="form-group">
                                    <asp:DropDownList class="form-control" ID="ddlStudentCountry"
                                        runat="server">
                                    </asp:DropDownList>

                                </div>
                            </div>


                            <%-- drop down list for jender--%>
                            <div class="col-md-6">
                                <label>Gender</label>
                                <div class="form-group">
                                    <asp:DropDownList class="form-control" ID="ddlGender"
                                        runat="server">
                                    </asp:DropDownList>

                                </div>
                            </div>


                        </div>





                        <%--text box user --%>

                        <div class="row">

                             <div class="col-md-12">
                                <label>User ID </label>
                                <div class="form-group">
                                    <asp:TextBox Class="form-control" ID="txtUserStudent" runat="server"
                                        placeholder="User ID" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>




                            <div class="col-md-12">
                                <label>Old Password </label>
                                <div class="form-group">
                                    <asp:TextBox Class="form-control" ID="txtOldStudentPassword" runat="server"
                                        placeholder="Old Password" TextMode="Password" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>


                            <div class="col-md-12">
                                <label>New Password </label>
                                <div class="form-group">
                                    <asp:TextBox Class="form-control" ID="txtNewStudentPassword" runat="server"
                                        placeholder="New Password" TextMode="Password"></asp:TextBox>
                                </div>
                            </div>
                            </div>

                            <div class="row">
                            <div class="col-md-12">
                                <label>Upload receipt: </label>
                                <div class="form-group">
                                    <asp:FileUpload ID="FileUpload1" runat="server"  Class="form-control" />
                                    <asp:Label ID="lblRecipt" runat="server" ></asp:Label>
                                </div>
                            </div>
                        </div>



                        <div class="row">
                            <div class="col">

                                <div class="form-group">

                                </div>

                            </div>

                        </div>

                    </div>

                </div>



                <a href="homepage.aspx"><< Back to Home<asp:Button class="btn btn-primary btn-block  btn-lg" ID="btnStudentUpdate"
                                        runat="server" Text="Update" OnClick="btnStudentUpdate_Click" />

                                </a><br>
                <br>
                <br>
                <br>
            </div>
        </div>
    </div>
         


</asp:Content>
