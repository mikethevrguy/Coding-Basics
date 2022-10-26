using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemClick : MonoBehaviour
{
    // placeholder for the RecipeBook script
    RecipeBook recipeBook;
    // this variable is static so that it will be the same for all objects
    // otherwise each object would have its own instance of clickCount
    public static int clickCount = 0;
    private void Start()
    {
        // since the items are spawned in, we cannot use a public or serializedfield
        // to reference the script, we need to find the Game Object by name
        // and then get the script component
        recipeBook = GameObject.Find("Recipe Book").GetComponent<RecipeBook>();
    }
    // when the player clicks on the object, the following code will execute
    // note a collider is needed for this to work
    private void OnMouseDown()
    {
        // calls the function which stores the selected ingredient by ID in the
        // usedIngredients list in the RecipeBook script. The id is retrieved by getting
        // the name of the clicked object. Since the object name is a string int.Parse
        // is used to convert the string to an interger NOTE: this will only work with
        // string values that are numbers (eg. it won't convert 'one' to an integer
        recipeBook.ChooseIngredient(int.Parse(gameObject.name));
        // increase the clickCount to determine which location on the pan the ingredient should move to
        clickCount++;
        Transform moveLoc;
        GameObject tmp = Instantiate(this.gameObject);
        
        // depending on the clickCount variable, the ingredient is moved to the matching position
        // in the frying pan. NOTE: there are 3 empty objects acting as move locations
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
