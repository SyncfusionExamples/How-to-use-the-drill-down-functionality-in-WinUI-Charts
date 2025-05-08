# How-to-use-the-drill-down-functionality-in-WinUI-SfCircularChart

This article explains how to implement the drill-down functionality in [WinUI (SfCircularChart)](https://help.syncfusion.com/winui/circular-charts/getting-started).

The drill-down functionality allows users to navigate from one chart to another by tapping on a segment. In [WinUI (SfCircularChart)](https://help.syncfusion.com/winui/circular-charts/getting-started), this functionality can be achieved using the [SelectionChanged](https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.ChartSelectionBehavior.html#Syncfusion_UI_Xaml_Charts_ChartSelectionBehavior_SelectionChanged) event in the [SelectionBehavior](https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.ChartSeries.html#Syncfusion_UI_Xaml_Charts_ChartSeries_SelectionBehavior) property.


For example, let's say we have a pie chart that initially displays the monthly expenses of different individuals. When a user taps on a specific segment of the chart, it should generate a new chart that provides more detailed information.

To achieve this functionality, follow these steps:

## Step 1: 
Create the MainPage class in the App.cs file and implement the OnLaunched method, as shown in the code snippet below.

**[C#]**

```
          /// <summary>
         /// Invoked when the application is launched.
         /// </summary>
         /// <param name="args">Details about the launch request and process.</param>
         protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
         {
            m_window = new MainWindow();
            // Create a Frame to act as the navigation context and navigate to the first page
            Frame rootFrame = new Frame();
            rootFrame.NavigationFailed += OnNavigationFailed;
            // Navigate to the first page, configuring the new page
            // by passing required information as a navigation parameter
           rootFrame.Navigate(typeof(MainPage), args.Arguments);
           
            // Place the frame in the current Window
            m_window.Content = rootFrame;
            m_window.Activate();
        }

```

## Step 2: 
Initialize the MainPage class and set up the pie chart with the generated data. Invoke the [SelectionChanged](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Charts.ChartSelectionBehavior.html#Syncfusion_Maui_Charts_ChartSelectionBehavior_SelectionChanged) event to handle the navigation to the new page when a segment is tapped.
To navigate to the new page, use the [Frame.Navigate](https://learn.microsoft.com/en-us/windows/windows-app-sdk/api/winrt/microsoft.ui.xaml.controls.frame.navigate?view=windows-app-sdk-1.3#microsoft-ui-xaml-controls-frame-navigate(windows-ui-xaml-interop-typename-system-object-microsoft-ui-xaml-media-animation-navigationtransitioninfo)) method. You can also pass a parameter object to initialize the new page with specific state information.

**[Xaml]**
```
<Grid>
        <Grid.DataContext>
            <local:ViewModel />
        </Grid.DataContext>
        <chart:SfCircularChart  Margin="10">
…
            <chart:PieSeries ItemsSource="{Binding PieData}" 
                             XBindingPath="Type" PaletteBrushes="{StaticResource ChartCustomPalette}"
                             YBindingPath="Value"
                             ShowDataLabels="True">
                <!--To enable the selection support-->
                <chart:PieSeries.SelectionBehavior>
                    <chart:DataPointSelectionBehavior SelectionChanged="DataPointSelectionBehavior_SelectionChanged"/>
                </chart:PieSeries.SelectionBehavior>
            </chart:PieSeries>
        </chart:SfCircularChart>
    </Grid>

```
**[C#]**
```
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
            Frame.Navigate(typeof(NewPage),list);
        }

```

## Step 3:
Obtain the parameter for the new page class by overriding the **OnNavigatedTo** method. In the previous page, navigate using the **HyperlinkButton** control, as demonstrated in the code snippet below.

**[Xaml]**
```
  <Grid>
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="0.1*"/>
            <ColumnDefinition Width="2*"/>
        </Grid.ColumnDefinitions>
        <HyperlinkButton Content="Back" Grid.Column="0" VerticalAlignment="Top"
                  Margin="0,90,0,0"   Click="HyperlinkButton_Click"
                     HorizontalAlignment="Left"/>

        <Grid Grid.Column="1">
            <chart:SfCartesianChart x:Name="chart" Margin="20"
                                    HorizontalAlignment="Center" VerticalAlignment="Center">
               
                <chart:SfCartesianChart.XAxes>
                    <chart:CategoryAxis />
                </chart:SfCartesianChart.XAxes>
                <chart:SfCartesianChart.YAxes>
                    <chart:NumericalAxis PlotOffsetEnd="20"/>
                </chart:SfCartesianChart.YAxes>

                <chart:ColumnSeries x:Name="series"
                                XBindingPath="Type" ShowDataLabels="True"
                                YBindingPath="Value"
                                ItemsSource="{Binding Collections}"/>

            </chart:SfCartesianChart>
        </Grid>
    </Grid>

```

**[C#]**
```
private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
           Frame.Navigate(typeof(MainPage));
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is object)
            {
                List<object> item = (List<object>)e.Parameter;
                DataContext =  item[0];
                Model model = DataContext as Model;
                chart.Header = "Monthly Expense Of " + model.Type.ToString();
                series.Fill = (Brush)item[1];
            }

            base.OnNavigatedTo(e);
        }

## Output:
 
![Drill_Down_Output](https://github.com/SyncfusionExamples/How-to-use-the-drill-down-functionality-in-WinUI-Charts/assets/105482474/21c5a8f4-a581-49c4-869e-30cabf3822ad)

KB link -[how to use the drill down functionality in winui charts](https://www.syncfusion.com/code-examples/how-to-use-the-drill-down-functionality-in-winui-charts).
