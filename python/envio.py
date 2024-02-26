import requests
from requests.structures import CaseInsensitiveDict

url = "https://api.xmailer.com.br/send/"

headers = CaseInsensitiveDict()
headers["Authorization"] = "Content-Type: application/json"
headers["Content-Type"] = "application/json"

data = """
{"host_smtp": "HOST-SMTP","usuario_smtp": "USUARIO-SMTP", "senha_smtp": "SENHA-SMTP", "emailRemetente": "EMAIL-REMETENTE", "nomeRemetente": "NOME-REMETENTE","emailDestino": ["postmaster@xmailer.com.br","dev@xmailer.com.br"], "assunto": "Teste de envio via API JSON",
"mensagem": "mensagem de teste da API JSON"}
"""


resp = requests.post(url, headers=headers, data=data)

print(resp.status_code)

