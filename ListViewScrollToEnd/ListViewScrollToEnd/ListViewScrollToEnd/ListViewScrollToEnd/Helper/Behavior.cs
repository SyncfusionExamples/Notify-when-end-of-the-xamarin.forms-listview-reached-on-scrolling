using ListViewScrollToEnd;
using Syncfusion.GridCommon.ScrollAxis;
using Syncfusion.ListView.XForms;
using Syncfusion.ListView.XForms.Control.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace GettingStarted
{
   public class Behavior: Behavior<SfListView>
    {
        #region Fields
        SfListView ListView;
        VisualContainer visualContainer;
        bool isAlertShown = false;

        #endregion

        #region Overrides
        protected override void OnAttachedTo(SfListView bindable)
        {
            ListView = bindable;
            visualContainer = ListView.GetVisualContainer();
            visualContainer.ScrollRows.Changed += ScrollRows_Changed;
            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(SfListView bindable)
        {
            base.OnDetachingFrom(bindable);
        }

        #endregion

        #region CallBacks
        private void ScrollRows_Changed(object sender, ScrollChangedEventArgs e)
        {
            var lastIndex = visualContainer.ScrollRows.LastBodyVisibleLineIndex;
            var header = (ListView.HeaderTemplate != null && !ListView.IsStickyHeader) ? 1 : 0;
            var footer = (ListView.FooterTemplate != null && !ListView.IsStickyFooter) ? 1 : 0;
            var totalItems = ListView.DataSource.DisplayItems.Count + header + footer;
            if ((lastIndex == totalItems - 1))
            {
                if (!isAlertShown)
                {
                    App.Current.MainPage.DisplayAlert("Alert", "End of list reached...", "Ok");
                    isAlertShown = true;
                }
            }
            else
                isAlertShown = false;
        }

        #endregion
    }
}
