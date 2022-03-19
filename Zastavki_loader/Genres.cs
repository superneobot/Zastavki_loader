namespace Zastavki_loader
{
    public class Genres
    {
        public string Title { get; set; }
        public string Link { get; set; }

        public Genres(string _title, string _link)
        {
            Title = _title;
            Link = _link;
        }
    }
}
