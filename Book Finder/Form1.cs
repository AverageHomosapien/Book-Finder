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
        public const string URLPnP = "https://www.googleapis.com/books/v1/volumes/s1gVAAAAYAAK";
        // Search for quilting - https://www.googleapis.com/books/v1/volumes?q=quilting
        // Search Harry Potter https://www.googleapis.com/books/v1/volumes?q=harry+potter&callback=handleResponse
        //Use a comma-separated list to select multiple fields.


        HttpClient client = new HttpClient();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            output.Text = "";
        }

        private void APIbutton_click(object sender, EventArgs e)
        {
            String urlParameters = "?" + input.Text; 

            // Add an Accept header for JSON format
            client.BaseAddress = new Uri(URL);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // List data response
            HttpResponseMessage response = client.GetAsync(urlParameters).Result;

            //infoBox.Text = response.Content.ReadAsStringAsync().ToString();

            infoBox.Text = client.GetAsync(urlParameters).Result.Content.ToString();

            if (response.IsSuccessStatusCode)
            {
                // Parse the response body
                var dataObjects = response.Content.ReadAsAsync<IEnumerable<DataObject>>().Result; // Add a reference to System.Net.Http.Formatting.dll
                output.Text = "Success: ";
                foreach (var d in dataObjects)
                {
                    output.Text += d.Name + "\n";
                }
            }
            else
            {
                output.Text = "Fail: " + (int)response.StatusCode + " " + response.ReasonPhrase;
            }

            // Other HTTP Client calls here

            

            //client.Dispose(); // Once calls are complete
        }

        private void simpleAPI_Click(object sender, EventArgs e)
        {
            client.BaseAddress = new Uri(URLPnP);
            String urlParameters = "?";

            // How the JSON breaks down:
            // a lil bit of meta data; VolumeInfo - info on book; sale info - how much and site;
            // .....access info - country and viewability (PDF and EPUB); -- all ojObject parse

            HttpResponseMessage response = client.GetAsync(urlParameters).Result;
            infoBox.Text = response.Content.ReadAsStringAsync().Result; // Fills infobox with all the content
            
            JObject bookJson = JObject.Parse(response.Content.ReadAsStringAsync().Result); // Parses all Json content

            BookObject book = new BookObject(); // Create the book object

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
            Console.WriteLine("at authors");
            book.authors = new List<string>();
            foreach (var author in authors)
            {
                Console.WriteLine(author.ToString());
                book.authors.Add(author.ToString());
            }

            string body = string.Format("Title is {0} and publisher is {1} and description is {2} and page count is {3}",
                                                book.title, book.publisher, book.description, book.pageCount);
            output.Text = body;

            //string title = ojObject["title"].ToString();
            //JArray array = (JArray)ojObject["title"];

            //JObject ojObject = (JObject)joResponse["volumeInfo"];
            //JArray array = (JArray)ojObject["title"];

            //JArray array = (JObject)joResponse["volumeInfo"];
            //string title = ojObject[0].ToString();

            // output.Text = ojObject.ToString(); -- prints volume info
            //output.Text = title;

            if (response.IsSuccessStatusCode)
            {
                

                //JsonConvert.DeserializeObject< response.Content.ReadAsAsync<IEnumerable<DataObject>>() > (string json);
                //output.Text = infoBox.Text



                /*
                foreach (var d in response.Content.ReadAsAsync<IEnumerable<DataObject>>().Result)
                {
                    System.Console.WriteLine(d.Name);
                }

                /*
                var dataObjects = response.Content.ReadAsAsync<IEnumerable<DataObject>>().Result;
                output.Text = "Success: \n";

                foreach (var d in dataObjects)
                {
                    output.Text += d.Name + "\n";
                }
                */
            }
            else
            {
                output.Text = "Fail: " + (int)response.StatusCode + " " + response.ReasonPhrase;
            }
        }

        public class DataObject
        {
            public string Name { get; set; }
            public string Value { get; set; }
        }

        [Serializable]
        public class BookObject
        {
            public string title { get; set; }
            public List<string> authors { get; set; }
            public string publisher { get; set; }
            public string publishedDate { get; set; }
            public string description { get; set; }
            public ReadingModes readingModes { get; set; }
            public int pageCount { get; set; }
        }

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
