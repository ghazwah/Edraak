<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FindTeacher.aspx.cs" Inherits="EdraakProject.FindTeacher" %>
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

                    <h2>Find Teacher</h2>
                    <p class="auto-style1">
                      
                        <asp:DropDownList ID="DdlTeacher" runat="server" AutoPostBack="true" width="40%" OnSelectedIndexChanged="DdlCourse_SelectedIndexChanged"></asp:DropDownList>
                    </p>
   
                        <br />
                        

                         <p class="auto-style1">
                        <asp:GridView ID="GVTeacher" Width="100%" AutoGenerateColumns="false" runat="server" HeaderStyle-ForeColor="White" 
                             HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" 
                             RowStyle-HorizontalAlign="Center" RowStyle-VerticalAlign="Middle" HeaderStyle-BackColor="#993399">
                         
                            <Columns >
                                <asp:BoundField DataField="Course" HeaderText="Course Name"  />
                               
                                
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
