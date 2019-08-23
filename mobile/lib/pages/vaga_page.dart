import 'package:flutter/material.dart';
import 'package:url_launcher/url_launcher.dart';

class VagaPage extends StatelessWidget {
  final Map _vagaData;

  VagaPage(this._vagaData);

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        appBar: AppBar(
          title: Text(_vagaData["titulo"]),
          centerTitle: true,
          backgroundColor: Color.fromARGB(255, 32, 61, 147),
        ),
        body: SingleChildScrollView(
          child: Container(
            padding: EdgeInsets.all(5.0),
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: <Widget>[
                Row(
                  children: <Widget>[
                    Text("Localização da vaga: ",
                        style: TextStyle(fontSize: 20)),
                    Text(
                      "Fortaleza - Ce",
                      style: TextStyle(fontSize: 20),
                      textAlign: TextAlign.start,
                    ),
                  ],
                ),
                Row(
                  children: <Widget>[
                    Text("Código da vaga: ",
                        style: TextStyle(
                            fontWeight: FontWeight.bold, fontSize: 20)),
                    Text(
                      _vagaData["codigo"],
                      style: TextStyle(
                          fontSize: 20, color: Color.fromARGB(255, 255, 77, 0)),
                      textAlign: TextAlign.start,
                    ),
                  ],
                ),
                SizedBox(
                  height: 10,
                ),
                descricao(),
                Text("Formação acadêmica:",
                    style:
                        TextStyle(fontWeight: FontWeight.bold, fontSize: 20)),
                Text(
                  _vagaData["formacao"],
                  style: TextStyle(fontSize: 15),
                  textAlign: TextAlign.start,
                ),
                SizedBox(
                  height: 10,
                ),
                Text("Atividades a serem desenvolvidas:",
                    style:
                        TextStyle(fontWeight: FontWeight.bold, fontSize: 20)),
                Column(
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: _vagaData["atividades"]
                        .map<Widget>((atividade) => Text(
                              "* " + atividade["name"],
                              style: TextStyle(fontSize: 15),
                            ))
                        .toList()),
                SizedBox(
                  height: 10,
                ),
                Text("Requisitos obrigatórios:",
                    style:
                        TextStyle(fontWeight: FontWeight.bold, fontSize: 20)),
                Column(
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: _vagaData["obrigatorios"]
                        .map<Widget>((obrigatorio) => Text(
                            "* " + obrigatorio["name"],
                            style: TextStyle(fontSize: 15)))
                        .toList()),
                SizedBox(
                  height: 10,
                ),
                Text("Competências Desejáveis:",
                    style:
                        TextStyle(fontWeight: FontWeight.bold, fontSize: 20)),
                Column(
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: _vagaData["desejaveis"]
                        .map<Widget>((desejavel) => Text(
                            "* " + desejavel["name"],
                            style: TextStyle(fontSize: 15)))
                        .toList()),
                SizedBox(
                  height: 10,
                ),
                Text("Modalidade de contratação: ",
                    style:
                        TextStyle(fontSize: 20, fontWeight: FontWeight.bold)),
                Text(_vagaData["contratacao"], style: TextStyle(fontSize: 20)),
              ],
            ),
          ),
        ),
        bottomNavigationBar: BottomAppBar(
          color: Color.fromARGB(255, 32, 61, 147),
          child: GestureDetector(
            child: Container(
              height: 50,
              child: Text(
                "Candidatar-se",
                style: TextStyle(color: Colors.white, fontSize: 20),
              ),
              alignment: Alignment.center,
            ),
            onTap: email,
          ),
        ));
  }

  Widget descricao() {
    return _vagaData["descricao"].length > 0
        ? Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: <Widget>[
              Text("Descrição da Vaga:",
                  style: TextStyle(fontWeight: FontWeight.bold, fontSize: 20)),
              Text(
                _vagaData["descricao"],
                style: TextStyle(fontSize: 15),
                textAlign: TextAlign.start,
              ),
              SizedBox(
                height: 10,
              ),
            ],
          )
        : Container();
  }

  void email() async {
    String url = "mailto:rh@atlantico.com.br?subject=" + _vagaData["codigo"].replaceAll(RegExp(r'#'), '%23');
    if (await canLaunch(url)) {
      await launch(url);
    } else {
      throw 'Could not launch $url';
    }
  }
}
