using MaterialDesignColors;
using MaterialDesignThemes.Wpf;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ERP.Views
{
    /// <summary>
    /// Interaction logic for SettingsView.xaml
    /// </summary>
    public partial class SettingsView : Page
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public SettingsView()
        {
            swatches = new SwatchesProvider().Swatches;
            InitializeComponent();
            //Swatch asd = new Swatch();
            //asd.AccentExemplarHue.Color
        }

        public IEnumerable<Swatch> swatches { get; }

        private Swatch _primaryColour;
        public Swatch primaryColour
        {
            get { return _primaryColour; }
            set { _primaryColour = value; OnPropertyChanged("primaryColour"); }
        }
        
        private Swatch _accentColour;
        public Swatch accentColour
        {
            get { return _accentColour; }
            set { _accentColour = value; OnPropertyChanged("accentColour"); }
        }

        private void PrimaryColour_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(primaryColour != null)
            {
                new PaletteHelper().ReplacePrimaryColor(primaryColour);
            }
        }

        private void AccentColour_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            new PaletteHelper().ReplaceAccentColor(accentColour);
        }
    }
}
