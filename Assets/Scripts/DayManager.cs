using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayManager : MonoBehaviour
{
    public GameObject triangle;


    [SerializeField] public TimeManager timeManager;
    // Start is called before the first frame update
    void Start()
    {
        if(timeManager == null)
        {
            Debug.Log("Can't find TimeManager Script");
            timeManager = FindAnyObjectByType<TimeManager>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (timeManager != null && timeManager.currentDay == 2)
        {
            triangle.SetActive(false);
        }

    }
}
