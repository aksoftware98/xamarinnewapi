using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        // GET: Request 
        async Task getNews()
        {
            HttpClient client = new HttpClient();
            //lstNews.IsReffreshing = true;
            lstNews.IsRefreshing = true;
            //client.PostAsync()
            var response = await client.GetAsync("https://newsapi.org/v2/top-headlines?sources=nbc-news&apiKey=f40fac3aaa5249bab7f3dc22e46c2635");
            string jsonData = await response.Content.ReadAsStringAsync();

            Result result = JsonConvert.DeserializeObject<Result>(jsonData);

            lstNews.ItemsSource = result.articles;
            lstNews.IsRefreshing = false;

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await getNews();
        }
    }

    public class article
    {
        public string title { get; set; }

        public string description { get; set; }

        public string urlToImage { get; set; }
    }

    public class Result
    {
        public string status { get; set; }

        public int totalResults { get; set; }

        public List<article> articles { get; set; }
    }


}
