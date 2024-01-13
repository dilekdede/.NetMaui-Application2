using System.Collections.ObjectModel;

namespace GörselÖdev2;

public partial class Gundem : ContentPage
{
    public Gundem()
    {
        InitializeComponent();
        Items = new ObservableCollection<ItemViewModel>();
        BindingContext = this;
        LoadRssFeed();

    }

    public ObservableCollection<ItemViewModel> Items { get; set; }

    private async void LoadRssFeed()
    {
        String rssUrl = "https://api.rss2json.com/v1/api.json?rss_url=https%3A%2F%2Fwww.haberturk.com%2Frss%2Fmanset.xml";

        try
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync(rssUrl);

            var root = Newtonsoft.Json.JsonConvert.DeserializeObject<Root>(response);
            foreach (var item in root.items)
            {
                Items.Add(new ItemViewModel(item));
            }

        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Eror loading RSS feed: {ex.Message}", "OK");
        }

    }

}

public class Enclosure4
{
    public string link { get; set; }
    public String type { get; set; }
}



public class Item4
{
    public String title { get; set; }
    public String pubDate { get; set; }
    public String link { get; set; }
    public String guid { get; set; }
    public String author { get; set; }
    public String thumbnail { get; set; }
    public String description { get; set; }
    public String content { get; set; }
    public Enclosure enclosure { get; set; }
    public List<Object> categories { get; set; }

}

public class Root4
{

    public string status { get; set; }
    public Feed feed { get; set; }
    public List<Item> items { get; set; }
}

public class Feed4
{

    public String url { get; set; }
    public String title { get; set; }
    public String link { get; set; }
    public String author { get; set; }
    public String description { get; set; }
    public String image { get; set; }

}


public class ItemViewModel4
{

    public String Title { get; set; }
    public String PubDate { get; set; }
    public String Link { get; set; }
    public String Author { get; set; }
    public String Thumbnail { get; set; }
    public String Description { get; set; }
    public String Content { get; set; }
    public String ImageSource { get; set; }



    public ItemViewModel4(Item item)
    {
        Title = item.title;
        PubDate = item.pubDate;
        Author = item.author;
        Thumbnail = item.thumbnail;
        Description = item.description;
        Content = item.content;

        if (item.enclosure != null && item.enclosure.type.StartsWith("image", StringComparison.OrdinalIgnoreCase))
        {
            ImageSource = item.enclosure.link;
        }

    }
}













