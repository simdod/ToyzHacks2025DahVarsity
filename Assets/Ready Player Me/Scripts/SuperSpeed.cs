using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class SuperSpeed : MonoBehaviour
{
    public float normalSpeed = 5f;
    public float superSpeed = 20f;
    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        float moveSpeed = Input.GetKey(KeyCode.LeftShift) ? superSpeed : normalSpeed;
        float moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float moveZ = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        characterController.Move(move);
    }
}

