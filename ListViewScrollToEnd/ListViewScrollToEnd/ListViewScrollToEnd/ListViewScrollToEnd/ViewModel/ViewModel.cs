using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingStarted
{
    public class ViewModel
    {
        #region Fields

        private ObservableCollection<BookInfo> bookInfo;

        #endregion

        #region Constructor

        public ViewModel()
        {
            GenerateSource();

            Items = new List<string>();
            for (int i = 0; i < 10000; i++)
                Items.Add("ListViewItem " + i);
        }

        #endregion

        #region Properties

        public ObservableCollection<BookInfo> BookInfo
        {
            get { return bookInfo; }
            set { this.bookInfo = value; }
        }

        #endregion

        #region Generate Source

        private void GenerateSource()
        {
            BookInfoRepository bookinfo = new BookInfoRepository();
            bookInfo = bookinfo.GetBookInfo();
        }

        public List<string> Items { get; set; }

        #endregion
    }
}
