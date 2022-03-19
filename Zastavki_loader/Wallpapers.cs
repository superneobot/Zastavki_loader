using System;
using System.Drawing;

namespace Zastavki_loader
{
    [System.Serializable]
    public class Wallpapers
    {
        public string Link { get; set; }
        public string Preview { get; set; }
        public string Title { get; set; }
        public Wallpapers(string _link, string _preview, string _title)
        {
            Link = _link;
            Preview = _preview;
            Title = _title;
        }
    }

    [Serializable]
    public class Previews
    {
        public Image image { get; set; }

        public Previews(Image _image)
        {
            image = _image;
        }
    }
}
