using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public Sprite active;
    public Sprite passive;
    public Button Easy;
    public Button Medium;
    public Button Hard;
    public GameObject panel;
    private int difficulty;
    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
        if (difficulty == 0)
        {
            Easy.image.sprite = active;
            Medium.image.sprite = passive;
            Hard.image.sprite = passive;
        }
        if (difficulty == 1)
        {
            Easy.image.sprite = passive;
            Medium.image.sprite = active;
            Hard.image.sprite = passive;
        }
        if (difficulty == 2)
        {
            Easy.image.sprite = passive;
            Medium.image.sprite = passive;
            Hard.image.sprite = active;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowSettings()
    {
        panel.SetActive(true);
    }

    public void HideSettings()
    {
        panel.SetActive(false);
    }

    public void SetDifficulty(int difficulty)
    {
        this.difficulty = difficulty;
        if (difficulty == 0)
        {
            Easy.image.sprite = active;
            Medium.image.sprite = passive;
            Hard.image.sprite = passive;
        }
        if (difficulty == 1)
        {
            Easy.image.sprite = passive;
            Medium.image.sprite = active;
            Hard.image.sprite = passive;
        }
        if (difficulty == 2)
        {
            Easy.image.sprite = passive;
            Medium.image.sprite = passive;
            Hard.image.sprite = active;
        }
    }
    private void OnEnable() 
    {
        difficulty = GlobalSettings.gameSpeed;
    }
    private void OnDisable()
    {
        GlobalSettings.gameSpeed = difficulty;
    }
}
