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
        
        if (timer < min && timer !=0)
        {
            Debug.Log("Food is undercooked!");
        } else if (timer > max && timer != 0)
        {
            Debug.Log("Food is burned!");
        }
    }
    public void StartCountDown(int _min, int _max)
    {
        min = _min;
        max = _max;
        StartCoroutine(Timer());
    }
    IEnumerator Timer()
    {
        while (timer <= max)
        {
            timer += Time.deltaTime;
            Debug.Log(timer);
            yield return null;
        }
    }
}
