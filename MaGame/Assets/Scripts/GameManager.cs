using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private const float EASY = 0.7f;
    private const float MEDIUM = 1f;
    private const float HARD = 1.3f;
    private float score = 0;
    public static GameManager Instance { get; private set; }
    public GameObject panelPause;
    public GameObject panelGameOver;
    public Text textScore1;
    public Text textScore2;
    public GameObject Player;

    public float gameSpeed { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else 
        {
            DestroyImmediate(gameObject);
        }
    }
    private void OnDestroy()
    {
        if(Instance == this)
        {
            Instance = null;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        OnPause(false);
        panelGameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!GlobalSettings.isPaused)
        {
            score += 0.01f * gameSpeed;
            textScore1.text = ((int)score).ToString();
            textScore2.text = ((int)score).ToString();
        }
        if (Player.transform.position.y < -8f || Player.transform.position.y > 8f)
        {
            panelGameOver.SetActive(true);
            Time.timeScale = 0f;
            GlobalSettings.isPaused = true;
        }

    }

    public void ChangeDifficulty(int level = 1)
    {
        if (level == 0) { gameSpeed = EASY; }
        if (level == 1) { gameSpeed = MEDIUM; }
        if (level == 2) { gameSpeed = HARD; }
    }
    private void OnEnable()
    {
        ChangeDifficulty(GlobalSettings.gameSpeed);
    }

    public void OnPause(bool pause)
    {
        if (pause)
        {
            panelPause.SetActive(true);
            Time.timeScale = 0f;
            GlobalSettings.isPaused = true;
        }
        else
        {
            panelPause.SetActive(false);
            Time.timeScale = 1f;
            GlobalSettings.isPaused = false;

        }
    }

    public void toMenu(int index)
    {
        SceneManager.LoadScene(index);
    }


}
