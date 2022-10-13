using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enumtest : MonoBehaviour
{   public enum moveDirection { forward, back, left, right, up, down};
    public moveDirection move;
    private List<int> list1;
    private List<int> list2;

    public List<List<int>> mainList;
    // Start is called before the first frame update
    void Start()
    {
        //list1.Add(1);
       // list1.Add(2);
       // list2.Add(3);
       // list2.Add(4);
       // mainList.Add(list1);
       // mainList.Add(list2);
       // Debug.Log("test" + mainList[0][0]);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            move = moveDirection.forward;
        } else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            move = moveDirection.back;
        }
    }
}
