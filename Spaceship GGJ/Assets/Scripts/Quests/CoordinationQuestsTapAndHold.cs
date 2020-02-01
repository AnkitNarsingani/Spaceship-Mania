using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoordinationQuestsTapAndHold : Quests
{
    public float timeToHold = 2f;

    private bool firstPlayerEntered = false, secondPlayerEntered = false;
    private KeyCode firstPlayerActionKey, secondPlayerActionKey;

    private bool canTime;
    private float timer = 0f;

    void Start()
    {

    }

    protected override void Update()
    {
        if (isActivated)
        {
            base.Update();

            if (firstPlayerEntered || secondPlayerEntered)
            {
                if (canTime)
                {
                    timer += Time.deltaTime;
                    if (timer > timeToHold) Complete();
                }

                if (firstPlayerActionKey != KeyCode.None && secondPlayerActionKey != KeyCode.None &&
                    Input.GetKey(firstPlayerActionKey) && Input.GetKey(secondPlayerActionKey))
                {
                    canTime = true;
                    fillAmount = 1f;
                }

                if (Input.GetKey(firstPlayerActionKey) && !Input.GetKey(secondPlayerActionKey))
                {
                    fillAmount = 0.5f;
                }
                else if (!Input.GetKey(firstPlayerActionKey) && Input.GetKey(secondPlayerActionKey))
                {
                    fillAmount = 0.5f;
                }

                if (Input.GetKeyUp(firstPlayerActionKey) && !Input.GetKey(secondPlayerActionKey))
                {
                    fillAmount = 0;
                }
                else if (!Input.GetKey(firstPlayerActionKey) && Input.GetKeyUp(secondPlayerActionKey))
                {
                    fillAmount = 0;
                }
            }
        }
    }

    public override void Complete()
    {    
        base.Complete();
        ResetQuest();
    }

    private void ResetQuest()
    {
        canTime = false;
        timer = 0;
        firstPlayerActionKey = KeyCode.None;
        secondPlayerActionKey = KeyCode.None;
        firstPlayerEntered = false;
        secondPlayerEntered = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerMovement player = other.GetComponent<PlayerMovement>();

        if (player != null && !firstPlayerEntered)
        {
            firstPlayerEntered = true;
            firstPlayerActionKey = player.GetActionKey();
        }
        else if (player != null && firstPlayerEntered)
        {
            secondPlayerEntered = true;
            secondPlayerActionKey = player.GetActionKey();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerMovement player = other.GetComponent<PlayerMovement>();

        if (player != null && firstPlayerEntered)
        {
            firstPlayerEntered = false;
            firstPlayerActionKey = KeyCode.None;
        }
        else if (player != null && !firstPlayerEntered)
        {
            secondPlayerEntered = false;
            secondPlayerActionKey = KeyCode.None;
        }
    }
}
