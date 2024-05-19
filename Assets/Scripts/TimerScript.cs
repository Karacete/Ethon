using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    private float minute;
    public float second;
    [SerializeField]
    private TextMeshProUGUI minText;
    [SerializeField]
    private TextMeshProUGUI secText;
    void Start()
    {
        minute = 1;
        second = 59;
    }

    void Update()
    {
        second -= Time.deltaTime;
        minText.text = minute.ToString();
        secText.text = Convert.ToInt32(second).ToString();
        if(second<=0)
        {
            if(minute<=0)
            {
                Time.timeScale = 0f;
            }
            else
            {
                minute -= 1;
                second = 59;
            }
        }
        if(second>59)
        {
            minute += 1;
            second -= 59;
        }
    }
}
