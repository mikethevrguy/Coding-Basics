using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        classexample truck = new classexample(4, 100.5f, 30);
        classexample car = new classexample(10, 40);
        classexample bike = new classexample(40, 10);
        helicopter copter = new helicopter();
        copter.Move();
        Debug.Log("wheels " + car.wheels);
        Debug.Log("speed " + bike.speed);

        
    
        Debug.Log("wheel count " + truck.wheels);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
