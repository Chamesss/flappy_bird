using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class BirdScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Rigidbody2D birdRigidbody;
    [SerializeField]private float jumpForce;
    private ScoreScript logic;
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("logic").GetComponent<ScoreScript>();
        if (logic == null)
            Debug.LogError("No ScoreScript found");
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            birdRigidbody.linearVelocity = Vector2.up * jumpForce;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic?.GameOver();
    }
    
    // get offbounds of the screen
    private void OnBecameInvisible()
    {
        logic?.GameOver();
    }

}
