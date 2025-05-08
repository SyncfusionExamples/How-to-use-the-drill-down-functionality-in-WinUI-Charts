using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Syncfusion.UI.Xaml.Charts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Drill_Down_Sample
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void DataPointSelectionBehavior_SelectionChanged(object sender, Syncfusion.UI.Xaml.Charts.ChartSelectionChangedEventArgs e)
        {
            var series = sender as PieSeries;
            var items = series.ItemsSource as IList;
            int selectedIndex = e.NewIndexes[0];
            Brush brush = series.PaletteBrushes[selectedIndex];

            List<object> list = new List<object>();
            // Get selected segment data
            var selectedData = items[selectedIndex] as Model;
            list.Add(selectedData);
            list.Add(brush);
            // Navigate to the next page which is representing the chart with details.
            Frame.Navigate(typeof(NewPage), list);
        }
    }
}
