using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Comparer
/// </summary>
/// 
public class StudentComparer : IComparer<Student>
{
    public string OrderBy { get; set; }

    public int Compare(Student student1, Student student2)
    {
        int compare = student1.CompareTo(student2);
        if (student1.Name == student2.Name)

        {
            string studentType1 = student1.ToString();
            string studentType2 = student2.ToString();

            if (studentType1.Contains("full") && (studentType2.Contains("part") || studentType2.Contains("co-op")))
            {
                return -1;
            }

            if (studentType2.Contains("full") && (studentType1.Contains("part") || studentType1.Contains("co-op")))
            {
                return 1;
            }

            if (studentType1.Contains("part") && (studentType2.Contains("full")))
            {
                return -1;
            }

            if (studentType2.Contains("part") && (studentType2.Contains("full")))
            {
                return 1;
            }

            if (studentType1.Contains("part") && (studentType2.Contains("co-op")))
            {
                return -1;
            }

            if (studentType2.Contains("part") && (studentType1.Contains("co-op")))
            {
                return 1;
            }

            if (studentType1.Contains("co-op") && (studentType2.Contains("part") || studentType2.Contains("full")))
            {
                return -1;
            }

            if (studentType2.Contains("co-op") && (studentType1.Contains("part") || studentType1.Contains("full")))
            {
                return 1;
            }

            if ((studentType1.Contains("full") && studentType2.Contains("full")) || (studentType1.Contains("part") && studentType2.Contains("part")) || (studentType1.Contains("co-op") && studentType2.Contains("co-op")))
            {
                return student1.Number.CompareTo(student2.Number);
            }
        }

        return 0;
    }

}