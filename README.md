# whatsgw
Exemplos de aplicação para utilizar a API WhatsApp [WhatsGW](https://whatsgw.com.br)

1. [Cadastre-se](https://app.whatsgw.com.br/login_novo.aspx) para obter seu APIKey
2. [Instale a Exntesão do Google Chrome](https://chrome.google.com/webstore/detail/whatsgw/bcddfclcghmjpkihmjdlnejflhccdjgg?hl=pt-BR)
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
parameters.Add("message_body", "Hello Word WhatsGW");

string responseString = "";
byte[] response_data;

response_data = client.UploadValues(url, "POST", parameters);
responseString = UnicodeEncoding.UTF8.GetString(response_data);
```
