using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class timer : MonoBehaviour
{
    [SerializeField]
    float timerValue = 30;
    [SerializeField]
    TextMeshProUGUI timerText;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BeginTimer());
    }
    IEnumerator BeginTimer()
    {
        while (timerValue >= 0)
        {
            timerValue -= Time.deltaTime;
            timerText.text = "Time: " + (int)timerValue;
            yield return null;
        }
        timerText.text = "Time: 0";
    }
}
