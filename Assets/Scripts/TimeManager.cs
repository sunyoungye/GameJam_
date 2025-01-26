using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.UIElements;
using Unity.VisualScripting;

public class TimeManager : MonoBehaviour
{
    public static Action OnMinuteChanged;
    public static Action OnHourChanged;

    public static int Minute {  get; private set; }
    public static int Hour { get; private set; }

    //Time Fast 
    private float minuteToRealTime = 0.5f;
    private float timer;
    private bool isPaused = false;

    //Day
    public int currentDay = 1;
    private const int fullDay = 30;
    public TextMeshProUGUI dayCount;

    //Panel
    public GameObject pop_up;
    private Button nextDay;

    void Start()
    {
        InitilizeTime();
        pop_up.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isPaused) return;

        // For Time
        timer -= Time.deltaTime;


        if(timer <= 0)
        {
            Minute++;
            OnMinuteChanged?.Invoke();
            if(Minute >= 60)
            {
                Hour++;
                Minute = 0;
                OnHourChanged?.Invoke();
            }

            timer = minuteToRealTime;
        }

        if(Hour == 24)
        {
            pop_up.SetActive(true);
            isPaused = true;
        }
    }

    private void InitilizeTime()
    {
        isPaused = false;
        Minute = 56;
        Hour = 23;
        timer = minuteToRealTime;
    }

    public void CurrentDay()
    {
        dayCount.text = $"Day:{currentDay = currentDay + 1}";
    }

    public void OnButtonNextDay()
    {
        InitilizeTime();
        Debug.Log("is Next Day");
        pop_up.SetActive(false);
        CurrentDay(); 
    }

}
