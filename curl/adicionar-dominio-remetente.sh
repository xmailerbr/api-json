
# Definição da URL do endpoint da API
URL="https://api.xmailer.com.br/domain/add/"

# Token de autenticação e domínio a ser adicionado
TOKEN_AUTH="SEU_TOKEN_AQUI"  # Substitua com seu token de autenticação
DOMINIO="dominioaseradicionado.net.br"  # Substitua com o domínio a ser adicionado

# Dados a serem enviados no corpo da requisição em formato JSON
DATA="{\"token_auth\":\"$TOKEN_AUTH\", \"dominio\":\"$DOMINIO\"}"

# Requisição cURL
curl -X POST "$URL" \  # Método POST
	-H "Content-Type: application/json" \  # Define o cabeçalho Content-Type
	-d "$DATA" \  # Dados JSON enviados no corpo da requisição
	--timeout 30 \  # Define o tempo limite da requisição (30 segundos)
	--ssl-verify  # Verifica o SSL da conexão (padrão de segurança)

# A resposta será exibida diretamente no terminal, incluindo erros se houver