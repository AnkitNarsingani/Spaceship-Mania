using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

  
    public float speed = 5;


    private void Start()
    {
        Invoke("Destroy", 10);
    }
    void Update ()
    {
        transform.localPosition += transform.right *speed* Time.deltaTime;
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }

}
