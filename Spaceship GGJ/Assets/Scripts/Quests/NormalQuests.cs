using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalQuests : Quests
{
    public float timeToHold = 2f;

    private float timer = 0f;
    private KeyCode action;
    private bool playerEntered = false;

    void Start()
    {

    }

    protected override void Update()
    {
        if (isActivated)
        {
            base.Update();

            if (action != KeyCode.None && Input.GetKey(action))
            {
                timer += Time.deltaTime;
            }
            else if (Input.GetKeyUp(action))
            {
                timer = 0;
            }

            if (timer > timeToHold)
                Complete();

            fillAmount = timer / timeToHold;
        }
    }

    public override void Complete()
    {
        base.Complete();
        ResetQuest();
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerMovement player = other.GetComponent<PlayerMovement>();

        if (player != null)
        {
            playerEntered = true;
            action = player.GetActionKey();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        ResetQuest();
    }

    private void ResetQuest()
    {
        playerEntered = true;
        action = KeyCode.None;
        timer = 0;
    }
}
