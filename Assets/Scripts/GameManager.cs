using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameManager instance;
    public HashSet<string> words;
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
        words = new HashSet<string> (comboFile.text.Split('\n'));
        combos = new char[words.Count][];
        int i = 0;
        foreach (var word in words) {
            combos[i] = word.ToCharArray();
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
