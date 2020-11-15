import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';

void main() => runApp(MyApp());

class MyApp extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Dia Smart',
      theme: ThemeData(
          primarySwatch: Colors.purple,
          buttonColor: Colors.purple,
          buttonTheme:
              const ButtonThemeData(textTheme: ButtonTextTheme.primary)),
      home: MyHomePage(),
    );
  }
}

class MyHomePage extends StatelessWidget {
  MyHomePage({Key key}) : super(key: key);

  Widget _dialogBuilder(BuildContext context, MealItem mealItem) {
    ThemeData localTheme = Theme.of(context);

    return SimpleDialog(
      contentPadding: EdgeInsets.zero,
      children: [
        Image(
          image: AssetImage('assets/images/' + mealItem.meal + '.jpg'),
        ),
        Padding(
          padding: const EdgeInsets.all(16.0),
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.stretch,
            children: [
              Text(
                mealItem.meal,
                style: localTheme.textTheme.headline4,
              ),
              Text(
                mealItem.mealTime.toIso8601String(),
                style: localTheme.textTheme.subtitle1
                    .copyWith(fontStyle: FontStyle.italic),
              ),
              SizedBox(
                height: 16.0,
              ),
              Text(
                'Carbo : ' + mealItem.carbo.toString() + 'g',
                style: localTheme.textTheme.bodyText1,
              ),
              Text(
                'Insulin : ' + mealItem.insulin.toString() + 'u',
                style: localTheme.textTheme.bodyText1,
              ),
              Text(
                'GluLevel : ' + mealItem.gluLevel.toString() + 'mg/dL',
                style: localTheme.textTheme.bodyText1,
              ),
              SizedBox(
                height: 16.0,
              ),
              Wrap(
                alignment: WrapAlignment.end,
                children: [
                  FlatButton(
                      onPressed: () {
                        Navigator.of(context).pop();
                      },
                      child: const Text('Close')),
                  RaisedButton(
                    onPressed: () {},
                    child: const Text('Good'),
                  )
                ],
              )
            ],
          ),
        )
      ],
    );
  }

  Widget _listItemBuilder(BuildContext context, int index) {
    return new GestureDetector(
      onTap: () => showDialog(
          context: context,
          builder: (context) => _dialogBuilder(context, _meals[index])),
      child: Container(
        padding: const EdgeInsets.only(left: 16.0),
        alignment: Alignment.centerLeft,
        child: Text(_meals[index].meal,
            style: Theme.of(context).textTheme.headline5),
      ),
    );
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Meals'),
      ),
      body: ListView.builder(
        itemCount: _meals.length,
        itemExtent: 60.0,
        itemBuilder: _listItemBuilder,
      ),
    );
  }
}

class MealItem {
  final int id;
  final String meal;
  final DateTime mealTime;
  final double carbo;
  final double insulin;
  final double gluLevel;
  final double ratio;

  MealItem(
      {this.id,
      this.meal,
      this.mealTime,
      this.carbo,
      this.insulin,
      this.gluLevel,
      this.ratio});
}

final List<MealItem> _meals = <MealItem>[
  MealItem(
      id: 1,
      meal: 'breakfast',
      mealTime: DateTime.now(),
      carbo: 10,
      insulin: 1,
      gluLevel: 100,
      ratio: 0.1),
  MealItem(
      id: 2,
      meal: 'lunch',
      mealTime: DateTime.now(),
      carbo: 20,
      insulin: 2,
      gluLevel: 200,
      ratio: 0.2),
  MealItem(
      id: 3,
      meal: 'dinner',
      mealTime: DateTime.now(),
      carbo: 30,
      insulin: 3,
      gluLevel: 300,
      ratio: 0.3),
  MealItem(
      id: 4,
      meal: 'other',
      mealTime: DateTime.now(),
      carbo: 40,
      insulin: 4,
      gluLevel: 400,
      ratio: 0.4),
];
