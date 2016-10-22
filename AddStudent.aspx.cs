using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddStudent : PageBase
{
    CourseOffering coursesOffered = null;
    StudentComparer sortBy = new StudentComparer();
    CourseOfferingComparer sortOffering = new CourseOfferingComparer();

    protected void Page_PreRender(object sender, EventArgs e)

    {
        if (!IsPostBack)
        {
            List<CourseOffering> ourCourses = CourseOfferingsDataAccess.retreiveAllCourses();
            ourCourses.Sort(sortOffering);

            foreach (CourseOffering course in ourCourses)
            {
                ListItem item = new ListItem(course.ToString(), course.CourseOffered.CourseNumber);
                ddlCourseOffering.Items.Add(item);
            }
        }

        if (IsPostBack)
        {
            List<CourseOffering> coursesOffered = CourseOfferingsDataAccess.retreiveAllCourses();
            int selectedIndex = ddlCourseOffering.SelectedIndex;

            List<Student> studentsInOfferingList = RegistrationDataAccess.getStudentsFromOffering(coursesOffered[selectedIndex]);
            studentsInOfferingList.Sort(sortBy);

            if (studentsInOfferingList.Count == 0)
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
                foreach (Student student in studentsInOfferingList)
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

                        tblStudentRecords.Rows.Add(row);
                    }
                }
            }
        }
    }

    protected void btnAddCourseOffering_Click1(object sender, EventArgs e)
    {
        string studentNumber = txtStudentName.Text;
        string studentName = txtStudentName.Text;

        List<CourseOffering> coursesOffered = CourseOfferingsDataAccess.retreiveAllCourses();
        int j = ddlCourseOffering.SelectedIndex;

        string test = rblStudentStatus.SelectedValue;

        if (rblStudentStatus.SelectedValue == "Full-Time")
        {
            Student ourStudents = new FullTimeStudent(studentNumber, studentName);
            StudentDataAccess.AddStudent(ourStudents);

            int selectedIndex = ddlCourseOffering.SelectedIndex;

            coursesOffered[selectedIndex].AddStudent(ourStudents);

            RegistrationDataAccess.addRegistration(ourStudents, coursesOffered[selectedIndex]);

            txtStudentName.Text = "";
            txtStudentNumber.Text = "";
        }

        else if (rblStudentStatus.SelectedValue == "Part-Time")
        {
            Student ourStudents = new PartTimeStudent(studentNumber, studentName);
            StudentDataAccess.AddStudent(ourStudents);

            int selectedIndex = ddlCourseOffering.SelectedIndex;

            coursesOffered[selectedIndex].AddStudent(ourStudents);

            RegistrationDataAccess.addRegistration(ourStudents, coursesOffered[selectedIndex]);

            txtStudentName.Text = "";
            txtStudentNumber.Text = "";
        }
        else if (rblStudentStatus.SelectedValue == "Co-op")
        {
            Student ourStudents = new CoopStudent(studentNumber, studentName);
            StudentDataAccess.AddStudent(ourStudents);

            int selectedIndex = ddlCourseOffering.SelectedIndex;

            coursesOffered[selectedIndex].AddStudent(ourStudents);

            RegistrationDataAccess.addRegistration(ourStudents, coursesOffered[selectedIndex]);

            txtStudentName.Text = "";
            txtStudentNumber.Text = "";
        }
    }
}