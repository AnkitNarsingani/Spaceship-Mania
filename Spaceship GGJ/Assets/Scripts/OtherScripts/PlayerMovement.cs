using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] KeyCode UP;
    [SerializeField] KeyCode DOWN;
    [SerializeField] KeyCode LEFT;
    [SerializeField] KeyCode RIGHT;
    [SerializeField] KeyCode Action;


    [SerializeField] float speed = 5;
    [SerializeField] float MaxTurnSpeed = 0.2f;
    [SerializeField] float playerBobbSpeed = 0.2f;
    [SerializeField] float frequency = 0.2f;
    float MaxTurnSpeedREF;

    Vector3 direction;
    Rigidbody rigidBody;
    bool canBob = false;
    bool canMove = true;


    Animator anim;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (canMove)
        {
            MovePlayer();
            RotatePlayer();
        }
        if (Input.GetKey(Action))
            anim.SetTrigger("isInteracting");

    }

    private void MovePlayer()
    {
        if (Input.GetKey(UP))
            direction.z = -1;
        else if (Input.GetKey(DOWN))
            direction.z = 1;
        else
            direction.z = 0;

        if (Input.GetKey(RIGHT))
            direction.x = -1;
        else if (Input.GetKey(LEFT))
            direction.x = 1;
        else
            direction.x = 0;
        if (canBob)
            direction.y = transform.position.y + PlayerBobbing();
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
        anim.SetBool("isMoving", Mathf.Abs(direction.x) != 0 || Mathf.Abs(direction.z) != 0);

    }

    private void RotatePlayer()
    {
        if (direction != Vector3.zero)
        {
            float targetRotation = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref MaxTurnSpeedREF, MaxTurnSpeed);
        }

    }

    public KeyCode GetActionKey()
    {
        return Action;
    }

    float PlayerBobbing()
    {
        return Mathf.Sin(Time.time * playerBobbSpeed / 10) * frequency;
    }

    public void StartBobbing()
    {
        canBob = true;
    }

    public void StopBobbing()
    {
        canBob = false;
    }

    public void SetMovement(bool bCanMove)
    {
        canMove = bCanMove;
    }
}
