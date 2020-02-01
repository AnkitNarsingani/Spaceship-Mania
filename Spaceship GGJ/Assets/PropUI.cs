using UnityEngine;
using UnityEngine.UI;


public class PropUI : MonoBehaviour
{
    ProgressBar progressBar;
    void Start()
    {
        progressBar = GetComponent<ProgressBar>();
        progressBar.restart = true;
        progressBar.currentPercent = 0;
        progressBar.isOn = true;
    }
    void OnEnable()
    {
        if (progressBar)
        {
            progressBar.restart = true;
            progressBar.currentPercent = 0;
            progressBar.isOn = true;
        }
    }

    void Update()
    {
        if (progressBar.currentPercent <= 100)
        {
            //Subtract Health
        }
    }



}