<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FindCourse.aspx.cs" Inherits="EdraakProject.FindCourse" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-12 mx-auto">

                <br />
                <br />

                <div class="card">
                    <div class="card-body">

                        <div class="col">
                            <center>

                
                    <img width="300" src="imge/search-online.png" />

                    <h2>Find Course</h2>
                    <p class="auto-style1">
                      
                        <asp:DropDownList ID="DdlCourse" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DdlCourse_SelectedIndexChanged"></asp:DropDownList>
                    </p>
   
                        <br />
                        

                         <p class="auto-style1">
                        <asp:GridView ID="GVTeacher" Width="100%" AutoGenerateColumns="false" runat="server" HeaderStyle-ForeColor="White" 
                             HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" 
                             RowStyle-HorizontalAlign="Center" RowStyle-VerticalAlign="Middle" HeaderStyle-BackColor="#993399">
                         
                            <Columns >
                                <asp:BoundField DataField="teacher" HeaderText="Teacher Name"  />
                                <asp:BoundField DataField="teacherEmail" HeaderText="Teacher Email"  />
                                <asp:BoundField DataField="gender" HeaderText="gender"  />
                                <asp:BoundField DataField="contactNo" HeaderText="contactNo"  />
                                <asp:BoundField DataField="country" HeaderText="country"  />
                                <asp:BoundField DataField="major" HeaderText="major"  />
                                
                            </Columns>
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" BorderColor="#000" ForeColor="White" BackColor="#993399"></HeaderStyle>
                        </asp:GridView>
                   

                </center>
                        </div>
                    </div>
                </div>

                <a href="homepage.aspx"><< Back to Home</a><br>
                <br>
            </div>
        </div>

    </div>
</asp:Content>
