using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using HtmlAgilityPack;

namespace WordGet
{
    public partial class Form1 : Form
    {
        public string inputfile = @"Words.txt";
        public string outputfile = @"WordsInfo.txt";
        public string workdir = @"C:\\Users\\joebu\\OneDrive\\Documents\\Visual Studio 2017\\Projects\\WordGet\\TEMP\\";
        public string dictionary = @"http://www.macmillandictionary.com/dictionary/british/";
        public string imagesearch = @"https://www.pexels.com/search/";
        public string browser = "chrome.exe";
        public string theword;
        public int imgcount;
        public int imgcounttotal;


        public Form1()
        {
            InitializeComponent();
            setupdirectories();
            getdefegs();
        }


        public void setupdirectories()
        {
            //check if exist else create and TEMP
            Directory.Delete(workdir + "OUTPUT\\", true);
            Directory.CreateDirectory(workdir + "OUTPUT\\IMAGES");
            Directory.CreateDirectory(workdir + "OUTPUT\\INFO");
            Directory.CreateDirectory(workdir + "OUTPUT\\RESOURCES");
        }


        public void getdefegs()
        {
            //string theword;
            // Read the file and display it line by line.  
            System.IO.StreamReader file = new System.IO.StreamReader(workdir + "INPUT\\" + inputfile);

            while ((theword = file.ReadLine()) != null)
            {
                // load definition htmls
                theword = theword.Replace(" ", "-");
                string htmlurl = dictionary + theword;
                HtmlWeb h = new HtmlWeb();
                HtmlAgilityPack.HtmlDocument htmldoc = h.Load(htmlurl);

                HtmlNodeCollection definitions = htmldoc.DocumentNode.SelectNodes("*//span[@class=\"DEFINITION\"]");

                if (definitions != null) // if definitions have been found
                {
                    string[] str_def_egs = new string[4];
                    int tocheck = 0; // first word info checkbox true
                    foreach (HtmlNode definition in definitions)
                    {

                        str_def_egs[1] = theword;
                        string def = definition.InnerText.Trim();
                        str_def_egs[2] = def;
                        string egstext = definition.NextSibling.InnerText.Trim();
                        bool noexample = egstext.StartsWith("Synonyms");

                        if ((egstext != "") && (noexample != true))
                        {
                            str_def_egs[3] = egstext;
                        }

                        if (tocheck == 0)
                        {
                            tocheck = 1;
                            str_def_egs[0] = "Y";
                        }

                        defegslist.Rows.Add(str_def_egs);
                        str_def_egs[0] = "";

                    }
                }
                else // if no definitions have been found open Google search in Chrome tab
                {
                    MessageBox.Show("No data found for\r\n\r\n\t" + theword + "\r\n\r\nPlease look at the Chrome tab");

                    // open Chrome tab
                    Process process = new Process();
                    process.StartInfo.FileName = browser;
                    process.StartInfo.Arguments = ("\"" + htmlurl + "\"");
                    process.Start();
                }
            }
            if ((theword = file.ReadLine()) != null)
            {
                MessageBox.Show("Enter a list of words in the file - " + inputfile);
            }
        }




        // save user's selections to Google sheet
        private void button_SaveWordInfo_Click(object sender, EventArgs e)
        {
            Array.ForEach(Directory.GetFiles(workdir + "OUTPUT\\IMAGES"), File.Delete);
            Array.ForEach(Directory.GetFiles(workdir + "OUTPUT\\INFO"), File.Delete);
            Array.ForEach(Directory.GetFiles(workdir + "OUTPUT\\RESOURCES"), File.Delete);

            int checkedword = 0; //to find checked "Y" grid records
            while (checkedword < defegslist.Rows.Count - 1)
            {
                if (defegslist.Rows[checkedword].Cells[0].Value.ToString() == "Y")
                {
                    theword = defegslist.Rows[checkedword].Cells[1].Value.ToString();

                    //download image
                    getimage(theword, checkedword);

                    string lines =
                        "\r\n" + theword +
                        "\t" + defegslist.Rows[checkedword].Cells[2].Value +
                        "\t" + defegslist.Rows[checkedword].Cells[3].Value;

                    File.AppendAllText(workdir + "OUTPUT\\INFO/" + outputfile, lines);
                }
                checkedword++;

            }

            if (checkedword == 0)
            {
                MessageBox.Show("Select words to save in the grid.");
                return;
            }

            //makeresources();
            MessageBox.Show("Word infomation saved to  - \r\n\r\n" + workdir + "OUTPUT\\INFO\\" + outputfile);
        }



