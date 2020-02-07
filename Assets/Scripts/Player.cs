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

    public GameObject stack;
    public GameObject opponentStack;
    public GameObject combo;

    private StackScript stackScript;
    private StackScript opStackScript;
    private ComboScript comboScript;

    public string lastAcceptedWord;

    public int points;

    // Start is called before the first frame update
    void Start()
    {
        guiText = GetComponentInChildren<TextMeshProUGUI>();
        listener = GetComponent<PlayerListener>();
        keyText = transform.Find("Chars").GetComponent<TextMeshProUGUI>();
        
        stackScript = stack.GetComponent<StackScript>();
        opStackScript = opponentStack.GetComponent<StackScript>();
        comboScript = combo.GetComponent<ComboScript>();

        Check();
    }

    private void Check() {
        //Check word for correctness and give out points
        if (GameManager.instance.IsWord(guiText.text)) {
            stackScript.Remove();
            comboScript.Add();
            ComboCheck();
            points++;
            lastAcceptedWord = guiText.text;
        }
        else
            comboScript.Reset();

        //Reset the word either way
        guiText.text = "";

        //Set the player's letter combo
        listener.SetLetters(GameManager.instance.GetCombo());
        keyText.text = listener.GetLetterString();


        //Do some other juice stuff
    }

    private void ComboCheck()
    {
        if (comboScript.fullCombo())
        {
            opStackScript.Add(2);
            comboScript.Reset();
        }
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
