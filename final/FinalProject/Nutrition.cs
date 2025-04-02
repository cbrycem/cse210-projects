using System;
using System.Dynamic;

class Nutrition
{
    public Nutrition () {

    }
    public Nutrition(string name, int amount, string units) {
        _name = name;
        _amount = amount;
        _units = units;
    }
    public Nutrition(string name, int amount, string units, int percentage) {
        _name = name;
        _amount = amount;
        _units = units;
        _percentage = percentage;
    }
    private string _name;
    private int _amount;
    private string _units;
    private int _percentage;
    public string Name {
        get {return _name;}
        set {_name = value;}
    }
    public string Units {
        get {return _units;}
        set {_units = value;}
    }
    public int Amount {
        get {return _amount;}
        set {_amount = value;}
    }
    public int Percentage {
        get {return _percentage;}
        set {_percentage = value;}
    }
    public void UpdateNutrients() {

    }
    public void DisplayInfo() {
        Console.WriteLine($"{_name} - {_amount} {_units} - Daily Percentage: {_percentage}%");
    }


}