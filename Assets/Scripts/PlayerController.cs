using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System.Runtime.CompilerServices;
using Valve.VR;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;
    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    private int pickupCount = 15;
    private bool alreadyWon = false;

    [SerializeField] private AudioClip pickupSound;

    public float timeLeft;
    public TextMeshProUGUI timerText;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
    }

    private void Update()
    {
        if (timeLeft > 0 && !alreadyWon)
        {
            timeLeft -= Time.deltaTime;
        } else 
        {
            if (!alreadyWon)
            {
                LoseScreen();
            }
        }
        int minutes = Mathf.FloorToInt(timeLeft / 60);
        int seconds = Mathf.FloorToInt(timeLeft % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        if (gameObject.transform.position.y < -5 && !alreadyWon)
        {
            ResetBall();
            timeLeft -= 10;
        }
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
            AudioSource.PlayClipAtPoint(pickupSound, GameObject.FindGameObjectWithTag("MainCamera").transform.position);
        }
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= pickupCount)
        {
            winTextObject.SetActive(true);
            deleteText();
            alreadyWon = true;
        }
    }

    private void deleteText()
    {
        countText.text = "";
        timerText.text = "";
    }

    private void LoseScreen()
    {
        // Destroy the current object
        Destroy(gameObject);
        // Update the winText to display "You Lose!"
        deleteText();
        winTextObject.gameObject.SetActive(true);
        winTextObject.GetComponent<TextMeshProUGUI>().text = "You Lose!";
    }

    private void ResetBall()
    {
        gameObject.transform.position = new Vector3(0.0f, 10.0f, 0.0f);
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

}
