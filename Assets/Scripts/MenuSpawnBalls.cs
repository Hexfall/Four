using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSpawnBalls : MonoBehaviour
{
    [SerializeField] private Transform ballZone;
    [SerializeField] private GameObject ball;

    [SerializeField] private float ballSize = 5f;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = -10; i < 11; i++)
        {
            for (int j = 0; j < 40; j++)
            {
                Vector3 offset = new Vector2(i * ballSize, j * ballSize * 4);
                offset += (Vector3) Random.insideUnitCircle;
                Vector3 location = ballZone.position + offset;
                Quaternion rotation = new Quaternion();
                GameObject clone = Instantiate(ball, location, rotation);
                SpriteRenderer renderer = clone.GetComponent<SpriteRenderer>();
                renderer.color = Random.ColorHSV();
            }
        }
    }
}
