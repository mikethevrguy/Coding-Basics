using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemClick : MonoBehaviour
{
    RecipeBook recipeBook;
    private void Start()
    {
        recipeBook = GameObject.Find("Recipe Book").GetComponent<RecipeBook>();
    }
    private void OnMouseDown()
    {
        recipeBook.ChooseIngredient(int.Parse(gameObject.name));
    }
}
