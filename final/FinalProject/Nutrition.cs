using System;
using System.Dynamic;

class Nutrition
{
    public Nutrition () {

    }
    public Nutrition(string name, double amount, string units) {
        _name = name;
        _amount = amount;
        _units = units;
    }
    public Nutrition(string name, double amount, string units, double percentage) {
        _name = name;
        _amount = amount;
        _units = units;
        _percentage = percentage;
    }
    private string _name;
    private double _amount;
    private string _units;
    private double _percentage;
    public string Name {
        get {return _name;}
        set {_name = value;}
    }
    public string Units {
        get {return _units;}
        set {_units = value;}
    }
    public double Amount {
        get {return _amount;}
        set {_amount = value;}
    }
    public double Percentage {
        get {return _percentage;}
        set {_percentage = value;}
    }
    public void DisplayInfo() {
        Console.WriteLine($"{_name} - {_amount} {_units} - Daily Percentage: {_percentage}%");
    }


}