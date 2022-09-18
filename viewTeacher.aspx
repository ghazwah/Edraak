<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="viewTeacher.aspx.cs" Inherits="EdraakProject1.viewTeacher" %>

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
                              <h2>View Teacher</h2>
                    
   
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
                                <asp:BoundField DataField="experience" HeaderText="experience"  />
                                <asp:BoundField DataField="note" HeaderText="note"  />
                                
                            </Columns>
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" BorderColor="#000" ForeColor="White" BackColor="#993399"></HeaderStyle>
                        </asp:GridView>
                    </div>
                </div>


                <br />
                <br />


            </div>
        </div>
    </div>
    <center>
                    <a href="homepage.aspx">
                        << Back to Home</a><span class="clearfix"></span>
                            <br />
                            <center>
</asp:Content>
