using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField]
    float moveTime = 5f;
    public Vector3 startPos;
    public Vector3 endPos;
    private SimonSays simonSaysScript;
    private void Start()
    {
        simonSaysScript = GameObject.Find("GameManager").GetComponent<SimonSays>();
    }
    private void OnMouseDown()
    {
        simonSaysScript.AddGuess(gameObject);
    }
    public void StartHover()
    {
        startPos = transform.position;
        endPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.25f, gameObject.transform.position.z);
        StartCoroutine(animateCube(startPos, endPos));
    }
    IEnumerator animateCube(Vector3 start, Vector3 end)
    {
        float timeElapsed = 0;
        float rate = 5 / moveTime;
        while (timeElapsed < 1)
        {
            transform.position = Vector3.Lerp(start, end, timeElapsed);
            timeElapsed += Time.deltaTime * rate;
            yield return null;
        }
        
        if (start == startPos)
        {
            timeElapsed = 0;
            StartCoroutine(animateCube(endPos, startPos)); // recursive function
        }
    }
}
