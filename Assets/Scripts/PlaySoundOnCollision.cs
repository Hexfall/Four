using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnCollision : MonoBehaviour
{
    private AudioSource source;
    private Rigidbody2D body;

    private float intialVolume;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        body = GetComponent<Rigidbody2D>();
        intialVolume = source.volume;
    }

    // Update is called once per frame
    void OnCollisionEnter2D()
    {
        if (body != null && body.velocity.magnitude > 3f)
        {
            if (source != null) {
                source.Play();
                source.volume = intialVolume + Mathf.Log(body.velocity.magnitude) * 0.05f;
                source.pitch = Random.Range(0.3f, 1f);
            }
        }
    }
}
