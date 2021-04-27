using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Book_Finder
{
    public partial class Form1 : Form
    {
        // https://developers.google.com/books/docs/v1/getting_started#REST
        public const string myLib = "https://www.googleapis.com/books/v1/mylibrary/";
        public const string URL = "https://www.googleapis.com/books/v1/volumes/";
        public const string URLPnP = "https://www.googleapis.com/books/v1/volumes/s1gVAAAAYAAK"; // Jane Austin PNP
        // Search for quilting - https://www.googleapis.com/books/v1/volumes?q=quilting
        // Search Harry Potter https://www.googleapis.com/books/v1/volumes?q=harry+potter&callback=handleResponse
        //Use a comma-separated list to select multiple fields.


        HttpClient client = new HttpClient();

        public Form1()
        {
            InitializeComponent();
            client.BaseAddress = new Uri(URL);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            output.Text = "";
        }


        // API Button
        private void APIbutton_Click(object sender, EventArgs e)
        {
            //string searchedURL = URL + ;
            String urlParameters = input.Text;//+ "?"
            Console.WriteLine("Searched for: " + urlParameters);

            // How the JSON breaks down:
            // a lil bit of meta data; VolumeInfo - info on book; sale info - how much and site;
            // .....access info - country and viewability (PDF and EPUB); -- all ojObject parse

            HttpResponseMessage response = client.GetAsync(urlParameters).Result;


            if (response.IsSuccessStatusCode)
            {
                JObject bookJson = JObject.Parse(response.Content.ReadAsStringAsync().Result); // Parses all Json content

                BookObject book = new BookObject(); // Create the book object
                
                // Reading and storing data
                JObject volumeInfoObject = (JObject)bookJson["volumeInfo"];
                book.title = volumeInfoObject["title"].ToString();
                book.publisher = volumeInfoObject["publisher"].ToString();
                book.publishedDate = volumeInfoObject["publishedDate"].ToString();
                book.description = volumeInfoObject["description"].ToString();
                book.readingModes = new ReadingModes(System.Convert.ToBoolean(volumeInfoObject["text"]),
                                                System.Convert.ToBoolean(volumeInfoObject["image"]));
                output.Text = volumeInfoObject["pageCount"].ToString();
                book.pageCount = Convert.ToInt32(volumeInfoObject["pageCount"].ToString());

                JArray authors = (JArray)volumeInfoObject["authors"];

                foreach (var author in authors)
                {
                    book.authors.Add(author.ToString());
                }

                // Printing to screen
                StringBuilder sb = new StringBuilder();
                sb.Append("Title: " + book.title + " \r\n");
                sb.Append("Publisher: " + book.publisher + " \r\n");
                sb.Append("Published: " + book.publishedDate + " \r\n");
                sb.Append("Page Count: " + book.pageCount + " \r\n");

                sb.Append("Authors: ");
                foreach (string author in authors)
                {
                    sb.Append(author + ", ");
                }
                sb.Append(" \r\n");
                sb.Append("Descrption: " + book.description + " \r\n");
                output.Text = sb.ToString();

                infoBox.Text = "Success: " + (int)response.StatusCode + " " + response.ReasonPhrase; // Fills infobox with the book content
            }
            else
            {
                infoBox.Text = "Fail: " + (int)response.StatusCode + " " + response.ReasonPhrase;
            }

            //response.Dispose();
            //client.Dispose();
            //client.DeleteAsync(searchedURL);
        }


        [Serializable]
        public class BookObject
        {
            public BookObject()
            {
                authors = new List<string>(); // init authors
            }
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
    }
}
