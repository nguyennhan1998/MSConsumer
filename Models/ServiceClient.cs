
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MSConsumer.Models
{
    public class ServiceClient
    {
        StudentServiceReference.StudentServiceClient client = new StudentServiceReference.StudentServiceClient();
        public List<Student> GetStudents()
        {
            var list = client.getStudents().ToList();
            var t = new List<Student>();
            list.ForEach(c => t.Add(new Student
            {
                ID = c.ID,
                Name = c.Name,
                Age = c.Age,
                Sex = c.Sex,
                Phone = c.Phone,
                Email = c.Email,
                ClassID = c.ClassID,
            }));
            return t;
        }
        public bool CreateStudent(Student newStudent)
        {
            var student = new StudentServiceReference.Student()
            {
                ID = newStudent.ID,
                Name = newStudent.Name,
                Age = newStudent.Age,
                Sex = newStudent.Sex,
                Phone = newStudent.Phone,
                Email = newStudent.Email,
                ClassID = newStudent.ClassID,
            };
            return client.createStudent(student);
        }
        public bool EditStudent(Student newStudent)
        {
            var student = new StudentServiceReference.Student()
            {

                ID = newStudent.ID,
                Name = newStudent.Name,
                Age = newStudent.Age,
                Sex = newStudent.Sex,
                Phone = newStudent.Phone,
                Email = newStudent.Email,
                ClassID = newStudent.ClassID,
            };
            return client.editStudent(student.ID.ToString(), student);
        }
        public bool DeleteStudent(string id)
        {
            return client.deleteStudent(id);
        }


        public List<Class> GetClasses()
        {
            var list = client.getClasses().ToList();
            var t = new List<Class>();
            list.ForEach(c => t.Add(new Class
            {
                ID = c.ID,
                Name = c.Name,
              
            }));
            return t;
        }
        public bool CreateClass(Class newClass)
        {
            var class1 = new StudentServiceReference.Class()
            {
                ID = newClass.ID,
                Name = newClass.Name,
            
            };
            return client.createClass(class1);
        }
       public bool EditClass(Class newClass)
        {
            var class1 = new StudentServiceReference.Class()
            {

                ID = newClass.ID,
                Name = newClass.Name,
            };
            return client.editClass(class1.ID.ToString(), class1);
        }
        public bool DeleteClass(string id)
        {
            return client.deleteClass(id);
        }
    }
}