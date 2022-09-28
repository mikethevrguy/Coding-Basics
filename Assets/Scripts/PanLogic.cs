using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanLogic : MonoBehaviour
{
    [SerializeField]
    RecipeBook recipeBook;
    private int min;
    private int max;
    float timer = 0;
    private void OnMouseDown()
    {
        StopAllCoroutines();
        
        if (timer < min && timer !=0)
        {
            Debug.Log("Food is undercooked!");
            Debug.Log("You lost $" + recipeBook.CalculateEarnings(false));
            Debug.Log("Total profit $" + recipeBook.earnings);
        } else if (timer > max && timer != 0)
        {
            Debug.Log("Food is burned!");
            Debug.Log("You lost $" + recipeBook.CalculateEarnings(false));
            Debug.Log("Total profit $" + recipeBook.earnings);
        } else if (timer != 0)
        {
            Debug.Log("Food is cooked perfectly!");
            Debug.Log("You earned $" + recipeBook.CalculateEarnings(true));
            Debug.Log("Total profit $" + recipeBook.earnings);
        }
        timer = 0;
        

        recipeBook.ChooseRecipe();
    }
    public void StartCountDown(int _min, int _max)
    {
        min = _min;
        max = _max;
        StartCoroutine(Timer());
    }
    IEnumerator Timer()
    {
        while (true)
        {
            timer += Time.deltaTime;
            Debug.Log(timer);
            yield return null;
        }
    }
}
