using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Xml.Linq;
using System.Linq;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Xml;

namespace TheClients
{
    class Program
    {
        static void Main(string[] args)
        {
            //WebClientDemo();
            //HttpClientDemo();
            RssViaLinkToXml();
            //RssViaXmlSerializer();
            //RssViaXmlDocument();

            Console.ReadLine();
        }

        private static async void RssViaXmlDocument()
        {
            List<Item> list = new List<Item>();

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://www.nu.nl");
            HttpResponseMessage resp = await client.GetAsync("rss");
            if (resp.IsSuccessStatusCode)
            {
                Stream data = await resp.Content.ReadAsStreamAsync();
                XmlDocument doc = new XmlDocument();
                doc.Load(data);

                var nodes = doc.GetElementsByTagName("item");
                foreach (XmlElement node in nodes)
                {
                    Item it = new Item
                    {
                        Title = node["title"].InnerText,
                        Description = node["description"].InnerText,
                        Category = node["category"].InnerText
                    };
                    list.Add(it);
                }
                ShowFeed(list);
            }
        }

        private static async void RssViaXmlSerializer()
        {
            XmlSerializer ser = new XmlSerializer(typeof(Item));
            List<Item> list = new List<Item>();

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://www.nu.nl");
            HttpResponseMessage resp = await client.GetAsync("rss");
            if (resp.IsSuccessStatusCode)
            {
                Stream data = await resp.Content.ReadAsStreamAsync();
                XmlReader rdr = XmlReader.Create(data);
                while (rdr.ReadToFollowing("item"))
                {
                    Item it = ser.Deserialize(rdr.ReadSubtree()) as Item;
                    list.Add(it);
                }
            }
            ShowFeed(list);
        }

        private static async void RssViaLinkToXml()
        {
            XDocument doc = XDocument.Load("https://www.nu.nl/rss");
            var query = from it in doc.Descendants("item")
                        select new Item
                        {
                            Title = it.Element("title").Value,
                            Description = it.Element("description").Value,
                            Category = it.Element("category").Value
                        };
            ShowFeed(query.ToList());
        }

        private static void ShowFeed(List<Item> lists)
        {
            foreach (var grp in lists.GroupBy(it => it.Category))
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(grp.Key);
                Console.ResetColor();
                foreach (Item item in grp)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(item.Title);
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(item.Description);
                    Console.ResetColor();
                }
            }
        }

        private static async void HttpClientDemo()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://www.nu.nl");
            HttpResponseMessage resp = await client.GetAsync("rss");
            if (resp.IsSuccessStatusCode)
            {
                string data = await resp.Content.ReadAsStringAsync();
                Console.WriteLine(data);
            }

            //StringContent content = new StringContent("", Encoding.UTF8);
            //content.Headers.ContentType = new MediaTypeHeaderValue("text/http");
            //await client.PostAsync("rss", content);
        }

        private static void WebClientDemo()
        {
            //FtpWebRequest
            //FileWebRequest
            HttpWebRequest wr = WebRequest.Create("https://www.nu.nl/rss") as HttpWebRequest;
            wr.Credentials = CredentialCache.DefaultCredentials;
            wr.Method = "GET";
            wr.Headers.Add("Accept", "application/json,application/xml,*/*");

            HttpWebResponse resp = wr.GetResponse() as HttpWebResponse;
            if (resp.StatusCode == HttpStatusCode.OK)
            {
                Console.WriteLine(resp.Headers["Content-Type"]);
                Stream str = resp.GetResponseStream();
                StreamReader rdr = new StreamReader(str);
                string txt = rdr.ReadToEnd();
                Console.WriteLine(txt);
            }
        }
    }
}
