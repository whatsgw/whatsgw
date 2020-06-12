using System;
using System.Text;

namespace WhatsGWExemploConsoleNetCore
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                Console.WriteLine("Press <ENTER> for send");
                Console.ReadLine();

                var parameters = new System.Collections.Specialized.NameValueCollection();
                var client = new System.Net.WebClient();
                var url = "https://app.whatsgw.com.br/api/WhatsGw/Send/";

                parameters.Add("apikey", "6E3F58D5-8784-45F3-B436-YOWAPIKEY");
                parameters.Add("phone_number", "551199999999");
                parameters.Add("contact_phone_number", "551199999999");
                parameters.Add("message_custom_id", "tste");
                parameters.Add("message_type", "text");
                parameters.Add("message_body", "Hello World WhatsGW");

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
    }
}
