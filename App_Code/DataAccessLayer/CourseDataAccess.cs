
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Configuration;
using System.Data.SqlClient;

/// <summary>
/// Summary description for CourseDataAccess
/// </summary>
public class CourseDataAccess : DataAccessBase
{
    public static void addNewCourse(Course course)
    {
        string insertCourseSQL = "INSERT INTO Course(CourseID, CourseTitle, HoursPerWeek) VALUES(@courseID, @courseTitle, @courseHours)";
        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand sqlCourseCommand = new SqlCommand(insertCourseSQL, connection);

        sqlCourseCommand.Parameters.AddWithValue("@courseID", course.courseNumber);
        sqlCourseCommand.Parameters.AddWithValue("@courseTitle", course.CourseName);
        sqlCourseCommand.Parameters.AddWithValue("@courseHours", course.WeeklyHours);

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

    public static Course retreiveCourseByCourseID(string id)
    {

        Course course = null;

        string selectCoursesIdSQL = "SELECT * FROM Course WHERE CourseID = @courseID";
        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand sqlCourseIDCommand = new SqlCommand(selectCoursesIdSQL, connection);

        sqlCourseIDCommand.Parameters.AddWithValue("@courseID", id);

        SqlDataReader reader = null;

        try
        {
            connection.Open();
            reader = sqlCourseIDCommand.ExecuteReader();

            if (reader != null && reader.HasRows)
            {
                while (reader.Read())
                {
                    string courseNum = (string)reader["CourseID"];
                    string courseName = (string)reader["CourseTitle"];
                    int courseHours = (int)reader["HoursPerWeek"];
                    course = new Course(courseNum, courseName, courseHours);
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
        return course;
    }




    public static List<Course> retreiveAllCourses()
    {
        string selectCoursesSQL = "SELECT * FROM Course";
        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand command = new SqlCommand(selectCoursesSQL, connection);

        SqlDataReader reader = null;

        List<Course> courses = new List<Course>();

        try
        {
            connection.Open();
            reader = command.ExecuteReader();

            if (reader != null && reader.HasRows)
            {
                while (reader.Read())
                {
                    string courseNum = (string)reader["CourseID"];
                    string courseName = (string)reader["CourseTitle"];
                    int courseHours = (int)reader["HoursPerWeek"];

                    Course course = new Course(courseNum, courseName, courseHours);
                    courses.Add(course);
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
        return courses;
    }

}