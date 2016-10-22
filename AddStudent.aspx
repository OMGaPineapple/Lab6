<%@ Page Language="C#" MasterPageFile="~/AlgonquinMasterPage2.master" AutoEventWireup="true" CodeFile="AddStudent.aspx.cs" Inherits="AddStudent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Register Students</h1>
        <asp:DropDownList ID="ddlCourseOffering" CssClass="dropdown" runat="server" AutoPostBack ="true">
            <%--<asp:ListItem Text="Select a Course Offering..." Value="-1"></asp:ListItem>--%>
        </asp:DropDownList>
    <br /><br />

    <asp:Label ID="lblStudentNumber" runat="server" Text="Student Number: ">
        <asp:TextBox ID="txtStudentNumber" runat="server"></asp:TextBox>
    </asp:Label><br /><br />
      
    <asp:Label ID="lblStudentName" runat="server" Text="Student Name: ">
        <asp:TextBox ID="txtStudentName" runat="server"></asp:TextBox>
    </asp:Label><br /><br />  

    <asp:RadioButtonList ID="rblStudentStatus" RepeatDirection="Horizontal" runat="server">
        <asp:ListItem Text="Full Time" Value="Full-Time"></asp:ListItem>
        <asp:ListItem Text="Part Time" Value="Part-Time"></asp:ListItem>
        <asp:ListItem Text="Co-op" Value="Co-op"></asp:ListItem>
    </asp:RadioButtonList>
    
    <asp:Button ID="btnAddCourseOffering" runat="server" Text="Add to course offering" OnClick="btnAddCourseOffering_Click1" /><br /><br />
    <asp:Label runat="server" Id="label" Text="The selected course offering has the following registered students."></asp:Label><br />
    <asp:Table ID="tblStudentRecords" runat="server" CssClass="table">
            <asp:TableRow>
                <asp:TableCell>
                     ID
                </asp:TableCell>
                <asp:TableCell>
                     Name
                </asp:TableCell>
                <asp:TableCell>
                     Type
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>   
</asp:Content>