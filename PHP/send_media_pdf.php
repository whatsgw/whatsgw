<?php


$curl = curl_init();

$data = file_get_contents('sample.pdf');
$mediaBody = base64_encode($data);

$postfields = "apikey=6E3F58D5-8784-45F3-B436-87DC96DCAEFC&phone_number=5511966394667&contact_phone_number=5511989366726&message_custom_id=mysoftwareid&message_type=document&message_body_mimetype=application/pdf&message_body_filename=sample.pdf&message_caption=hello caption&message_body=".$mediaBody;

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