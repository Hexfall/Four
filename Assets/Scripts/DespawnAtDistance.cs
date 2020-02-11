using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnAtDistance : MonoBehaviour
{
    public Transform camera;
    public float maxDist = 100f;

    // Start is called before the first frame update
    void Start()
    {
        if (camera == null)
        {
            camera = GameObject.FindGameObjectWithTag("MainCamera").transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if ((camera.position + transform.position).magnitude > maxDist)
        {
            gameObject.SetActive(false);
        }
    }
}
