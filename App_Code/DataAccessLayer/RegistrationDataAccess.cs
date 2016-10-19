using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Configuration;
using System.Data.SqlClient;

/// <summary>
/// Summary description for RegistrationDataAccess
/// </summary>
public class RegistrationDataAccess : DataAccessBase
{
    public static void addRegistration(Student student, CourseOffering courseOffering)
    {
        string insertRegistrationSQL = "INSERT INTO Registration " + "(Student_StudentNum, CourseOffering_Course_CourseID, CourseOffering_Year, CourseOffering_Semester) " + "VALUES (@studentNum, @courseID, @year, @semester)";

        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand sqlCourseCommand = new SqlCommand(insertRegistrationSQL, connection);
        string type = StudentType.getStudentType(student);

        sqlCourseCommand.Parameters.AddWithValue("@studentNum", student.Number);
        sqlCourseCommand.Parameters.AddWithValue("@courseID", courseOffering.CourseOffered.CourseNumber);
        sqlCourseCommand.Parameters.AddWithValue("@year", courseOffering.Year);
        sqlCourseCommand.Parameters.AddWithValue("@semester", courseOffering.Semester);

        int added = 0;
        try
        {
            connection.Open();
            added = sqlCourseCommand.ExecuteNonQuery();
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            connection.Close();
        }
    }

        public static List<Student> getStudentsFromOffering()
    {
        string selectSQL = "SELECT s.StudentNum, s.Name, s.Type FROM Student s "
                                + "JOIN Registration r ON s.StudentNum = r.Student_StudentNum  "
                                + "WHERE r.CourseOffering_Course_CourseID=@courseID "
                                + "  AND r.CourseOffering_Year = @year "
                                + "  AND r.CourseOffering_Semester = @Semester";

        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand command = new SqlCommand(selectSQL, connection);

        SqlDataReader reader = null;

        List<Student> students = new List<Student>();
        List<Student> studentsInOffering = null;

        try
        {
            connection.Open();
            reader = command.ExecuteReader();

            if (reader != null && reader.HasRows)
            {
                while (reader.Read())
                {
                    //int studentNumber = (int)reader["Student_StudentNum"];
                    string courseID = (string)reader["Course_CourseID"];
                    int courseYear = (int)reader["Year"];
                    string courseSemester = (string)reader["Semester"];

                    List<Student> student = StudentDataAccess.retreiveAllStudents();

                    foreach (Student i in student)
                    {
                        string type = StudentType.getStudentType(i);

                        if (type == "Full Time")
                        {
                            Student ourStudent = new FullTimeStudent(i.Number, i.Name);
                            studentsInOffering.Add(ourStudent);

                        }
                        if (type == "Part Time")
                        {
                            Student ourStudent = new PartTimeStudent(i.Number, i.Name);
                            studentsInOffering.Add(ourStudent);
                        }
                        else
                        {
                            Student ourStudent = new CoopStudent(i.Number, i.Name);
                            studentsInOffering.Add(ourStudent);
                        }

                    }
                }
            }
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            connection.Close();
        }
        return studentsInOffering;
    }


    //public static List<courseOffering> GetRegusteredCourseOfferingByStudent(student)

}
