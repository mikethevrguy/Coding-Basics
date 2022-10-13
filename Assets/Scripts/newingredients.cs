using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newingredients
{
    public enum itemType { vegetable, boil, blend };
    //public cookType cookT;
    string name;
    public int id;
    public GameObject prefab;
    int dollarValue;

    
    public newingredients(string _name, int _id, GameObject _prefab, int _dollarValue)
    {
        //cookT = _cookType;
        name = _name;
        id = _id;
        prefab = _prefab;
        dollarValue = _dollarValue;
    }
    
}
