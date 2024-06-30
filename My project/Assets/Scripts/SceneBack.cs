using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;
using UnityEngine.SceneManagement;

public class SceneBack : MonoBehaviour
{
    private System.Timers.Timer timer;
    private bool flag;
    // Start is called before the first frame update
    void Start()
    {
        flag = false;
        timer = new System.Timers.Timer();
        timer.Interval = 5000;
        timer.Elapsed += BackToFirstScene;
        timer.Start();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(flag) { SceneLoad(); }
        if (Input.anyKeyDown)
        {
            timer.Stop();
            timer.Start();
        }
        if (Input.GetMouseButtonUp(0)) 
        {
            timer.Start();
        }
        if (Input.GetMouseButtonDown(0)) 
        {
            timer.Stop();
        }

    }

    private void SceneLoad()
    {
        SceneManager.LoadScene("Scenes/FirstScene");
    }

    public void BackToFirstScene(object sender, ElapsedEventArgs e)
    {
        timer.Stop();
        flag = true;
    }

    public void RotateDown()
    {
        timer.Stop();
    }

    public void RotateUp()
    {
        timer.Start();
    }

}
