﻿using System.Collections;
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
        if (Input.GetMouseButtonDown(0))
            Remove();
        if (Input.GetMouseButtonDown(1))
            Add();
    }

    public void Add(int amount = 1)
    {
        // Create a box, set it's position and add it to the boxArray. Amount times.
        GameObject b = Instantiate(box) as GameObject;
        b.transform.parent = transform;
        b.transform.localPosition = new Vector2(curAmount % 4 * spacing, Mathf.Floor(curAmount / 4) * spacing);
        boxArray[curAmount] = b;
        curAmount++;
        if (!(amount <= 1))
            Add(amount - 1);
    }

    public void Remove(int amount = 1)
    {
        // Destroy the 'amount' youngest boxes.
        Destroy(boxArray[pointer]);
        pointer++;
        if (Empty())
            GameManager.instance.Win(gameObject.name);
        if (!(amount <= 1))
            Remove(amount - 1);
    }

    public bool Empty()
    {
        // Returns true if there are no boxes left.
        return boxArray[pointer] == null;
    }
}
