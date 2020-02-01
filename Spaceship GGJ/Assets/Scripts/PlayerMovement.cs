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
    float MaxTurnSpeedREF;

    [SerializeField] Vector3 direction;
    Rigidbody rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        MovePlayer();
        RotatePlayer();
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
        transform.Translate(direction.normalized * speed * Time.deltaTime,Space.World);

    }

    private void RotatePlayer()
    {
        if (direction != Vector3.zero)
        {
            float targetRotation = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            transform.eulerAngles = Vector3.up *  Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation,ref MaxTurnSpeedREF, MaxTurnSpeed);
        }

    }

    public KeyCode GetActionKey()
    {
        return Action;
    }
}
