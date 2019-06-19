using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.WebRequestMethods;

namespace MusicWPF
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.Type.DataContext = SearchType.Album;
            InitializeComponent();
        }

        public enum SearchType
        {
            SongList=0,
            Singer =1,
            SongName=2,
            Album=3,
        }
            


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var type = this.Type.SelectedItem;

            var keyword = this.KeyWord.Text;

            switch (type)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
            }
                

            HttpRequestHelper httpRequestHelper = new HttpRequestHelper();

            var url = $"https://v1.itooi.cn/tencent/songList?id={keyword}&pageSize=3&page=1&format=1";

            var request = httpRequestHelper.HttpGet(url, "");
            var data = JsonConvert.DeserializeObject<Request>(request);

            this.DataList.DataContext = data.Data;
            foreach (var music in data.Data)
            {
                httpRequestHelper.Download($"{music.Url}&quality=flac", $"d:\\Music\\{music.Name}.flac");
            }
        }

        public class Request
        {
            public string Msg { get; set; }

            public string TimeStamp { get; set; }

             public string Code { get; set; }

            public List<Music> Data { get; set; }
        }

        public class Music
        {
            public string Singer { get; set; }

            public string Name { get; set; }

            public string Time { get; set; }

            public string Pic { get; set; }

            public string Lrc { get; set;}

            public string Url { get; set; }

        }

        private void DataList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
