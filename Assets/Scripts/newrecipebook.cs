using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newrecipebook : MonoBehaviour
{
    // creates new lists to hold all ingredient and recipe options
    public List<newingredients> ingredients = new List<newingredients>();
    public List<newrecipe> recipes = new List<newrecipe>();
    // this will hold the ID of the selected recipe
    // and will be used when comparing the list of player selected
    // ingredients
    public int chosenRecipeID;
    public void CheckRecipe(int itemID)
    {
        bool isCorrect = false;
        for (int i = 0; i < recipes[chosenRecipeID].ingredientIDs.Count; i++)
        {
            if (itemID == recipes[chosenRecipeID].ingredientIDs[i])
            {
                isCorrect = true;
                break;
            } 
        }
        if (isCorrect)
        {
            Debug.Log("is correct");
        } else
        {
            Debug.Log("not correct");
        }
    }
    void Start()
    {
        // add new ingredients to ingredients list
        // the 'new newingredients' code below creates a new instance
        // of the newingredients class
        // to learn more about Resources.Load, visit https://docs.unity3d.com/ScriptReference/Resources.Load.html
        ingredients.Add(new newingredients("Red Cube", 0, Resources.Load("Ingredients/RedCube") as GameObject, 3));
       ingredients.Add(new newingredients("Green Cube", 1, Resources.Load("Ingredients/GreenCube") as GameObject, 5));
       ingredients.Add(new newingredients("Orange Cube", 2, Resources.Load("Ingredients/OrangeCube") as GameObject, 2));
       ingredients.Add(new newingredients("Purple Sphere", 3, Resources.Load("Ingredients/PurpleSphere") as GameObject, 8));
        ingredients.Add(new newingredients("Yellow Sphere", 4, Resources.Load("Ingredients/YellowSphere") as GameObject, 1));

        // add new recipes to recipes list - the RandomIngredientList function
        // calls a function that creates and returns a list with randomized
        // ingredient IDs for the recipe
        recipes.Add(new newrecipe("Grilled Cheese", 0, RandomIngredientList(0, 1, 3, 1, 5), 3, 5, 20));
       recipes.Add(new newrecipe("Brain Soup", 1, RandomIngredientList(0,1,3,1,5), 5, 10, 20));
       recipes.Add(new newrecipe("Recipe 3", 2, RandomIngredientList(0, 1, 3, 1, 5), 3, 7, 50));
       recipes.Add(new newrecipe("Recipe 4", 3, RandomIngredientList(0, 1, 3, 1, 5), 2, 8, 30));
        // calls the function to spawn ingredients
        SpawnIngredients();
        // calls the function to randomly select a recipe
        ChooseRecipe();
    }
    void ChooseRecipe()
    {
        // creates a random number from 0 to the length of the recipes list
        // this will be used when comparing if the user selected
        // ingredients match the recipe list
        chosenRecipeID = Random.Range(0, recipes.Count-1);
    }
    void SpawnIngredients()
    {
        // this will loop through all ingredients in the ingredients
        // list and spawn the prefab assigned in the list
        for (int i = 0; i < ingredients.Count; i++)
        {
            // this will assign the spawned game object to a temp
            // variable and allow us to change the name
            // the name will be the same as the ingredient ID
            // we will store this ID in a user selected list
            // and then compare this list with the ingredient IDs list
            // attached to the chosen recipe
            GameObject tempObj = Instantiate(ingredients[i].prefab);
            tempObj.name = ingredients[i].id.ToString();
        }
    }

    // function that will return a list with random ingredient IDs
    List<int> RandomIngredientList(int item1, int item2, int item3, int item4, int item5)
    {

        
        List<int> tempList = new List<int>();
        tempList.Add(item1);
        tempList.Add(item2);
        tempList.Add(item3);
        tempList.Add(item4);
        tempList.Add(item5);
        /*
        for (int i = 0; i < newrecipe.maxIngredients; i++)
        {
            tempList.Add(Random.Range(0, ingredients.Count - 1));
        }
        */
        return tempList;
    }
}
