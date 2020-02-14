using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOnDestroy : MonoBehaviour
{
    public AudioClip clip;

    public float pitch = 1f;

    public Player player;

    public void DoDestroy()
    {
        GameObject s = new GameObject();
        s.transform.position = transform.position;
        s.transform.rotation = transform.rotation;
        AudioSource source = s.AddComponent<AudioSource>();
        if (player != null)
            source.pitch = player.getComboPitch();
        source.PlayOneShot(clip);
        GameManager.instance.GlobalCorutine(() => Destroy(s), clip.length);
    }
}
