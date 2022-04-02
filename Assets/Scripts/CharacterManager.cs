using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterManager : MonoBehaviour
{
    static CharacterManager instance;

    public Text characterName;
    public Text characterInfo;

    public GameObject[] playerMenuAnim;

    public static int currentIndex;

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
        currentIndex = 0;
    }



    public void GoGame()
    {
        AudioManager.PlayClickAudio();
        SceneManager.LoadScene("game");
        AudioManager.PlayGameBgm();
    }

    public void BackToMenu()
    {
        AudioManager.PlayClickAudio();
        SceneManager.LoadScene("StartMenu");
        AudioManager.PlayStartMenuBgm();
    }

    public void NextCharacter()
    {
        AudioManager.PlayClickAudio();
        currentIndex++;
        if (currentIndex >= playerMenuAnim.Length)
        {
            currentIndex = 0;          
        }
        ShowCharacterInfo();
    }

    public void lastCharacter()
    {
        AudioManager.PlayClickAudio();
        currentIndex--;
        if (currentIndex < 0)
        {
            currentIndex = playerMenuAnim.Length - 1;
        }
        ShowCharacterInfo();
    }

    void ShowCharacterInfo()
    {
        if (currentIndex == 0)
        {
            playerMenuAnim[0].SetActive(true);
            playerMenuAnim[1].SetActive(false);
            playerMenuAnim[2].SetActive(false);
            playerMenuAnim[3].SetActive(false);

            characterName.text = "<color=#EC9292>Pink Man</color>";
            characterInfo.text = "Nothing Special Just\nPink";
        }
        if (currentIndex == 1)
        {
            playerMenuAnim[0].SetActive(false);
            playerMenuAnim[1].SetActive(true);
            playerMenuAnim[2].SetActive(false);
            playerMenuAnim[3].SetActive(false);

            characterName.text = "<color=blue>Virtual Man</color>";
            characterInfo.text = "Can Run Faster Than\nOther";
        }
        if (currentIndex == 2)
        {
            playerMenuAnim[0].SetActive(false);
            playerMenuAnim[1].SetActive(false);
            playerMenuAnim[2].SetActive(true);
            playerMenuAnim[3].SetActive(false);

            characterName.text = "<color=green>NinjaFrog</color>";
            characterInfo.text = "You Know Frog Always\nJump High";
        }
        if (currentIndex == 3)
        {
            playerMenuAnim[0].SetActive(false);
            playerMenuAnim[1].SetActive(false);
            playerMenuAnim[2].SetActive(false);
            playerMenuAnim[3].SetActive(true);

            characterName.text = "<color=#A67D3D>Mask Dude</color>";
            characterInfo.text = "Mask Dude Never Take\nOff His Heavy Mask!";
        }


    }


}
