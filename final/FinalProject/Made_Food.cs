using System;

class Made_Food : Food
{
    public Made_Food () {

    }
    public Made_Food (List<string> _info) : base () {

    }
    private List<double> _amounts = new List<double>();
    private List<Food> _ingredients = new List<Food>();
    private List<string> _ingunits = new List<string>();

    public override string Type() {
        return "Made_Food";
    }
    public List<double> Amounts() {
        return _amounts;
    }
    public List<Food> Ingredients() {
        return _ingredients;
    }
    public List<string> IngUnits() {
        return _ingunits;
    }
    public void AddIngredient(Food ingredient, double amount, string unit)
    {
        _ingredients.Add(ingredient);
        _amounts.Add(amount);
        _ingunits.Add(unit);
    }
    public void DisplayIngredients() {

        for (int i = 0; i < _ingredients.Count; i++) {
            
            Food ingredient = _ingredients[i];
            double amount = _amounts[i];
            string unit = _ingunits[i];

            Console.WriteLine($"Ingredient: {ingredient.Name}, Amount: {amount} {unit}");
        }
    }
    public void NutrientUpdate() {

        Dictionary<string, Nutrition> nutrientMap = new Dictionary<string, Nutrition>();

        for (int i = 0; i < _ingredients.Count; i++)
        {
            Food ingredient = _ingredients[i];
            double amount = _amounts[i];

            foreach (var nutrient in ingredient.Nutrients)
            {
                string key = nutrient.Name;

                double scaledAmount = nutrient.Amount * amount;
                double scaledPercentage = nutrient.Percentage * amount;

                if (nutrientMap.ContainsKey(key))
                {
                    nutrientMap[key].Amount += scaledAmount;
                    nutrientMap[key].Percentage += scaledPercentage;
                }
                else
                {
                    nutrientMap[key] = new Nutrition(key, scaledAmount, nutrient.Units, scaledPercentage);
                }
            }
        }

        Nutrients = nutrientMap.Values.ToList();
    }


}