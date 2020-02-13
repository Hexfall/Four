using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackScript : MonoBehaviour
{
    public GameObject box;
    public int startAmount;
    private int curAmount = 0;
    private int pointer = 0;
    public float spacing = 0.7f;
    private GameObject[] boxArray;
    public int maxBoxes = 24;
    private AudioSource score;

    // Start is called before the first frame update
    void Start()
    {
        boxArray = new GameObject[maxBoxes];
        Add(startAmount);
        score = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Remove();
        if (Input.GetMouseButtonDown(1))
            Add();
    }

    public void Add(int amount = 1)
    {
        // Create a box, set it's position and add it to the boxArray. Amount times.
        GameObject b = Instantiate(box);
        SpriteRenderer renderer = b.GetComponent<SpriteRenderer>();
        renderer.color = Random.ColorHSV();
        b.transform.parent = transform;
        b.transform.localPosition = new Vector2(curAmount % 3 * spacing, Mathf.Floor(curAmount / 3) * spacing);
        b.transform.position += (Vector3) Random.insideUnitCircle / 4f;
        b.transform.localScale *= 0.8f;
        boxArray[curAmount] = b;
        curAmount++;
        if (!(amount <= 1))
            Add(amount - 1);
    }

    public void Remove(int amount = 1)
    {
        // Destroy the 'amount' youngest boxes.
        Destroy(boxArray[pointer]);
        pointer++;
        if (Empty())
            GameManager.instance.Win(gameObject.name);
        if (!(amount <= 1))
            Remove(amount - 1);
        score.Play();
    }

    public bool Empty()
    {
        // Returns true if there are no boxes left.
        return boxArray[pointer] == null;
    }
}
