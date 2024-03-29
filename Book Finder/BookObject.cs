using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Finder
{
    [Serializable]
    public class BookObject
    {
        public BookObject()
        {
            authors = new List<string>(); // init authors in constructor
        }
        public string id { get; set; }
        public string title { get; set; }
        public List<string> authors { get; set; }
        public string publisher { get; set; }
        public string publishedDate { get; set; }
        public string description { get; set; }
        public int pageCount { get; set; }
        public string blurb { get; set; }

        // Availability
        public bool pdfAvailable { get; set; }
        public string pdfLink { get; set; }
        public bool epubAvailable { get; set; }
        public string epubLink { get; set; }
        public string forSale { get; set; }
        public string saleLink { get; set; }
    }
}
