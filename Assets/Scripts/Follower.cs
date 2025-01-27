using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    public Transform leader;
    private float speed = 2.0f;
    private float maxDistance = 3.0f;

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        if (Vector3.Distance(transform.position, leader.transform.position) > maxDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, leader.transform.position, step);
        }
    }
}
