using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShoot : MonoBehaviour
{
    public Bullet bullet;
    public Transform shootPosition;
    private float timeBetweenShoot = 5f;


    private Animator anim;
    private float timer = 0f;
    private CoordinationQuestsSync turretQuest;

    void Start()
    {
        anim = GetComponent<Animator>();
        turretQuest = GetComponent<CoordinationQuestsSync>();
    }

    void Update()
    {
        if(timer > timeBetweenShoot)
        {
            Bullet b = Instantiate(bullet, shootPosition.position, Quaternion.identity);
            b.transform.eulerAngles = new Vector3(b.transform.eulerAngles.x, b.transform.eulerAngles.y + 180, b.transform.eulerAngles.z);
            anim.SetTrigger("Shoot");
            timeBetweenShoot = Random.Range(1, 6);
            timer = 0;
        }

        if(!turretQuest.isActivated)
            timer += Time.deltaTime;
    }
}
