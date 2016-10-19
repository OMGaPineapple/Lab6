using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddCourse : PageBase
{
    Course userCourse = null;
    CourseComparer sortBy = new CourseComparer();

    protected void Page_PreRender(object sender, EventArgs e)
    {
        List<Course> userCourse = CourseDataAccess.retreiveAllCourses();
        userCourse.Sort(sortBy);

        if (userCourse.Count == 0)
        {
            TableRow lastRow = new TableRow();
            TableCell lastRowCell = new TableCell();
            lastRowCell.Text = "There are currently no students enlisted";
            lastRowCell.ForeColor = System.Drawing.Color.Red;
            lastRowCell.ColumnSpan = 4;
            lastRowCell.HorizontalAlign = HorizontalAlign.Center;
            lastRow.Cells.Add(lastRowCell);
            tblCourses.Rows.Add(lastRow);
        }
        else
        {
            foreach (Course course in userCourse)
            {
                {
                    TableRow row = new TableRow();

                    TableCell cell = new TableCell();
                    cell.Text = course.CourseNumber;
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.Text = course.CourseName;
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.Text = course.WeeklyHours.ToString();
                    row.Cells.Add(cell);

                    tblCourses.Rows.Add(row);
                }
            }
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string courseNumber = txtCourseNumber.Text;
        string courseName = txtCourseName.Text;
        string stringCourseHours = txtCourseHours.Text;
        int courseHours = Int32.Parse(stringCourseHours);

        userCourse = new Course(courseNumber, courseName, courseHours);
        CourseDataAccess.addNewCourse(userCourse);
    }
}