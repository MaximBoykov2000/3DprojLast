﻿using UnityEngine;


public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 2;
    public float runSpeed = 4;
    public float jumpPower = 10;
    public float mouse_x = 10;
    public float mouse_y = 10;
    public Transform cam;
    public float max_angle = 70, min_angle = -60;

    private Rigidbody rbody;
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
    }

    float angle = 0;
    bool jumpCommand = false;
    void Update()
    {
        jumpCommand |= Input.GetButtonDown("Jump");
        var mouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        transform.rotation *= Quaternion.Euler(0, mouseInput.x * mouse_x * Time.deltaTime, 0);
        angle = Mathf.Clamp(angle - mouseInput.y * mouse_y * Time.deltaTime, -max_angle, -min_angle);
        cam.localRotation = Quaternion.Euler(angle, 0, 0);
    }
    private void FixedUpdate()
    {
        var motionInput = transform.rotation * new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        motionInput.x += rbody.velocity.x;
        motionInput.z += rbody.velocity.z;
        var speed = Input.GetButton("Fire3") ? runSpeed : moveSpeed;
        motionInput = Vector3.ClampMagnitude(motionInput, speed);

        motionInput.y = rbody.velocity.y;
        if (jumpCommand)
        {
            jumpCommand = false;
            if (Physics.Raycast(transform.position, Vector3.down, 1.2f))
            {
                motionInput.y = jumpPower;
            }
        }
        rbody.velocity = motionInput;
    }
}
