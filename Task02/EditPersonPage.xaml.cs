using Task02.Models;
using Task02.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.Windows.Media.Animation;
using Task02.Utils;

namespace Task02
{
    /// <summary>
    /// Interaction logic for EditPersonPage.xaml
    /// </summary>
    public partial class EditPersonPage : FramedPage
    {
        private bool initFinished = false;
        private readonly Person? person;
        public EditPersonPage(PersonViewModel personViewModel,
            Person? person = null
            ) : base(personViewModel) 
        {
            InitializeComponent();
            this.person = person ?? new Person();

            initFinished = true;

            SetupFormFor(this.person);
            LoadForm(this.person);
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (!IsFormValid())
            {
                MessageBox.Show("Something you've entered is wrong.");
                return;
            }

            Person person = BuildPerson();
            if (person == null)
            {
                MessageBox.Show("Build failed");
                return;
            }

            PersonViewModel.People.Add(person);

            Frame?.Navigate(new ListPeoplePage(PersonViewModel)
            {
                Frame = Frame
            });
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame?.NavigationService.GoBack();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (sender.GetType() != typeof(RadioButton)) return;
            RadioButton button = (RadioButton)sender;

            if (!button.GroupName.Equals("PersonType")) return;

            string selection = button.Content.ToString().ToLower();

            switch (selection)
            { 
                case "student":
                    SetupFormFor(new Student());
                    break;
                case "professor":
                    SetupFormFor(new Professor());
                    break;
                case "employee":
                    SetupFormFor(new Employee());
                    break;
            }

        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            FileDialog dialog = new OpenFileDialog()
            {
                Filter = "Images|*.png;*.jpg;*.jpeg",
                CheckFileExists = true,
                Multiselect = true
            };
            if (dialog.ShowDialog() == true)
            {
                picture.Source = new BitmapImage(new Uri(dialog.FileName));
            }
        }


        // Below here lies the ugliest code in the universe
        // take a welding mask because you're about to see things that will melt your eyes
        private Person BuildPerson()
        {
            Person person;
            if (rbStudent.IsChecked.Value)
            {
                Student student = new Student();
                student.GPA = double.Parse(tbGPA.Text);
                person = student;
            } else if (rbProfessor.IsChecked.Value)
            {
                Professor professor = new Professor();
                professor.Salary = double.Parse(tbSalary.Text);
                professor.Degree = tbDegree.Text;
                person = professor;
            } else if (rbEmployee.IsChecked.Value)
            {
                Employee employee = new Employee();
                employee.Salary = double.Parse(tbSalary.Text);
                employee.Degree = tbDegree.Text;
                employee.Position = tbPosition.Text;

                person = employee;
            } else
            {
                return null;
            }

            person.FirstName = tbFirstName.Text;
            person.LastName = tbLastName.Text;
            person.Email = tbEmail.Text;
            person.Age = int.Parse(tbAge.Text);
            person.Picture = ImageUtils.BitmapImageToByteArray(picture.Source as BitmapImage);

            return person;
        }

        private bool IsFormValid()
        {
            bool ok = true;

            ok &= !string.IsNullOrEmpty(tbFirstName.Text);
            ok &= !string.IsNullOrEmpty(tbLastName.Text);
            ok &= !string.IsNullOrEmpty(tbEmail.Text);

            if (tbDegree.IsVisible)
                ok &= !string.IsNullOrEmpty(tbDegree.Text);

            if (tbPosition.IsVisible)
                ok &= !string.IsNullOrEmpty(tbPosition.Text);
            
            if (tbGPA.IsVisible)
                ok &= double.TryParse(tbGPA.Text, out double a);

            if (tbSalary.IsVisible)
                ok &= double.TryParse(tbSalary.Text, out double b);

            ok &= int.TryParse(tbAge.Text, out int c);

            ok &= picture.Source != null;

            return ok;
        }


        private void LoadForm(Person person)
        {
            rbStudent.IsChecked = false;
            rbProfessor.IsChecked = false;
            rbEmployee.IsChecked = false;

            if (person == null) return;

            tbFirstName.Text = person.FirstName;
            tbLastName.Text = person.LastName;
            tbEmail.Text = person.Email;
            tbAge.Text = person.Age.ToString();

            picture.Source = person.Image;

            if (person.GetType() == typeof(Student))
            {
                rbStudent.IsChecked = true;
                Student student = (Student)person;

                tbGPA.Text = student.GPA.ToString();
            }
            else if (person.GetType() == typeof(Professor))
            {
                rbProfessor.IsChecked = true;
                Professor professor = (Professor)person;
                tbSalary.Text = professor.Salary.ToString();
                tbDegree.Text = professor.Degree;
            }
            else if (person.GetType() == typeof(Employee))
            {
                rbEmployee.IsChecked = true;
                Employee employee = (Employee)person;
                tbSalary.Text = employee.Salary.ToString();
                tbDegree.Text = employee.Degree;
                tbPosition.Text = employee.Position;
            }
        }

        private void SetupFormFor(Person person)
        {
            if (!initFinished) return;

            // hide everything
            lbGPA.Visibility = Visibility.Hidden;
            tbGPA.Visibility = Visibility.Hidden;
            lbDegree.Visibility = Visibility.Hidden;
            tbDegree.Visibility = Visibility.Hidden;
            lbPosition.Visibility = Visibility.Hidden;
            tbPosition.Visibility = Visibility.Hidden;
            lbSalary.Visibility = Visibility.Hidden;
            tbSalary.Visibility = Visibility.Hidden;

            if (person == null) return;

            if (person.GetType() == typeof(Student))
            {
                lbGPA.Visibility = Visibility.Visible;
                tbGPA.Visibility = Visibility.Visible;
            }
            else if (person.GetType() == typeof(Professor))
            {
                lbDegree.Visibility = Visibility.Visible;
                tbDegree.Visibility = Visibility.Visible;
                lbSalary.Visibility = Visibility.Visible;
                tbSalary.Visibility = Visibility.Visible;
            }
            else if (person.GetType() == typeof(Employee))
            {
                lbDegree.Visibility = Visibility.Visible;
                tbDegree.Visibility = Visibility.Visible;
                lbPosition.Visibility = Visibility.Visible;
                tbPosition.Visibility = Visibility.Visible;
                lbSalary.Visibility = Visibility.Visible;
                tbSalary.Visibility = Visibility.Visible;
            }
        }
    }
}
