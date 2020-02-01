using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quests : MonoBehaviour
{
    public bool isActivated { get; private set; }

    public GameEvent OnActivate;
    public GameEvent OnComplete;

    public Transform exclamationPointHolder;
    public GameObject exclamationPoint;

    public GameObject brokenParticleEffect;

    public Transform timerHolder;
    public Image CompletionCircle;
    protected float fillAmount = 0;

    void Start()
    {
        CompletionCircle.fillAmount = 0;
    }

    protected virtual void Update()
    {
        if (isActivated)
        {
            CompletionCircle.fillAmount = Mathf.Lerp(CompletionCircle.fillAmount, fillAmount, Time.deltaTime * 7);
            exclamationPoint.transform.position = Camera.main.WorldToScreenPoint(exclamationPointHolder.position);
            CompletionCircle.transform.position = Camera.main.WorldToScreenPoint(timerHolder.position);
        }
    }

    public virtual void Activate()
    {
        isActivated = true;
        GetComponent<Collider>().enabled = true;
        exclamationPoint.SetActive(true);
        CompletionCircle.gameObject.SetActive(true);
        brokenParticleEffect.SetActive(true);
        if (OnActivate != null) OnActivate.Raise();
    }

    public virtual void Complete()
    {
        Debug.Log("Complete", this);
        isActivated = false;

        QuestManager.questsActive--;

        exclamationPoint.SetActive(false);
        CompletionCircle.fillAmount = 0;
        CompletionCircle.gameObject.SetActive(false);
        brokenParticleEffect.SetActive(false);
        GetComponent<Collider>().enabled = false;

        if (OnActivate != null) OnComplete.Raise();
    }
}
