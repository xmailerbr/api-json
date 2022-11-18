var url = "https://api.xmailer.com.br/";

var xhr = new XMLHttpRequest();
xhr.open("POST", url);

xhr.setRequestHeader("Authorization", "Content-Type: application/json");
xhr.setRequestHeader("Content-Type", "application/json");

xhr.onreadystatechange = function () {
   if (xhr.readyState === 4) {
      console.log(xhr.status);
      console.log(xhr.responseText);
   }};

var data = `{"host_smtp": "HOST-SMTP","usuario_smtp": "USUARIO-SMTP", "senha_smtp": "SENHA-SMTP", "emailRemetente": "EMAIL-REMETENTE", "nomeRemetente": "NOME-REMETENTE","emailDestino": ["postmaster@xmailer.com.br","dev@xmailer.com.br"], "assunto": "Teste de envio via API JSON",
"mensagem": "mensagem de teste da API JSON"}`;

xhr.send(data);
