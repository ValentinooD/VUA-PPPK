using Task02.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Task02
{
    public class FramedPage : Page
    {
        public FramedPage(PersonViewModel personViewModel)
        {
            PersonViewModel = personViewModel;
        }

        public PersonViewModel PersonViewModel { get; }
        public Frame? Frame { get; set; }
    }
}
