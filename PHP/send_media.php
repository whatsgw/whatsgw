<?php


$curl = curl_init();

$data = file_get_contents('sample.jpg');
$mediaBody = base64_encode($data);

$postfields = "apikey=B3CA76C2-07F3-47E6-A2F8-YOWAPIKEY&phone_number=5511999999999&contact_phone_number=5511988888888&message_custom_id=mysoftwareid&message_type=image&message_body_mimetype=image/jpeg&message_body_filename=file.jpg&message_caption=hello caption&message_body=".$mediaBody;

$postfields=stripslashes($postfields);

curl_setopt_array($curl, array(
  CURLOPT_URL => "https://app.whatsgw.com.br/api/WhatsGw/Send",
  CURLOPT_RETURNTRANSFER => true,
  CURLOPT_ENCODING => "",
  CURLOPT_MAXREDIRS => 10,
  CURLOPT_TIMEOUT => 0,
  CURLOPT_FOLLOWLOCATION => true,
  CURLOPT_HTTP_VERSION => CURL_HTTP_VERSION_1_1,
  CURLOPT_CUSTOMREQUEST => "POST",
  CURLOPT_POSTFIELDS => $postfields,
  CURLOPT_HTTPHEADER => array(
    "Content-Type: application/x-www-form-urlencoded"
  ),
));

$response = curl_exec($curl);

curl_close($curl);
echo $response;

?>