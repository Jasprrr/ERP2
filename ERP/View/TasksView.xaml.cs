using ERP.Model;
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

namespace ERP.View
{
    /// <summary>
    /// Interaction logic for TasksView.xaml
    /// </summary>
    public partial class TasksView : Page
    {
        public TasksView()
        {
            InitializeComponent();
            _todoList.Add(new ToDo { dueDate = new DateTime(2008, 3, 1, 7, 0, 0), account = "Acc 01", description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse vel lectus commodo, interdum lacus vel, tristique nisl. Cras ut sapien at lectus lobortis dictum ac a ex. Sed fringilla gravida nunc. Integer in erat eleifend, sollicitudin tortor at, luctus quam. Vestibulum eget augue purus. Donec quis hendrerit erat, a ornare purus." });
            _todoList.Add(new ToDo { dueDate = new DateTime(2008, 3, 1, 7, 0, 0), account = "Acc 02", description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse vel lectus commodo, interdum lacus vel, tristique nisl. Cras ut sapien at lectus lobortis dictum ac a ex. Sed fringilla gravida nunc. Integer in erat eleifend, sollicitudin tortor at, luctus quam. Vestibulum eget augue purus. Donec quis hendrerit erat, a ornare purus." });
            _todoList.Add(new ToDo { dueDate = new DateTime(2008, 3, 1, 7, 0, 0), account = "Acc 03", description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse vel lectus commodo, interdum lacus vel, tristique nisl. Cras ut sapien at lectus lobortis dictum ac a ex. Sed fringilla gravida nunc. Integer in erat eleifend, sollicitudin tortor at, luctus quam. Vestibulum eget augue purus. Donec quis hendrerit erat, a ornare purus." });
            _todoList.Add(new ToDo { dueDate = new DateTime(2008, 3, 1, 7, 0, 0), account = "Acc 04", description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse vel lectus commodo, interdum lacus vel, tristique nisl. Cras ut sapien at lectus lobortis dictum ac a ex. Sed fringilla gravida nunc. Integer in erat eleifend, sollicitudin tortor at, luctus quam. Vestibulum eget augue purus. Donec quis hendrerit erat, a ornare purus." });
            _todoList.Add(new ToDo { dueDate = new DateTime(2008, 3, 1, 7, 0, 0), account = "Acc 05", description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse vel lectus commodo, interdum lacus vel, tristique nisl. Cras ut sapien at lectus lobortis dictum ac a ex. Sed fringilla gravida nunc. Integer in erat eleifend, sollicitudin tortor at, luctus quam. Vestibulum eget augue purus. Donec quis hendrerit erat, a ornare purus." });
            _todoList.Add(new ToDo { dueDate = new DateTime(2008, 3, 1, 7, 0, 0), account = "Acc 06", description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse vel lectus commodo, interdum lacus vel, tristique nisl. Cras ut sapien at lectus lobortis dictum ac a ex. Sed fringilla gravida nunc. Integer in erat eleifend, sollicitudin tortor at, luctus quam. Vestibulum eget augue purus. Donec quis hendrerit erat, a ornare purus." });
            _todoList.Add(new ToDo { dueDate = new DateTime(2008, 3, 1, 7, 0, 0), account = "Acc 07", description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse vel lectus commodo, interdum lacus vel, tristique nisl. Cras ut sapien at lectus lobortis dictum ac a ex. Sed fringilla gravida nunc. Integer in erat eleifend, sollicitudin tortor at, luctus quam. Vestibulum eget augue purus. Donec quis hendrerit erat, a ornare purus." });
            _todoList.Add(new ToDo { dueDate = new DateTime(2008, 3, 1, 7, 0, 0), account = "Acc 08", description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse vel lectus commodo, interdum lacus vel, tristique nisl. Cras ut sapien at lectus lobortis dictum ac a ex. Sed fringilla gravida nunc. Integer in erat eleifend, sollicitudin tortor at, luctus quam. Vestibulum eget augue purus. Donec quis hendrerit erat, a ornare purus." });
            _todoList.Add(new ToDo { dueDate = new DateTime(2008, 3, 1, 7, 0, 0), account = "Acc 09", description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse vel lectus commodo, interdum lacus vel, tristique nisl. Cras ut sapien at lectus lobortis dictum ac a ex. Sed fringilla gravida nunc. Integer in erat eleifend, sollicitudin tortor at, luctus quam. Vestibulum eget augue purus. Donec quis hendrerit erat, a ornare purus." });
            _todoList.Add(new ToDo { dueDate = new DateTime(2008, 3, 1, 7, 0, 0), account = "Acc 10", description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse vel lectus commodo, interdum lacus vel, tristique nisl. Cras ut sapien at lectus lobortis dictum ac a ex. Sed fringilla gravida nunc. Integer in erat eleifend, sollicitudin tortor at, luctus quam. Vestibulum eget augue purus. Donec quis hendrerit erat, a ornare purus." });
            _todoList.Add(new ToDo { dueDate = new DateTime(2008, 3, 1, 7, 0, 0), account = "Acc 11", description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse vel lectus commodo, interdum lacus vel, tristique nisl. Cras ut sapien at lectus lobortis dictum ac a ex. Sed fringilla gravida nunc. Integer in erat eleifend, sollicitudin tortor at, luctus quam. Vestibulum eget augue purus. Donec quis hendrerit erat, a ornare purus." });
            _todoList.Add(new ToDo { dueDate = new DateTime(2008, 3, 1, 7, 0, 0), account = "Acc 12", description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse vel lectus commodo, interdum lacus vel, tristique nisl. Cras ut sapien at lectus lobortis dictum ac a ex. Sed fringilla gravida nunc. Integer in erat eleifend, sollicitudin tortor at, luctus quam. Vestibulum eget augue purus. Donec quis hendrerit erat, a ornare purus." });
            _todoList.Add(new ToDo { dueDate = new DateTime(2008, 3, 1, 7, 0, 0), account = "Acc 13", description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse vel lectus commodo, interdum lacus vel, tristique nisl. Cras ut sapien at lectus lobortis dictum ac a ex. Sed fringilla gravida nunc. Integer in erat eleifend, sollicitudin tortor at, luctus quam. Vestibulum eget augue purus. Donec quis hendrerit erat, a ornare purus." });
            _todoList.Add(new ToDo { dueDate = new DateTime(2008, 3, 1, 7, 0, 0), account = "Acc 14", description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse vel lectus commodo, interdum lacus vel, tristique nisl. Cras ut sapien at lectus lobortis dictum ac a ex. Sed fringilla gravida nunc. Integer in erat eleifend, sollicitudin tortor at, luctus quam. Vestibulum eget augue purus. Donec quis hendrerit erat, a ornare purus." });
        }

        private ObservableCollection<ToDo> _todoList { get; set; }
        public ObservableCollection<ToDo> todoList
        {
            get { return _todoList ?? (_todoList = new ObservableCollection<ToDo>()); }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var taskWindow = new TaskView();
            taskWindow.Show();
        }
    }
}
