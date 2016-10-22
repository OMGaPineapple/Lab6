using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddStudent : PageBase
{
   // CourseComparer sortBy = new CourseComparer();
    protected void Page_PreRender(object sender, EventArgs e)
    {
        List<CourseOffering> coursesOffered = CourseOfferingsDataAccess.retreiveAllCourses();
        List<Student> students =  StudentDataAccess.retreiveAllStudents();

        List<Student> registeredStudents = null;

        foreach (CourseOffering courseOffering in coursesOffered)
        {
            if (courseOffering.ToString() == ddCourseOffering.SelectedItem.Text)
            {
                registeredStudents = RegistrationDataAccess.getStudentsFromOffering(courseOffering);
            }
        }

        if (!IsPostBack)
        {     
            foreach (CourseOffering course in coursesOffered)
            {
                ListItem item = new ListItem(course.ToString(),course.CourseOffered.CourseNumber);
                ddCourseOffering.Items.Add(item);
            }
        }

        if (students.Count == 0)
        {
            TableRow lastRow = new TableRow();
            TableCell lastRowCell = new TableCell();
            lastRowCell.Text = "There are currently no students enlisted";
            lastRowCell.ForeColor = System.Drawing.Color.Red;
            lastRowCell.ColumnSpan = 4;
            lastRowCell.HorizontalAlign = HorizontalAlign.Center;
            lastRow.Cells.Add(lastRowCell);
            tblNAMETHISCODY.Rows.Add(lastRow);
        }
        else
        {
            if (registeredStudents == null)
            {

            }
            else
            {

                foreach (Student student in registeredStudents)
                {
                    {
                        string type = StudentType.getStudentType(student);

                        TableRow row = new TableRow();

                        TableCell cell = new TableCell();
                        cell.Text = student.Number;
                        row.Cells.Add(cell);

                        cell = new TableCell();
                        cell.Text = student.Name;
                        row.Cells.Add(cell);

                        cell = new TableCell();
                        cell.Text = type;
                        row.Cells.Add(cell);

                        tblNAMETHISCODY.Rows.Add(row);
                    }
                }
            }
        }
    }


    protected void btnAddStudent_Click(object sender, EventArgs e)
    {
        string studentNum = txtStudentNumber.Text;
        string courseID = ddCourseOffering.SelectedValue;
        string studentName = txtStudentName.Text;

        List<CourseOffering> coursesOffered = CourseOfferingsDataAccess.retreiveAllCourses();
        List<Student> students = StudentDataAccess.retreiveAllStudents();
        List<Student> registeredStudents = null;

        if (rblStudentStatus.SelectedValue == "Full-Time") {
            FullTimeStudent student = new FullTimeStudent(studentNum, studentName);

            foreach (CourseOffering courseOffering in coursesOffered)
            {
                if (courseOffering.ToString() == ddCourseOffering.SelectedItem.Text)
                {
                    registeredStudents = RegistrationDataAccess.getStudentsFromOffering(courseOffering);
                }
            }
            if (registeredStudents == null)
            {
                foreach (Student thisStudent in students)
                {
                    if(!(thisStudent.Name == student.Name))
                    {
                     StudentDataAccess.AddStudent(student);
                    }
                }
 
                foreach (CourseOffering courseOffering in coursesOffered)
                {
                    if (courseOffering.ToString() == ddCourseOffering.SelectedItem.Text)
                    {
                        RegistrationDataAccess.addRegistration(student, courseOffering);
                    }
                }
               
            }
            else
            {
                foreach (Student registeredStudent in students)
                {
                    if (!(student.Number == registeredStudent.Number))
                    {
                        StudentDataAccess.AddStudent(student);
                    }

                    if (registeredStudent.Number == student.Number)
                    {
                        //Does nothing. 
                    }
                    else
                    {
                        foreach (CourseOffering courseOffering in coursesOffered)
                        {
                            if (courseOffering.CourseOffered.ToString() == ddCourseOffering.SelectedItem.Text)
                            {
                                RegistrationDataAccess.addRegistration(student, courseOffering);
                            }
                        }
                    }
                }
            }
    //    } else if (rblStudentStatus.SelectedValue == "Part-Time")
    //    {
    //        PartTimeStudent student = new PartTimeStudent(studentNum, studentName);

    //        foreach (Student registeredStudent in students)
    //        {
    //            if (!(student.Number == registeredStudent.Number))
    //            {
    //                StudentDataAccess.AddStudent(student);
    //            }
    //        }
            
    //        foreach (CourseOffering course in coursesOffered)
    //        {
    //            if (course.ToString() == ddCourseOffering.Text)
    //            {
    //                RegistrationDataAccess.addRegistration(student, course);
    //            }
    //        }

    //    }
    //    else if (rblStudentStatus.SelectedValue == "Co-Op")
    //    {
    //        CoopStudent student = new CoopStudent(studentNum,studentName);

    //        foreach (Student registeredStudent in students)
    //        {
    //            if (!(student.Number == registeredStudent.Number))
    //            {
    //                StudentDataAccess.AddStudent(student);
    //            }
    //        }

    //        foreach (CourseOffering course in coursesOffered)
    //        {
    //            if(course.ToString() == ddCourseOffering.Text)
    //            {
    //                RegistrationDataAccess.addRegistration(student, course);
    //             }
    //        }

       }
        
    }
}