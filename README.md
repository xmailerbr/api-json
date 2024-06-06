API xMailer - JSON
///////////////////////////////////////////////////////////////////////


<h2>ENVIO DE EMAILS</h2>
Bem-vindo ao guia de referências da API de envio SMTP! É através desta API que você irá integrar seu sistema ao nosso para realizar os envios através de nosso SMTP dedicado.

///////////////////////////////////////////////////////////////////////


<h3>ENDPOINT PARA ENVIO</h3>

A primeira coisa que você deve saber é o endpoint que usamos: <b>https://api.xmailer.com.br/send/</b>
<ul>
  <li>
  Também é possível usar o protocolo http caso prefira.
  </li>
  <li>
  As chamadas da API devem ser feitas em POST.
  </li>
  <li>
  Máx. 10 chamadas simultâneas, por segundo.
  </li>
</ul>

///////////////////////////////////////////////////////////////////////


<h3>INFORMAÇÕES ADICIONAIS</h3>

<ul>
  <li>Todos os envios são realizados na API pela porta 587 SMTP.</li>
  <li>Os parâmetros e conteúdos passados, devem ser codificados em UTF-8.</li>
</ul>

///////////////////////////////////////////////////////////////////////


<h3>PARÂMETROS A SEREM PASSADOS</h3>

host_smtp (Endereço do servidor SMTP) - Obrigatório

usuario_smtp (Usuário para autenticação) - Obrigatório

senha_smtp (Senha para autenticação) - Obrigatório

emailRemetente (Email do remetente) - Obrigatório

nomeRemetente (Nome do remetente) - Opcional

emailReply (Email de resposta) - Opcional

emailDestino (Array com emails para onde será enviada a mensagem - max 100 contatos por chamada) - Obrigatório

nomeDestino (Nome do destinatário) - Opcional

emailDestinoCopia (Array com email para onde será copiada a mensagem - max 100 contatos por chamada) - Opcional

emailDestinoCopiaOculta (Array com email para onde será copiada a mensagem de forma oculta - max 100 contatos por chamada) - Opcional

assunto (Assunto da mensagem) - Obrigatório

mensagem (Mensagem a ser enviada) - Obrigatório, aceita texto ou HTML

mensagemAlt (Mensagem alternativa/AltBody, texto puro) - Opcional

mensagemTipo (Tipo da mensagem, se texto ou HTML) - Opcional, caso não seja definido, o tipo padrão será HTML

mensagemEncoding (Codificação da mensagem, base64 ou quoted-printable) - Opcional, caso não seja definido, a codificação padrão será base64

mensagemAnexos (Array com anexos codificados em base64) - Opcional

NO CASO DE ENVIAR UM OU MAIS ANEXOS

A API permite o envio de um ou mais arquivos anexos, usando o parâmetro opcional, mensagemAnexos para isso, em array, no seguinte modelo:

onde:

name - deve ser informado o nome do arquivo (ex: imagem.jpg) type - tipo Mime do arquivo a ser anexado (ex: image/jpeg) content - arquivo codificado em base64 / Data URI

exemplo:

{"file1": {"name": "imagem.jpg", "type": "image/jpeg", "content": "/9j/4AAQSkZJRgABAQEBLAEsAAD/2wBDAAYEBAQFBAYFBQYJBgUGCQsIBgYICwwKCgsKCgwQDAwMDAwMEAwODxAPDgwTExQUExMcGxsbHCAgICAgICAgICD/2wBDAQcHBw0MDRgQEBgaFREVGiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICD/wAARCAAUABQDAREAAhEBAxEB/8QAFQABAQAAAAAAAAAAAAAAAAAAAAb/xAAUEAEAAAAAAAAAAAAAAAAAAAAA/8QAFQEBAQAAAAAAAAAAAAAAAAAAAAf/xAAUEQEAAAAAAAAAAAAAAAAAAAAA/9oADAMBAAIRAxEAPwCNVJaAAAAAAAAH/9k="}, "file2": {"name": "pixel2.jpg", "type": "image/jpeg", "content": "/9j/4AAQSkZJRgABAQEBLAEsAAD/2wBDAAYEBAQFBAYFBQYJBgUGCQsIBgYICwwKCgsKCgwQDAwMDAwMEAwODxAPDgwTExQUExMcGxsbHCAgICAgICAgICD/2wBDAQcHBw0MDRgQEBgaFREVGiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICD/wAARCAAUABQDAREAAhEBAxEB/8QAFQABAQAAAAAAAAAAAAAAAAAAAAP/xAAUEAEAAAAAAAAAAAAAAAAAAAAA/8QAFgEBAQEAAAAAAAAAAAAAAAAAAAYH/8QAFBEBAAAAAAAAAAAAAAAAAAAAAP/aAAwDAQACEQMRAD8AoytOgAAAAAAAP//Z"}},

