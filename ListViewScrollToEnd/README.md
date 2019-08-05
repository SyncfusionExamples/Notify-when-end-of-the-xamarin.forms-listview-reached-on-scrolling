# Identify when end of listview is reached on scrolling

The SfListView allows notifying when scrolling using [Changed](https://help.syncfusion.com/cr/cref_files/xamarin/Syncfusion.GridCommon.Portable~Syncfusion.GridCommon.ScrollAxis.ScrollAxisBase~Changed_EV.html) event of [ScrollAxisBase](http://help.syncfusion.com/cr/cref_files/wpf/Syncfusion.SfGrid.WPF~Syncfusion.UI.Xaml.ScrollAxis.ScrollAxisBase.html) in [VisualContainer](https://help.syncfusion.com/cr/cref_files/xamarin/Syncfusion.SfListView.XForms~Syncfusion.ListView.XForms.VisualContainer.html) of the SfListView. By using this event, you can find whether reached the last item in the list in the SfListView based on [LastBodyVisibleLineIndex])(https://help.syncfusion.com/cr/cref_files/xamarin/Syncfusion.GridCommon.Portable~Syncfusion.GridCommon.ScrollAxis.ScrollAxisBase~LastBodyVisibleLineIndex.html) property and underlying collection count.

```
using Syncfusion.ListView.XForms.Control.Helpers;
public partial class MainPage : ContentPage
{
    VisualContainer visualContainer;
    bool isAlertShown = false;

    public MainPage()
    {
        InitializeComponent();
        visualContainer = listView.GetVisualContainer();
        visualContainer.ScrollRows.Changed += ScrollRows_Changed;
    }

    ///<summary>
    ///To notify when end reached
    ///</summary>
    private void ScrollRows_Changed(object sender, ScrollChangedEventArgs e)
    {
        var lastIndex = visualContainer.ScrollRows.LastBodyVisibleLineIndex;

        //To include header if used
        var header = (listView.HeaderTemplate != null && !listView.IsStickyHeader) ? 1 : 0;

        //To include footer if used
        var footer = (listView.FooterTemplate != null && !listView.IsStickyFooter) ? 1 : 0;
        var totalItems = listView.DataSource.DisplayItems.Count + header + footer;

        if ((lastIndex == totalItems - 1))
        {
            if (!isAlertShown)
            {
                DisplayAlert("Alert", "End of list reached...", "Ok");
                isAlertShown = true;
            }
        }
        else
            isAlertShown = false;
    }
}
```
To know more about scrolling, please refer our documentation [here](https://help.syncfusion.com/xamarin/sflistview/scrolling)

