using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class BallLaunch : MonoBehaviour
{

    public SteamVR_Action_Boolean shootBallAction = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("ShootBall");
    public float launchPower = 100.0f;

    private AudioSource shootSound;

    // Start is called before the first frame update
    void Start()
    {
        shootSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LaunchBall()
    {
        bool isShooting = shootBallAction.GetState(SteamVR_Input_Sources.Any);
        if (isShooting)
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            Vector3 headPosition = GameObject.FindGameObjectWithTag("MainCamera").transform.position;
            Vector3 launchDirection = (transform.position - headPosition).normalized;
            rb.AddForce(launchDirection * launchPower);
            shootSound.Play();
        }
    }
}
