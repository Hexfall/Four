using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameManager instance;
    public string[] words;
    public char[][] combos;
    public TextAsset wordsFile;
    public TextAsset comboFile;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        words = comboFile.text.Split('\n');
        combos = new char[words.Length][];
        for (int i = 0; i < words.Length; i++)
            combos[i] = words[i].ToCharArray();
        words = wordsFile.text.Split('\n');
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
