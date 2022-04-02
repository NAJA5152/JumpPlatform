using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager instance;

    public GameObject gameOverUI;
    public GameObject[] characters;
    public Image fadeImage;
    private float alpha;

    [Header("Time&&Score")]  
    public Text surviveTime;
    public Text highestScore;
    public Text currentScore;
    public static float _surviveTime;
    public static float _collectionScore;
    public static float _currentScore;
    float _highestScore;

    [Header("collections")]  
    public Text appleNum;
    public Text pineappleNum;
    public Text strawberryNum;
    public Text bananaNum;
    public static int _appleNum;
    public static int _pineappleNum;
    public static int _strawberryNum;
    public static int _bananaNum;

    bool gameOver;
    
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        instance = this;
    }

    private void Start()
    {
        Instantiate(characters[CharacterManager.currentIndex], transform.position, Quaternion.identity);       

        LoadData();
        highestScore.text = _highestScore.ToString("00000");

        Cursor.visible = false;
        _appleNum = 0;
        _pineappleNum = 0;
        _strawberryNum = 0;
        _bananaNum = 0;
        _collectionScore = 0;
    }

    void Update()
    {
        if (gameOver)
        {
            return;
        }
        _surviveTime = Time.timeSinceLevelLoad;
        _currentScore = _surviveTime * 10+_collectionScore;

        surviveTime.text = _surviveTime.ToString("000");
        currentScore.text = _currentScore.ToString("00000");

        appleNum.text = _appleNum.ToString();
        pineappleNum.text = _pineappleNum.ToString();
        strawberryNum.text = _strawberryNum.ToString();
        bananaNum.text = _bananaNum.ToString();
       
    }

    public void Again()
    {
        AudioManager.PlayClickAudio();
        StartCoroutine(FadeScene("game"));
        AudioManager.PlayGameBgm();
    }

    public void Menu()
    {
        AudioManager.PlayClickAudio();
        StartCoroutine(FadeScene("StartMenu"));
        AudioManager.PlayStartMenuBgm();
    }

    IEnumerator FadeScene(string sceneName)
    {      
        alpha = 1;

        while (alpha>0)
        {
            alpha -= Time.deltaTime*2;
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return new WaitForSeconds(0);
            SceneManager.LoadScene(sceneName);
        }
       
    }

    void SaveData()
    {
        if (_currentScore >= _highestScore)
        {
            _highestScore = _currentScore;
        }
        
        PlayerPrefs.SetFloat("HighestScore", _highestScore);
    }

    void LoadData()
    {
        if (PlayerPrefs.HasKey("HighestScore"))
        {
            _highestScore = PlayerPrefs.GetFloat("HighestScore");
        }
    }

    public static void GameOver(bool dead)
    {

        if (dead)
        {        
            instance.gameOverUI.SetActive(true);
            Cursor.visible = true;
            instance.gameOver = true;
            instance.SaveData();
        }
    }
}
