using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerListener : MonoBehaviour
{
    //Class that listens to the players input and sends string messages
    [SerializeField] private KeyCode key1;
    [SerializeField] private KeyCode key2;
    [SerializeField] private KeyCode key3;
    [SerializeField] private KeyCode key4;

    private char c1, c2, c3, c4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetLetters(char c1, char c2, char c3, char c4) {
        this.c1 = c1;
        this.c2 = c2;
        this.c3 = c3;
        this.c4 = c4;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(key1)) {
            print(c1);
        }
        if (Input.GetKeyDown(key2)) {
            print(c2);
        }
        if (Input.GetKeyDown(key3)) {
            print(c3);
        }
        if (Input.GetKeyDown(key4)) {
            print(c4);
        }
    }
}
