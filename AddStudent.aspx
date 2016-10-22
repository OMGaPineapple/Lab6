<%@ Page Language="C#" MasterPageFile="~/AlgonquinMasterPage2.master" AutoEventWireup="true" CodeFile="AddStudent.aspx.cs" Inherits="AddStudent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Register Students</h1>
    <asp:Label ID="lblCourseOffering" runat="server" Text="Course Offering: " >
        <asp:DropDownList ID="ddCourseOffering" CssClass="dropdown" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddCourseOffering_SelectedIndexChanged">
            <asp:ListItem Text="Select a Course..." Value="-1"></asp:ListItem>
        </asp:DropDownList>
    </asp:Label><br /><br />

    <asp:Label ID="label1" runat="server" Text="Student Number: ">
        <asp:TextBox ID="txtStudentNumber" runat="server"></asp:TextBox>
    </asp:Label><br /><br />
      
    <asp:Label ID="label2" runat="server" Text="Student Name: ">
        <asp:TextBox ID="txtStudentName" runat="server"></asp:TextBox>
    </asp:Label><br /><br />  

    <asp:RadioButtonList ID="rblStudentStatus" RepeatDirection="Horizontal" runat="server">
        <asp:ListItem Text="Full Time" Value="Full-Time"></asp:ListItem>
        <asp:ListItem Text="Part Time" Value="Part-Time"></asp:ListItem>
        <asp:ListItem Text="Co-Op" Value="Co-Op"></asp:ListItem>
    </asp:RadioButtonList>
    
    <asp:Button ID="btnAddStudent" runat="server" Text="Add Student" OnClick="btnAddStudent_Click" /><br /><br />
    <asp:Label runat="server" Id="label" Text="The selected course offering has the following registered students."></asp:Label><br />
    <asp:Table ID="tblNAMETHISCODY" runat="server" CssClass="table">
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