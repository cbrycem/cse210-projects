using System;

class Made_Food : Food
{
    public Made_Food () {

    }
    public Made_Food (List<string> _info) : base () {

    }
    private List<int> _amounts = new List<int>();
    private List<Food> _ingredients = new List<Food>();
    private List<string> _ingunits = new List<string>();

    public override string Type() {
        return "Made_Food";
    }
    public List<int> Amounts() {
        return _amounts;
    }
    public List<Food> Ingredients() {
        return _ingredients;
    }
    public List<string> IngUnits() {
        return _ingunits;
    }
    public void DisplayIngredients() {

    }


}