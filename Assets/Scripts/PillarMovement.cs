using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PillarMovement : MonoBehaviour
{
    public float maxHeight;
    public float speed = 1.0f;

    private bool movingUp = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var step = speed * Time.deltaTime; // calculate distance to move
        //transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }
}
