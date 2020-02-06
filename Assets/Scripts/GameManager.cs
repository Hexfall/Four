using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
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
        words = new HashSet<string> (comboFile.text.Split('\n').Select(word => word.Trim()));
        combos = new char[words.Count][];
        int i = 0;
        foreach (var word in words) {
            combos[i] = word.ToCharArray();
            i++;
        }
        words = new HashSet<string> (wordsFile.text.Split('\n').Select(word => word.Trim()));
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

    public void Win(string loser)
    {
        
    }
}
