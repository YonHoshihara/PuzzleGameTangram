using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    // Start is called before the first frame update
    public TimeController time_controller;
    public GameObject game_over_feedback;
    public bool game_over;
    
    public IEnumerator Start()
    {
        game_over = false;
        while (true)
        {
            if (time_controller.time_end)
            {
                Debug.Log(time_controller.time_end);
                GameOver();
            }
            yield return new WaitForSeconds(.01f);
        }

    }

    // Update is called once per frame
    
    public void GameOver()
    {
        game_over = true;
        game_over_feedback.SetActive(true);
    }
    void Update()
    {
        
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
