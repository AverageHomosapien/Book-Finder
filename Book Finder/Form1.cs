using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Book_Finder
{
    // Book form searcher
    public partial class Form1 : Form
    {
        /* Info and links:
         * Link to documentation:
         * https://developers.google.com/books/docs/v1/getting_started#REST 
         * Search Harry Potter by title:
         * https://www.googleapis.com/books/v1/volumes?q=intitle:%22harry+potter%22 
         * 
         * JSON breakdown for a single volume:
         * Bit of meta data; VolumeInfo - info on book; sale info - how much and site;
         * .....access info - country and viewability (PDF and EPUB); -- all ojObject parse
        */

        public const string myLib = "https://www.googleapis.com/books/v1/mylibrary/";
        public const string bookURL = "https://www.googleapis.com/books/v1/volumes/";
        public const string searchURL = "https://www.googleapis.com/books/v1/volumes";

        HttpClient bookClient = new HttpClient();
        HttpClient searchClient = new HttpClient();

        public Form1()
        {
            InitializeComponent();
            bookClient.BaseAddress = new Uri(bookURL);
            searchClient.BaseAddress = new Uri(searchURL);
        }

        // Set up Form
        private void Form1_Load(object sender, EventArgs e)
        {
            infoBox.Text = "Please enter a book address or search for a book.";
            output.Text = "";
            radioVolumeSearch.Checked = true;
            maxResults.Value = 10;

            // Add search items and select default
            string[] searchItems = new string[] { "all", "title", "author" };
            searchComboBox.Items.AddRange(searchItems);
            searchComboBox.SelectedItem = "all";

            // Add results and select all items
            string[] resultItems = new string[] { "Title", "Volume ID", "Blurb", "Publisher", "Published Date", "Page Count", "Authors", "Description"};
            resultsListBox.Items.AddRange(resultItems);
            for (int i = 0; i < resultsListBox.Items.Count-1; i++)
            {
                resultsListBox.SetItemChecked(i, true);
            }

            string[] availabilityItems = new string[] { "PDF Available", "PDF Link", "Epub Available", "Epub Link", "For Sale", "Sale Link"};
            availabilityListBox.Items.AddRange(availabilityItems);
            for (int i = 0; i < availabilityListBox.Items.Count; i++)
            {
                availabilityListBox.SetItemChecked(i, true);
            }
        }


        // Search API Button
        private void APIbutton_Click(object sender, EventArgs e)
        {
            output.Text = "";

            String urlParameters;
            HttpResponseMessage response;

            if (radioVolumeID.Checked)
            {
                urlParameters = input.Text;//+ "?"
            }
            else
            //else if (radioVolumeSearch.Checked)
            {
                string searchFor = searchComboBox.SelectedItem.ToString();
                Console.WriteLine("Searching for " + searchFor);

                urlParameters = "?q="; // Search param

                if (searchFor == "author")
                {
                    urlParameters += "inauthor:" + input.Text;
                }
                else if (searchFor == "title")
                {
                    //https://www.googleapis.com/books/v1/volumes?q=intitle:%22harry+potter%22
                    urlParameters += "intitle:" + input.Text;
                }
                else
                {
                    urlParameters += input.Text;
                }

                urlParameters += "&maxResults=" + maxResults.Value; // Adding max results
            }

            Console.WriteLine("User entered: " + urlParameters);
            response = bookClient.GetAsync(urlParameters).Result;

            if (response.IsSuccessStatusCode && radioVolumeID.Checked)
            {
                JObject bookJson = JObject.Parse(response.Content.ReadAsStringAsync().Result); // Parses all Json content

                output.Text = ParseBook(bookJson);
                infoBox.Text = "Success: " + (int)response.StatusCode + " " + response.ReasonPhrase; // Infobox success code
            }
            else if (response.IsSuccessStatusCode && radioVolumeSearch.Checked)
            {
                JObject bookJson = JObject.Parse(response.Content.ReadAsStringAsync().Result);

                string text = "Number of records: " + bookJson["totalItems"].ToString() + "\r\n";

                string availability = "Availability: ";


                output.Text = text + availability;

                JArray books = (JArray)bookJson["items"];

                StringBuilder sb = new StringBuilder();

                if (books != null)
                {
                    foreach (var book in books)
                    {
                        sb.Append(ParseBook((JObject)book) + "\r\n \r\n");
                    }
                    output.Text += sb.ToString();
                    infoBox.Text = "Success: " + (int)response.StatusCode + " " + response.ReasonPhrase; // Infobox success code
                }
                else
                {
                    infoBox.Text = "Fail: Search didn't provide any valid results"; // Infobox fail code
                }

            }
            else
            {
                infoBox.Text = "Fail: " + (int)response.StatusCode + " " + response.ReasonPhrase; // Infobox success code
            }
        }


        // Parses the Json for the Book Info Box
        public string ParseBook(JObject bookJson)
        {
            BookObject book = new BookObject(); // Create the book object


            JObject volumeInfoObject = (JObject)bookJson["volumeInfo"]; // Reading book info for attributes
            JObject searchInfoObject = (JObject)bookJson["searchInfo"]; // Reading search info for blurb

            StringBuilder sb = new StringBuilder(); // Printing to screen

            bool[] resultBool = new bool[resultsListBox.Items.Count];
            for (int i = 0; i <= resultsListBox.Items.Count - 1; i++)
            {
                resultBool[i] = resultsListBox.GetItemChecked(i);
            }

            if (resultBool[0])
            {
                book.title = TryParse(volumeInfoObject, "title");
                sb.Append("Title: " + book.title + " \r\n");
            }

            if (resultBool[1])
            {
                MatchCollection mc = Regex.Matches(bookJson["selfLink"].ToString(), "(?<=volumes/).*"); // Parsing ID
                foreach (Match m in mc)
                {
                    book.id += m;
                }
                sb.Append("Volume ID: " + book.id + "\r\n");
            }

            if (resultBool[2])
            {
                //Console.WriteLine("Search info object: " + searchInfoObject.ToString());
                book.blurb = TryParse(searchInfoObject, "textSnippet");
                sb.Append(" \r\n");
                sb.Append("Blurb: " + book.blurb);
            }

            if (resultBool[3])
            {
                book.publisher = TryParse(volumeInfoObject, "publisher");
                sb.Append("Publisher: " + book.publisher + " \r\n");
            }

            if (resultBool[4])
            {
                book.publishedDate = TryParse(volumeInfoObject, "publishedDate");
                sb.Append("Published: " + book.publishedDate + " \r\n");
            }

            if (resultBool[5])
            {
                string pages = TryParse(volumeInfoObject, "pageCount");
                book.pageCount = (pages == "") ? 0 : Convert.ToInt32(pages);
                sb.Append("Page Count: " + book.pageCount + " \r\n");
            }

            if (resultBool[6])
            {
                JArray authors = (JArray)volumeInfoObject["authors"];

                sb.Append("Authors: ");

                if (authors != null)
                {
                    foreach (var author in authors)
                    {
                        book.authors.Add(author.ToString());
                        sb.Append(author + ", ");
                    }

                }
                
            }

            if (resultBool[7])
            {
                book.description = TryParse(volumeInfoObject, "description");
                sb.Append(" \r\n");
                sb.Append("Description: " + book.description + " \r\n");
            }


            //// Parsing Availability
            // "PDF Available", "PDF Link", "Epub Available", "Epub Link", "For Sale", "Sale Link
            JObject countryObject = (JObject)bookJson["country"]; // Reading country
            JObject epubObject = (JObject)countryObject["epub"]; // Reading Epub
            JObject pdfObject = (JObject)countryObject["pdf"]; // Reading PDF
            JObject saleInfoObject = (JObject)bookJson["saleInfo"]; // Reading sale

            bool[] availBool = new bool[availabilityListBox.Items.Count];
            for (int i = 0; i <= availabilityListBox.Items.Count - 1; i++)
            {
                availBool[i] = availabilityListBox.GetItemChecked(i);
            }

            if (availBool[0])
            {
                book.pdfAvailable = TryParseBool(volumeInfoObject, "publishedDate");
                sb.Append("PDF Available: " + book.publisher + " \r\n");
            }
            if (availBool[1])
            {
                book.pdfLink = TryParse(volumeInfoObject, "publishedDate");
                sb.Append("PDF Link: " + book.publisher + " \r\n");
            }
            if (availBool[2])
            {
                book.epubAvailable = TryParseBool(volumeInfoObject, "publishedDate");
                sb.Append("PDF Available: " + book.publisher + " \r\n");
            }
            if (availBool[3])
            {
                book.epubLink = TryParse(volumeInfoObject, "publishedDate");
                sb.Append("PDF Link: " + book.publisher + " \r\n");
            }
            if (availBool[4])
            {
                book.forSale = TryParseBool(volumeInfoObject, "publishedDate");
                sb.Append("PDF Available: " + book.publisher + " \r\n");
            }
            if (availBool[5])
            {
                book.saleLink = TryParse(volumeInfoObject, "publishedDate");
                sb.Append("PDF Link: " + book.publisher + " \r\n");
            }


            return sb.ToString();
        }

        // Trying to parse string Json
        public string TryParse(JObject bookJson, string toParse)
        {
            if (bookJson == null)
            {
                return "";
            }
            else if (bookJson[toParse] == null)
            {
                return "";
            }
            else return bookJson[toParse].ToString();
        }

        // Trying to parse boolean Json
        public bool TryParseBool(JObject bookJson, string toParse)
        {
            if (bookJson == null)
            {
                return false;
            }
            else if (bookJson[toParse] == null)
            {
                return false;
            }
            else return (bool)bookJson[toParse];
        }


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
            public bool forSale { get; set; }
            public string saleLink { get; set; }
        }

        // Search box disabled when absolute value active
        private void radioVolumeID_CheckedChanged(object sender, EventArgs e)
        {
            searchComboBox.Enabled = false;
        }

        // Search box enabled when search active
        private void radioVolumeSearch_CheckedChanged(object sender, EventArgs e)
        {
            searchComboBox.Enabled = true;
        }

        // Selecting all book info
        private void allResultsBox_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < resultsListBox.Items.Count; i++)
            {
                resultsListBox.SetItemChecked(i, true);
            }
        }

        // Selecting no book info
        private void noneResultsBox_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < resultsListBox.Items.Count; i++)
            {
                resultsListBox.SetItemChecked(i, false);
            }
        }

        // Selecting all availability info
        private void selectAvailabilityButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < availabilityListBox.Items.Count; i++)
            {
                availabilityListBox.SetItemChecked(i, true);
            }
        }

        // Selecting no availability info
        private void deselectAvailabilityButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < availabilityListBox.Items.Count; i++)
            {
                availabilityListBox.SetItemChecked(i, false);
            }
        }
    }
}
