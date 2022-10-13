using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonSays : MonoBehaviour
{
    enum colors { black, blue, cyan, gray, green, magenta, red, yellow };
    colors cubeColor;
    [Range(1, 8)]
    public int itemCount = 1;
    [SerializeField]
    GameObject cubePrefab;
    [SerializeField]
    List<colors> colorEnumList;
    public List<GameObject> cubePatterns = new List<GameObject>();
    public List<GameObject> guesses = new List<GameObject>();
    private List<GameObject> cubes = new List<GameObject>();

    void Start()
    {
        StartGame();
    }
    public void StartGame()
    {
        foreach (colors color in System.Enum.GetValues(typeof(colors)))
        {
            colorEnumList.Add(color);
        }
        SpawnObjects();
        StartCoroutine(Pattern());
    }
    public void AddGuess(GameObject obj)
    {
        guesses.Add(obj);
        string message = "";
        for (int i = 0; i < guesses.Count; i++)
        {
            if (cubePatterns[i].name != guesses[i].name)
            {
                message = "You Lose!!!";
                Debug.Log(message);
                return; 
            } else
            {
                message = "You Win!!!";
                if (cubePatterns.Count == guesses.Count)
                {
                    guesses.Clear();
                    StartCoroutine(Pattern());
                    Debug.Log(message);
                }
            }
        }
    }
    IEnumerator Pattern()
    {
        int ranNum = RandomNumber(0, cubes.Count);
        cubePatterns.Add(cubes[ranNum]);
        foreach (GameObject obj in cubePatterns)
        {
            yield return new WaitForSeconds(0.75f);
            obj.GetComponent<Cube>().StartHover();
        }
    }
    void SpawnObjects()
    {
        if (itemCount > colorEnumList.Count)
        {
            itemCount = colorEnumList.Count;
        }
        for(int i = 0; i < itemCount; i++)
        {
            int ranNum = RandomNumber(0, colorEnumList.Count);
            GameObject tempCube = (GameObject)Instantiate(cubePrefab);
            cubes.Add(tempCube);
            Renderer tempRend = tempCube.GetComponent<Renderer>();
            tempCube.transform.position = new Vector3(i*1, 0, 0);
            cubeColor = colorEnumList[ranNum];
            switch (cubeColor) {
                case colors.black:
                    tempCube.name = colors.black.ToString();
                    tempRend.material.color = Color.black;
                    break;
                case colors.blue:
                    tempCube.name = colors.blue.ToString();
                    tempRend.material.color = Color.blue;
                    break;
                case colors.cyan:
                    tempCube.name = colors.cyan.ToString();
                    tempRend.material.color = Color.cyan;
                    break;
                case colors.gray:
                    tempCube.name = colors.gray.ToString();
                    tempRend.material.color = Color.gray;
                    break;
                case colors.green:
                    tempCube.name = colors.green.ToString();
                    tempRend.material.color = Color.green;
                    break;
                case colors.magenta:
                    tempCube.name = colors.magenta.ToString();
                    tempRend.material.color = Color.magenta;
                    break;
                case colors.red:
                    tempCube.name = colors.red.ToString();
                    tempRend.material.color = Color.red;
                    break;
                case colors.yellow:
                    tempCube.name = colors.yellow.ToString();
                    tempRend.material.color = Color.yellow;
                    break;
            }
            colorEnumList.Remove(cubeColor);
        }
    }
    private int RandomNumber(int min, int max)
    {
        return Random.Range(min, max);
    }
}
