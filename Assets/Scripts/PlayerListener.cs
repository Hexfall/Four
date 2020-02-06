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

    private Player player;


    private char c1, c2, c3, c4;

    public void SetLetters(char[] characters)
    {
        if (characters.Length < 4)
        {
            print("Invalid char array in SetLetters");
            return;
        }
        this.c1 = characters[0];
        this.c2 = characters[1];
        this.c3 = characters[2];
        this.c4 = characters[3];
    }

    public string GetLetterString()
    {
        return c1 + "\n" + c2 + c3 + c4;
    }

    void Start()
    {
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            char? c = null;
            if (Input.GetKeyDown(key1))
            {
                print(c1);
                c = c1;
            }
            else if (Input.GetKeyDown(key2))
            {
                print(c2);
                c = c2;
            }
            else if (Input.GetKeyDown(key3))
            {
                print(c3);
                c = c3;
            }
            else if (Input.GetKeyDown(key4))
            {
                print(c4);
                c = c4;
            }

            if (c != null)
            {
                player.Write((char)c);
            }
        }
    }
}
