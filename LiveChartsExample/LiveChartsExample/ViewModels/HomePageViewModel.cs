using LiveCharts;
using LiveCharts.Uwp;
using Prism.Commands;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;

namespace LiveChartsExample.ViewModels
{
    public class HomePageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        public HomePageViewModel(INavigationService navigetionService)
        {
            _navigationService = navigetionService;
            Series1 = new LineSeries
            {
                Title = "Series 1",
                Values = new ChartValues<double> { 4, 6, 5, 2, 4 }
            };
            Series2 = new LineSeries
            {
                Title = "Series 2",
                Values = new ChartValues<double> { 6, 7, 3, 4, 6 },
                PointGeometry = null
            };
            Series3 = new LineSeries
            {
                Title = "Series 3",
                Values = new ChartValues<double> { 4, 2, 7, 2, 7 },
                PointGeometry = DefaultGeometries.Square,
                PointGeometrySize = 15
            };

            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Series 1",
                    Values = new ChartValues<double> { 4, 6, 5, 2 ,4 }
                },
                new LineSeries
                {
                    Title = "Series 2",
                    Values = new ChartValues<double> { 6, 7, 3, 4 ,6 },
                    PointGeometry = DefaultGeometries.Triangle,
                    PointForeround = new Windows.UI.Xaml.Media.SolidColorBrush(Colors.Azure)
                },
                new LineSeries
                {
                    Title = "Series 3",
                    Values = new ChartValues<double> { 4,2,7,2,7 },
                    PointGeometry = DefaultGeometries.Square,
                    PointGeometrySize = 15
                }
            };

            Labels = new[] { "Jan", "Feb", "Mar", "Apr", "May" };
            YFormatter = value => value.ToString("C");

            GoToConstantChange = new DelegateCommand(() =>
            {
                _navigationService.Navigate("ConstantChange", null);
            });
        }
        public SeriesCollection SeriesCollection { get; set; }
        public LineSeries Series1 { get; set; }
        public LineSeries Series2 { get; set; }
        public LineSeries Series3 { get; set; }
        public string[] Labels { get; set; }
        public Func<double,string> YFormatter { get; set; }

        public DelegateCommand GoToConstantChange { get; private set; }
    }
}
