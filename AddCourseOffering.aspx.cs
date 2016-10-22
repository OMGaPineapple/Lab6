using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddCourseOffering : PageBase
{
   
    CourseComparer sortBy = new CourseComparer();
    CourseOfferingComparer sortOffering = new CourseOfferingComparer();

    protected void Page_PreRender(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            List<Course> userCourse = CourseDataAccess.retreiveAllCourses();
            userCourse.Sort(sortBy);

            foreach (Course course in userCourse)
            {
                ListItem item = new ListItem(course.ToString());
                ddlCourses.Items.Add(item);
            }
        }

        List<CourseOffering> coursesOffered = CourseOfferingsDataAccess.retreiveAllCourses();
        coursesOffered.Sort(sortOffering);

        if (coursesOffered.Count == 0)
        {
            TableRow lastRow = new TableRow();
            TableCell lastRowCell = new TableCell();
            lastRowCell.Text = "There are currently no students enlisted";
            lastRowCell.ForeColor = System.Drawing.Color.Red;
            lastRowCell.ColumnSpan = 4;
            lastRowCell.HorizontalAlign = HorizontalAlign.Center;
            lastRow.Cells.Add(lastRowCell);
            tblCourseOffering.Rows.Add(lastRow);
        }
        else
        {
            foreach (CourseOffering ourCourse in coursesOffered)
            {
                {
                    TableRow row = new TableRow();

                    TableCell cell = new TableCell();
                    cell.Text = ourCourse.CourseOffered.CourseNumber;
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.Text = ourCourse.CourseOffered.CourseName;
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.Text = ourCourse.Year.ToString();
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    if(ourCourse.Semester == "Spring/Summer")
                    {
                        cell.Text = Semesters.SpringSummer;
                    }
                    else if(ourCourse.Semester == "Fall")
                    {
                        cell.Text = Semesters.Fall;
                    }
                    else if (ourCourse.Semester == "Winter")
                    {
                        cell.Text = Semesters.Winter;
                    }
                    row.Cells.Add(cell);

                    tblCourseOffering.Rows.Add(row);
                }
            }
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        List<Course> userCourse = CourseDataAccess.retreiveAllCourses();
        userCourse.Sort(sortBy);

        string offeredSemester = ddlSemester.SelectedValue;
        int offeredYear = Int32.Parse(ddlOfferYear.SelectedValue);

        int courseIndex = ddlCourses.SelectedIndex - 1;

        CourseOffering coursesOffered = new CourseOffering(userCourse[courseIndex], offeredYear, offeredSemester);
        CourseOfferingsDataAccess.addNewCourseOffering(coursesOffered);

    }
}