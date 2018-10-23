using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour {

    [SerializeField]
    private Button musicBtn;

    [SerializeField]
    private Sprite soundOff, soundOn;

	public void PlayGame()
    {
        GameManager.instance.gameStartedFromMainMenu = true;
        SceneManager.LoadScene(Tags.GAMEPLAY_SCENE);
    }

    public void AboutUs()
    {
        Application.OpenURL("www.ssgames.ir");
    }

    public void ControllSound()
    {
        if (GameManager.instance.canPlayMusic)
        {
            musicBtn.image.sprite = soundOn;
            GameManager.instance.canPlayMusic = false;
        }
        else
        {
            musicBtn.image.sprite = soundOff;
            GameManager.instance.canPlayMusic = true;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }

}//class












