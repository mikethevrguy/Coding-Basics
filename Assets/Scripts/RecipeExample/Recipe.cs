using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe
{
    public static int maxIngredients = 3;
    public string name;
    public int id;
    public int minCookTime;
    public int maxCooktime;
    public List<int> ingredientIDs;
    public float markup;

    public Recipe(string _name, int _id, int _minCookTime, int _maxCookTime, List<int> _ingredientIDs, float _markup)
    {
        name = _name;
        id = _id;
        minCookTime = _minCookTime;
        maxCooktime = _maxCookTime;
        ingredientIDs = _ingredientIDs;
        markup = _markup;
    }
}
