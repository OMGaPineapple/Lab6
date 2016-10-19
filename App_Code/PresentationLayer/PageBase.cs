using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Configuration;
using System.Data.SqlClient;

/// <summary>
/// Summary description for PageBase
/// </summary>
public class PageBase : System.Web.UI.Page
{
    protected virtual void Page_Load(object sender, EventArgs e)
    {
        LinkButton addNewCourseSideButton = (LinkButton)Master.FindControl("sidebarButton1");
        LinkButton addNewCourseOfferingSideButton = (LinkButton)Master.FindControl("sidebarButton2");
        LinkButton registerStudentSideButton = (LinkButton)Master.FindControl("sidebarButton3");

        if(!IsPostBack)
        {
            Image logo = (Image)Master.FindControl("programLogo");
            logo.ImageUrl = "~/App_Themes/SAT.png";

            addNewCourseSideButton.Text += "Add Course";
            addNewCourseOfferingSideButton.Text += "Add Course Offering";
            registerStudentSideButton.Text += "Register Courses";
        }

        addNewCourseSideButton.Click += addNewCourseSideButton_Click;
        addNewCourseOfferingSideButton.Click += addCourseOfferingSideButton_Click;
        registerStudentSideButton.Click += registerStudentSideButton_Click;
    }

    protected void addNewCourseSideButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddCourse.aspx");
    }

    protected void addCourseOfferingSideButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddCourseOffering.aspx");
    }

    protected void registerStudentSideButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddStudent.aspx");
    }
}