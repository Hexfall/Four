using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackScript : MonoBehaviour
{
    public GameObject box;
    public int startAmount;
    private int curAmount = 0;
    private int pointer = 0;
    public float spacing = 1.0f;
    private GameObject[] boxArray;
    public int maxBoxes = 24;

    // Start is called before the first frame update
    void Start()
    {
        boxArray = new GameObject[maxBoxes];
        Add(startAmount);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Add(int amount = 1)
    {
        GameObject b = Instantiate(box) as GameObject;
        b.transform.parent = transform;
        b.transform.localPosition = new Vector2(curAmount % 4 * spacing, Mathf.Floor(curAmount / 4) * spacing);
        boxArray[curAmount] = b;
        curAmount++;
        if (amount > 1)
            Add(amount - 1);
    }

    void Remove(int amount = 1)
    {
        Destroy(boxArray[pointer]);
        pointer++;
        if (Empty())
            GameManager.instance.Win(gameObject.tag);
        if (amount > 1)
            Remove(amount - 1);
    }

    public bool Empty()
    {
        return boxArray[pointer] == null;
    }
}
