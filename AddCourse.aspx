<%@ Page Language="C#" MasterPageFile="~/AlgonquinMasterPage2.master" AutoEventWireup="true" CodeFile="AddCourse.aspx.cs" Inherits="AddCourse" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
        <h1>Student Course Records</h1>
        <asp:Label ID="lblCourseNumber" runat="server" Text="Course Number: " ></asp:Label>
        <asp:TextBox ID="txtCourseNumber" runat="server" Width="200px" CssClass="input"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lblCourseName" runat="server" Text="Course Name: " ></asp:Label>
        <asp:TextBox ID="txtCourseName" runat="server" Width="200px" CssClass="input"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lblWeeklyHours" runat="server" Text="Weekly Hours: " ></asp:Label>
        <asp:TextBox ID="txtCourseHours" runat="server" Width="200px" CssClass="input"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnSubmit" runat="server" Text="Submit Course Information" Width="225px" Height="20px" CssClass="button" OnClick="btnSubmit_Click" />
        <br />
        <br />
        <asp:Label ID="lblFollowingCourse" runat="server" Text="Following courses are currently in the system: " ></asp:Label>
        <br />
            <asp:Table ID="tblCourses" runat="server" CssClass="table">
            <asp:TableRow>
                <asp:TableCell>
                        Course Code
                </asp:TableCell>
                <asp:TableCell>
                        Course Name
                </asp:TableCell>
                <asp:TableCell>
                        Weekly Hours
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
</asp:Content>
