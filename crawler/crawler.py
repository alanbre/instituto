from bs4 import BeautifulSoup as bs
from requests import get, post


class Crawler():
    def instituto_atlantico(self):
        base_url = "http://www.atlantico.com.br/vagas/"
        site = get(base_url, headers={"User-Agent": "Chrome/31.0.1650.0"})
        site.encoding = 'utf-8'
        site_page = bs(site.text, 'html.parser')
        vagas = site_page.findAll('div', {'class': 'panel panel-default'})
        for vaga in vagas:
            titulo = ""
            nova = False
            localizacao = ""
            descricao_vaga = ""
            codigo = ""
            formacao = ""
            atividades = []
            obrigatorios = []
            desejaveis = []
            contratacao = ""

            titulo = vaga.find('a').next_element.strip()
            
            nova = (vaga.find('a').find('span') != None and len(
                vaga.find('a').find('span').text) > 0)
            
            localizacao = vaga.find(
                'span', {'class', 'local-vaga d-none d-lg-block d-lg-block'}).text
            
            dados_vaga = vaga.find('div', {'class', 'panel-body'})
            
            codigo = dados_vaga.find('span').text
            
            dados = dados_vaga.findAll('h6')
            for dado in dados:
                if dado.text.lower() == "formação acadêmica:":
                    formacao = dado.find_next('p').text
                elif dado.text.lower() == "descrição da vaga:":
                    descricao_vaga = dado.find_next('p').text
                elif dado.text.lower() == "atividades a serem desenvolvidas:":
                    atividades_tag = dado.find_next('ul').findAll('li')
                    for atividade in atividades_tag:
                        atividades.append({"name": atividade.text})
                elif dado.text.lower() == "requisitos obrigatórios:":
                    obrigatorios_tag = dado.find_next('ul').findAll('li')
                    for obrigatorio in obrigatorios_tag:
                        obrigatorios.append({"name": obrigatorio.text})
                elif dado.text.lower() == "competências desejáveis:":
                    desejaveis_tag = dado.find_next('ul').findAll('li')
                    for desejavel in desejaveis_tag:
                        desejaveis.append({"name": desejavel.text})
                elif dado.text.lower() == "modalidade de contratação:":
                    contratacao = dado.find_next('p').text
            
            post('https://institutoapplication.azurewebsites.net/api/vaga', json={
                    "nova": nova,
                    "codigo": codigo,
                    "titulo": titulo,
                    "localizacao": localizacao,
                    "descricao": descricao_vaga,
                    "formacao": formacao,
                    "atividades": atividades,
                    "desejaveis": desejaveis,
                    "obrigatorios": obrigatorios,
                    "contratacao": contratacao
                })


crawler = Crawler()
crawler.instituto_atlantico()
