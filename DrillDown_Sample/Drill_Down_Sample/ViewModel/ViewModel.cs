using Microsoft.UI;
using Microsoft.UI.Xaml.Media;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drill_Down_Sample
{
    public class ViewModel
    {
        public ObservableCollection<Model> PieData { get; set; }
        private ObservableCollection<Model> Data1 { get; set; }
        private ObservableCollection<Model> Data2 { get; set; }
        private ObservableCollection<Model> Data3 { get; set; }
        private ObservableCollection<Model> Data4 { get; set; }

        public List<Brush> CustomBrushes { get; set; }

        public ViewModel()
        {
            Data1 = new ObservableCollection<Model>
            {
                new Model("Home", 5000),
                new Model("Utilities", 3000),
                new Model("Transportation", 4000),
                new Model("Insurance", 2000),
                new Model("Debt Payments", 4000),
                new Model("Misc", 7000),
            };

            Data2 = new ObservableCollection<Model>
            {
                new Model("Home", 6000),
                new Model("Utilities", 8000),
                new Model("Transportation", 5000),
                new Model("Insurance", 3500),
                new Model("Debt Payments", 7500),
                new Model("Misc", 7000),
            };

            Data3 = new ObservableCollection<Model>
            {
                new Model("Home", 4000),
                new Model("Utilities", 2000),
                new Model("Transportation", 2500),
                new Model("Insurance", 2500),
                new Model("Debt Payments", 3000),
                new Model("Misc", 1000),
            };

            Data4 = new ObservableCollection<Model>
            {

                new Model("Home", 4000),
                new Model("Utilities", 4500),
                new Model("Transportation", 2000),
                new Model("Insurance", 3000),
                new Model("Debt Payments", 4500),
                new Model("Misc", 5000),
            };

            PieData = new ObservableCollection<Model>
            {
                new Model("David", 25000,Data1),
                new Model("Michael", 37000,Data2),
                new Model("Steve", 15000,Data3),
                new Model("Joel", 23000,Data4)
            };

            //CustomBrushes = new List<Brush>()
            //{
            //    new SolidColorBrush(Brush.FromArgb("#357cd2")),
            //    new SolidColorBrush(Color.FromArgb("#e56590")),
            //    new SolidColorBrush(Color.FromArgb("#f8b883")),
            //    new SolidColorBrush(Color.FromArgb("#70ad47"))
            //};

            CustomBrushes = new List<Brush>()
            {
                new SolidColorBrush(Colors.Yellow),
                new SolidColorBrush(Colors.Green),
                new SolidColorBrush(Colors.Blue),
                new SolidColorBrush (Colors.Magenta),
            };
        }
    }
}
