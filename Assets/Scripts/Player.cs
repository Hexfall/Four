using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    PlayerListener listener;
    public TextMeshProUGUI guiText;
    public TextMeshProUGUI keyText;
    public TextMeshProUGUI scoreText;

    public string lastAcceptedWord;

    public int points;

    // Start is called before the first frame update
    void Start()
    {
        guiText = GetComponentInChildren<TextMeshProUGUI>();
        listener = GetComponent<PlayerListener>();
        keyText = transform.Find("Chars").GetComponent<TextMeshProUGUI>();
        scoreText = transform.Find("Score").GetComponent<TextMeshProUGUI>();
        

        Check();
    }

    private void Check() {
        //Check word for correctness and give out points
        if (GameManager.instance.IsWord(guiText.text)) {
            points++;
            lastAcceptedWord = guiText.text;
            scoreText.text = "Score: " + points;
        }

        //Reset the word either way
        guiText.text = "";

        //Set the player's letter combo
        listener.SetLetters(GameManager.instance.GetCombo());
        keyText.text = listener.GetLetterString();


        //Do some other juice stuff
    }

    public void Write(char c) {
        if (guiText.text.Length >= 4){
            return;
        }

        //write out this char
        guiText.text += c;

        //if 4 chars have been written, then check
        if (guiText.text.Length == 4){
            StartCoroutine(Commons.DelayedAction(Check, 0.5f));
        }
    }
}