        public void getimage(string theword, int checkedword)
        {
            string imagesearchurl = imagesearch + theword;
            HtmlWeb g = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument imgdoc = g.Load(imagesearchurl);
            HtmlNodeCollection images = imgdoc.DocumentNode.SelectNodes("*//img[@class=\"photo-item__img\"]");

            if (images != null) // if definitions have been found    
            {

                int nodecount = 0; // only download first picture
                foreach (HtmlNode node in images)
                {
                    if (nodecount == 0)
                    {
                        string imageurl = node.Attributes["src"].Value;

                        WebRequest request = HttpWebRequest.Create(imageurl);
                        ((HttpWebRequest)request).AllowAutoRedirect = true;
                        int dataLength;
                        int bytesRead;
                        int wroteSoFar = 0;
                        var response = request.GetResponse();
                        Stream responseStream = response.GetResponseStream();

                        byte[] buffer = new byte[1024];
                        using (FileStream oFile = new FileStream(Path.Combine(workdir + "OUTPUT\\IMAGES\\", theword + checkedword + ".jpg"), FileMode.Append, FileAccess.Write))
                        {
                            dataLength = (int)response.ContentLength;
                            do
                            {
                                bytesRead = responseStream.Read(buffer, 0, buffer.Length);
                                oFile.Write(buffer, 0, bytesRead);
                                wroteSoFar += bytesRead;
                            }
                            while (bytesRead != 0);
                        }

                        File.AppendAllText(workdir + "OUTPUT\\INFO/" + outputfile, "\t" + workdir + "OUTPUT\\INFO\\" + theword + checkedword + ".jpg"); //+ nodecount
                    }
                    nodecount++;
                }
            }
        }

        //public void makeresources()
        //{
        //    string[] imagefiles = Directory.GetFiles(workdir + @"OUTPUT\\IMAGES");
        //    int slidecount = 0;
        //    imgcount = 0;
        //    imgcounttotal = imagefiles.Count() - 1;
        //    int slidearrayindex;
        //    string[] slidearray = new string[4];

        //    while (imgcount <= imgcounttotal) //foreach (string image in imagefiles)
        //    {
        //        slidearrayindex = imgcount % 4;
        //        slidearray[slidearrayindex] = imagefiles[imgcount].ToString(); // fill array of 4 images

        //        if (slidearrayindex == 3) // every 4th image
        //        {
        //            makejpg4images(slidecount, slidearray);
        //            slidearray = new string[4];
        //            slidecount++; // new slide
        //        }
        //        if (imgcount == imgcounttotal) // last remaining images
        //        {
        //            makejpg4images(slidecount, slidearray);
        //        }
        //        imgcount++;   
        //    }
        //}

        //public void makejpg4images(int slidecount, string[] slidearray)
        //{
        //    using (Bitmap FinalBitmap = new Bitmap(1368, 768))
        //    {
        //        using (Graphics FinalImage = Graphics.FromImage(FinalBitmap))
        //        {
        //            if (slidearray[0] != null)
        //            { System.Drawing.Image img0 = System.Drawing.Image.FromFile(slidearray[0]); 
        //                FinalImage.DrawImage(img0, new Rectangle(0, 0,
        //                    img0.Width * 684 / img0.Width, img0.Height * 384 / img0.Height));
        //            }
        //            if (slidearray[1] != null)
        //            {
        //                System.Drawing.Image img1 = System.Drawing.Image.FromFile(slidearray[1]);
        //                FinalImage.DrawImage(img1, new Rectangle(684, 0,
        //                    img1.Width * 684 / img1.Width, img1.Height * 384 / img1.Height));
        //            }
        //            if (slidearray[2] != null)
        //            {
        //                System.Drawing.Image img2 = System.Drawing.Image.FromFile(slidearray[2]);
        //                FinalImage.DrawImage(img2, new Rectangle(0, 384,
        //                    img2.Width * 684 / img2.Width, img2.Height * 384 / img2.Height));
        //            }
        //            if (slidearray[3] != null)
        //            {
        //                System.Drawing.Image img3 = System.Drawing.Image.FromFile(slidearray[3]);
        //                FinalImage.DrawImage(img3, new Rectangle(684, 384,
        //                img3.Width * 684 / img3.Width, img3.Height * 384 / img3.Height));
        //            }
        //            FinalBitmap.Save(workdir + @"OUTPUT\\RESOURCES\\outimage" + slidecount + ".jpg");
        //            slidearray[0] = "";
        //            slidearray[1] = "";
        //            slidearray[2] = "";
        //            slidearray[3] = "";
        //            FinalBitmap.Dispose();
        //        }
        //    }
        //}




        private void button_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void button_GetImages_Click(object sender, EventArgs e)
        {

        }

    }


    //class WordGetProg
    //{
    //    static void Main(string[] args)
    //    {
    //        Application.EnableVisualStyles();
    //        Application.SetCompatibleTextRenderingDefault(false);
    //        Application.Run(new Form1());
    //    }
    //}
}
