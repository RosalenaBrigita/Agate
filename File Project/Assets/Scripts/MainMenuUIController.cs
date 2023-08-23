using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuUIController : MonoBehaviour
{
    public Button playButton;
    public Button exitButton;
    public Button creditButton;

    public void PlayGame()
    {
        SceneManager.LoadScene("PinBall");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void CreditScene()
    {
        SceneManager.LoadScene("Credit");
    }
}
