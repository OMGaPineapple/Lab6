<%@ Page Title="" Language="C#" MasterPageFile="~/AlgonquinMasterPage2.master" AutoEventWireup="true" CodeFile="SmdStudentRegistration.aspx.cs" Inherits="SmdCourseRegistration" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Panel ID="Panel1" runat="server">
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
        <asp:Label ID="lblYear" runat="server" Text="Offer in Year: " ></asp:Label>
        <asp:DropDownList ID="ddlYear" runat="server" Width="200px">
            <asp:ListItem Text="Starting Year" Value="0"></asp:ListItem>
            <asp:ListItem Value="2016"></asp:ListItem>
            <asp:ListItem Value="2017"></asp:ListItem>
            <asp:ListItem Value="2018"></asp:ListItem>
            <asp:ListItem Value="2019"></asp:ListItem>
            <asp:ListItem Value="2020"></asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="lblSemester" runat="server" Text="Semester: " ></asp:Label>
        <asp:DropDownList ID="ddlSemester" runat="server" Width="200px">
            <asp:ListItem Text="Starting Semester" Value="0"></asp:ListItem>
            <asp:ListItem Text="Fall" Value="0"></asp:ListItem>
            <asp:ListItem Text="Summer" Value="1"></asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <asp:Button ID="btnSubmit" runat="server" Text="Submit Course Information" Width="225px" Height="20px" CssClass="button" OnClick="btnSubmit_Click" />
    </asp:Panel>

    <asp:Panel ID="Panel2" runat="server">
        <h1>Course Registration</h1>
        <asp:Label ID="lblStudentNumber" runat="server" Text="Student Number:"></asp:Label>
        <asp:TextBox ID="txtStudentNumber" runat="server" Width="200px" CssClass="input"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lblStudentName" runat="server" Text="Student Name: " ></asp:Label>
        <asp:TextBox ID="txtStudentName" runat="server" Width="200px" CssClass="input"></asp:TextBox>
        <br />
        <br />
        <asp:RadioButtonList RepeatDirection="Horizontal" ID="rblSortOptions" runat="server" Width="340px" AutoPostBack="False">
            <asp:ListItem Value="fullTime" Selected="True">Full Time</asp:ListItem>
            <asp:ListItem Value="partTime">Part Time</asp:ListItem>
            <asp:ListItem Value="coop">Co-op</asp:ListItem>
        </asp:RadioButtonList>
        <br />
        <asp:Button ID="btnAddCourse" runat="server" Text="Add to Course" Width="137px" Height="20px" CssClass="button" OnClick="btnAddCourse_Click" />
        <br />
        <br />
        The following students have been registered:
    <br />
        <br />
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
                <asp:TableCell>
                        Tuition
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </asp:Panel>

</asp:Content>

