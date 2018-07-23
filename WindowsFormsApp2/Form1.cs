using System;
//using System.Drawing;
using System.Windows.Forms;
using System.IO;
//using iText.Kernel.Pdf;
//using iText.Layout;
//using iText.Layout.Element;
using iText.License;
using MySql.Data.MySqlClient;
using iText.IO.Font;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.IO.Image;
using Newtonsoft.Json;
using System.Collections;
using Newtonsoft.Json.Linq;

namespace WindowsFormsApp2
{


    public partial class Form1 : Form
    {
        private static readonly string DEST = $@"Atyati.pdf";
        private static readonly string FONT = $@"ARIALUNI.ttf";
        public Form1()
        {
            InitializeComponent();
        }

       
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

       

     

        private void button3_Click(object sender, EventArgs e)
        {
            LicenseKey.LoadLicenseFile("itextkey1528179689217_0.xml");
            string line1, line;
             StreamReader file = new StreamReader("test.txt");
        line1 = file.ReadLine();
            string[] words1 = line1.Split(' ');
        /* int aa = (Int32.Parse(words1[2]));
         int ab = (Int32.Parse(words1[3]));
         int ac = (Int32.Parse(words1[4]));
         int ad = (Int32.Parse(words1[5]));*/
        //Document doc = new Document(iTextSharp.text.PageSize.LETTER,aa , ab, ac, ad);
        // PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream("Test.pdf", FileMode.Create));
        //doc.Open();
        PdfDocument pdf = new PdfDocument(new PdfWriter(DEST));

        Document document = new Document(pdf);
        // PdfContentByte pcb = wri.DirectContent;
        file.Close();


            StreamReader file1 = new StreamReader("test.txt");

        int count = 0;

            while ((line = file1.ReadLine()) != null)
            {
                count = count + 1;
            }
             file1.Close();


            string[] Commands = new string[count];

            StreamReader file2 = new StreamReader("test.txt");
            for (int i = 0; i<count; i++)
            {
                Commands[i] = file2.ReadLine();
            }
                file2.Close();

            string[] words;
            int alpha = 0;


            while (alpha != count)
            {
                string temp = Commands[alpha];
                words = temp.Split();

                if (words[0].Equals("insert_image"))
                {

                    iTextSharp.text.Image png = iTextSharp.text.Image.GetInstance("yesbank.jpg");
                    png.ScalePercent(float.Parse(words[1]));
                    float a = (float.Parse(words[2]));
                    float b = (float.Parse(words[3]));
                    float c = (float.Parse(words[4]));
                    float d = (float.Parse(words[5]));
                    //png.SetAbsolutePosition(doc.PageSize.Width -a -b, doc.PageSize.Height -c -d);
                    // png.SetAbsolutePosition(doc.PageSize.Width - a - b, doc.PageSize.Height - c - d);
                    // doc.Add(png);
                    ImageData imageData = ImageDataFactory.Create("C:/Users/Ganesh.P.Nischay/source/repos/WindowsFormsApp2/WindowsFormsApp2/bin/Debug/yesbank.jpg");
                    // Create layout image object and provide parameters. Page number = 1
                    Image image = new Image(imageData).ScaleAbsolute(50, 60).SetFixedPosition(1, 530, 790);

                    document.Add(image);

                }
               /* if (words[0].Equals("insert_bank_officials_signature"))
                {

                    iTextSharp.text.Image png1 = iTextSharp.text.Image.GetInstance("signature.jpg");
                    png1.ScalePercent(float.Parse(words[1]));
                    float a = (float.Parse(words[2]));
                    float b = (float.Parse(words[3]));
                        float c = (float.Parse(words[4]));
                    float d = (float.Parse(words[5]));
                    // png1.SetAbsolutePosition(doc.PageSize.Width - a - b, doc.PageSize.Height -c -d);
                    //doc.Add(png1);

                }*/

                if (words[0].Equals("para_write"))
                {

                    //label1.Text = words[3];
                    words[0] = "\0";                                          // 0


                    string align = words[1];
                        words[1] = "\0";                                        // 1


                    words[words.Length - 1] = "\0";                         // last "
                    string type = "\0";

                        int fontsize = (Int32.Parse(words[3]));
                            words[3] = "\0";                                       // 3


                    //iTextSharp.text.Font pfont1 = FontFactory.GetFont(iTextSharp.text.Font.FontFamily.TIMES_ROMAN.ToString(), 15, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);


                    iTextSharp.text.Font pfont11;
                                string color = words[4];
                        words[4] = "\0";                                        // 4

                    words[5] = "\0";

                    // 2

                    string str;
                    str = File.ReadAllText(@"Details.json");
                    //Details result = JsonConvert.DeserializeObject<Details>(str);
                    Details result= new Details();
                    //var dictionary = JsonConvert.DeserializeObject<IDictionary>(str);
                    /*foreach(DictionaryEntry entry in dictionary)
                    {
                        Console.WriteLine(entry.Key + ": " + entry.Value);
                    }*/
                    JObject obj = JObject.Parse(str);
                    
                    for (int i = 0; i < words.Length; i++)
                    {
                        if (words[i].Equals("#amount#"))
                        {
                            string name  = (string) obj["amount"];
                            words[i] = name;

                        }
                        if (words[i].Equals("#balance#"))
                        {
                            string name = (string)obj["balance"];
                            words[i] = name;

                        }
                        if (words[i].Equals("#purpose#"))
                        {
                            string name = (string)obj["purpose"];
                            words[i] = name;

                        }
                        if (words[i].Equals("#id#"))
                        {
                            string name = (string)obj["id"];
                            words[i] = name;

                        }


                    }


                    if (words[2] == "BOLD")
                    {
                        words[2] = "\0";
                        for (int i = 0; i < words.Length; i++)
                        {
                            type = type + words[i] + " ";
                        }

                        // PdfFont font1250 = PdfFontFactory.CreateFont(FONT, PdfEncodings.IDENTITY_H);
                        // Paragraph para1 = new Paragraph(type, pfont11);
                        PdfFont font1250 = PdfFontFactory.CreateFont(FONT, PdfEncodings.IDENTITY_H);
                        Paragraph para1 = new Paragraph();
                        para1.SetFont(font1250);
                        para1.Add(type);
                        if (align.Equals("LEFT"))
                        {

                            para1.SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT);
                        }
                        if (align.Equals("CENTRE"))
                        {
                            para1.SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);

                        }
                        document.Add(para1);
                    }
                    else
                    {
                        words[2] = "\0";

                        for (int i = 0; i<words.Length; i++)
                        {
                            type = type + words[i] + " ";
                        }
                  
                        PdfFont font1250 = PdfFontFactory.CreateFont(FONT, PdfEncodings.IDENTITY_H);
                        Paragraph para = new Paragraph().SetFontSize(fontsize);
                        para.SetFont(font1250);
                        para.Add(type);
                        if (align.Equals("LEFT"))
                        {
                            para.SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT);
                        }
                        if (align.Equals("CENTRE"))
                        {
                            para.SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
                        }
                        document.Add(para);
                    }



                }
                int gamma=1;//////////////////////////////yyyyyy
               
