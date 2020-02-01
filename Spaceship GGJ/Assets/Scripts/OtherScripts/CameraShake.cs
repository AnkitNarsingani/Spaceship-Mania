using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CameraShake : MonoBehaviour
{

    Vector3 cameraInitialPosition;
    public float shakeMagnetude = 0.05f, shakeTime = 0.5f;
    public float waitTime = 0.4f;
    public float frequency = 0.5f;
    public float cameraBobbSpeed = 20f;
    Camera mainCamera;
    public Animator anim;
    public Image image;
    Color tempColor;
    Vector3 camPosition;


    void Start()
    {
        mainCamera = Camera.main;
        camPosition = mainCamera.transform.position;
    }
    public void ShakeIt()
    {
        cameraInitialPosition = mainCamera.transform.position;
        InvokeRepeating("StartCameraShaking", 0f, 0.005f);
        Invoke("StopCameraShaking", shakeTime);
        anim.enabled = true;
        anim.Play("HitImage_Hit");
    }

    void Update()
    {
       
        //camPosition.y = transform.position.y+ BobbCamera();
        transform.position = camPosition+BobbCamera();
    }

    Vector3 BobbCamera()
    {
        return new  Vector3(0, Mathf.Sin(Time.time * cameraBobbSpeed / 10) * frequency,0);
    }

    void StartCameraShaking()
    {
        float cameraShakingOffsetX = UnityEngine.Random.value * shakeMagnetude * 2 - shakeMagnetude;
        float cameraShakingOffsetY = UnityEngine.Random.value * shakeMagnetude * 2 - shakeMagnetude;
        Vector3 cameraIntermadiatePosition = mainCamera.transform.position;
        cameraIntermadiatePosition.x += cameraShakingOffsetX;
        cameraIntermadiatePosition.y += cameraShakingOffsetY;
        mainCamera.transform.position = cameraIntermadiatePosition;


    }

    void StopCameraShaking()
    {
        CancelInvoke("StartCameraShaking");
        mainCamera.transform.position = cameraInitialPosition;
        anim.enabled = false;
        tempColor = image.color;
        tempColor.a = 0;
        image.color = tempColor;

    }


}
