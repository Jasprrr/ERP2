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
            _todoList.Add(new ToDo { DueDate = new DateTime(2008, 3, 1, 7, 0, 0), Account = "Acc 01", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse vel lectus commodo, interdum lacus vel, tristique nisl. Cras ut sapien at lectus lobortis dictum ac a ex. Sed fringilla gravida nunc. Integer in erat eleifend, sollicitudin tortor at, luctus quam. Vestibulum eget augue purus. Donec quis hendrerit erat, a ornare purus." });
            _todoList.Add(new ToDo { DueDate = new DateTime(2008, 3, 1, 7, 0, 0), Account = "Acc 02", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse vel lectus commodo, interdum lacus vel, tristique nisl. Cras ut sapien at lectus lobortis dictum ac a ex. Sed fringilla gravida nunc. Integer in erat eleifend, sollicitudin tortor at, luctus quam. Vestibulum eget augue purus. Donec quis hendrerit erat, a ornare purus." });
            _todoList.Add(new ToDo { DueDate = new DateTime(2008, 3, 1, 7, 0, 0), Account = "Acc 03", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse vel lectus commodo, interdum lacus vel, tristique nisl. Cras ut sapien at lectus lobortis dictum ac a ex. Sed fringilla gravida nunc. Integer in erat eleifend, sollicitudin tortor at, luctus quam. Vestibulum eget augue purus. Donec quis hendrerit erat, a ornare purus." });
            _todoList.Add(new ToDo { DueDate = new DateTime(2008, 3, 1, 7, 0, 0), Account = "Acc 04", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse vel lectus commodo, interdum lacus vel, tristique nisl. Cras ut sapien at lectus lobortis dictum ac a ex. Sed fringilla gravida nunc. Integer in erat eleifend, sollicitudin tortor at, luctus quam. Vestibulum eget augue purus. Donec quis hendrerit erat, a ornare purus." });
            _todoList.Add(new ToDo { DueDate = new DateTime(2008, 3, 1, 7, 0, 0), Account = "Acc 05", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse vel lectus commodo, interdum lacus vel, tristique nisl. Cras ut sapien at lectus lobortis dictum ac a ex. Sed fringilla gravida nunc. Integer in erat eleifend, sollicitudin tortor at, luctus quam. Vestibulum eget augue purus. Donec quis hendrerit erat, a ornare purus." });
            _todoList.Add(new ToDo { DueDate = new DateTime(2008, 3, 1, 7, 0, 0), Account = "Acc 06", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse vel lectus commodo, interdum lacus vel, tristique nisl. Cras ut sapien at lectus lobortis dictum ac a ex. Sed fringilla gravida nunc. Integer in erat eleifend, sollicitudin tortor at, luctus quam. Vestibulum eget augue purus. Donec quis hendrerit erat, a ornare purus." });
            _todoList.Add(new ToDo { DueDate = new DateTime(2008, 3, 1, 7, 0, 0), Account = "Acc 07", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse vel lectus commodo, interdum lacus vel, tristique nisl. Cras ut sapien at lectus lobortis dictum ac a ex. Sed fringilla gravida nunc. Integer in erat eleifend, sollicitudin tortor at, luctus quam. Vestibulum eget augue purus. Donec quis hendrerit erat, a ornare purus." });
            _todoList.Add(new ToDo { DueDate = new DateTime(2008, 3, 1, 7, 0, 0), Account = "Acc 08", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse vel lectus commodo, interdum lacus vel, tristique nisl. Cras ut sapien at lectus lobortis dictum ac a ex. Sed fringilla gravida nunc. Integer in erat eleifend, sollicitudin tortor at, luctus quam. Vestibulum eget augue purus. Donec quis hendrerit erat, a ornare purus." });
            _todoList.Add(new ToDo { DueDate = new DateTime(2008, 3, 1, 7, 0, 0), Account = "Acc 09", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse vel lectus commodo, interdum lacus vel, tristique nisl. Cras ut sapien at lectus lobortis dictum ac a ex. Sed fringilla gravida nunc. Integer in erat eleifend, sollicitudin tortor at, luctus quam. Vestibulum eget augue purus. Donec quis hendrerit erat, a ornare purus." });
            _todoList.Add(new ToDo { DueDate = new DateTime(2008, 3, 1, 7, 0, 0), Account = "Acc 10", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse vel lectus commodo, interdum lacus vel, tristique nisl. Cras ut sapien at lectus lobortis dictum ac a ex. Sed fringilla gravida nunc. Integer in erat eleifend, sollicitudin tortor at, luctus quam. Vestibulum eget augue purus. Donec quis hendrerit erat, a ornare purus." });
            _todoList.Add(new ToDo { DueDate = new DateTime(2008, 3, 1, 7, 0, 0), Account = "Acc 11", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse vel lectus commodo, interdum lacus vel, tristique nisl. Cras ut sapien at lectus lobortis dictum ac a ex. Sed fringilla gravida nunc. Integer in erat eleifend, sollicitudin tortor at, luctus quam. Vestibulum eget augue purus. Donec quis hendrerit erat, a ornare purus." });
            _todoList.Add(new ToDo { DueDate = new DateTime(2008, 3, 1, 7, 0, 0), Account = "Acc 12", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse vel lectus commodo, interdum lacus vel, tristique nisl. Cras ut sapien at lectus lobortis dictum ac a ex. Sed fringilla gravida nunc. Integer in erat eleifend, sollicitudin tortor at, luctus quam. Vestibulum eget augue purus. Donec quis hendrerit erat, a ornare purus." });
            _todoList.Add(new ToDo { DueDate = new DateTime(2008, 3, 1, 7, 0, 0), Account = "Acc 13", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse vel lectus commodo, interdum lacus vel, tristique nisl. Cras ut sapien at lectus lobortis dictum ac a ex. Sed fringilla gravida nunc. Integer in erat eleifend, sollicitudin tortor at, luctus quam. Vestibulum eget augue purus. Donec quis hendrerit erat, a ornare purus." });
            _todoList.Add(new ToDo { DueDate = new DateTime(2008, 3, 1, 7, 0, 0), Account = "Acc 14", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse vel lectus commodo, interdum lacus vel, tristique nisl. Cras ut sapien at lectus lobortis dictum ac a ex. Sed fringilla gravida nunc. Integer in erat eleifend, sollicitudin tortor at, luctus quam. Vestibulum eget augue purus. Donec quis hendrerit erat, a ornare purus." });
        }

        private ObservableCollection<ToDo> _todoList { get; set; }
        public ObservableCollection<ToDo> todoList
        {
            get { return _todoList ?? (_todoList = new ObservableCollection<ToDo>()); }
        }
    }
}
