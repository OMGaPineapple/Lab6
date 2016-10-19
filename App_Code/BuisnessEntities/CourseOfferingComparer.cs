using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CourseOfferingComparer
/// </summary>
public class CourseOfferingComparer : IComparer<CourseOffering>
{

    public int Compare(CourseOffering courseOffered1, CourseOffering courseOffered2)
    {
        if(courseOffered1.Year < courseOffered2.Year)
        {
            return 1;
        }
        else if (courseOffered1.Year > courseOffered2.Year)
        {
            return -1;
        }
        else if (courseOffered1.Year == courseOffered2.Year)
        {
            if (courseOffered1.Semester == Semesters.Fall && courseOffered2.Semester == Semesters.Winter || courseOffered2.Semester == Semesters.SpringSummer)
            {
                return -1;
            }

            if (courseOffered2.Semester == Semesters.Fall && courseOffered1.Semester == Semesters.Winter || courseOffered1.Semester == Semesters.SpringSummer)
            {
                return 1;
            }

            if (courseOffered1.Semester == Semesters.Winter && courseOffered2.Semester == Semesters.Fall)
            {
                return -1;
            }

            if (courseOffered2.Semester == Semesters.Winter && courseOffered1.Semester == Semesters.Fall)
            {
                return 1;
            }

            if (courseOffered1.Semester == Semesters.Winter && courseOffered2.Semester == Semesters.SpringSummer)
            {
                return -1;
            }

            if (courseOffered2.Semester == Semesters.Winter && courseOffered1.Semester == Semesters.SpringSummer)
            {
                return 1;
            }

            if (courseOffered1.Semester == Semesters.SpringSummer && courseOffered2.Semester == Semesters.Winter || courseOffered2.Semester == Semesters.Fall)
            {
                return -1;
            }

            if (courseOffered2.Semester == Semesters.SpringSummer && courseOffered1.Semester == Semesters.Winter || courseOffered2.Semester == Semesters.Fall)
            {
                return 1;
            }

            if (courseOffered1.Semester == courseOffered2.Semester)
            {
                return courseOffered1.CourseOffered.CourseName.CompareTo(courseOffered2.CourseOffered.CourseName);
            }
        }

        return 0;
    }
}