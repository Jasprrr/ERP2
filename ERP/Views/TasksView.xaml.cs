using ERP.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace ERP.Views
{
    /// <summary>
    /// Interaction logic for TasksView.xaml
    /// </summary>
    public partial class TasksView : Page
    {
        public TasksView()
        {
            InitializeComponent();
            _todoList.Add(new ToDo { dueDate = new DateTime(2008, 1, 15, 7, 10, 0), account = "Acc 01", description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse vel lectus commodo, interdum lacus vel, tristique nisl. Cras ut sapien at lectus lobortis dictum ac a ex. Sed fringilla gravida nunc. Integer in erat eleifend, sollicitudin tortor at, luctus quam. Vestibulum eget augue purus. Donec quis hendrerit erat, a ornare purus." });
            _todoList.Add(new ToDo { dueDate = new DateTime(2008, 2, 14, 7, 20, 0), account = "Acc 02", description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse vel lectus commodo, interdum lacus vel, tristique nisl. Cras ut sapien at lectus lobortis dictum ac a ex. Sed fringilla gravida nunc. Integer in erat eleifend, sollicitudin tortor at, luctus quam. Vestibulum eget augue purus. Donec quis hendrerit erat, a ornare purus." });
            _todoList.Add(new ToDo { dueDate = new DateTime(2008, 3, 13, 7, 30, 0), account = "Acc 03", description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse vel lectus commodo, interdum lacus vel, tristique nisl. Cras ut sapien at lectus lobortis dictum ac a ex. Sed fringilla gravida nunc. Integer in erat eleifend, sollicitudin tortor at, luctus quam. Vestibulum eget augue purus. Donec quis hendrerit erat, a ornare purus." });
            _todoList.Add(new ToDo { dueDate = new DateTime(2008, 4, 12, 7, 40, 0), account = "Acc 04", description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse vel lectus commodo, interdum lacus vel, tristique nisl. Cras ut sapien at lectus lobortis dictum ac a ex. Sed fringilla gravida nunc. Integer in erat eleifend, sollicitudin tortor at, luctus quam. Vestibulum eget augue purus. Donec quis hendrerit erat, a ornare purus." });
            _todoList.Add(new ToDo { dueDate = new DateTime(2008, 5, 11, 7, 50, 0), account = "Acc 05", description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse vel lectus commodo, interdum lacus vel, tristique nisl. Cras ut sapien at lectus lobortis dictum ac a ex. Sed fringilla gravida nunc. Integer in erat eleifend, sollicitudin tortor at, luctus quam. Vestibulum eget augue purus. Donec quis hendrerit erat, a ornare purus." });
            _todoList.Add(new ToDo { dueDate = new DateTime(2008, 6, 10, 7, 10, 0), account = "Acc 06", description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse vel lectus commodo, interdum lacus vel, tristique nisl. Cras ut sapien at lectus lobortis dictum ac a ex. Sed fringilla gravida nunc. Integer in erat eleifend, sollicitudin tortor at, luctus quam. Vestibulum eget augue purus. Donec quis hendrerit erat, a ornare purus." });
            _todoList.Add(new ToDo { dueDate = new DateTime(2008, 7, 9, 7, 20, 0), account = "Acc 07", description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse vel lectus commodo, interdum lacus vel, tristique nisl. Cras ut sapien at lectus lobortis dictum ac a ex. Sed fringilla gravida nunc. Integer in erat eleifend, sollicitudin tortor at, luctus quam. Vestibulum eget augue purus. Donec quis hendrerit erat, a ornare purus." });
            _todoList.Add(new ToDo { dueDate = new DateTime(2008, 8, 8, 7, 30, 0), account = "Acc 08", description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse vel lectus commodo, interdum lacus vel, tristique nisl. Cras ut sapien at lectus lobortis dictum ac a ex. Sed fringilla gravida nunc. Integer in erat eleifend, sollicitudin tortor at, luctus quam. Vestibulum eget augue purus. Donec quis hendrerit erat, a ornare purus." });
            _todoList.Add(new ToDo { dueDate = new DateTime(2008, 9, 7, 7, 40, 0), account = "Acc 09", description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse vel lectus commodo, interdum lacus vel, tristique nisl. Cras ut sapien at lectus lobortis dictum ac a ex. Sed fringilla gravida nunc. Integer in erat eleifend, sollicitudin tortor at, luctus quam. Vestibulum eget augue purus. Donec quis hendrerit erat, a ornare purus." });
            _todoList.Add(new ToDo { dueDate = new DateTime(2008, 10, 6, 7, 50, 0), account = "Acc 10", description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse vel lectus commodo, interdum lacus vel, tristique nisl. Cras ut sapien at lectus lobortis dictum ac a ex. Sed fringilla gravida nunc. Integer in erat eleifend, sollicitudin tortor at, luctus quam. Vestibulum eget augue purus. Donec quis hendrerit erat, a ornare purus." });
            _todoList.Add(new ToDo { dueDate = new DateTime(2008, 11, 5, 7, 10, 0), account = "Acc 11", description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse vel lectus commodo, interdum lacus vel, tristique nisl. Cras ut sapien at lectus lobortis dictum ac a ex. Sed fringilla gravida nunc. Integer in erat eleifend, sollicitudin tortor at, luctus quam. Vestibulum eget augue purus. Donec quis hendrerit erat, a ornare purus." });
            _todoList.Add(new ToDo { dueDate = new DateTime(2008, 12, 4, 7, 20, 0), account = "Acc 12", description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse vel lectus commodo, interdum lacus vel, tristique nisl. Cras ut sapien at lectus lobortis dictum ac a ex. Sed fringilla gravida nunc. Integer in erat eleifend, sollicitudin tortor at, luctus quam. Vestibulum eget augue purus. Donec quis hendrerit erat, a ornare purus." });
            _todoList.Add(new ToDo { dueDate = new DateTime(2008, 1, 3, 7, 30, 0), account = "Acc 13", description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse vel lectus commodo, interdum lacus vel, tristique nisl. Cras ut sapien at lectus lobortis dictum ac a ex. Sed fringilla gravida nunc. Integer in erat eleifend, sollicitudin tortor at, luctus quam. Vestibulum eget augue purus. Donec quis hendrerit erat, a ornare purus." });
            _todoList.Add(new ToDo { dueDate = new DateTime(2008, 2, 2, 7, 40, 0), account = "Acc 14", description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse vel lectus commodo, interdum lacus vel, tristique nisl. Cras ut sapien at lectus lobortis dictum ac a ex. Sed fringilla gravida nunc. Integer in erat eleifend, sollicitudin tortor at, luctus quam. Vestibulum eget augue purus. Donec quis hendrerit erat, a ornare purus." });
            _todoList.Add(new ToDo { dueDate = new DateTime(2008, 3, 1, 7, 50, 0), account = "Acc 14", description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse vel lectus commodo, interdum lacus vel, tristique nisl. Cras ut sapien at lectus lobortis dictum ac a ex. Sed fringilla gravida nunc. Integer in erat eleifend, sollicitudin tortor at, luctus quam. Vestibulum eget augue purus. Donec quis hendrerit erat, a ornare purus." });
        }

        private ObservableCollection<ToDo> _todoList { get; set; }
        public ObservableCollection<ToDo> todoList
        {
            get { return _todoList ?? (_todoList = new ObservableCollection<ToDo>()); }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
