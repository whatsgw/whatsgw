<?php

if($json = json_decode(file_get_contents("php://input"), true)) {
  print_r($json);
  $data = $json;
} else {
  
  print_r($_POST);
  $data = $_POST;
}

?>
