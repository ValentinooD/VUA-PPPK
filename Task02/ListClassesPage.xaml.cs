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
using Task02.Models;
using Task02.ViewModels;

namespace Task02
{
    /// <summary>
    /// Interaction logic for ListClassesPage.xaml
    /// </summary>
    public partial class ListClassesPage : FramedPage
    {
        private Person person;
        private ClassViewModel model;

        public ListClassesPage(PersonViewModel personViewModel, Person person) : base(personViewModel)
        {
            InitializeComponent();
            this.person = person;
            this.model = new ClassViewModel(person);

            InitData();
        }

        private void InitData()
        {
            lvClasses.ItemsSource = model.Courses;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lvClasses.SelectedItem != null)
            {
                model.Courses.Remove(lvClasses.SelectedItem as Course);
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Frame?.Navigate(new EditCoursePage(PersonViewModel, model, person)
            {
                Frame = Frame
            });
        }

        private void btnClasses_Click(object sender, RoutedEventArgs e)
        {
            Frame?.NavigationService.GoBack();
        }

        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
