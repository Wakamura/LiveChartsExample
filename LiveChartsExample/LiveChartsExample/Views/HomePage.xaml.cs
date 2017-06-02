using LiveChartsExample.ViewModels;
using Prism.Windows.Mvvm;
using System.ComponentModel;
using Windows.UI.Xaml;
using LiveCharts;
using LiveCharts.Uwp;
using Prism.Windows.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace LiveChartsExample.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HomePage : SessionStateAwarePage, INotifyPropertyChanged
    {
        
        public HomePage()
        {
            InitializeComponent();
            DataContextChanged += HomePage_DataContextChanged;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public HomePageViewModel ConcreteDataContext
        {
            get
            {
                return DataContext as HomePageViewModel;
            }
        }

        private void HomePage_DataContextChanged(FrameworkElement sender, DataContextChangedEventArgs args)
        {
            var propertyChanged = PropertyChanged;
            if (propertyChanged != null)
            {
                propertyChanged(this, new PropertyChangedEventArgs(nameof(ConcreteDataContext)));
            }
        }
    }
}
