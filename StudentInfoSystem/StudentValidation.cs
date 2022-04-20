using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLogin;

namespace StudentInfoSystem
{
    internal class StudentValidation
    {
        public Student GetStudentDataByUser(User u)
        {
            foreach (Student s in StudentData.TestStudents)
            {
                if (s.facultyNumber != null || s.facultyNumber == u.facultyNumber)
                    return s;
            }
            Console.WriteLine("Faculty number not found");
            return null;
        }
    }
}
