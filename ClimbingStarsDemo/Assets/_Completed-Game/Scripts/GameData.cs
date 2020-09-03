using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameData : MonoBehaviour {
    
    public Text scoreText, distanceText, coinText;
    public float timer;
    public Text levelName;
    public GameObject gameWinPopUP, gameOverPopUp, pausePopUp;
    public bool hasReachedTop;
    
    public static GameData _instance;

    public int coins, score;
    int level, unlockedLevelIndex;
    float distance;
    Vector3 initialPos;
    private void Awake()
    {
        _instance = this;
    }

    // Use this for initialization
    void Start()
    {
        //Transform parent = GameObject.Find("Canvas").transform;
        //gameOverPopUp = Instantiate(Resources.Load("Prefabs/GameOverPopUp"), parent)  as GameObject;
        //gameWinPopUP = Instantiate(Resources.Load("Prefabs/GameWinPopUP"), parent) as GameObject;
        //pausePopUp = Instantiate(Resources.Load("Prefabs/PausePopUP"), parent) as GameObject;
        gameOverPopUp.SetActive(false);
        gameWinPopUP.SetActive(false);
        pausePopUp.SetActive(false);
        score = 0;
        timer = 0.0f;
        //Cursor.visible = false;
        coins = 0;
        level = PlayerPrefs.GetInt("SelectedLevel");
        levelName.text = "Level: " + level;
        PlayerPrefs.SetInt("LevelComplete", 0);
        hasReachedTop = false;
        initialPos = transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        coinText.text = "Rewards: " + (coins);
        distance = Mathf.Round(Vector3.Distance(initialPos, transform.position));
        //Debug.Log(distance.ToString());
        distanceText.text = "Distance: " + distance.ToString() + "m";

        if (pausePopUp.activeInHierarchy || gameWinPopUP.activeInHierarchy || gameOverPopUp.activeInHierarchy)
            Time.timeScale = 0.0f;
        else
        {
            Time.timeScale = 1.0f;
            timer += Time.deltaTime;//* 10.0f;
            if (timer > 0)
            {
                score += 1 + coins;
                scoreText.text = "Score: " + score;
            }
        }

        //levelcomplete condition
        if (hasReachedTop)
        {
            PlayerPrefs.SetInt("LevelComplete", 1);
            // unlock the next level
            if (PlayerPrefs.GetInt("LevelComplete") == 1)
            {
                unlockedLevelIndex = level + 1;
                PlayerPrefs.SetInt("UnlockedLevel", unlockedLevelIndex);
                Debug.Log(PlayerPrefs.GetInt("UnlockedLevel"));
            }

            PlayerPrefs.SetInt("Totalcoins", PlayerPrefs.GetInt("Totalcoins") + coins);
            gameWinPopUP.SetActive(true);

        }

        if (timer >= 120.0f)
        {
            gameOverPopUp.SetActive(true);
        }

    }

}
