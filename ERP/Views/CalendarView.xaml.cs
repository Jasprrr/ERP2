using ERP.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace ERP.Views
{
    /// <summary>
    /// Interaction logic for ScheduleView.xaml
    /// </summary>
    public partial class CalendarView : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public CalendarView()
        {
            InitializeComponent();
            SetUpCalendar();
        }

        private int _gridOffset;
        public int gridOffset
        {
            get { return _gridOffset; }
            set
            {
                if (_gridOffset != value)
                {
                    _gridOffset = value;
                    OnPropertyChanged("gridOffset");
                }
            }
        }

        private ObservableCollection<SchedulerDay> _todoList;
        public ObservableCollection<SchedulerDay> todoList
        {
            get { return _todoList; }
            set
            {
                if (_todoList != value)
                {
                    _todoList = value;
                    OnPropertyChanged("todoList");
                }
            }
        }

        private ObservableCollection<SchedulerDay> _schedulerList;
        public ObservableCollection<SchedulerDay> schedulerList
        {
            get { return _schedulerList; }
            set { if (value != null) { _schedulerList = value; OnPropertyChanged("schedulerList"); } }
        }
        
        private SchedulerDay _selectedTodo;
        public SchedulerDay selectedTodo
        {
            get { return _selectedTodo; }
            set { if (selectedTodo != value) { _selectedTodo = value; OnPropertyChanged("selectedTodo"); } }
        }

        private void InitializeCalendar(DateTime? date = null)
        {
            DateTime firstOfMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);

            todoList = new ObservableCollection<SchedulerDay>();
            
            gridOffset = (int)firstOfMonth.DayOfWeek;
            
            for (int i = 0; i < DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month); i++)
            {
                DateTime _isToday = new DateTime(DateTime.Today.Year, DateTime.Today.Month, i + 1);

                todoList.Add(new SchedulerDay()
                {
                    date = new DateTime(DateTime.Today.Year, DateTime.Today.Month, i + 1),
                    todo = todoListGenerator,
                    isToday = _isToday == DateTime.Today ? true : false
                });
            };
            
        }

        private List<ToDo> todoListGenerator
        {
            get
            {
                List<ToDo> _temp = new List<ToDo>();

                Random rnd = new Random();

                int rndInt = rnd.Next(0, 5);

                for (int i = 0; i < rndInt; i++)
                {
                    _temp.Add(new ToDo { description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In aliquam luctus magna, nec consequat mauris sodales at. Suspendisse efficitur pellentesque dui vitae volutpat. " });
                }

                return _temp;
            }
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            InitializeCalendar();
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = (System.Windows.Controls.Button)sender;
            Debug.WriteLine(button.Tag);
        }

        private void PopupBox_Closed(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Menu closed");
        }

        private void NewCall_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void SetUpCalendar()
        {
            await Task.Run(() => {
                InitializeCalendar();
            });
        }
    }
}