///////////////////////////////////////////////////////////////////////

Atenção: Os dados devem ser passados via POST, codificados em JSON. Não esqueça de passar o header Content-Type: application/json

O tamanho total da mensagem (incluindo anexos) não deve exceder 50 MB. Isso inclui a mensagem em si, os cabeçalhos e o tamanho combinado de quaisquer anexos.

///////////////////////////////////////////////////////////////////////


<h3>CÓDIGOS DE RETORNO</h3>

<ul>
  <li><p>200 MSG ENVIADA - Informa que o envio ocorreu com sucesso</p></li>
  <li><p>208 FALTAM PARAMETROS - Informa que um ou mais parâmetros obrigatórios, não foi passado ou não foram passados no formato JSON</p></li>
  <li><p>204 ERRO DE ENVIO - Ocorre quando houve erro no envio, ocasionado por falha de conexão SMTP</p></li>
  <li><p>207 ERRO: FALHA DE AUTENTICACAO - Ocorre quando forem passados dados incorretos de autenticação SMTP</p></li>
  <li><p>211 ERRO: ENCODING INVALIDO - Ocorre quando for passado o parâmetro demensagemEncoding de forma incorreta ou formato inválido</p></li>
  <li><p>212 ERRO: TIPO INVALIDO - Ocorre quando for passado o parâmetro mensagemTipo de forma incorreta ou formato inválido</p></li>
  <li><p>215 ERRO: TAMANHO EXCEDIDO - Ocorre quando o tamanho total da mensagem, incluindo anexos, exceder o limite do plano</p></li>
  <li><p>221 ERRO: LIMITE DE CONTATOS EXCEDIDO - Parâmetro emailDestino - Ocorre quando o limite de contatos no campo emailDestino, por chamada, é excedido</p></li>
  <li><p>222 ERRO: LIMITE DE CONTATOS EXCEDIDO - parametro emailDestinoCopia - Ocorre quando o limite de contatos no campo emailDestinoCopia, por chamada, é excedido</p></li>
  <li><p>223 ERRO: LIMITE DE CONTATOS EXCEDIDO - parametro emailDestinoCopiaOculta - Ocorre quando o limite de contatos no campo emailDestinoCopiaOculta, por chamada, é excedido</p></li>
  <li><p>227 ERRO: FORMATO INCORRETO - parametro emailDestino - deve ser formato array</p></li>
  <li><p>228 ERRO: FORMATO INCORRETO - parametro emailDestinoCopia - deve ser formato array</p></li>
  <li><p>229 ERRO: FORMATO INCORRETO - parametro emailDestinoCopiaOculta - deve ser formato array</p></li>
  <li><p>230 ERRO: HOST INVALIDO - parametro host_smtp so pode conter hosts da xMailer</p></li>
</ul>

///////////////////////////////////////////////////////////////////////


<h3>EXEMPLOS DE CHAMADA E RETORNO</h3>

Exemplo de chamada para envio:

