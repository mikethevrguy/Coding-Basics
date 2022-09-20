using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class RecipeBook : MonoBehaviour
{
    public List<Ingredient> ingredients = new List<Ingredient>();

    public List<Recipe> recipes = new List<Recipe>();

    public List<int> usedIngredients = new List<int>();

    public static int chosenRecipeID;

    public PanLogic panLogic;

    public void ChooseIngredient(int ingredientID)
    {
        usedIngredients.Add(ingredientID);
        if (usedIngredients.Count == recipes[chosenRecipeID].ingredientIDs.Count)
        {
            Debug.Log(isMatch(chosenRecipeID, usedIngredients));
            if (isMatch(chosenRecipeID, usedIngredients))
            {
                panLogic.StartCountDown(recipes[chosenRecipeID].minCookTime, recipes[chosenRecipeID].maxCooktime);
            }
        }
    }
    private void Start()
    {
        ingredients.Add(new Ingredient("Red Cube", 0, Resources.Load("Ingredients/RedCube") as GameObject));
        ingredients.Add(new Ingredient("Green Cube", 1, Resources.Load("Ingredients/GreenCube") as GameObject));
        ingredients.Add(new Ingredient("Orange Cube", 2, Resources.Load("Ingredients/OrangeCube") as GameObject));
        ingredients.Add(new Ingredient("Purple Sphere", 3, Resources.Load("Ingredients/PurpleSphere") as GameObject));
        ingredients.Add(new Ingredient("Yellow Sphere", 0, Resources.Load("Ingredients/YellowSphere") as GameObject));

        recipes.Add(new Recipe("Recipe 1", 0, 3, 5, RandomIngredientList()));
        recipes.Add(new Recipe("Recipe 2", 1, 5, 10, RandomIngredientList()));
        recipes.Add(new Recipe("Recipe 3", 2, 3, 7, RandomIngredientList()));
        recipes.Add(new Recipe("Recipe 4", 3, 2, 8, RandomIngredientList()));

        SpawnIngredients();

        ChooseRecipe();
    }
    void ChooseRecipe()
    {
        chosenRecipeID = Random.Range(0, recipes.Count - 1);
        for (int i = 0; i < recipes[chosenRecipeID].ingredientIDs.Count; i++)
        {
            Debug.Log(recipes[chosenRecipeID].ingredientIDs[i]);
        }
    }
    List<int> RandomIngredientList()
    {
        List<int> tempList = new List<int>();
        for (int i = 0; i < Recipe.maxIngredients; i++)
        {
            tempList.Add(Random.Range(0, ingredients.Count - 1));
        }
        return tempList;
    }

    void SpawnIngredients()
    {
        for (int i = 0; i < ingredients.Count; i++)
        {
            GameObject tempObj = Instantiate(ingredients[i].prefab);
            tempObj.name = i.ToString();
            Vector3 tempV3 = tempObj.transform.position;
            tempObj.transform.position = new Vector3(tempV3.x + (i * 1), tempV3.y, tempV3.z);
        }
    }

    public bool isMatch(int recipeID, List<int> selectedIngredients)
    {
        foreach (Recipe thisRecipe in recipes)
        {
            if (thisRecipe.id == recipeID)
            {
                for (int i = 0; i < thisRecipe.ingredientIDs.Count; i++)
                {
                    if (thisRecipe.ingredientIDs[i] != selectedIngredients[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }
        return false;
    }
}
