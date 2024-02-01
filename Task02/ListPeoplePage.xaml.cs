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
using Task02;

namespace Task02
{
    /// <summary>
    /// Interaction logic for ListPeoplePage.xaml
    /// </summary>
    public partial class ListPeoplePage : FramedPage
    {
        public ListPeoplePage(PersonViewModel personViewModel) : base(personViewModel)
        {
            InitializeComponent();
            lvPeople.ItemsSource = personViewModel.People;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Frame?.Navigate(new EditPersonPage(PersonViewModel)
            {
                Frame = Frame
            });
        }


        private void btnClasses_Click(object sender, RoutedEventArgs e)
        {
            Frame?.Navigate(new ListClassesPage(PersonViewModel, lvPeople.SelectedItem as Person)
            {
                Frame = Frame
            });
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (lvPeople.SelectedItem != null)
            {
                Frame?.Navigate(new EditPersonPage(
                    PersonViewModel,
                    lvPeople.SelectedItem as Person
                    )
                {
                    Frame = Frame
                });
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lvPeople.SelectedItem != null)
            {
                PersonViewModel.People.Remove((lvPeople.SelectedItem as Person)!);
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (sender.GetType() != typeof(RadioButton)) return;
            RadioButton button = (RadioButton) sender;

            if (!button.GroupName.Equals("Display")) return;

            string selection = button.Content.ToString().ToLower();

            switch(selection)
            {
                case "all":
                    PersonViewModel.SelectedFilter = PersonViewModel.FilterType.All;
                    break;
                case "students":
                    PersonViewModel.SelectedFilter = PersonViewModel.FilterType.Students;
                    break;
                case "professors":
                    PersonViewModel.SelectedFilter = PersonViewModel.FilterType.Professors;
                    break;
                case "employees":
                    PersonViewModel.SelectedFilter = PersonViewModel.FilterType.Employees;
                    break;
                default:
                    PersonViewModel.SelectedFilter = PersonViewModel.FilterType.All;
                    MessageBox.Show("Invalid selection. Somehow...");
                    break;
            }

            PersonViewModel.RefreshList();
        }
    }
}
