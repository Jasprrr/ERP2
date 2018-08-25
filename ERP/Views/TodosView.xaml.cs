using ERP.Controllers;
using ERP.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace ERP.Views
{
    /// <summary>
    /// Interaction logic for TodoView.xaml
    /// </summary>
    public partial class TodosView : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public TodosView()
        {
            InitializeComponent();
            todoList = TodoController.GetTodos();
        }

        private ObservableCollection<Todo> _todoList { get; set; }
        public ObservableCollection<Todo> todoList
        {
            get { return _todoList; }
            set { _todoList = value;  OnPropertyChanged("todoList"); }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