                if (words[0].Equals("blank_line"))
                {


                    Paragraph para = new Paragraph();
                    
                    para.Add(new Text("\n"));
                    document.Add(para);
                }
                if (words[0].Equals("create_table"))
                {

                    int rows = (Int32.Parse(words[1]));
                    int col = (Int32.Parse(words[2]));

                    Table table = new Table(col);
                    PdfFont font12501 = PdfFontFactory.CreateFont(FONT, PdfEncodings.IDENTITY_H);

                    int control = rows + 1;
                    table.SetFont(font12501);

                    int u = 0;
                    if (words[3].Equals("D"))
                    {
                        for (int j1 = 1; j1 <= rows+1; j1++)
                        {
                            line = Commands[alpha + j1];
                            string[] words2 = line.Split(' ');
                            words2[0] = "";
                            words2[1] = "";
                            words2[words2.Length-1] = "";
                            string str;
                            string h = string.Join(" ", words2);

                            if (j1 == control)
                            {
                                str = File.ReadAllText(@"Details.json");

                                JObject jo = JObject.Parse(str);
                                u = 9;
                               
                                if (words2[2].Equals("#input#"))
                                {

                                    foreach (var result in jo["table"])
                                    {
                                        string slno = (string)result["sl no"];
                                        string FirstName = (string)result["FirstName"];
                                        string Last_name = (string)result["Last_name"];

                                        
                                        table.AddCell(slno);
                                        table.AddCell(FirstName);
                                        table.AddCell(Last_name);

                                    }
                                    // string name = (string)j["table"];
                                  
                                }
                            }
                            if (u != 9)
                            {
                                table.AddCell(h);
                            }
                           

                        }
                    }
                    else
                    {
                        for (int j = 1; j <= (rows * col); j++)
                        {

                            line = Commands[alpha + j];
                            string[] words2 = line.Split(' ');
                            words2[0] = "";
                            words2[1] = "";
                            words2[words2.Length - 1] = "";
                            string[] type;
                            //int y = 1;
                            string h = string.Join(" ", words2);


                            table.AddCell(h);
                        }
                    }

                    

                    //float width = (float.Parse(words[3])); 570
                    //table.PaddingTop = 100;
                    // table.LockedWidth = true;
                    //table.TotalWidth = width;

                    int H_alignment = 0;
                    if (words[4] != "0")
                    {
                        // H_alignment = (Int32.Parse(words[1]));
                        table.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);
                        //make changes to noepad
                    }
                    document.Add(table);
                }
                alpha = alpha + 1;
            }

            document.Close();


        }

        private void button4_Click(object sender, EventArgs e)
        {
            LicenseKey.LoadLicenseFile("itextkey1528179689217_0.xml");
            int count1 = 0;
            string DEST = $@"AtyatiBaby.pdf";
            using (MySqlConnection conn1 = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=hindi_1;"))
            {

                conn1.Open();
                MySqlCommand command = new MySqlCommand("SELECT COUNT(amount) FROM data", conn1);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //label1.Text = reader[0].ToString();
                        count1 = Convert.ToInt32(reader[0]);


                    }
                }

            }

            int beta = 0;
            int gamma = 0;

            for (int k = 0; k < count1; k++)
            {
                gamma = gamma + 1;
                beta = beta + 1;
                string line1, line;
                StreamReader file = new StreamReader("test.txt");
                line1 = file.ReadLine();
                string[] words1 = line1.Split(' ');
                // int aa = (Int32.Parse(words1[2]));
                // int ab = (Int32.Parse(words1[3]));
                // int ac = (Int32.Parse(words1[4]));
                //int ad = (Int32.Parse(words1[5]));


                PdfDocument pdf = new PdfDocument(new PdfWriter("AtyatiBaby"+gamma+".pdf"));

                Document document = new Document(pdf);

                StreamReader file1 = new StreamReader("test.txt");
                int count = 0;

                while ((line = file1.ReadLine()) != null)
                {
                    count = count + 1;
                }
                file1.Close();

                string[] Commands = new string[count];

                StreamReader file2 = new StreamReader("test.txt");
                for (int i = 0; i < count; i++)
                {
                    Commands[i] = file2.ReadLine();
                }
                file2.Close();

                string[] words;
                int alpha = 0;
                string temp;

                while (alpha != count)
                {
                    temp = Commands[alpha];
                    words = temp.Split();

                    if (words[0].Equals("insert_image"))
                    {

                        iTextSharp.text.Image png = iTextSharp.text.Image.GetInstance("yesbank.jpg");
                        png.ScalePercent(float.Parse(words[1]));
                        float a = (float.Parse(words[2]));
                        float b = (float.Parse(words[3]));
                        float c = (float.Parse(words[4]));
                        float d = (float.Parse(words[5]));
                        // png.SetAbsolutePosition(doc.PageSize.Width - a - b, doc.PageSize.Height - c - d);
                        //doc.Add(png);
                       
                        // Document to add layout elements: paragraphs, images etc
                       

                        // Load image from disk
                        ImageData imageData = ImageDataFactory.Create("yesbank.jpeg");
                        // Create layout image object and provide parameters. Page number = 1
                        Image image = new Image(imageData).ScaleAbsolute(100, 200).SetFixedPosition(1, 25, 25);
  
                        document.Add(image);
                        
                    }
                    /*if (words[0].Equals("insert_bank_officials_signature"))
                    {

                        iTextSharp.text.Image png1 = iTextSharp.text.Image.GetInstance("signature.jpg");
                        png1.ScalePercent(float.Parse(words[1]));
                        float a = (float.Parse(words[2]));
                        float b = (float.Parse(words[3]));
                        float c = (float.Parse(words[4]));
                        float d = (float.Parse(words[5]));
                        //png1.SetAbsolutePosition(doc.PageSize.Width - a - b, doc.PageSize.Height - c - d);
                        // doc.Add(png1);

                    }*/
                    if (words[0].Equals("para_write"))
                    {


                        //words[0] = "";
                      /*  string align = words[1];
                        words[1] = "\0";
                        words[words.Length - 1] = "\0";
                        string type = "\0";
                        int al = 2, o = 1;
                        string c = "";*/

                        //label1.Text = words[3];
                        words[0] = "\0";                                          // 0


                        string align = words[1];
                        words[1] = "\0";                                        // 1


                        words[words.Length - 1] = "\0";                         // last "
                        string type = "\0";

                        int font = (Int32.Parse(words[3]));
                        words[3] = "\0";                                       // 3


                        //iTextSharp.text.Font pfont1 = FontFactory.GetFont(iTextSharp.text.Font.FontFamily.TIMES_ROMAN.ToString(), 15, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);


                       // iTextSharp.text.Font pfont11;
                        string color = words[4];
                        words[4] = "\0";                                        // 4

                        words[5] = "\0";

                        //string path = System.Web.HttpContext.Current.Server.MapPath("C:/Users/Ganesh.P.Nischay/source/repos/WindowsFormsApp2/WindowsFormsApp2/bin/Debug/ARIALUNI.TTF");
                        //iTextSharp.text.Font fnt = new iTextSharp.text.Font();
                        //FontFactory.Register(@"C:/Users/Ganesh.P.Nischay/source/repos/WindowsFormsApp2/WindowsFormsApp2/bin/Debug/ARIALUNI.TTF", "CustomAriel");
                        // fnt = FontFactory.GetFont("CustomAriel", BaseFont.IDENTITY_H, BaseFont.EMBEDDED, 10);


                        string[] arr = { "amount", "balance", "purpose", "date" };
                        int w = 0;

                        for (int i = 0; i < words.Length; i++)
                        {
                            if (words[i].Equals("_"))
                            {
                                // Excel excel = new Excel(@"C:\Users\Ganesh.P.Nischay\source\repos\WindowsFormsApp2\WindowsFormsApp2\sample3.xlsx", 1);
                                //words[i] =  excel.ReadCell(l, o);
                                //  string abc1 = excel.ReadCell(al, o);

                                // words[i] = abc1;

                                // excel.close();
                                //  o = o + 1;


                                using (MySqlConnection conn = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=hindi_1;"))
                                {
                                    // DO REMEMBER TO OPEN THE CONNECTION!!!  
                                    conn.Open();

                                    // Connection Established  
                                    MySqlCommand command = new MySqlCommand("SELECT" + " " +"purpose" + " " + "FROM data " + "WHERE " + "id=" + " " + gamma, conn);

                                    // For better readability  
                                    // text.FontSize = 13;

                                    // End the line for the data in the database  
                                    // text.Text = "Langauge\t | \tUnicodeData" + Environment.NewLine + Environment.NewLine;
                                    using (MySqlDataReader reader = command.ExecuteReader())
                                    {
                                        while (reader.Read())
                                        {
                                            // Write the data  
                                            //label1.Text = reader[0].ToString();
                                            words[i] = reader[0].ToString();
                                            //c = reader[0].ToString(); 
                                        }
                                    }

                                }
                                w = w + 1;
                                // o = o + 1;

                            }


                        }

                        for (int i = 1; i < words.Length; i++)
                        {
                            type = type + words[i] + " ";
                        }



                        PdfFont font12501 = PdfFontFactory.CreateFont(FONT, PdfEncodings.IDENTITY_H);
                        Paragraph para = new Paragraph();
                        para.SetFont(font12501);
                        para.Add(type);
                        if (align.Equals("LEFT"))
                        {
                            para.SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT);
                        }
                        if (align.Equals("CENTRE"))
                        {
                            para.SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
                        }
                        document.Add(para);

                    }
                    if (words[0].Equals("blank_line"))
                    {


                        Paragraph para = new Paragraph();

                        para.Add(new Text("\n"));
                        document.Add(para);

                    }
                    if (words[0].Equals("create_table"))
                    {

                        int rows = (Int32.Parse(words[1]));
                        int col = (Int32.Parse(words[2]));
                        Table table = new Table(col);
                        PdfFont font12501 = PdfFontFactory.CreateFont(FONT, PdfEncodings.IDENTITY_H);

                        table.SetFont(font12501);
                        for (int j = 1; j <= (rows * col); j++)
                        {

                            line = Commands[alpha + j];
                            string[] words2 = line.Split(' ');
                            words2[0] = "";
                            words2[1] = "";
                            words2[words2.Length - 1] = "";
                            string[] type;
                            int y = 1;
                            string h = string.Join(" ", words2);

                           
                            table.AddCell(h);
                        }

                        float width = (float.Parse(words[3]));
                        //table.PaddingTop = 100;
                        // table.LockedWidth = true;
                        //table.TotalWidth = width;

                        int H_alignment = 0;
                        if (words[4] != "0")
                        {
                            //  H_alignment = (Int32.Parse(words[1]));
                            table.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);
                        }
                        document.Add(table);
                    }
                    alpha = alpha + 1;
                }

                document.Close();
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Atyati.pdf");

        }

        private void button6_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Details.json");
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("test.txt");
        }
    }
}
//para_write LEFT BOLD 15 ORANGE " ಎಸ್ .ಎಮ್.ಎಸ್ ಮುಖಾಂತರ ಪ್ರಮಾಣ कारपार्किं ग   YES Bank Ltd ಎಸ್ .ಎಮ್.ಎಸ್ ಮುಖಾಂತರ ಪ್ರಮಾಣ कारपार्किं ग is pleased ಎಸ್ .ಎಮ್.ಎಸ್ ಮುಖಾಂತರ ಪ್ರಮಾಣ कारपार्किं ग to sanction loan facility of Rs ಎಸ್ .ಎಮ್.ಎಸ್ ಮುಖಾಂತರ ಪ್ರಮಾಣ कारपार्किं ग  interest rate at reducing balance repayable _ as per the repayment schedule from the date of disbursement for the purpose of _ against the application received on _ "



