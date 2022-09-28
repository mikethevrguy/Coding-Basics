using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicles 
{
    public string model;
    public int hp;
    public int maxSpeed;
    public int doors;
    public int wheels;

    public Vehicles (string _model, int _hp, int _maxSpeed, int _doors, int _wheels)
    {
        model = _model;
        hp = _hp;
        maxSpeed = _maxSpeed;
        doors = _doors;
        wheels = _wheels;
    }
    public Vehicles()
    {

    }
    public virtual void Accelerate()
    {
        Debug.Log("moving forward");
    }
}

public class HoverBike : Vehicles
{
    public HoverBike()
    {

    }
    public override void Accelerate()
    {
        //base.Accelerate(); // inherits the function in the parent class
        Debug.Log("moving up");
    }
}
