using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TimeController : MonoBehaviour
{

    public float max_time;
    [Range(0,100000)]
    private float current_time;
    public Text time_text;
    public bool time_end;
    // Start is called before the first frame update
    void Start()
    {
        time_end = false;
        current_time = max_time;
    }

    // Update is called once per frame
    void Update()
    {

        if (current_time > 0)
        {
            current_time = current_time - Time.deltaTime;
            time_text.text = current_time.ToString("0");
        }

        if (current_time <=0)
        {
            time_end = true;
        }
    }
}
