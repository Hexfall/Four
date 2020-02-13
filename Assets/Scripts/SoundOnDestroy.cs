using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOnDestroy : MonoBehaviour
{
    public AudioClip clip;

    void OnDestroy()
    {
        GameObject s = Instantiate(new GameObject(), transform.position, transform.rotation);
        AudioSource source = s.AddComponent<AudioSource>();
        source.PlayOneShot(clip);
        Destroy(source, clip.length);
    }
}
