<%@ Page Language="C#" MasterPageFile="~/AlgonquinMasterPage2.master" AutoEventWireup="true" CodeFile="AddCourseOffering.aspx.cs" Inherits="AddCourseOffering" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Course: ">
        <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem Text="Select a Course..." Value="-1"></asp:ListItem>
        </asp:DropDownList>
    </asp:Label><br /><br />

    <asp:Label ID="Label4" runat="server" Text="Offer In Year: ">
        <asp:DropDownList ID="DropDownList4" runat="server">
            <asp:ListItem Text="Select..." Value="-1"></asp:ListItem>
        </asp:DropDownList>
    </asp:Label><br /><br />
      
    <asp:Label ID="Label5" runat="server" Text="Semester: ">
        <asp:DropDownList ID="DropDownList5" runat="server">
            <asp:ListItem Text="Select..." Value="-1"></asp:ListItem>
        </asp:DropDownList>
    </asp:Label><br /><br />  
    <asp:Table ID="tblNAMETHISCODY" runat="server" CssClass="table">
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
