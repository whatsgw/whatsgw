# whatsgw
Exemplos de aplicação para utilizar a API WhatsApp [WhatsGW](https://whatsgw.com.br)

1. [Cadastre-se](https://app.whatsgw.com.br/login_novo.aspx) para obter seu APIKey
2. [Instale a Extensão do Google Chrome](https://chrome.google.com/webstore/detail/whatsgw/bcddfclcghmjpkihmjdlnejflhccdjgg?hl=pt-BR)
3. Valide sua APIKey na Extensão do Google Chrome
4. Abra o [WhatsApp Web](https://web.whatsapp.com)
5. [Faça suas integrações](https://documenter.getpostman.com/view/3741041/SztBa7ku?version=latest)

##CSHARP

```csharp
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
```

##COMMAND LINE

Example1: [send.exe](https://github.com/whatsgw/whatsgw/blob/master/utilities/send/bin/Release/send.exe) "apikey=B3CA76C2-07F3-47E6-A2F8-YOWAPIKEY&phone_number=5511999999999&contact_phone_number=5511999999999&message_custom_id=mysoftwareid&message_type=text&message_body=Teste%20de%20Msg%5Cn_Italico_%20%5Cn*negrito*%5Cn~tachado~%5Cn%60%60%60Monoespa%C3%A7ado%60%60%60%5Cn%F0%9F%98%9C&check_status=1&schedule=2021%2F04%2F01%2021%3A00%3A00"

Example2: [send.exe](https://github.com/whatsgw/whatsgw/blob/master/utilities/send/bin/Release/send.exe) "" "[c:\body.txt](https://github.com/whatsgw/whatsgw/blob/master/utilities/send/bin/Release/body.txt)"
