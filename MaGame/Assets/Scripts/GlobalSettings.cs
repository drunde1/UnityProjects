using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalSettings : MonoBehaviour
{
    public static int gameSpeed;
    public static bool isPaused = false;
    private void Start()
    {
        Debug.Log("Started");
    }
}
