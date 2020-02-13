using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDestructionParticles : MonoBehaviour
{
    public GameObject destructionParticles;

    // Update is called once per frame
    void OnDestroy()
    {
        GameObject particleObject = Instantiate(destructionParticles, transform.position, transform.rotation);
        ParticleSystem particle = particleObject.GetComponent<ParticleSystem>();
        ParticleSystem.MainModule main = particle.main;
        main.startColor = GetComponent<SpriteRenderer>().color;
        Destroy(particleObject, 5);
        particleObject.StartCoroutine(Commons.DelayedAction(() => print("test"), 2));
        // StartCoroutine(Commons.DelayedAction(() => Destroy(particleObject), 1));
    }
}
