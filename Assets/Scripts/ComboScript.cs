using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboScript : MonoBehaviour
{
    public Color standby;
    public Color active;
    private int pointer = 0;
    private AudioSource yay;

    private StressReceiver stressReceiver;

    // Start is called before the first frame update
    void Start()
    {
        Reset();
        yay = GetComponent<AudioSource>();
        Camera camera = Camera.current;
        stressReceiver = camera.GetComponent<StressReceiver>();
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

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Add();
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
