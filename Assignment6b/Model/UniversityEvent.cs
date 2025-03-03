using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6b.Model
{
    internal class UniversityEvent
    {

        //pyhton WorkShop

        Dictionary<int, Student> pythonWorkshop = new Dictionary<int, Student>();

        public void RegisterPythonWorkshop(int studentId, Student student)
        {

            if (!GetStudentIdPythonWorkshop(studentId))
            {
                pythonWorkshop.Add(studentId, student);
                Console.WriteLine($"Student ID:{studentId} successfully Register for Python Workshop");
            }
            else
                Console.WriteLine($"Student ID:{studentId} already Register for Python Workshop!!");
        }

        public void StudentListOfPython()
        {

            Console.WriteLine("Student List of Python Workshop:");
            foreach (KeyValuePair<int, Student> item in pythonWorkshop)
            {
                Console.WriteLine($"StudentId:{item.Key}  Student Name:{item.Value.StudentName}  CourseName::{item.Value.StudentCourseName}");
            }
        }
        public bool GetStudentIdPythonWorkshop(int studentId)
        {
            return pythonWorkshop.ContainsKey(studentId);
        }
        
        
        //java Workshop

        Dictionary<int, Student> javaWorkshop = new Dictionary<int, Student>();

        public void RegisterJavaWorkshop(int studentId, Student student)
        {

            if (!GetStudentIdJavaWorkshop(studentId))
            {
                javaWorkshop.Add(studentId, student);
                Console.WriteLine($"Student ID:{studentId} successfully Register for Python Workshop");
            }
            else
                Console.WriteLine($"Student ID:{studentId} already Register for Python Workshop!!");
        }

        public void StudentListOfJava()
        {

            Console.WriteLine("Student List of Python Workshop:");
            foreach (KeyValuePair<int, Student> item in javaWorkshop)
            {
                Console.WriteLine($"StudentId:{item.Key}  Student Name:{item.Value.StudentName}  CourseName::{item.Value.StudentCourseName}");
            }
        }
        public bool GetStudentIdJavaWorkshop(int studentId)
        {
            return javaWorkshop.ContainsKey(studentId);
        }

    }
}



