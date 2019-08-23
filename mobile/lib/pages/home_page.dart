import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'dart:convert';
import 'package:mobile/pages/vaga_page.dart';

import 'package:mobile/widgets/vaga_card.widget.dart';

const apiurl = "https://institutoapplication.azurewebsites.net/api/vaga";
// const apiurl = "http://192.168.0.150:3333/vagas";

class HomePage extends StatefulWidget {
  @override
  _HomePageState createState() => _HomePageState();
}

class _HomePageState extends State<HomePage> {
  Future<List> _getVagas() async {
    http.Response response;
    response = await http.get(apiurl);
    return json.decode(response.body);
  }

  @override
  Widget build(BuildContext context) {
    return Container(
      child: Scaffold(
        appBar: AppBar(
          backgroundColor: Colors.white,
          title: Image.asset(
            "images/logo-atlantico@2x.png",
            fit: BoxFit.cover,
          ),
          centerTitle: true,
        ),
        backgroundColor: Color.fromARGB(255, 32, 61, 147),
        body: FutureBuilder(
          future: _getVagas(),
          builder: (context, snapshot) {
            switch (snapshot.connectionState) {
              case ConnectionState.none:
              case ConnectionState.waiting:
                return Center(
                    child: Container(
                  width: 200,
                  height: 200,
                  alignment: Alignment.center,
                  child: CircularProgressIndicator(
                    valueColor: AlwaysStoppedAnimation<Color>(Colors.white),
                    strokeWidth: 5.0,
                  ),
                ));
                break;
              default:
                if (snapshot.hasError) return Container();
                return _createVagaTable(context, snapshot);
            }
          },
        ),
      ),
    );
  }

  Widget _createVagaTable(BuildContext context, AsyncSnapshot snapshot) {
    return Container(
      padding: EdgeInsets.all(5),
      child: ListView.builder(
        itemCount: snapshot.data.length,
        itemBuilder: (context, index) {
          if (index < snapshot.data.length) {
            return GestureDetector(
              child: VagaCard(snapshot.data[index]),
              onTap: () {
                Navigator.of(context).push(
                  MaterialPageRoute(
                      builder: (context) => VagaPage(snapshot.data[index])),
                );
              },
            );
          }
        },
      ),
    );
  }
}
