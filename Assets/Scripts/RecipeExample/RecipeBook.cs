using System.Collections;
using System.Reflection;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class RecipeBook : MonoBehaviour
{
    public List<Ingredient> ingredients = new List<Ingredient>();

    public List<Recipe> recipes = new List<Recipe>();

    public List<int> usedIngredients = new List<int>();

    public Transform[] recipeSpawn;

    public int chosenRecipeID;

    public PanLogic panLogic;

    public float earnings;
    private bool gameStarted = false;

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
        
        ingredients.Add(new Ingredient("Red Cube", 0, Resources.Load("Ingredients/RedCube") as GameObject, 3));
        ingredients.Add(new Ingredient("Green Cube", 1, Resources.Load("Ingredients/GreenCube") as GameObject, 5));
        ingredients.Add(new Ingredient("Orange Cube", 2, Resources.Load("Ingredients/OrangeCube") as GameObject, 2));
        ingredients.Add(new Ingredient("Purple Sphere", 3, Resources.Load("Ingredients/PurpleSphere") as GameObject, 8));
        ingredients.Add(new Ingredient("Yellow Sphere", 4, Resources.Load("Ingredients/YellowSphere") as GameObject, 1));

        recipes.Add(new Recipe("Recipe 1", 0, 3, 5, RandomIngredientList(), 20));
        recipes.Add(new Recipe("Recipe 2", 1, 5, 10, RandomIngredientList(), 20));
        recipes.Add(new Recipe("Recipe 3", 2, 3, 7, RandomIngredientList(), 50));
        recipes.Add(new Recipe("Recipe 4", 3, 2, 8, RandomIngredientList(), 30));
        

        SpawnIngredients();

        ChooseRecipe();
    }
    public float CalculateEarnings(bool gain)
    {
        float temp = 0;
        for (int i = 0; i < recipes[chosenRecipeID].ingredientIDs.Count; i++)
        {
            temp += ingredients[recipes[chosenRecipeID].ingredientIDs[i]].dollarValue;
        }
        if (gain)
        {
            temp = temp + (temp / recipes[chosenRecipeID].markup);
            earnings += temp;
        } else
        {
            earnings -= temp;
        }

        return temp;
    }
   public void ChooseRecipe()
    {
        clearConsole();
        if (gameStarted)
        {
            ResetPan();
        }
       
        chosenRecipeID = Random.Range(0, recipes.Count - 1);
        for (int i = 0; i < recipes[chosenRecipeID].ingredientIDs.Count; i++)
        {
            Debug.Log("Recipe ID: " + chosenRecipeID);
            Debug.Log("Item " + i + ": " + recipes[chosenRecipeID].ingredientIDs[i]);
            GameObject tmp = Instantiate(ingredients[recipes[chosenRecipeID].ingredientIDs[i]].prefab);
            tmp.transform.parent = recipeSpawn[i];
            tmp.transform.localPosition = Vector3.zero;
        }
        gameStarted = true;
    }
    void clearConsole()
    {
        var assembly = Assembly.GetAssembly(typeof(UnityEditor.Editor));
        var type = assembly.GetType("UnityEditor.LogEntries");
        var method = type.GetMethod("Clear");
        method.Invoke(new object(), null);
    }
    void ResetPan()
    {
        
        Destroy(GameObject.Find("Pan Item 1"));
        Destroy(GameObject.Find("Pan Item 2"));
        Destroy(GameObject.Find("Pan Item 3"));
        for (int i = 0; i < recipeSpawn.Length; i++)
        {
            Destroy(recipeSpawn[i].GetChild(0).gameObject);
        }
        usedIngredients.Clear();

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
                        CalculateEarnings(false);
                        return false;
                    }
                }
                return true;
            }
        }
        return false;
    }
}
