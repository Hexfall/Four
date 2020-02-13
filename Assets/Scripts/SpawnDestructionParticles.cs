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
        ParticleSystem.EmissionModule emission = particle.emission;
        main.startColor = GetComponent<SpriteRenderer>().color;
        Destroy(particleObject, 5f);
        GameManager.instance.GlobalCorutine(() => {emission.enabled = false;}, 0.3f);
        particleObject.transform.position = particleObject.transform.position + new Vector3(0,0,-0.2f);
        // particleObject.StartCoroutine(Commons.DelayedAction(() => print("test"), 2));
        // StartCoroutine(Commons.DelayedAction(() => Destroy(particleObject), 1));
    }
}
