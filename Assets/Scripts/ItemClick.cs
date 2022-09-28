using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemClick : MonoBehaviour
{
    RecipeBook recipeBook;
    public static int clickCount = 0;
    private void Start()
    {
        recipeBook = GameObject.Find("Recipe Book").GetComponent<RecipeBook>();
    }
    private void OnMouseDown()
    {
        recipeBook.ChooseIngredient(int.Parse(gameObject.name));
        clickCount++;
        Transform moveLoc;
        GameObject tmp = Instantiate(this.gameObject);
        
        switch (clickCount)
        {
            case 1:
                tmp.name = "Pan Item 1";
                moveLoc = GameObject.Find("recipe loc 1").transform;
                
                tmp.transform.position = moveLoc.position;
                tmp.transform.rotation = moveLoc.parent.transform.rotation;
                tmp.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                break;
            case 2:
                tmp.name = "Pan Item 2";
                moveLoc = GameObject.Find("recipe loc 2").transform;
                tmp.transform.position = moveLoc.position;
                tmp.transform.rotation = moveLoc.parent.transform.rotation;
                tmp.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                break;
            case 3:
                tmp.name = "Pan Item 3";
                moveLoc = GameObject.Find("recipe loc 3").transform;
                tmp.transform.position = moveLoc.position;
                tmp.transform.rotation = moveLoc.parent.transform.rotation;
                tmp.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                clickCount = 0;
                break;
        }
    }
}
