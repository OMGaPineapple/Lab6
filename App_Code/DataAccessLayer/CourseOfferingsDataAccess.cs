using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

/// <summary>
/// Summary description for CourseOfferingsDataAccess
/// </summary>
public class CourseOfferingsDataAccess : DataAccessBase
{
   
    public static void addNewCourseOffering(CourseOffering courseOffering)
    { 

        string insertCourseOfferingSQL = "INSERT INTO CourseOffering (Year, Semester, Course_CourseID) VALUES (@year, @Semester, @courseID)";

        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand sqlCourseCommand = new SqlCommand(insertCourseOfferingSQL, connection);

        sqlCourseCommand.Parameters.AddWithValue("@year", courseOffering.Year);
        sqlCourseCommand.Parameters.AddWithValue("@Semester", courseOffering.Semester);
        sqlCourseCommand.Parameters.AddWithValue("@courseID", courseOffering.CourseOffered.CourseNumber);

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


    public static List<CourseOffering> retreiveAllCourses()
    {
        string selectCoursesOfferedSQL = "SELECT * FROM CourseOffering";
        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand command = new SqlCommand(selectCoursesOfferedSQL, connection);

        SqlDataReader reader = null;

        List<CourseOffering> courses = new List<CourseOffering>();

        try
        {
            connection.Open();
            reader = command.ExecuteReader();

            if (reader != null && reader.HasRows)
            {
                while (reader.Read())
                {
                    int courseYear = (int)reader["Year"];
                    string courseSemester = (string)reader["Semester"];
                    string courseID = (string)reader["Course_CourseID"];

                    Course course = CourseDataAccess.retreiveCourseByCourseID(courseID);

                    CourseOffering retrievedCourse = new CourseOffering(course, courseYear, courseSemester);
                    courses.Add(retrievedCourse);

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

