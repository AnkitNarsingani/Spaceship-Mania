using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance { get; private set; }

    [SerializeField] private List<Quests> quests;
    [SerializeField] private float timeBetweenQuests = 5f;

    [HideInInspector] public static float questsActive;

    private float timer = 0f;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {

    }

    void Update()
    {
        if (timer > timeBetweenQuests)
        {
            Quests q = GetNextQuest();
            if (q != null) q.Activate();
            timer = 0f;
        }

        timer += Time.deltaTime;

        if(Time.timeSinceLevelLoad > 60 && Time.timeSinceLevelLoad < 120)
        {
            timeBetweenQuests = 4;
        }
        if(Time.timeSinceLevelLoad > 120 && Time.timeSinceLevelLoad < 180)
        {
            timeBetweenQuests = 3;
        }
        if (Time.timeSinceLevelLoad > 180 && Time.timeSinceLevelLoad < 240)
        {
            timeBetweenQuests = 2;
        }
    }

    public Quests GetNextQuest()
    {
        if (questsActive != quests.Count)
        {
            int index = Random.Range(0, quests.Count);

            if (!quests[index].isActivated)
            {
                questsActive++;
                return quests[index];
            }
            else
            {
                return GetNextQuest();
            }
        }
        else
            return null;
    }
}
