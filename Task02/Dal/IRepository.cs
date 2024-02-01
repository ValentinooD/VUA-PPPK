using Task02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02.Dal
{
    public interface IRepository
    {
        // Create
        void AddPerson(Person person);

        // Read
        Person GetPerson(int idPerson);
        Student? GetStudent(int idPerson);
        Professor? GetProfessor(int idPerson);
        Employee? GetEmployee(int idPerson);
        IList<Person> GetPeople();
        IList<Student> GetStudents();
        IList<Professor> GetProfessors();
        IList<Employee> GetEmployees();

        // Update
        void UpdatePerson(Person person);
        
        //  Delete
        void DeletePerson(Person person);

        // Courses CRUD
        IList<Course> GetCourses(int idPerson);
        void AddCourse(Course course);
        void DeleteCourse(Course course);
    }
}
