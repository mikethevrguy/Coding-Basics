using System.Collections;
using System.Reflection;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class RecipeBook : MonoBehaviour
{
    // lists used to store ingredients, recipes and selected ingredients
    public List<Ingredient> ingredients = new List<Ingredient>();
    public List<Recipe> recipes = new List<Recipe>();
    public List<int> usedIngredients = new List<int>();

    // array for spawn points to spawn ingredients needed for the recipe
    public Transform[] recipeSpawn;

    // int to store the ID of the chosen recipe
    public int chosenRecipeID;

    // since this script is in the scene at runtime, we can use a serizlied field to 
    // reference the panLogic script
    [SerializeField]
    private PanLogic panLogic;

    // float to track incremented earnings
    public float earnings;

    // bool to track if the game has started
    private bool gameStarted = false;

    // function that is called when player clicks on an ingredient, the ingredient ID is passed
    public void ChooseIngredient(int ingredientID)
    {
        // adds the selected ingredient ID to the usedIngredients list
        usedIngredients.Add(ingredientID);
        // checks to see if the usedIngredients list is the same length as the 
        // ingredients list for the chosen recipe. If it is, this means we need to compare
        // to see if the contents of the list match
        if (usedIngredients.Count == recipes[chosenRecipeID].ingredientIDs.Count)
        {
            // call a isMatch function and pass the recipeID and usedIngredients list
            // the function returns true if both lists having matching contents in the same order
            Debug.Log(isMatch(chosenRecipeID, usedIngredients));
            if (isMatch(chosenRecipeID, usedIngredients))
            {
                // start the countdown timer in the panLogic script and pass the min/max cook time from the chosen recipe
                panLogic.StartCountDown(recipes[chosenRecipeID].minCookTime, recipes[chosenRecipeID].maxCooktime);
            }
        }
    }
    private void Start()
    {
        // when the game starts, add ingredients to the ingredients list
        // the Resources.Load allows a prefab to be loaded NOTE: the prefab needs to be in a Resources
        // folder. For example, the RedCube prefab is in the Ingredients folder, which is in the Resources folder
        // when referencing prefabs with Resources.Load, do not include file extensions
        // the new Ingredients is refering to creating a new instance of the Ingredients class and uses the default constructor
        ingredients.Add(new Ingredient("Red Cube", 0, Resources.Load("Ingredients/RedCube") as GameObject, 3));
        ingredients.Add(new Ingredient("Green Cube", 1, Resources.Load("Ingredients/GreenCube") as GameObject, 5));
        ingredients.Add(new Ingredient("Orange Cube", 2, Resources.Load("Ingredients/OrangeCube") as GameObject, 2));
        ingredients.Add(new Ingredient("Purple Sphere", 3, Resources.Load("Ingredients/PurpleSphere") as GameObject, 8));
        ingredients.Add(new Ingredient("Yellow Sphere", 4, Resources.Load("Ingredients/YellowSphere") as GameObject, 1));

        // populate the recipe list with recipes
        // the RandomIngredientList is just a function that returns a random list of ingredients
        recipes.Add(new Recipe("Recipe 1", 0, 3, 5, RandomIngredientList(), 20));
        recipes.Add(new Recipe("Recipe 2", 1, 5, 10, RandomIngredientList(), 20));
        recipes.Add(new Recipe("Recipe 3", 2, 3, 7, RandomIngredientList(), 50));
        recipes.Add(new Recipe("Recipe 4", 3, 2, 8, RandomIngredientList(), 30));
        
        // call the spawnIngredients function
        SpawnIngredients();

        // call the ChooseRecipe function
        ChooseRecipe();
    }
    // function to calculate earnings, if true is passed the calculation is added, if false is passed, the calculation is deducted
    public float CalculateEarnings(bool gain)
    {
        float temp = 0;
        // loop through the ingredients list of the chosen recipe
        for (int i = 0; i < recipes[chosenRecipeID].ingredientIDs.Count; i++)
        {
            // store the dollar value of each ingredient in a temp float
            temp += ingredients[recipes[chosenRecipeID].ingredientIDs[i]].dollarValue;
        }
        // if true is passed, add the markup value associated with the recipt to the total value of temp
        // increase the earnings variable by the value of temp
        if (gain)
        {
            temp = temp + (temp / recipes[chosenRecipeID].markup);
            earnings += temp;
        // if false is passed, deduct the total value of ingredients used for the earnings variable
        } else
        {
            earnings -= temp;
        }
        // return the temp variable
        return temp;
    }
    // function to randomly choose a recipe
   public void ChooseRecipe()
    {
        // calls the clearConsole function
        clearConsole();
        // if the game has started, eg. this is the second round, call the ResetPan function
        if (gameStarted)
        {
            ResetPan();
        }
        // store the recipe ID based on a random number between 0 and the count of the recipes list - 1
        chosenRecipeID = Random.Range(0, recipes.Count - 1);

        // loop through the ingredients list for the chosen recipe
        // spawn the associated prefab for the recipe ingredient and position
        // in the correlated spawn position
        for (int i = 0; i < recipes[chosenRecipeID].ingredientIDs.Count; i++)
        {
            Debug.Log("Recipe ID: " + chosenRecipeID);
            Debug.Log("Item " + i + ": " + recipes[chosenRecipeID].ingredientIDs[i]);
            GameObject tmp = Instantiate(ingredients[recipes[chosenRecipeID].ingredientIDs[i]].prefab);
            tmp.transform.parent = recipeSpawn[i];
            tmp.transform.localPosition = Vector3.zero;
        }
        // set this bool to true
        gameStarted = true;
    }
    // function for clearing the Debug.Log console, not needed for production games
    void clearConsole()
    {
        var assembly = Assembly.GetAssembly(typeof(UnityEditor.Editor));
        var type = assembly.GetType("UnityEditor.LogEntries");
        var method = type.GetMethod("Clear");
        method.Invoke(new object(), null);
    }
    void ResetPan()
    {
        // destroy spawned ingredients in the frying pan
        Destroy(GameObject.Find("Pan Item 1"));
        Destroy(GameObject.Find("Pan Item 2"));
        Destroy(GameObject.Find("Pan Item 3"));
        // loop through the recipe ingredients and destroy the spawned ingredients
        for (int i = 0; i < recipeSpawn.Length; i++)
        {
            Destroy(recipeSpawn[i].GetChild(0).gameObject);
        }
        // clear the player selected ingredients list
        usedIngredients.Clear();

    }
    List<int> RandomIngredientList()
    {
        // create a temp list
        List<int> tempList = new List<int>();
        // loop through using the Recipe.maxIngredients static variable as the count limit
        // randomly add an ingredient ID using the ingredients list count as the loop limit
        for (int i = 0; i < Recipe.maxIngredients; i++)
        {
            tempList.Add(Random.Range(0, ingredients.Count - 1));
        }
        // return the temp list
        return tempList;
    }

    void SpawnIngredients()
    {
        // loop through the ingredients list
        for (int i = 0; i < ingredients.Count; i++)
        {
            // instantiate each prefab in the ingredients list
            GameObject tempObj = Instantiate(ingredients[i].prefab);
            // rename the object to the associated ingredient ID (will be used when we click on the ingredient prefab)
            tempObj.name = i.ToString();
            // code to offset the ingredients so they are not on top of each other
            Vector3 tempV3 = tempObj.transform.position;
            tempObj.transform.position = new Vector3(tempV3.x + (i * 1), tempV3.y, tempV3.z);
        }
    }
    // a function that return true/false of the ingredients in the recipe match the ingredients added to the usedIngredients list
    public bool isMatch(int recipeID, List<int> selectedIngredients)
    {
        // loop through each recipe in the recipes list
        foreach (Recipe thisRecipe in recipes)
        {
            // if the ID of the current recipe in the loop matches the recipeID that is passed
            // this is the chosen recipe and run a comparison
            if (thisRecipe.id == recipeID)
            {
                // loop through the ingredients list in the chosen recipe
                for (int i = 0; i < thisRecipe.ingredientIDs.Count; i++)
                {
                    // if the contents in the chosen recipe list DO NOT MATCH the contents of the usedIngredients list (including order)
                    // return false and call the CalculateEarnings code, which will subtract the value of lost ingredients for earnings
                    if (thisRecipe.ingredientIDs[i] != selectedIngredients[i])
                    {
                        CalculateEarnings(false);
                        return false;
                    }
                }
                // if all the ingredients match, return true
                return true;
            }
        }
        return false;
    }
}
