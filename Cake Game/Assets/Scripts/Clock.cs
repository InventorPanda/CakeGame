using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    [SerializeField]
    private const float REAL_SECONDS_PER_DAY = 700f;

    private float day;

    public Text time;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        day += Time.deltaTime / REAL_SECONDS_PER_DAY;

        float dayNormalized = day % 1f;

        float hoursPerDay = 24f;
        string hoursString = Mathf.Floor(dayNormalized * hoursPerDay).ToString("00");

        float minutesPerHour = 60f;
        string minutesString = (((dayNormalized * hoursPerDay) % 1f) * minutesPerHour).ToString("00");

        time.text = hoursString + ":" + minutesString;

    }
}