{ "host_smtp": "xxxxx.xmailer.com.br", "usuario_smtp": "apitestexxxxxx@xmailer.com.br", "senha_smtp": "xxxxxxxxxxxxxxxx", "emailRemetente": "teste@xmailer.com.br", "nomeRemetente": "xmailer", "emailDestino": ["teste@xmailer.com.br","postmaster@xmailer.com.br"], "assunto": "Teste da API json produção", "mensagemAnexos": {"file1": {"name": "pixel.jpg", "type": "image/jpeg", "content": "/9j/4AAQSkZJRgABAQEBLAEsAAD/2wBDAAYEBAQFBAYFBQYJBgUGCQsIBgYICwwKCgsKCgwQDAwMDAwMEAwODxAPDgwTExQUExMcGxsbHCAgICAgICAgICD/2wBDAQcHBw0MDRgQEBgaFREVGiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICD/wAARCAAUABQDAREAAhEBAxEB/8QAFQABAQAAAAAAAAAAAAAAAAAAAAb/xAAUEAEAAAAAAAAAAAAAAAAAAAAA/8QAFQEBAQAAAAAAAAAAAAAAAAAAAAf/xAAUEQEAAAAAAAAAAAAAAAAAAAAA/9oADAMBAAIRAxEAPwCNVJaAAAAAAAAH/9k="}, "file2": {"name": "pixel2.jpg", "type": "image/jpeg", "content": "/9j/4AAQSkZJRgABAQEBLAEsAAD/2wBDAAYEBAQFBAYFBQYJBgUGCQsIBgYICwwKCgsKCgwQDAwMDAwMEAwODxAPDgwTExQUExMcGxsbHCAgICAgICAgICD/2wBDAQcHBw0MDRgQEBgaFREVGiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICD/wAARCAAUABQDAREAAhEBAxEB/8QAFQABAQAAAAAAAAAAAAAAAAAAAAP/xAAUEAEAAAAAAAAAAAAAAAAAAAAA/8QAFgEBAQEAAAAAAAAAAAAAAAAAAAYH/8QAFBEBAAAAAAAAAAAAAAAAAAAAAP/aAAwDAQACEQMRAD8AoytOgAAAAAAAP//Z"}}, "mensagem": "Mensagem de teste da API - Testando api de html de envio json", "mensagemTipo": "html", "mensagemEncoding": "base64", "mensagemAlt": "mensagem de teste da API json" }

<h4>Exemplo de retorno em JSON:</h4>
<ul>
  <li>
  Quando a mensagem for enviada com sucesso:
  </li>
</ul>

```
{
  "0":
    {
      "status": "MSG ENVIADA",
      "codigo": "200",
      "id": "1rDPyZ-0006kJ-2N",
      "criptokey": "67bb60dc8c61c2c807c53a97c781176a",
      "to": "postmaster@xmailer.com.br"
    }
}
```
<ul>
  <li>
    Quando ocorrer erro no envio, retornará o erro:
  </li>
</ul>

```
{
  "status":"ERRO DE ENVIO",
  "codigo": "204",
  "criptokey":
  "f87e7bf77c609d9537e146fb32d88418",
  "to": "seunome@seuemail.com"
}
```
<ul>
  <li>
    Caso a API retorne o erro “FALTAM PARAMETROS”, ex:
  </li>
</ul>

```
{
  "status": "ERRO: FALTAM PARAMETROS",
  "codigo":"208"
}
```

Isso quer dizer que um ou mais parâmetros não foram passados corretamente via POST e codificados em JSON.

As mensagens enviadas com sucesso são registradas automaticamente no relatório de envios, onde o painel tem atualização aprox. a cada 10 minutos.

///////////////////////////////////////////////////////////////////////



<h2>RELATÓRIO DE EMAILS</h2>

É através desta API que você irá integrar seu sistema ao nosso para obter relatórios dos envios realizados através de nosso SMTP dedicado.
///////////////////////////////////////////////////////////////////////


<h3>ENDPOINT PARA OBTER RELATÓRIO DE ENVIOS</h3>

Use para obter relatório dos envios realizados

A primeira coisa que você deve saber é o endpoint que usamos: <b>https://api.xmailer.com.br/report/</b>

