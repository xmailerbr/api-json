var client = new HttpClient();
var request = new HttpRequestMessage(HttpMethod.Post, "https://api.xmailer.com.br/send/");
var content = new StringContent("{\r\n    \"host_smtp\": \"HOST-SMTP\",\r\n    \"usuario_smtp\": \"USUARIO-SMTP\", \r\n    \"senha_smtp\": \"SENHA-SMTP\", \r\n    \"emailRemetente\": \"EMAIL-REMETENTE\", \r\n    \"nomeRemetente\": \"NOME-REMETENTE\",\r\n    \"emailDestino\": [\"dev@xmailer.com.br\",\"postmaster@xmailer.com.br\"], \r\n    \"assunto\": \"Teste da API JSON com anexo\",\r\n    \"mensagemAnexos\": {\"file1\": {\"name\": \"pixel.jpg\", \"type\": \"image/jpeg\", \"content\": \"/9j/4AAQSkZJRgABAQEBLAEsAAD/2wBDAAYEBAQFBAYFBQYJBgUGCQsIBgYICwwKCgsKCgwQDAwMDAwMEAwODxAPDgwTExQUExMcGxsbHCAgICAgICAgICD/2wBDAQcHBw0MDRgQEBgaFREVGiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICD/wAARCAAUABQDAREAAhEBAxEB/8QAFQABAQAAAAAAAAAAAAAAAAAAAAb/xAAUEAEAAAAAAAAAAAAAAAAAAAAA/8QAFQEBAQAAAAAAAAAAAAAAAAAAAAf/xAAUEQEAAAAAAAAAAAAAAAAAAAAA/9oADAMBAAIRAxEAPwCNVJaAAAAAAAAH/9k=\"}, \"file2\": {\"name\": \"pixel2.jpg\", \"type\": \"image/jpeg\", \"content\": \"/9j/4AAQSkZJRgABAQEBLAEsAAD/2wBDAAYEBAQFBAYFBQYJBgUGCQsIBgYICwwKCgsKCgwQDAwMDAwMEAwODxAPDgwTExQUExMcGxsbHCAgICAgICAgICD/2wBDAQcHBw0MDRgQEBgaFREVGiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICD/wAARCAAUABQDAREAAhEBAxEB/8QAFQABAQAAAAAAAAAAAAAAAAAAAAP/xAAUEAEAAAAAAAAAAAAAAAAAAAAA/8QAFgEBAQEAAAAAAAAAAAAAAAAAAAYH/8QAFBEBAAAAAAAAAAAAAAAAAAAAAP/aAAwDAQACEQMRAD8AoytOgAAAAAAAP//Z\"}},\r\n    \"mensagem\": \"<h1>Mensagem de teste da API com anexos</h1> <p>Testando anexos de <b>html</b> no envio da api</p>\",\r\n    \"mensagemTipo\": \"html\",\r\n    \"mensagemEncoding\": \"quoted-printable\",\r\n    \"mensagemAlt\": \"mensagem de teste da API JSON com anexos\"\r\n    }", null, "application/json");
request.Content = content;
var response = await client.SendAsync(request);
response.EnsureSuccessStatusCode();
Console.WriteLine(await response.Content.ReadAsStringAsync());
