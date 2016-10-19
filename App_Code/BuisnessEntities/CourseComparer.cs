using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CourseComparer
/// </summary>
public class CourseComparer : IComparer<Course>
{
    public int Compare(Course course1, Course course2)
    {
        return course1.CourseName.CompareTo(course2.CourseName);
    }
}