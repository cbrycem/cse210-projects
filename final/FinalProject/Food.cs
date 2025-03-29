using System;
using System.Runtime.CompilerServices;

class Food
{
    public Food () {

    }

    protected int _stock;
    protected int _weekamount;
    protected string _name;
    protected string _brand;
    protected List<Nutrition> _nutritients = new List<Nutrition>();
    protected string _foodGroup;
    protected string _units;
    public virtual string Type() {
        return "";
    }
    public string Name {
        get {return _name;}
        set {_name = value;}
    }
    public string Brand {
        get {return _brand;}
        set {_brand = value;}
    }
    public string FoodGroup {
        get {return _foodGroup;}
        set {_foodGroup = value;}
    }
    public int Stock {
        get {return _stock;}
        set {_stock = value;}
    }
    public int WeekAmount {
        get {return _weekamount;}
        set {_weekamount = value;}
    }
    public string Units {
        get {return _units;}
        set {_units = value;}
    }
    public List<Nutrition> Nutrients 
    {
        get { return _nutritients; }
        set { _nutritients = value; }
    }
    public virtual void InfoGather() {

    }
    public void AddToSchedule() {

    }
    public void DisplayData() {

    }
    public void DisplayName() {

    }
    public virtual void AddToShopping() {

    }


}