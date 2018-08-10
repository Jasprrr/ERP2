using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
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
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }

        protected void OnPropertyChanged(string propertyName)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        public LoginView()
        {
            InitializeComponent();
        }

        private void SignIn_Click(object sender, RoutedEventArgs e)
        {
            if (username != null)
            {
                Properties.Settings.Default["Username"] = username;
                Properties.Settings.Default.Save();
            }
            loginTimer = new DispatcherTimer();
            loginTimer.Tick += loginTimer_Tick;
            loginTimer.Interval = new TimeSpan(0, 0, 1);
            loginTimer.Start();
            LoginProgress.Visibility = Visibility.Visible;
        }

        private DispatcherTimer loginTimer;

        private void loginTimer_Tick(object sender, EventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(() => {
                loginTimer.Stop();
                var editwindow = new MainWindow();
                editwindow.Show();
                editwindow.Focus();
                this.Close();
            }));
        }

        private string _username;
        public string username
        {
            get { return _username; }
            set { _username = value; OnPropertyChanged("username"); }
        }
    }
}
