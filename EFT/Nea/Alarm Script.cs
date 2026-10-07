using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AlarmScript : MonoBehaviour
{
    [SerializeField] private AudioSource alarm;

    void Start()
    {
        //Invoke("wakeup", 10f);  // Time that it takes for the alarm to start
    }

    void wakeup()
    {
        alarm.enabled = true;

    }

    private void OnEnable()
    {
        AlarmSystem.AlarmActivated += wakeup;
    }

    private void OnDisable()
    {
        AlarmSystem.AlarmActivated -= wakeup;
    }

}
