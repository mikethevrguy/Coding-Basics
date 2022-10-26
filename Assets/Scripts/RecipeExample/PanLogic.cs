using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PanLogic : MonoBehaviour
{
    // since the frying pan is in the scene, we can use a serializedfield
    // to reference the RecipeBook script
    [SerializeField]
    RecipeBook recipeBook;
    // this is to the textmeshpro field for the score text. NOTE: to reference TextMeshPro objects
    // the line using TMPro; needs to be at the top
    [SerializeField]
    TextMeshProUGUI scoreText;
    // variables used to store the min/max values from the associated recipe in the RecipeBook script
    private int min;
    private int max;
    float timer = 0;
    // when the frying pan is clicked on, the following code will be executed
    // NOTE: a collider is needed for this to work
    private void OnMouseDown()
    {
        // stops all coroutines running in this script
        StopAllCoroutines();
        
        // the following if/else if statements are dependent on if the timer is < min or > max
        // if so, the CalculateEarning function in the RecipeBook is called and passes false, which means
        // the player loses money
        // the earnings variable from the RecipeBook script is outputted
        if (timer < min && timer !=0)
        {
            Debug.Log("Food is undercooked!");
            Debug.Log("You lost $" + recipeBook.CalculateEarnings(false));
            Debug.Log("Total profit $" + recipeBook.earnings);
            scoreText.text = "Earnings: $" + recipeBook.earnings;
        } else if (timer > max && timer != 0)
        {
            Debug.Log("Food is burned!");
            Debug.Log("You lost $" + recipeBook.CalculateEarnings(false));
            Debug.Log("Total profit $" + recipeBook.earnings);
            scoreText.text = "Earnings: $" + recipeBook.earnings;
        } else if (timer != 0)
        {
            Debug.Log("Food is cooked perfectly!");
            Debug.Log("You earned $" + recipeBook.CalculateEarnings(true));
            Debug.Log("Total profit $" + recipeBook.earnings);
            scoreText.text = "Earnings: $" + recipeBook.earnings;
        }
        // reset the timer
        timer = 0;
        
        // call the ChooseRecipe function in the RecipeBook script to reset the recipe
        recipeBook.ChooseRecipe();
    }
    // function that is called from the RecipeBook script when the correct number of ingredients are selected
    // the min/max are passed from the selected recipe
    // the Timer coroutine is started to start the cook time
    public void StartCountDown(int _min, int _max)
    {
        min = _min;
        max = _max;
        StartCoroutine(Timer());
    }
    // simple coroutine to start a timer
    IEnumerator Timer()
    {
        // this will run indefintely, but a StopAllCoroutines function is called above, which stops this
        while (true)
        {
            // timer value is started a 0 and then increases by 1 each second
            // because of the Time.deltaTime
            timer += Time.deltaTime;
            Debug.Log(timer);
            // coroutines need at least one line with a yield statement
            // for info on coroutines, visit: https://docs.unity3d.com/Manual/Coroutines.html
            yield return null;
        }
    }
}
