using System;
using System.Net;

namespace PrototypeDemo
{
    public class WebPageScraper : ICloneable
    {
        private string title;
        private int headerTagCount;
        private string firstHeaderTagContents;
        
        public WebPageScraper(string url)
        {
            var client = new WebClient();
            Scrape(client.DownloadString(url));
        }

        private void Scrape(string page)
        {
            title = "Fake title";
            headerTagCount = 3;
            firstHeaderTagContents = "Fake header text";
        }

        public void PrintPageData()
        {
            Console.WriteLine("Title: {0}, Header Count: {1}, First Header: {2}", title, headerTagCount, firstHeaderTagContents);
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
