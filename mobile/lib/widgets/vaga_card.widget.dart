import 'package:flutter/material.dart';

class VagaCard extends StatelessWidget {

  final Map _vagaData;

  VagaCard(this._vagaData);

  @override
  Widget build(BuildContext context) {
    return Container(
        color: Color.fromARGB(255, 52, 58, 64),
        margin: EdgeInsets.only(top: 5),
        height: 60,
        child: Row(
          mainAxisAlignment: MainAxisAlignment.spaceBetween,
          children: <Widget>[
            Expanded(
              child: Container(
                padding: EdgeInsets.only(left: 5),
                child: Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  mainAxisAlignment: MainAxisAlignment.center,
                  children: <Widget>[
                    Text(
                      _vagaData["titulo"],
                      maxLines: 2,
                      style: TextStyle(
                          color: Colors.white,
                          fontSize: 15,
                          fontWeight: FontWeight.bold),
                      textAlign: TextAlign.left,
                    ),
                  ],
                ),
              ),
            ),
            Container(
              padding: EdgeInsets.only(right: 5),
              width: 95,
              child: Text(
                _vagaData["localizacao"],
                textAlign: TextAlign.right,
                style: TextStyle(
                  color: Colors.white,
                  fontSize: 15,
                ),
              ),
            ),
          ],
        ));
  }
}
