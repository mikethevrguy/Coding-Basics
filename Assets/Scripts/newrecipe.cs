using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newrecipe 
{
    // this will be used to determine the for loop when creating random ingredients
    public static int maxIngredients = 3;
    public string name;
    public int id;
    // stores the list of ingredient IDs for the recipe
    public List<int> ingredientIDs = new List<int>();
    // these values will be used to determine if the pan was clicked
    // in the correct time range
    public int minCookTime;
    public int maxCooktime;
    public float markupValue;

    // this is a constructor that will force variables to be set
    // when an instance of the class is created
    public newrecipe(string _name, int _id, List<int> _ingredientIDs, int _minCookTime, int _maxCookTime, float _markupValue)
    {
        name = _name;
        id = _id;
        ingredientIDs = _ingredientIDs;
        minCookTime = _minCookTime;
        maxCooktime = _maxCookTime;
        markupValue = _markupValue;
    }
}
