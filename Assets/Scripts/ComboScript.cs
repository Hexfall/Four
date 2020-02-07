﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboScript : MonoBehaviour
{
    public Color standby;
    public Color active;
    private int pointer = 0;

    // Start is called before the first frame update
    void Start()
    {
        Reset();
    }

    // Update is called once per frame
    public void Add()
    {
        transform.GetChild(pointer).GetComponent<SpriteRenderer>().color = active;
        pointer++;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Add();
    }

    public void Reset()
    {
        for (int i = 0; i < transform.childCount; i++)
            transform.GetChild(i).GetComponent<SpriteRenderer>().color = standby;
        pointer = 0;
    }

    public bool fullCombo()
    {
        return pointer == transform.childCount;
    }
}
