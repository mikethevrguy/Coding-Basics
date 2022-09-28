using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassesDemo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vehicles Car1 = new Vehicles("Dodge Ram", 300, 100, 4, 4);
        HoverBike bike1 = new HoverBike();
        bike1.Accelerate();
        Debug.Log(Car1.hp);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
