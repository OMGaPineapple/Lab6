using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class SmdCourseRegistration : PageBase
{
    CourseOffering coursesOffered = null;
    Course userCourse = null;
    RegistrationDataAccess registerCourse = null;
    CourseOfferingsDataAccess ourData = null;
    StudentComparer sortBy = new StudentComparer();

    protected void Page_Load(object sender, EventArgs e)
    {

        List<Course> userCourse = CourseDataAccess.retreiveAllCourses();

        int j = userCourse.Count - 1;

        List<CourseOffering>coursesOffered = CourseOfferingsDataAccess.retreiveAllCourses();
        int i = coursesOffered.Count - 1;

        List<Student> getStudents = StudentDataAccess.retreiveAllStudents();

        if (coursesOffered.Count == 0)
        {
            Panel1.Visible = true;
            Panel2.Visible = false;
        }
        else
        {
            CourseOffering workingCourse = new CourseOffering(userCourse[j], coursesOffered[i].Year, coursesOffered[i].Semester);
            workingCourse.AddStudents(getStudents);
            workingCourse.GetStudents().Sort();
            workingCourse.GetStudents().Sort(sortBy);
            string courseNumber = workingCourse.CourseOffered.CourseNumber;

            userCourse[j] = CourseDataAccess.retreiveCourseByCourseID(courseNumber);
            Page.Title = userCourse[j].ToString();

            Panel1.Visible = false;
            Panel2.Visible = true;

            if (workingCourse.GetStudents().Count == 0)
            {
                TableRow lastRow = new TableRow();
                TableCell lastRowCell = new TableCell();
                lastRowCell.Text = "There are currently no students enlisted";
                lastRowCell.ForeColor = System.Drawing.Color.Red;
                lastRowCell.ColumnSpan = 4;
                lastRowCell.HorizontalAlign = HorizontalAlign.Center;
                lastRow.Cells.Add(lastRowCell);
                tblStudentRecords.Rows.Add(lastRow);
            }
            else
            {

                foreach (Student student in workingCourse.GetStudents())
                {
                    {
                        TableRow row = new TableRow();

                        TableCell cell = new TableCell();
                        cell.Text = student.Number;
                        row.Cells.Add(cell);

                        cell = new TableCell();
                        cell.Text = student.Name;
                        row.Cells.Add(cell);

                        string studentType = student.ToString();

                        cell = new TableCell();
                        cell.Text = StudentType.getStudentType(student);
                        row.Cells.Add(cell);

                        cell = new TableCell();
                        double tuitonToPay = student.TuitionPayable();
                        string stringTuitionToPay = tuitonToPay.ToString();
                        cell.Text = stringTuitionToPay;
                        row.Cells.Add(cell);

                        tblStudentRecords.Rows.Add(row);
                    }
                }
            }
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string courseNumber = txtCourseNumber.Text;
        string courseName = txtCourseName.Text;
        string stringCourseHours = txtCourseHours.Text;
        int offeredYear = Int32.Parse(ddlYear.SelectedValue);
        string offeredSemester = ddlSemester.SelectedValue;
        int courseHours = Int32.Parse(stringCourseHours);

        userCourse = new Course(courseNumber, courseName, courseHours);
        CourseDataAccess.addNewCourse(userCourse);

        coursesOffered = new CourseOffering(userCourse, offeredYear, offeredSemester);
        CourseOfferingsDataAccess.addNewCourseOffering(coursesOffered);

        Response.Redirect(Request.RawUrl);
    }

    protected void btnAddCourse_Click(object sender, EventArgs e)
    {

        string studentNumber = txtStudentNumber.Text;
        string studentName = txtStudentName.Text;

        List<CourseOffering> coursesOffered = CourseOfferingsDataAccess.retreiveAllCourses();
        int j = coursesOffered.Count - 1;

        if (rblSortOptions.SelectedValue == "fullTime")
        {
            Student ourStudents = new FullTimeStudent(studentNumber, studentName);
            StudentDataAccess.AddStudent(ourStudents);

            List<Course> userCourse = CourseDataAccess.retreiveAllCourses();
            int i = userCourse.Count() - 1;


            CourseOffering courseOfferedCourses = new CourseOffering(userCourse[i], coursesOffered[j].Year, coursesOffered[j].Semester);

            courseOfferedCourses.AddStudent(ourStudents);
            courseOfferedCourses.GetStudents().Sort(sortBy);

            RegistrationDataAccess.addRegistration(ourStudents, courseOfferedCourses);

            txtStudentName.Text = "";
            txtStudentNumber.Text = "";

            Response.Redirect(Request.RawUrl);
        }

        else if (rblSortOptions.SelectedValue == "partTime")
        {
            Student ourStudents = new PartTimeStudent(studentNumber, studentName);
            StudentDataAccess.AddStudent(ourStudents);

            List<Course> userCourse = CourseDataAccess.retreiveAllCourses();
            int i = userCourse.Count() - 1;

            CourseOffering courseOfferedCourses = new CourseOffering(userCourse[i], coursesOffered[j].Year, coursesOffered[j].Semester);

            courseOfferedCourses.AddStudent(ourStudents);
            courseOfferedCourses.GetStudents().Sort(sortBy);

            txtStudentName.Text = "";
            txtStudentNumber.Text = "";

            Response.Redirect(Request.RawUrl);
        }
        else if (rblSortOptions.SelectedValue == "coop")
        {
            Student ourStudents = new CoopStudent(studentNumber, studentName);
            StudentDataAccess.AddStudent(ourStudents);

            List<Course> userCourse = CourseDataAccess.retreiveAllCourses();
            int i = userCourse.Count() - 1;

            CourseOffering courseOfferedCourses = new CourseOffering(userCourse[i], coursesOffered[j].Year, coursesOffered[j].Semester);

            courseOfferedCourses.AddStudent(ourStudents);
            courseOfferedCourses.GetStudents().Sort(sortBy);

            txtStudentName.Text = "";
            txtStudentNumber.Text = "";

            Response.Redirect(Request.RawUrl);
        }
    }
}
