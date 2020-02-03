using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        words = new HashSet<string> (wordsFile.text.Split('\n'));
        foreach (string word in words)
        {
            print(word.Length);
        }
        foreach (string s in "someMtext".Split('M'))
            print(s);
        print(IsWord("WORD"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public char[] GetCombo()
    {
        int index = Random.Range(0, combos.Length);
        char[] combo = combos[index];
        char[] shuffledCombo = combo.OrderBy( x => Random.value ).ToArray();
        return shuffledCombo;
    }

    public bool IsWord(string word)
    {
        return words.Contains(word);
    }
}
