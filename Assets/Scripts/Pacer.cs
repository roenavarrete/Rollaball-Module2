using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pacer : MonoBehaviour
{
    public float speed = 5.0f;
    private float xMax = 7.5f;
    private float xMin = 3.5f;
    private int direction = 1;

    // Update is called once per frame
    void Update()
    {
        float xNew = transform.position.x + 
            direction * speed * Time.deltaTime;
        if (xNew >= xMax)
        {
            xNew = xMax;
            direction *= -1;
            }
        else if (xNew <= xMin)
        {
            direction *= -1;
            xNew = xMin;
        }
        transform.position = new Vector3(xNew, 0.75f, -5.25f);
    }
}
