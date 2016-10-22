using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for StudentType
/// </summary>
public class StudentType : Student
{
    public StudentType(string name, string number) : base(name, number)
    {
        
    }

    public static string getStudentType(Student student)
    {
        if(student is FullTimeStudent)
        {
            return "Full Time";
        }
        else if(student is PartTimeStudent)
        {
            return "Part Time";
        }
        else if(student is CoopStudent)
        {
            return "Co-op";
        } else
        {
            return null;
        }

        
    }

    //public class StudentType
    //{
    //    public const string FullTime = "Full time";
    //    public const string PartTime = "Part time";
    //    public const string Co-op = "Co-op";
    //}

    public override double TuitionPayable()
    {
        return 0;
    }
}