using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundPoint : MonoBehaviour
{
    public Vector3 pivot;
    public float distance;
    private float place;

    public float speed = 1f;
    // Update is called once per frame
    void Update()
    {
        place += Time.deltaTime * speed;
        float x = Mathf.Sin(place) * distance;
        float y = Mathf.Cos(place) * distance;
        transform.position = pivot + new Vector3(x, y, 0); 
    }
}