Também é possível usar o protocolo http caso prefira.
As chamadas da API devem ser feitas em POST, codificados em JSON
///////////////////////////////////////////////////////////////////////


<h3>PARÂMETROS</h3>

usuario_smtp (usuário para autenticação – fornecido na abertura de conta, o mesmo utilizado para autenticação smtp) - Obrigatório

senha_smtp (senha para autenticação – a mesma senha utilizada na autenticação smtp) - Obrigatório

dataini (Data de início da consulta – formato aaaa-mm-dd) - Obrigatório

horaini (Hora de início da consulta – formato HH:MM) - Obrigatório

datafim (Data de fim da consulta – formato aaaa-mm-dd) - Obrigatório

horafim (Hora de fim da consulta – formato HH:MM) - Obrigatório

status (status dos envios a serem consultados, erro ou sucesso - ex: se passar status=sucesso o relatório somente retornará os emails entregues) - Opcional

emaildestino (email para onde a mensagem foi enviada - caso queira pesquisar emails enviados para um determinado destinatário) - Opcional

remetente (email utilizado como remetente do envio - caso queira pesquisar emails enviados por um determinado remetente) - Opcional

idMensagem (caso queira consultar/pesquisar apenas pelo id de uma mensagem enviada) - Opcional

///////////////////////////////////////////////////////////////////////

Atenção: Os dados devem ser passados via POST, codificados em JSON. Não esqueça de passar o header Content-Type: application/json

///////////////////////////////////////////////////////////////////////

<h4>Exemplo de chamada em JSON:</h4>

<ul>
  <li>
    Substitua os valores conforme os dados da sua conta e período desejado para consulta. 
  </li>
</ul>

```
{
  "usuario_smtp": "smtp1@seudominio.com.br",
  "senha_smtp": "xxxxxxxx",
  "dataini": "2023-02-01",
  "horaini": "00:01",
  "datafim": "2023-08-30",
  "horafim": "00:01"
}
```

<h4>Exemplo de retorno da API: </h4>

<ul>
  <li>
    Quando os parâmetros forem passados corretamente, a API retornará os dados dos envios, no período selecionado. Ex: 
  </li>
</ul>

```
{
"0":
  {
    "msgid": "1htNLA-0007eW-SP",
    "email_de": "nfe@seudominio.com.br",
    "email_para": "joao@gmail.com",
    "data": "01/08/2023",
    "hora": "23:30:47",
    "status": "Entregue com sucesso"
  },
  "1":
  {
    "msgid": "1htKEX-0003Ef-0G",
    "email_de": "nfe@seudominio.com.br",
    "email_para": "roberto@hotmail.com",
    "data": "01/08/2023",
    "hora": "20:11:43",
    "status": "Entregue com sucesso"
  }
}
```
///////////////////////////////////////////////////////////////////////


<h3>CÓDIGOS DE RETORNO</h3>

207 ERRO: FALHA DE AUTENTICACAO - Dados de autenticação informados incorretamente (usuario e senha da conta principal)

208 ERRO: FALTAM PARAMETROS - Informa que um ou mais parâmetros obrigatórios, não foi passado ou não foram passados no formato JSON

210 ERRO: DATA COM FORMATO INCORRETO - Data para pesquisa, informada incorretamente - use somente formato YYYY-MM-DD

211 ERRO: HORA COM FORMATO INCORRETO - Hora para pesquisa, informada incorretamente - use somente formato HH:MM

Atenção! Os relatórios de envios são atualizados aprox. a cada 10 minutos. Ao realizar um envio, caso não o veja em seguida no painel, basta aguardar a atualização.

///////////////////////////////////////////////////////////////////////

<h3>RELATÓRIO CONSOLIDADO</h3>
É através desta API que você irá integrar seu sistema ao nosso para obter o relatório consolidado dos envios realizados através de SMTP.

///////////////////////////////////////////////////////////////////////

<h2>ENDPOINT PARA OBTER RELATÓRIO DE ENVIOS</h2>

Use para obter relatório dos envios realizados

