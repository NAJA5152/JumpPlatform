using UnityEngine;
using UnityEngine.SceneManagement;
public class StartMenu : MonoBehaviour
{

    public void StartButton()
    {
        AudioManager.PlayClickAudio();
        SceneManager.LoadScene("ChooseMenu");
        AudioManager.PlayChooseMenuBgm();
    }

    public void QuitButton()
    {
        AudioManager.PlayClickAudio();
        Application.Quit();
    }
}
