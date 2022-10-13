using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item : MonoBehaviour
{
   newrecipebook recipeScript;
    // Start is called before the first frame update
    void Start()
    {
        recipeScript = GameObject.Find("recipe").GetComponent<newrecipebook>();
    }
    private void OnMouseDown()
    {
        recipeScript.CheckRecipe(int.Parse(gameObject.name));
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
