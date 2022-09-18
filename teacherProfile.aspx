<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="teacherProfile.aspx.cs" Inherits="EdraakProject1.teacherProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-md-8 mx-auto">

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
                           <h4> Teacher Profile </h4>
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
                                    <asp:TextBox CssClass="form-control" ID="txtPhoneTeacher" runat="server"
                                        placeholder="Contact No" TextMode="Number"></asp:TextBox>
                                </div>


                            </div>
                            <div class="col-md-6">
                                <label>Email</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtEmail" runat="server"
                                        placeholder="Email ID" TextMode="Email" ></asp:TextBox>
                                </div>
                            </div>
                        </div>


                        <div class="row">

                            <%-- drop down list for country--%>
                            <div class="col-md-4">
                                <label>Country</label>
                                <div class="form-group">
                                    <asp:DropDownList class="form-control" ID="ddlTeacherCountry"
                                        runat="server">
                                    </asp:DropDownList>

                                </div>
                            </div>


                            <%-- drop down list for jender--%>
                            <div class="col-md-4">
                                <label>Jender</label>
                                <div class="form-group">
                                    <asp:DropDownList class="form-control" ID="ddlGender"
                                        runat="server">
                                    </asp:DropDownList>

                                </div>
                            </div>

                            <%-- drop down list for major--%>
                            <div class="col-md-4">
                                <label>Major</label>
                                <div class="form-group">
                                    <asp:DropDownList class="form-control" ID="ddlMajor"
                                        runat="server">
                                    </asp:DropDownList>

                                </div>
                            </div>


                            <%-- drop down list for course--%>
                             <%--will change to radio button list --%>
                            <div class="col-md-4">
                                <label>Cource</label>
                                <div class="form-group">
                                    <asp:CheckBoxList ID="cblCourse" runat="server"></asp:CheckBoxList>

                                </div>
                            </div>
                            <%--will change to radio button list --%>


                        </div>

                         <div class="row">

                            <div class="col">
                                <label>Experiance </label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtExperiance" runat="server"
                                        placeholder="Note" TextMode="MultiLine" Rows="3"></asp:TextBox>
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
                                    <asp:TextBox Class="form-control" ID="txtUserTeacher" runat="server"
                                        placeholder="User ID" ReadOnly="True" ></asp:TextBox>
                                </div>
                            </div>



                            
                            <div class="col-md-4">
                               <label>Old Password </label>
                             <div class="form-group">  
                                 <asp:TextBox Class="form-control" ID="txtOldTeacherPassword" runat="server" 
                                     placeholder="Old Password" TextMode="Password" ReadOnly="True"></asp:TextBox>
                             </div>
                            </div>


                             <div class="col-md-4">
                               <label>New Password </label>
                             <div class="form-group">  
                                 <asp:TextBox Class="form-control" ID="txtNewTeacherPassword" runat="server" 
                                     placeholder="New Password" TextMode="Password"></asp:TextBox>
                             </div>
                            </div>
                        </div>


                        <div class="row">
                            <div class="col-8 mx-auto">
                                <center>
                                <div class="form-group">
                                    <asp:Button class="btn btn-primary btn-block  btn-lg" ID="btnTeacherUpdate" OnClick="btnTeacherUpdate_Click"
                                        runat="server" Text="Update" />
                                    <asp:HiddenField ID="HiddenFieldID" runat="server"></asp:HiddenField>
                                </div>
                                    </center>
                            </div>

                        </div>

                </div>

 </div>
                <a href="homepage.aspx"><< Back to Home</a><br> <br>
            </div>

            
        </div>
    </div>
       
</asp:Content>
