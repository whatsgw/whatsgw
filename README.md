# whatsgw
Exemplos de aplicação para utilizar a API WhatsApp WhatsGW

C#
var parameters = new System.Collections.Specialized.NameValueCollection();
var client = new System.Net.WebClient();
var url = "https://app.whatsgw.com.br/api/WhatsGw/Send/";

parameters.Add("apikey", "6E3F58D5-8784-45F3-B436-YOWAPIKEY");<br>
parameters.Add("phone_number", "551199999999");<br>
parameters.Add("contact_phone_number", "551199999999");<br>
parameters.Add("message_custom_id", "tste");<br>
parameters.Add("message_type", "text");<br>
parameters.Add("message_body", "Hello Word WhatsGW");<br><br>

string responseString = "";<br>
byte[] response_data;<br><br>

response_data = client.UploadValues(url, "POST", parameters);<br>
responseString = UnicodeEncoding.UTF8.GetString(response_data);<br>
