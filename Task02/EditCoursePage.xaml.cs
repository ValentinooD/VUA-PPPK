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
using Task02.Dal;
using Task02.Models;
using Task02.ViewModels;

namespace Task02
{
    /// <summary>
    /// Interaction logic for EditCoursePage.xaml
    /// </summary>
    public partial class EditCoursePage : FramedPage
    {
        private ClassViewModel classViewModel;
        private Person person;
        public EditCoursePage(PersonViewModel model, ClassViewModel classViewModel, Person person, Course? course = null) : base(model)
        {
            this.classViewModel = classViewModel;
            this.person = person;
            InitializeComponent();
            
            tbStudent.Text = person.FirstName + " " + person.LastName;
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if(!IsFormValid())
            {
                MessageBox.Show("Something you've entered is wrong.");
                return;
            }

            Course course = new Course()
            {
                Name = tbName.Text,
                StartTime = TimeSpan.Parse(tbStart.Text),
                EndTime = TimeSpan.Parse(tbEnd.Text),
                IDPerson = person.IDPerson,
                Person = person
            };
            
            classViewModel.Courses.Add(course);
            Frame?.NavigationService.GoBack();
        }

        private bool IsFormValid()
        {
            bool ok = true;

            ok &= !string.IsNullOrEmpty(tbName.Text);
            ok &= TimeSpan.TryParse(tbStart.Text, out TimeSpan ajoisd);
            ok &= TimeSpan.TryParse(tbEnd.Text, out TimeSpan dsaxsca);

            return ok;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame?.NavigationService.GoBack();
        }
    }
}
