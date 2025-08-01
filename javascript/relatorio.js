// URL do endpoint da API para gerar relatórios
var url = "https://api.xmailer.com.br/report/";

// Criação de um novo objeto XMLHttpRequest para realizar a requisição
var xhr = new XMLHttpRequest();

// Configuração do método da requisição (POST) e URL do endpoint
xhr.open("POST", url);

// Definindo os cabeçalhos da requisição
// "Content-Type" define o tipo de dados que estamos enviando (JSON)
xhr.setRequestHeader("Content-Type", "application/json"); 

// Função que será chamada sempre que o estado da requisição mudar
xhr.onreadystatechange = function () {
	// Verifica se a requisição foi concluída (readyState 4 significa "done")
	if (xhr.readyState === 4) {
		// Exibe o código de status HTTP da resposta
		console.log("Código de status:", xhr.status);
		
		// Exibe o conteúdo da resposta da API
		console.log("Resposta:", xhr.responseText);
		
		// Verifica se a requisição foi bem-sucedida (status HTTP 2xx)
		if (xhr.status >= 200 && xhr.status < 300) {
			console.log("Relatório gerado com sucesso!");
		} else {
			console.error("Erro ao gerar o relatório. Código de status:", xhr.status);
		}
	}
};

// Dados para a consulta de relatório
var data = JSON.stringify({
	"token_auth": "INFORME-O-TOKEN-AQUI",    // Substitua pelo token de autenticação fornecido
	"dataini": "2022-09-27",           // Data inicial para a consulta (formato YYYY-MM-DD)
	"horaini": "00:01",                // Hora inicial para a consulta (formato HH:MM)
	"datafim": "2022-09-27",           // Data final para a consulta (formato YYYY-MM-DD)
	"horafim": "23:59"                 // Hora final para a consulta (formato HH:MM)
});

// Envia a requisição com os dados no formato JSON
xhr.send(data);