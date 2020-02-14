using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboScript : MonoBehaviour
{
    public Color standby;
    public Color active;
    private int pointer = 0;
    private AudioSource yay;

    public StressReceiver stressReceiver;

    // Start is called before the first frame update
    void Start()
    {
        Reset();
        yay = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void Add()
    {
        transform.GetChild(pointer).GetComponent<SpriteRenderer>().color = active;
        pointer++;
        if (fullCombo())
        {
            yay.Play();
            stressReceiver.InduceStress(0.4f);
        } else {
            stressReceiver.InduceStress(0.1f);
        }
    }

    public void Reset()
    {
        for (int i = 0; i < transform.childCount; i++)
            transform.GetChild(i).GetComponent<SpriteRenderer>().color = standby;
        pointer = 0;
    }

    public bool fullCombo()
    {
        return pointer == transform.childCount;
    }

    public float comboProgress() {
        return ((float) pointer) / ((float) transform.childCount);
    }
}
