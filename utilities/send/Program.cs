using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace send
{
    class Program
    {
        static void Main(string[] args)
        {





            try
            {

                if (args.Length < 1)
                {
                    Console.WriteLine("Usage: send.exe [bodydata] ([bodyfile])" +
                        "\n\n" +
                        "Example1: send.exe \"apikey=B3CA76C2-07F3-47E6-A2F8-YOWAPIKEY&phone_number=5511999999999&contact_phone_number=5511999999999&message_custom_id=mysoftwareid&message_type=text&message_body=Teste%20de%20Msg%5Cn_Italico_%20%5Cn*negrito*%5Cn~tachado~%5Cn%60%60%60Monoespa%C3%A7ado%60%60%60%5Cn%F0%9F%98%9C&check_status=1&schedule=2021%2F04%2F01%2021%3A00%3A00\"\n"
                    + "\nExample2: send.exe \"\" \"c:\\body.txt\"\n"
                        );
                    return;
                }

                string body = args[0];

                if (args.Length >= 2)
                    body = System.IO.File.ReadAllText(args[1]);

                var parameters = new System.Collections.Specialized.NameValueCollection();
                var client = new System.Net.WebClient();
                var url = "https://app.whatsgw.com.br/api/WhatsGw/Send/";

                foreach (var p in body.Split('&'))
                {
                    var a = p.Split('=');
                    parameters.Add(a[0], a[1]);              
                }            
    


                string responseString = "";
                byte[] response_data;

                response_data = client.UploadValues(url, "POST", parameters);
                responseString = UnicodeEncoding.UTF8.GetString(response_data);

                Console.WriteLine("\n\n");
                Console.WriteLine(responseString);

            }
            catch (Exception ex)
            {

                Console.WriteLine($"Fail: {ex.Message}");
            }


            Environment.Exit(0);

        }
    }
}
