<%@ Page Language="C#" MasterPageFile="~/AlgonquinMasterPage2.master" AutoEventWireup="true" CodeFile="AddCourseOffering.aspx.cs" Inherits="AddCourseOffering" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Add New Course Offering</h1>
    <asp:Label ID="lblCourse" runat="server" Text="Course: " CssClass="center">
        <asp:DropDownList ID="ddlCourses" runat="server" CssClass="dropdown">
            <asp:ListItem Text="Select a Course..." Value="0"></asp:ListItem>
        </asp:DropDownList>
    </asp:Label><br /><br />

    <asp:Label ID="lblOfferYear" runat="server" Text="Offer In Year: " CssClass="center">
        <asp:DropDownList ID="ddlOfferYear" runat="server" CssClass="dropdown">
            <asp:ListItem Text="Select..." Value="0"></asp:ListItem>
            <asp:ListItem Value="2016"></asp:ListItem>
            <asp:ListItem Value="2017"></asp:ListItem>
            <asp:ListItem Value="2018"></asp:ListItem>
            <asp:ListItem Value="2019"></asp:ListItem>
            <asp:ListItem Value="2020"></asp:ListItem>
        </asp:DropDownList>
    </asp:Label><br /><br />
      
    <asp:Label ID="lblSemester" runat="server" Text="Semester: " CssClass="center">
        <asp:DropDownList ID="ddlSemester" runat="server" CssClass="dropdown">
            <asp:ListItem Text="Select..." Value="0"></asp:ListItem>
            <asp:ListItem Value="Spring/Summer"></asp:ListItem>
            <asp:ListItem Value="Fall"></asp:ListItem>
            <asp:ListItem Value="Winter"></asp:ListItem>
        </asp:DropDownList>
    </asp:Label><br /><br /> 
    <asp:Button ID="btnSubmit" runat="server" Text="Submit Course Information" Width="225px" Height="20px" CssClass="button" OnClick="btnSubmit_Click" />
     <br />
    <br />
     <asp:Label ID="Label1" runat="server" Text="There are following course offeringws: " CssClass="center"></asp:Label>
     <br />
    <asp:Table ID="tblCourseOffering" runat="server" CssClass="table">
            <asp:TableRow>
                <asp:TableCell>
                        Course Code
                </asp:TableCell>
                <asp:TableCell>
                        Course Title
                </asp:TableCell>
                <asp:TableCell>
                        Year
                </asp:TableCell>
                <asp:TableCell>
                        Semester
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>   
</asp:Content>
