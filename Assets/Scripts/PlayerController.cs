using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float speed = 2.5f;
    [SerializeField] private Rigidbody2D rb;                                     // Declaring Global variables
    [SerializeField]private float upwardForce = 0.2f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");                            
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);           // making player move by horizontal input

        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(new Vector2(0, upwardForce), ForceMode2D.Impulse);          // Making Player Jump
        }










    }
}
