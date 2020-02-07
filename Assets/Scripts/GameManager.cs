using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public HashSet<string> words;
    public char[][] combos;
    public TextAsset wordsFile;
    public TextAsset comboFile;
    public GameObject winLabel;

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
        winLabel.GetComponent<TextMeshProUGUI>().text = "";
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

    public void Win(string winner)
    {
        print(winner + " is the winner!");
        string winName = "1";
        if (winner.Contains("2"))
            winName = "2";
        winLabel.GetComponent<TextMeshProUGUI>().text = string.Format("Player {0} is the winner!", winName);
    }
}
