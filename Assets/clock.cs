using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class clock : MonoBehaviour
{
    // Start is called before the first frame update
    private const float
        hoursToDegrees = 360f / 12f,
        minutesToDegrees = 360f / 60f,
        secondsToDegrees = 360f / 60f;

    public Transform hours, minutes, seconds;
    private DateTime oldTime;

    // Start is called before the first frame update
    void Start()
    {
        oldTime = DateTime.Now;
    }

    // Update is called once per frame
    void Update()
    {
        DateTime time = DateTime.Now;
        if (time > oldTime)
        {
            seconds.localRotation = Quaternion.Euler(time.Second * secondsToDegrees, 0f, 0f);

            TimeSpan timespan = DateTime.Now.TimeOfDay;
            hours.localRotation =
                Quaternion.Euler((float)timespan.TotalHours * hoursToDegrees, 0f, 0f);
            minutes.localRotation =
                Quaternion.Euler((float)timespan.TotalMinutes * minutesToDegrees, 0f, 0f);
            oldTime = time;
        }
    }
}