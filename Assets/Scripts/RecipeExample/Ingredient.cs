using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Ingredient 
{
    public string name;
    public int id;
    public GameObject prefab;
    public int dollarValue;

    // constructor for ingredient class - each of the required parameters need
    // to be included when instantiating a new instance of the class
    public Ingredient(string _name, int _id, GameObject _prefab, int _dollarValue)
    {
        name = _name;
        id = _id;
        prefab = _prefab;
        dollarValue = _dollarValue;
    }
}
