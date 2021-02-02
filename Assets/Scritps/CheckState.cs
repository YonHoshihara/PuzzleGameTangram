using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckState : MonoBehaviour
{
    public bool complete;
    float timer;
    Moviment[] obj;
    
    
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        complete = false;
        obj = FindObjectsOfType<Moviment>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer>=0.2f){
            timer = 0;
            int sum = 0;
            for(int i = 0;i < obj.Length; i++){
                if(obj[i].is_conected){
                    sum++;
                }

            }
            if (sum>=obj.Length ){
                    complete = true;
            }
        }
    }
}
