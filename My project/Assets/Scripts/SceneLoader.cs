using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Timers;


public class SceneLoader : MonoBehaviour
{
    private System.Timers.Timer timer;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SceneLoad(int index)
    {
        SceneManager.LoadScene(index);
    }
}
