using Task02.Dal;
using Task02.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task02.Utils;

namespace Task02.ViewModels
{
    public class PersonViewModel
    {
        public enum FilterType
        {
            All,
            Students,
            Professors,
            Employees
        }

        public ObservableCollection<Person> People { get; }
        public FilterType SelectedFilter { get; set; } = FilterType.All;

        public PersonViewModel()
        {
            People = new ObservableCollection<Person>();
            People.CollectionChanged += People_CollectionChanged;
            RefreshList();
        }

        private void People_CollectionChanged(object? sender,
            System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    RepositoryFactory.GetRepository().AddPerson(People[e.NewStartingIndex]);
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    RepositoryFactory.GetRepository().DeletePerson(
                        e.OldItems!.OfType<Person>().ToList()[0]);

                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Replace:
                    RepositoryFactory.GetRepository().UpdatePerson(
                        e.NewItems!.OfType<Person>().ToList()[0]);
                    break;
            }
        }
        public void UpdatePerson(Person person) => People[People.IndexOf(person)] = person;

        public void RefreshList()
        {
            IRepository repository = RepositoryFactory.GetRepository();
            People.CollectionChanged -= People_CollectionChanged;
            People.Clear();

            switch(SelectedFilter)
            {
                case FilterType.All:
                    People.AddRange(repository.GetPeople());
                    break;
                case FilterType.Students:
                    People.AddRange(repository.GetStudents());
                    break;
                case FilterType.Professors:
                    People.AddRange(repository.GetProfessors());
                    break;
                case FilterType.Employees:
                    People.AddRange(repository.GetEmployees());
                    break;
            }

            People.CollectionChanged += People_CollectionChanged;
        }
    }
}
