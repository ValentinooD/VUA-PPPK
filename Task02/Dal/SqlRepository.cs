using Task02.Models;
using Task02.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Task02.Dal
{
    internal class SqlRepository : IRepository
    {
        private static readonly string cs =
            ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

        public void AddPerson(Person person)
        {
            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue(nameof(Person.FirstName), person.FirstName);
            cmd.Parameters.AddWithValue(nameof(Person.LastName), person.LastName);
            cmd.Parameters.AddWithValue(nameof(Person.Age), person.Age);
            cmd.Parameters.AddWithValue(nameof(Person.Email), person.Email);
            cmd.Parameters.Add(
                new SqlParameter(nameof(Person.Picture), System.Data.SqlDbType.Binary, person.Picture!.Length)
                {
                    Value = person.Picture
                });
            var id = new SqlParameter(nameof(Person.IDPerson), System.Data.SqlDbType.Int)
            {
                Direction = System.Data.ParameterDirection.Output
            };
            cmd.Parameters.Add(id);
            cmd.ExecuteNonQuery();
            person.IDPerson = (int)id.Value;
            
            if (person.GetType() == typeof(Student)) {
                AddStudent((Student)person);
            } else if (person.GetType() == typeof(Professor))
            {
                AddProfessor((Professor) person);
            } else if (person.GetType() == typeof(Employee))
            {
                AddEmployee((Employee) person);
            }
        }

        public void AddCourse(Course course)
        {
            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue(nameof(Course.Name), course.Name);
            cmd.Parameters.AddWithValue(nameof(Course.StartTime), course.StartTime);
            cmd.Parameters.AddWithValue(nameof(Course.EndTime), course.EndTime);
            cmd.Parameters.AddWithValue(nameof(Course.IDPerson), course.IDPerson);
            var id = new SqlParameter(nameof(Course.IDCourse), System.Data.SqlDbType.Int)
            {
                Direction = System.Data.ParameterDirection.Output
            };
            cmd.Parameters.Add(id);
            cmd.ExecuteNonQuery();
            course.IDCourse = (int) id.Value;
        }

        private void AddStudent(Student student)
        {
            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue(nameof(Student.GPA), student.GPA);
            cmd.Parameters.AddWithValue(nameof(Person.IDPerson), student.IDPerson);
            cmd.ExecuteNonQuery();
        }

        private void AddProfessor(Professor professor)
        {
            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue(nameof(Professor.Salary), professor.Salary);
            cmd.Parameters.AddWithValue(nameof(Professor.Degree), professor.Degree);
            cmd.Parameters.AddWithValue(nameof(Person.IDPerson), professor.IDPerson);
            cmd.ExecuteNonQuery();
        }

        private void AddEmployee(Employee employee)
        {
            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue(nameof(Employee.Salary), employee.Salary);
            cmd.Parameters.AddWithValue(nameof(Employee.Degree), employee.Degree);
            cmd.Parameters.AddWithValue(nameof(Employee.Position), employee.Position);
            cmd.Parameters.AddWithValue(nameof(Person.IDPerson), employee.IDPerson);
            cmd.ExecuteNonQuery();
        }

        public void DeletePerson(Person person)
        {
            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue(nameof(Person.IDPerson), person.IDPerson);

            cmd.ExecuteNonQuery();
        }


        public void DeleteCourse(Course course)
        {
            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue(nameof(Course.IDCourse), course.IDCourse);

            cmd.ExecuteNonQuery();
        }

        // ----- Get for all kinds of people -----
        public IList<Course> GetCourses(int idPerson)
        {
            IList<Course> list = new List<Course>();

            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue(nameof(Person.IDPerson), idPerson);
            using SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                list.Add(ReadCourse(dr));
            }

            return list;
        }

        private Course ReadCourse(SqlDataReader dr)
            => new()
            {
                IDCourse = (int)dr[nameof(Course.IDCourse)],
                Name = (string)dr[nameof(Course.Name)],
                StartTime = (TimeSpan)dr[nameof(Course.StartTime)],
                EndTime = (TimeSpan)dr[nameof(Course.EndTime)],
                IDPerson = (int)dr[nameof(Course.IDPerson)],
                Person = GetPerson((int)dr[nameof(Course.IDPerson)]),
            };

        public IList<Person> GetPeople()
        {
            IList<Person> list = new List<Person>();

            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            using SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                list.Add(ReadPerson(dr));
            }

            return list;
        }

        public IList<Student> GetStudents()
        {
            IList<Student> list = new List<Student>();

            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            using SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                list.Add(ReadStudent(dr));
            }

            return list;
        }

        public IList<Professor> GetProfessors()
        {
            IList<Professor> list = new List<Professor>();

            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            using SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                list.Add(ReadProfessor(dr));
            }

            return list;
        }

        public IList<Employee> GetEmployees()
        {
            IList<Employee> list = new List<Employee>();

            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            using SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                list.Add(ReadEmployee(dr));
            }

            return list;
        }

        public Person GetPerson(int idPerson)
        {
            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue(nameof(Person.IDPerson), idPerson);
            using SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return ReadPerson(dr);
            }
            throw new ArgumentException("Wrong id");
        }

        private Person ReadPerson(SqlDataReader dr)
         => new()
         {
             IDPerson = (int)dr[nameof(Person.IDPerson)],
             FirstName = dr[nameof(Person.FirstName)].ToString(),
             LastName = dr[nameof(Person.LastName)].ToString(),
             Age = (int)dr[nameof(Person.Age)],
             Email = dr[nameof(Person.Email)].ToString(),
             Picture = ImageUtils.ByteArrayFromReader(dr, nameof(Person.Picture))
         };

        public Student? GetStudent(int id)
        {
            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue(nameof(Person.IDPerson), id);
            using SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return ReadStudent(dr);
            }
            return null;
        }

        private Student ReadStudent(SqlDataReader dr)
            => new()
            {
                IDPerson = (int)dr[nameof(Person.IDPerson)],
                FirstName = (string)dr[nameof(Person.FirstName)],
                LastName = (string)dr[nameof(Person.LastName)],
                Email = (string)dr[nameof(Person.Email)],
                Age = (int)dr[nameof(Person.Age)],
                Picture = (byte[])dr[nameof(Person.Picture)],
                GPA = (double)dr[nameof(Student.GPA)]
            };

        public Professor? GetProfessor(int id)
        {
            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue(nameof(Person.IDPerson), id);
            using SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return ReadProfessor(dr);
            }
            return null;
        }

        private Professor ReadProfessor(SqlDataReader dr)
            => new()
            {
                IDPerson = (int)dr[nameof(Person.IDPerson)],
                FirstName = (string)dr[nameof(Person.FirstName)],
                LastName = (string)dr[nameof(Person.LastName)],
                Email = (string)dr[nameof(Person.Email)],
                Age = (int)dr[nameof(Person.Age)],
                Picture = (byte[])dr[nameof(Person.Picture)],
                Degree = (string)dr[nameof(Professor.Degree)],
                Salary = (double)dr[nameof(Professor.Salary)]
            };

        public Employee? GetEmployee(int id)
        {
            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue(nameof(Person.IDPerson), id);
            using SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return ReadEmployee(dr);
            }
            return null;
        }

        private Employee ReadEmployee(SqlDataReader dr)
            => new()
            {
                IDPerson = (int)dr[nameof(Person.IDPerson)],
                FirstName = (string)dr[nameof(Person.FirstName)],
                LastName = (string)dr[nameof(Person.LastName)],
                Email = (string)dr[nameof(Person.Email)],
                Age = (int)dr[nameof(Person.Age)],
                Picture = (byte[])dr[nameof(Person.Picture)],
                Degree = (string)dr[nameof(Employee.Degree)],
                Position = (string)dr[nameof(Employee.Position)],
                Salary = (double)dr[nameof(Employee.Salary)]
            };

        // ------- Update for all kinds of people --------
        public void UpdatePerson(Person person)
        {
            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue(nameof(Person.FirstName), person.FirstName);
            cmd.Parameters.AddWithValue(nameof(Person.LastName), person.LastName);
            cmd.Parameters.AddWithValue(nameof(Person.Age), person.Age);
            cmd.Parameters.AddWithValue(nameof(Person.Email), person.Email);
            cmd.Parameters.Add(
                new SqlParameter(nameof(Person.Picture), System.Data.SqlDbType.Binary, person.Picture!.Length)
                {
                    Value = person.Picture
                });
            cmd.Parameters.AddWithValue(nameof(Person.IDPerson), person.IDPerson);

            cmd.ExecuteNonQuery();

        }

    }
}
