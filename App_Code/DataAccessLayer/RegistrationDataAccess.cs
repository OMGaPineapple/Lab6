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

    public static List<Student> getStudentsFromOffering(CourseOffering courseOffering)
    {
        string selectSQL = "SELECT s.StudentNum, s.Name, s.Type FROM Student s "
                                + "JOIN Registration r ON s.StudentNum = r.Student_StudentNum  "
                                + "WHERE r.CourseOffering_Course_CourseID=@courseID "
                                + "  AND r.CourseOffering_Year = @year "
                                + "  AND r.CourseOffering_Semester = @Semester";

        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand command = new SqlCommand(selectSQL, connection);
        command.Parameters.AddWithValue("@courseID", courseOffering.CourseOffered.CourseNumber);
        command.Parameters.AddWithValue("@year", courseOffering.Year.ToString());
        command.Parameters.AddWithValue("@Semester", courseOffering.Semester);

        SqlDataReader reader = null;

        List<Student> studentsInOffering = new List<Student>();

        try
        {
            connection.Open();
            reader = command.ExecuteReader();

            if (reader != null && reader.HasRows)
            {
                while (reader.Read())
                {
                    string studentNumber = (string)reader["StudentNum"];
                    string studentName = (string)reader["Name"];
                    string type = (string)reader["Type"];

                    if (type == "Full Time")
                    {
                        Student ourStudent = new FullTimeStudent(studentNumber, studentName);
                        studentsInOffering.Add(ourStudent);

                    }
                    if (type == "Part Time")
                    {
                        Student ourStudent = new PartTimeStudent(studentNumber, studentName);
                        studentsInOffering.Add(ourStudent);
                    }
                    else
                    {
                        Student ourStudent = new CoopStudent(studentNumber, studentName);
                        studentsInOffering.Add(ourStudent);
                    }
                }
            }
        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            connection.Close();
        }
        return studentsInOffering;
    }


    //public static List<courseOffering> GetRegusteredCourseOfferingByStudent(student)

}
