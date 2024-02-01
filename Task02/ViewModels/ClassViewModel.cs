using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Task02.ViewModels.PersonViewModel;
using Task02.Dal;
using Task02.Models;

namespace Task02.ViewModels
{
    public class ClassViewModel
    {

        public ObservableCollection<Course> Courses { get; }
        private Person person;

        public ClassViewModel(Person person)
        {
            this.person = person;
            Courses = new ObservableCollection<Course>(
                RepositoryFactory.GetRepository().GetCourses(person.IDPerson)
                );
            Courses.CollectionChanged += Course_CollectionChanged;
        }

        private void Course_CollectionChanged(object? sender,
            System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    RepositoryFactory.GetRepository().AddCourse(Courses[e.NewStartingIndex]);
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    RepositoryFactory.GetRepository().DeleteCourse(
                        e.OldItems!.OfType<Course>().ToList()[0]);

                    break;
            }
        }
        public void UpdateCourse(Course course) => Courses[Courses.IndexOf(course)] = course;
    }
}
