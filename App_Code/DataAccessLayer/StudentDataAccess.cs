using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

/// <summary>
/// Summary description for StudentDataAccess
/// </summary>
public class StudentDataAccess : DataAccessBase
{

    public static void AddStudent(Student student)
    {
        string insertStudentSQL = "INSERT INTO Student (StudentNum, Name, Type) VALUES (@studentNum, @name, @type)";
        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand sqlCourseCommand = new SqlCommand(insertStudentSQL, connection);
        string type = StudentType.getStudentType(student);

        sqlCourseCommand.Parameters.AddWithValue("@studentNum", student.Number);
        sqlCourseCommand.Parameters.AddWithValue("@name", student.Name);
        sqlCourseCommand.Parameters.AddWithValue("@type", type);

        int added = 0;
        try
        {
            connection.Open();
            added = sqlCourseCommand.ExecuteNonQuery();
        }
        catch (Exception)
        {
           
        }
        finally
        {
            connection.Close();
        }
    }

    public static List<Student> retreiveAllStudents()
    {
        string selectStudentsSQL = "SELECT * FROM Student";
        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand command = new SqlCommand(selectStudentsSQL, connection);

        SqlDataReader reader = null;

        List<Student> students = new List<Student>();

        try
        {
            connection.Open();
            reader = command.ExecuteReader();

            if (reader != null && reader.HasRows)
            {
                while (reader.Read())
                {
                    string courseNum = (string)reader["StudentNum"];
                    string courseName = (string)reader["Name"];
                    string type = (string)reader["Type"];

                    if (type == "Full Time")
                    {
                        Student student = new FullTimeStudent(courseNum, courseName);

                        students.Add(student);
                    }
                    if (type == "Part Time")
                    {
                        Student student = new PartTimeStudent(courseNum, courseName);

                        students.Add(student);
                    }
                    if(type == "Co-op")
                    {
                        Student student = new CoopStudent(courseNum, courseName);

                        students.Add(student);
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
        return students;
    }

}
