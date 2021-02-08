using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Vector3 moveVector = Vector3.zero;
    CharacterController characterController;

    [SerializeField] private float walkSpeed = 6.0f;
    [SerializeField] private float jumpSpeed = 6.0f;
    [SerializeField] private float gravity = 10.0f;
    //private bool isRunning;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        moveVector.x = Input.GetAxis("Horizontal") * walkSpeed;
        moveVector.z = Input.GetAxis("Vertical") * walkSpeed;

        if (characterController.isGrounded && Input.GetKey(KeyCode.Space))
        {
            moveVector.y = jumpSpeed;
        }

        moveVector.y -= gravity * Time.deltaTime;

        characterController.Move(moveVector * Time.deltaTime);
    }
}

