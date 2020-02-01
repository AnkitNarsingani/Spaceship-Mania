using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quests : MonoBehaviour
{
    public bool isActivated { get; private set; }

    public GameEvent OnActivate;
    public GameEvent OnRepair;

    public Transform exclamationPointHolder;
    public GameObject exclamationPoint;

    public GameObject brokenParticleEffect;

    public Transform timerHolder;
    public Image CompletionCircle;
    protected float fillAmount = 0;

    public GameEvent OnQuestComplete;

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
        isActivated = false;

        QuestManager.questsActive--;

        exclamationPoint.SetActive(false);
        fillAmount = 0;
        CompletionCircle.fillAmount = 0;
        CompletionCircle.gameObject.SetActive(false);
        brokenParticleEffect.SetActive(false);
        GetComponent<Collider>().enabled = false;

        if (OnRepair != null) OnRepair.Raise();
        if (OnQuestComplete != null) OnQuestComplete.Raise();
    }
}
