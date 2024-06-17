<?php

// Exibir os parâmetros enviados via GET
if (!empty($_GET)) {
    echo "GET Parameters:\n";
    print_r($_GET);
}

// Verificar e processar o corpo JSON da requisição
if ($json = json_decode(file_get_contents("php://input"), true)) {
    echo "JSON Body:\n";
    print_r($json);
    $data = $json;
} else {
    // Caso não seja um JSON, exibir os parâmetros POST
    echo "POST Parameters:\n";
    print_r($_POST);
    $data = $_POST;
}

?>