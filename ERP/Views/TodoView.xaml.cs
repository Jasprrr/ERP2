using ERP.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace ERP.Views
{
    /// <summary>
    /// Interaction logic for TodoView.xaml
    /// </summary>
    public partial class TodoView : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public TodoView()
        {
            selectedTodo = new Todo();
            InitializeComponent();
        }

        private Todo _selectedTodo;
        public Todo selectedTodo
        {
            get { return _selectedTodo; }
            set { if(value != null) { _selectedTodo = value; OnPropertyChanged("selectedTodo"); } }
        }
    }
}
