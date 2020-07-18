<?php

$curl = curl_init();

curl_setopt_array($curl, array(
  CURLOPT_URL => "https://app.whatsgw.com.br/api/WhatsGw/Send",
  CURLOPT_RETURNTRANSFER => true,
  CURLOPT_ENCODING => "",
  CURLOPT_MAXREDIRS => 10,
  CURLOPT_TIMEOUT => 0,
  CURLOPT_FOLLOWLOCATION => true,
  CURLOPT_HTTP_VERSION => CURL_HTTP_VERSION_1_1,
  CURLOPT_CUSTOMREQUEST => "POST",
  CURLOPT_POSTFIELDS => "apikey=B3CA76C2-07F3-47E6-A2F8-YOWAPIKEY&phone_number=5511999999999&contact_phone_number=5511988888888&message_custom_id=mysoftwareid&message_type=text&message_body=Msg%20Test",
  CURLOPT_HTTPHEADER => array(
    "Content-Type: application/x-www-form-urlencoded"
  ),
));

$response = curl_exec($curl);

curl_close($curl);
echo $response;

?>