A primeira coisa que você deve saber é o endpoint que usamos: https://api.xmailer.com.br/consolidate/

Também é possível usar o protocolo http caso prefira.
As chamadas da API devem ser feitas em POST, codificados em JSON

///////////////////////////////////////////////////////////////////////


<h3>PARÂMETROS</h3>

usuario_smtp (usuário para autenticação – fornecido na abertura de conta, o mesmo utilizado para autenticação smtp) - Obrigatório

senha_smtp (senha para autenticação – a mesma senha utilizada na autenticação smtp) - Obrigatório

dataini (Data de início da consulta – formato aaaa-mm-dd) - Obrigatório

horaini (Hora de início da consulta – formato HH:MM) - Obrigatório

datafim (Data de fim da consulta – formato aaaa-mm-dd) - Obrigatório

horafim (Hora de fim da consulta – formato HH:MM) - Obrigatório

status (status dos envios a serem consultados, erro ou sucesso - ex: se passar status=sucesso o relatório somente retornará os emails entregues) - Opcional

emaildestino (email para onde a mensagem foi enviada - caso queira pesquisar emails enviados para um determinado destinatário) - Opcional

remetente (email utilizado como remetente do envio - caso queira pesquisar emails enviados por um determinado remetente) - Opcional

///////////////////////////////////////////////////////////////////////

Atenção: Os dados devem ser passados via POST, codificados em JSON. Não esqueça de passar o header Content-Type: application/json

///////////////////////////////////////////////////////////////////////

<h4>Exemplo de chamada em JSON:</h4>

<ul>
  <li>
    Substitua os valores conforme os dados da sua conta e período desejado para consulta.
  </li>
</ul>

```
{
  "usuario_smtp": "smtp1@seudominio.com.br",
  "senha_smtp": "xxxxxxxx",
  "dataini": "2023-02-01",
  "horaini": "00:01",
  "datafim": "2023-08-30",
  "horafim: "23:59"
}
```

<h4>Exemplo de retorno da API:</h4>

<ul>
  <li>
    Quando os parâmetros forem passados corretamente, a API retornará os dados dos envios, no período selecionado. Ex: 
  </li>
</ul>

```
{
  "0":
    {
      "msgid": "1htNLA-0007eW-SP",
      "email_de": "nfe@seudominio.com.br",
      "email_para": "joao@gmail.com",
      "data": "01/08/2019",
      "hora": "23:30:47",
      "status": "Entregue com sucesso"
    },
  "1":
    {
      "msgid": "1htKEX-0003Ef-0G",
      "email_de": "nfe@seudominio.com.br",
      "email_para": "roberto@hotmail.com",
      "data": "01/08/2019",
      "hora": "20:11:43",
      "status": "Entregue com sucesso"
    }
}
```
///////////////////////////////////////////////////////////////////////


<h3>CÓDIGOS DE RETORNO</h3>

207 ERRO: FALHA DE AUTENTICACAO - Dados de autenticação informados incorretamente (usuario e senha da conta principal)

208 ERRO: FALTAM PARAMETROS - Informa que um ou mais parâmetros obrigatórios, não foi passado ou não foram passados no formato JSON

210 ERRO: DATA COM FORMATO INCORRETO - Data para pesquisa, informada incorretamente - use somente formato YYYY-MM-DD

211 ERRO: HORA COM FORMATO INCORRETO - Hora para pesquisa, informada incorretamente - use somente formato HH:MM

Atenção! Os relatórios de envios são atualizados aprox. a cada 10 minutos. Ao realizar um envio, caso não o veja em seguida no painel, basta aguardar a atualização.

Atenção! Os relatórios de envios são atualizados aprox. a cada 10 minutos. Ao realizar um envio, caso não o veja em seguida no painel, basta aguardar a atualização.

///////////////////////////////////////////////////////////////////////

Em caso de dúvidas, entre em contato com nosso suporte técnico, pela URL https://www.xmailer.com.br/suporte

Link para acesso no site: https://www.xmailer.com.br/api
