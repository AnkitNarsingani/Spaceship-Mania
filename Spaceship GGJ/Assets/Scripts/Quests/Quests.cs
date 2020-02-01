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

    public Transform IconHolder;
    public GameObject Icon;

    public GameObject brokenParticleEffect;

    public Transform timerHolder;
    public Image CompletionCircle;
    protected float fillAmount = 0;

    [HideInInspector] public GameEvent OnQuestComplete;

    void Start()
    {
        CompletionCircle.fillAmount = 0;
    }

    protected virtual void Update()
    {
        if (isActivated)
        {
            CompletionCircle.fillAmount = Mathf.Lerp(CompletionCircle.fillAmount, fillAmount, Time.deltaTime * 7);
            Icon.transform.position = Camera.main.WorldToScreenPoint(IconHolder.position);
            CompletionCircle.transform.position = Camera.main.WorldToScreenPoint(timerHolder.position);
        }
    }

    public virtual void Activate()
    {
        isActivated = true;
        GetComponent<Collider>().enabled = true;
        Icon.SetActive(true);
        CompletionCircle.gameObject.SetActive(true);
        if (brokenParticleEffect != null) brokenParticleEffect.SetActive(true);
        if (OnActivate != null) OnActivate.Raise();
    }

    public virtual void Complete()
    {
        isActivated = false;

        QuestManager.questsActive--;

        Icon.SetActive(false);
        fillAmount = 0;
        CompletionCircle.fillAmount = 0;
        CompletionCircle.gameObject.SetActive(false);
        if (brokenParticleEffect != null)  brokenParticleEffect.SetActive(false);
        GetComponent<Collider>().enabled = false;

        if (OnRepair != null) OnRepair.Raise();
        if (OnQuestComplete != null) OnQuestComplete.Raise();
    }
}
