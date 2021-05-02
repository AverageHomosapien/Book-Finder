using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Book_Finder
{
    public partial class Form1 : Form
    {
        // https://developers.google.com/books/docs/v1/getting_started#REST
        public const string myLib = "https://www.googleapis.com/books/v1/mylibrary/";
        public const string bookURL = "https://www.googleapis.com/books/v1/volumes/";
        public const string searchURL = "https://www.googleapis.com/books/v1/volumes";
        public const string URLPnP = "https://www.googleapis.com/books/v1/volumes/s1gVAAAAYAAK"; // Jane Austin PNP
                                                                                                 // Search for quilting - https://www.googleapis.com/books/v1/volumes?q=quilting
                                                                                                 // Search Harry Potter https://www.googleapis.com/books/v1/volumes?q=harry+potter&callback=handleResponse
                                                                                                 //Use a comma-separated list to select multiple fields.

        //https://www.googleapis.com/books/v1/volumes?q=intitle:%22harry+potter%22

        // How the JSON breaks down for a single volume:
        // a lil bit of meta data; VolumeInfo - info on book; sale info - how much and site;
        // .....access info - country and viewability (PDF and EPUB); -- all ojObject parse




        HttpClient bookClient = new HttpClient();
        HttpClient searchClient = new HttpClient();

        public Form1() // Don't close Form1, just hide if switching windows
        {
            InitializeComponent();
            bookClient.BaseAddress = new Uri(bookURL);
            searchClient.BaseAddress = new Uri(searchURL);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //input.Text = "s1gVAAAAYAAK";

            infoBox.Text = "Please enter a book address or search for a book.";
            output.Text = "";
            radioVolumeID.Checked = true;
            maxResults.Value = 10;

            // Add search items and select default
            string[] searchItems = new string[] { "all", "title", "author" };
            searchComboBox.Items.AddRange(searchItems);
            searchComboBox.SelectedItem = "all";

            // Add results and select all items
            string[] resultItems = new string[] { "Title", "Volume ID", "Publisher", "Published Date", "Page Count", "Authors", "Description" };
            resultsListBox.Items.AddRange(resultItems);
            for (int i = 0; i < resultsListBox.Items.Count; i++)
            {
                resultsListBox.SetItemChecked(i, true);
            }
        }


        // API Button
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

                output.Text = "Number of records: " + bookJson["totalItems"].ToString() + "\r\n \r\n";

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

        public string ParseBook(JObject bookJson)
        {
            BookObject book = new BookObject(); // Create the book object


            JObject volumeInfoObject = (JObject)bookJson["volumeInfo"]; // Reading and storing data

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
                book.publisher = TryParse(volumeInfoObject, "publisher");
                sb.Append("Publisher: " + book.publisher + " \r\n");
            }

            if (resultBool[3])
            {
                book.publishedDate = TryParse(volumeInfoObject, "publishedDate");
                sb.Append("Published: " + book.publishedDate + " \r\n");
            }

            if (resultBool[4])
            {
                string pages = TryParse(volumeInfoObject, "pageCount");
                book.pageCount = (pages == "") ? 0 : Convert.ToInt32(pages);
                sb.Append("Page Count: " + book.pageCount + " \r\n");
            }

            if (resultBool[5])
            {
                JArray authors = (JArray)volumeInfoObject["authors"];

                if (authors != null)
                {
                    foreach (var author in authors)
                    {
                        book.authors.Add(author.ToString());
                    }
                }
                sb.Append("Authors: ");
                foreach (string author in authors)
                {
                    sb.Append(author + ", ");
                }
            }

            if (resultBool[6])
            {
                book.description = TryParse(volumeInfoObject, "description");
                sb.Append(" \r\n");
                sb.Append("Description: " + book.description + " \r\n");
            }

            /*
            book.readingModes = new ReadingModes(System.Convert.ToBoolean(volumeInfoObject["text"]),
                                        System.Convert.ToBoolean(volumeInfoObject["image"]));
            */
            return sb.ToString();
        }

        // Have a TryParse method to iteratively check if parsing available for each option
        public string TryParse(JObject bookJson, string toParse)
        {
            string parsedString;
            try
            {
                if (bookJson[toParse] != null)
                {
                    parsedString = bookJson[toParse].ToString();
                }
                else
                {
                    parsedString = "";
                }
            }
            catch
            {
                return "";
            }
            return parsedString;
        }


        [Serializable]
        public class BookObject
        {
            public BookObject()
            {
                authors = new List<string>(); // init authors
            }
            public string id { get; set; }
            public string title { get; set; }
            public List<string> authors { get; set; }
            public string publisher { get; set; }
            public string publishedDate { get; set; }
            public string description { get; set; }
            public ReadingModes readingModes { get; set; }
            public int pageCount { get; set; }
        }

        [Serializable]
        public class ReadingModes
        {
            public ReadingModes(bool text, bool image)
            {
                this.text = text;
                this.image = image;
            }
            public bool text { get; set; }
            public bool image { get; set; }
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

        private void allResultsBox_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < resultsListBox.Items.Count; i++)
            {
                resultsListBox.SetItemChecked(i, true);
            }
        }

        private void noneResultsBox_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < resultsListBox.Items.Count; i++)
            {
                resultsListBox.SetItemChecked(i, false);
            }
        }

    }
}
