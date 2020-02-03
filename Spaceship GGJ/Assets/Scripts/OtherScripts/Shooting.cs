using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

    public List<Transform> spawnPoints = new List<Transform>();
    public List<Vector3> directionPool = new List<Vector3>();

    public GameObject bulletPrefab;
    float timer;
    public float rateOfFire=1;

    void Start ()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            spawnPoints.Add(transform.GetChild(i));
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        timer += Time.deltaTime;
        if(timer>=rateOfFire)
        {
            timer = 0;
            Shoot();
        }
	}

    void Shoot()
    {
        int random = Random.Range(0, spawnPoints.Count);
        Quaternion current= Quaternion.Euler(directionPool[Random.Range(0, directionPool.Count)]);
        Instantiate(bulletPrefab, spawnPoints[random].transform.position, current);
        AudioManager.instance.Play("Beam");
    }
}
