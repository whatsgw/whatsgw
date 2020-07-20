using System;
using System.IO;
using System.Text;

namespace WhatsGWExemploConsoleNetCore
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                Console.WriteLine("Select 1 for text or 2 for media and Press <ENTER> for send");
                string opt = Console.ReadLine();

                var parameters = new System.Collections.Specialized.NameValueCollection();
                var client = new System.Net.WebClient();
                var url = "https://app.whatsgw.com.br/api/WhatsGw/Send/";

                parameters.Add("apikey", "6E3F58D5-8784-45F3-B436-YOWAPIKEY"); //switch to your api key
                parameters.Add("phone_number", "551199999999"); //switch to your connected number
                parameters.Add("contact_phone_number", "551199999999"); //switch to your number text to received message


                parameters.Add("message_custom_id", "tste");

                if (opt.Equals("2"))
                {

                    parameters.Add("message_type", "document");
                    parameters.Add("message_body_mimetype", "application/pdf");
                    parameters.Add("message_body_filename", "sample.pdf");
                    parameters.Add("message_caption", "PDF Caption");
                    parameters.Add("message_body", FileToBase64("sample.pdf")); //base64



                    //parameters.Add("message_type", "image");
                    //parameters.Add("message_body_mimetype", "image/jpeg");
                    //parameters.Add("message_body_filename", "file.jpg");
                    //parameters.Add("message_caption", "Caption Text");
                    //parameters.Add("message_body", FileToBase64("sample.jpg")); //base64

                }
                else
                {
                    parameters.Add("message_type", "text");
                    parameters.Add("message_body", "Hello Word WhatsGW");
                }
                
                

                string responseString = "";
                byte[] response_data;

                response_data = client.UploadValues(url, "POST", parameters);
                responseString = UnicodeEncoding.UTF8.GetString(response_data);

                Console.WriteLine(responseString);

            }
            catch (Exception ex)
            {

                Console.WriteLine($"FAIL: {ex.Message}");
            }

            Console.ReadLine();


            Environment.Exit(0);
        }

        public static string FileToBase64(string path)
        {
            Byte[] bytes = File.ReadAllBytes(path);
            String file = Convert.ToBase64String(bytes);
            return file;

        }
    }


}
