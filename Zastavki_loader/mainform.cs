using AngleSharp;
using AngleSharp.Io;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zastavki_loader
{
    public partial class mainform : Form
    {
        public List<Genres> groups;
        public List<Wallpapers> collection;
        public List<Previews> preview_list;
        public string pages_count;
        public string selected_genre_title;
        public string selected_genre_link;
        public string all_items_count;
        public int current_int = 1;
        public string pic_link;
        public string load_pic_link;
        public string p_link;
        public mainform()
        {
            InitializeComponent();
            groups = new List<Genres>();
            collection = new List<Wallpapers>();
            preview_list = new List<Previews>();
        }

        private async void mainform_Load(object sender, EventArgs e)
        {
            await GetGroups();
            current_page.Text = $"{current_int}";
            for (int i = 0; i < groups.Count; i++)
            {
                genres_list.Items.Add(groups[i].Title);
            }
        }

        public async Task<List<Genres>> GetGroups()
        {
            var requester = new DefaultHttpRequester("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/98.0.4758.82 Safari/537.36");
            var config = Configuration.Default.WithDefaultLoader().WithDefaultCookies().With(requester);
            var address = "https://zastavok.net/";
            var document = await BrowsingContext.New(config).OpenAsync(address);

            var block = document.QuerySelector("#navigation");
            var glist = block.QuerySelectorAll("li");
            foreach (var item in glist)
            {
                var alink = item.QuerySelector("a");
                var slink = "https://zastavok.net" + alink.GetAttribute("href");
                var atitle = alink.InnerHtml;

                groups.Add(new Genres(atitle, slink));
            }

            return groups;
        }

        public async Task<string> GetPages(string path)
        {
            var requester = new DefaultHttpRequester("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/98.0.4758.82 Safari/537.36");
            var config = Configuration.Default.WithDefaultLoader().WithDefaultCookies().With(requester);
            var document = await BrowsingContext.New(config).OpenAsync(path);

            var block = document.QuerySelector("#clsLink3");
            var glist = block.QuerySelectorAll("a");
            List<string> list1 = new List<string>();
            foreach (var item in glist)
            {
                list1.Add(item.TextContent);
            }
            list1.Remove(">>");
            var a = list1.Last();
            var s = block.TextContent;
            var ss = s.Split('>');
            all_items_count = ss[2];
            pages_count = a;
            return pages_count;
        }

        public async Task<List<Wallpapers>> GetCollection(string path)
        {
            var requester = new DefaultHttpRequester("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/98.0.4758.82 Safari/537.36");
            var config = Configuration.Default.WithDefaultLoader().WithDefaultCookies().With(requester);
            var document = await BrowsingContext.New(config).OpenAsync(path);

            var block = document.QuerySelector("body > div.full > div.main > div.block-photo");
            var wlist = block.QuerySelectorAll("img");
            var wurl = block.QuerySelectorAll("a");
            var wsize = block.QuerySelectorAll("div[class='short_bottom']");
            List<string> wlinks = new List<string>();
            List<string> wurls = new List<string>();
            List<string> wsizes = new List<string>();
            foreach (var item in wlist)
            {
                wlinks.Add("https://zastavok.net" + item.GetAttribute("src"));
            }
            foreach (var item in wurl)
            {
                wurls.Add("https://zastavok.net" + item.GetAttribute("href"));
            }
            foreach (var item in wsize)
            {
                wsizes.Add(item.TextContent.Trim());
            }
            for (int i = 0; i < wlinks.Count; i++)
            {
                collection.Add(new Wallpapers(wurls[i], wlinks[i], wsizes[i]));
            }
            // Thread.Sleep(100);
            return collection;
        }

        private async void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            collection.Clear();
            LV.Clear();
            previews.Images.Clear();
            preview_list.Clear();
            current_int = 1;
            current_page.Text = $"{current_int} / {g_count.Text}";
            if (genres_list.SelectedIndex > -1)
            {
                get_btn.Enabled = true;
                get_prev_btn.Enabled = true;
                prev_btn.Enabled = true;
                current_page.Enabled = true;
                next_btn.Enabled = true;
                int c = genres_list.SelectedIndex;
                selected_genre_title = groups[c].Title;
                selected_genre_link = groups[c].Link;

                Text = $"Zastavki loader - {selected_genre_title} [{collection.Count}]";

                await GetPages(selected_genre_link);
                g_count.Text = pages_count;
                all_items.Text = all_items_count;
                current_page.Text = $"{current_int} / {g_count.Text}";
                try
                {
                    await Collect();
                    var path = Application.StartupPath + @"\" + $@"Data\Previews\{selected_genre_title}\" + selected_genre_title + $@"_{current_int}.bin";
                    if (File.Exists(path))
                    {
                        LoadFiles(path);
                    }
                    else
                    {
                        GetPreviews();
                    }
                }
                catch (Exception ex)
                {
                    // MessageBox.Show(ex.Message);
                }
            }
        }

        private void get_btn_Click(object sender, EventArgs e)
        {
            Extract();
        }

        private async void Extract()
        {
            collection.Clear();
            Directory.CreateDirectory(Application.StartupPath + $@"/Data/Links/{selected_genre_title}/");
            var path = Application.StartupPath + @"\" + $@"Data\Links\{selected_genre_title}\" + selected_genre_title + $@"_{current_int}.json";
            int count = int.Parse(pages_count);

            await GetCollection(selected_genre_link + current_int + "/");

            Text = $"Zastavki loader - {selected_genre_title} [{collection.Count}]";

            SaveCollection(path);
        }

        private async Task Collect()
        {
            Directory.CreateDirectory(Application.StartupPath + $@"/Data/Links/{selected_genre_title}/");
            var path = Application.StartupPath + @"\" + $@"Data\Links\{selected_genre_title}\" + selected_genre_title + $@"_{current_int}.json";
            if (File.Exists(path))
            {
                collection = LoadCollection(path);
                Text = $"Zastavki loader - {selected_genre_title} [{collection.Count}]";
            }
            else
            {
                await GetCollection(selected_genre_link + current_int + "/");

                Text = $"Zastavki loader - {selected_genre_title} [{collection.Count}]";

                SaveCollection(path);
            }
        }

        public void SaveCollection(string path)
        {
            var json = JsonConvert.SerializeObject(collection, Formatting.Indented);
            File.WriteAllText(path, json);
        }

        public List<Wallpapers> LoadCollection(string path)
        {
            var file = File.ReadAllText(path);
            var target = JsonConvert.DeserializeObject<List<Wallpapers>>(file);
            return target;
        }

        public void SavePreviews(string path, List<Previews> list)
        {
            IFormatter formatter = new BinaryFormatter();

            using (var stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None, 65000))
            {
                if (stream.CanWrite)
                {
                    Invoke((Action)delegate { status.Text = "Сохраняем"; });
                    formatter.Serialize(stream, list);
                }
            }
        }

        public bool LoadPreviews(string path, out List<Previews> data)
        {
            data = null;
            if (File.Exists(path))
            {
                IFormatter formatter = new BinaryFormatter();
                using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    data = (List<Previews>)formatter.Deserialize(stream);
                }
            }
            return data != null;
        }

        private Image LoadImage(string url)
        {
            System.Net.WebRequest request =
            System.Net.WebRequest.Create(url);
            System.Net.WebResponse response = request.GetResponse();
            System.IO.Stream responseStream =
            response.GetResponseStream();
            Bitmap bmp = new Bitmap(responseStream);
            responseStream.Dispose();
            return bmp;
        }

        private void get_prev_btn_Click(object sender, EventArgs e)
        {
            GetPreviews();
        }

        private void GetPreviews()
        {
            LV.Clear();
            previews.Images.Clear();
            preview_list.Clear();

            Directory.CreateDirectory(Application.StartupPath + $@"/Data/Previews/{selected_genre_title}/");
            var path = Application.StartupPath + @"\" + $@"Data\Previews\{selected_genre_title}\" + selected_genre_title + $@"_{current_int}.bin";

            for (int i = 0; i < collection.Count; i++)
            {
                previews.Images.Add(LoadImage(collection[i].Preview));
            }
            for (int i = 0; i < previews.Images.Count; i++)
            {
                preview_list.Add(new Previews(previews.Images[i]));

                ListViewItem lvitem = new ListViewItem(collection[i].Title, i);
                LV.Items.Add(lvitem);
            }
            SavePreviews(path, preview_list);
        }

        public void LoadFiles(string file)
        {

            Task.Run(() =>
            {
                try
                {
                    List<Previews> result = null;
                    if (LoadPreviews(file, out result))
                    {
                        preview_list = result as List<Previews>;
                    }

                    for (int i = 0; i < collection.Count; i++)
                    {
                        previews.Images.Add(preview_list[i].image);
                    }
                }
                catch { }

                for (int i = 0; i < previews.Images.Count; i++)
                {
                    preview_list.Add(new Previews(previews.Images[i]));

                    ListViewItem lvitem = new ListViewItem(collection[i].Title, i);
                    Action ac = () =>
                    {
                        LV.Items.Add(lvitem);
                    };
                    Invoke(ac);
                }
            });

        }

        private async void next_btn_Click_1(object sender, EventArgs e)
        {
            collection.Clear();
            previews.Images.Clear();
            preview_list.Clear();
            LV.Clear();
            int maximum = int.Parse(g_count.Text);
            if (current_int != maximum)
            {
                current_int++;
                current_page.Text = $"{current_int} / {g_count.Text}";
                await Collect();
                var path = Application.StartupPath + @"\" + $@"Data\Previews\{selected_genre_title}\" + selected_genre_title + $@"_{current_int}.bin";
                if (File.Exists(path))
                {
                    LoadFiles(path);
                }
                else
                {
                    GetPreviews();
                }
            }
            else
            {
                //
            }
        }

        private async void prev_btn_Click_1(object sender, EventArgs e)
        {
            collection.Clear();
            previews.Images.Clear();
            preview_list.Clear();
            LV.Clear();
            if (current_int != 1)
            {
                current_int--;
                current_page.Text = $"{current_int} / {g_count.Text}";
                try
                {
                    await Collect();
                }
                catch { }
                var path = Application.StartupPath + @"\" + $@"Data\Previews\{selected_genre_title}\" + selected_genre_title + $@"_{current_int}.bin";
                if (File.Exists(path))
                {
                    LoadFiles(path);
                }
                else
                {
                    GetPreviews();
                }
            }
            else
            {
                //
            }
        }

        private async void LV_DoubleClick(object sender, EventArgs e)
        {
            if (LV.SelectedItems.Count >= 0)
            {
                var index = LV.Items.IndexOf(LV.SelectedItems[0]);
                var link = collection[index].Link;
                var size = collection[index].Title;
                var str_size = size.Split('x');
                int pic_width = int.Parse(str_size[0]);
                int pic_height = int.Parse(str_size[1]);
                pic_link = link;

                await GetPicture(link);

                Form view = new Form();                
                view.Width = pic_width / 3;
                view.Height = pic_height / 3;
                view.StartPosition = FormStartPosition.CenterScreen;
                view.Text = "Оригинальный размер: "+size;
                view.Show();
                PictureBox pb = new PictureBox();
                view.Controls.Add(pb);
                pb.SizeMode = PictureBoxSizeMode.StretchImage;
                pb.Dock = DockStyle.Fill;
                pb.LoadAsync(p_link);
            }
        }

        private async Task<string> GetPicture(string link)
        {
            var requester = new DefaultHttpRequester("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/98.0.4758.82 Safari/537.36");
            var config = Configuration.Default.WithDefaultLoader().WithDefaultCookies().With(requester);
            var document = await BrowsingContext.New(config).OpenAsync(link);

            //https://zastavok.net/download/58406/2560x1600/
            //
            var block = document.QuerySelector("#big-pic > div.image_data > div.image_data-func > div.block_down");
            var qlink = block.QuerySelector("a");
            var alink = qlink.GetAttribute("href");

            var str_link = pic_link.Split('/');
            var astr_link = str_link[4].Split('.');
            load_pic_link = astr_link[0] + ".jpg";
            p_link = "https://zastavok.net" + alink;// + load_pic_link;
            return p_link;
        }
    }
}
