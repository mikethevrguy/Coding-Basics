using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class classexample : MonoBehaviour
{
    public int wheels;
    public float speed;
    public float turnSpeed;

    public virtual void Move()
    {
        Debug.Log("move forward");
    }
    // constructors
    public classexample(int _wheels, float _speed, float _turnspeed)
    {
        wheels = _wheels;
        speed = _speed;
        turnSpeed = _turnspeed;
    }
    public classexample(float _speed, float _turnspeed)
    {
        speed = _speed;
        turnSpeed = _turnspeed;
    }
    public classexample(int _wheels, float _speed)
    {
        wheels = _wheels;
        speed = _speed;
    }
    public classexample()
    {

    }

}
