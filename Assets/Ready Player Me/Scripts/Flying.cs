using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class FlightController : MonoBehaviour
{
    public float flightSpeed = 10f;
    public float liftSpeed = 5f;
    private bool isFlying = false;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) // Press 'F' to toggle flight mode
        {
            isFlying = !isFlying;
            rb.useGravity = !isFlying;
        }

        if (isFlying)
        {
            float moveVertical = Input.GetAxis("Vertical") * flightSpeed * Time.deltaTime;
            float moveHorizontal = Input.GetAxis("Horizontal") * flightSpeed * Time.deltaTime;
            float ascend = Input.GetKey(KeyCode.Space) ? liftSpeed * Time.deltaTime : 0;
            float descend = Input.GetKey(KeyCode.LeftShift) ? -liftSpeed * Time.deltaTime : 0;

            transform.position += new Vector3(moveHorizontal, ascend + descend, moveVertical);
        }
    }
}
