#!/usr/bin/python

import base64
import requests

with open("sample.jpg", "rb") as image_file:
    encoded_string = base64.b64encode(image_file.read())

url = "https://app.whatsgw.com.br/api/WhatsGw/Send"

payload='apikey=B3CA76C2-07F3-47E6-A2F8-YOWAPIKEY&phone_number=5511999999999&contact_phone_number=5511988888888&message_custom_id=mysoftwareid&message_type=image&message_body_mimetype=image/jpeg&message_body_filename=sample.jpg&message_caption=captiontest&message_body='+encoded_string
headers = {
  'Content-Type': 'application/x-www-form-urlencoded'
}

response = requests.request("POST", url, headers=headers, data=payload)

print(response.text)

