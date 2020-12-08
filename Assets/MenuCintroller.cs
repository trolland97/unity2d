using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuCintroller : MonoBehaviour {
    public void startGame()
    {
        SceneManager.LoadScene(1);
    }

    public void backToMain()
    {
        SceneManager.LoadScene(0);
    }

    public void achievement()
    {
        SceneManager.LoadScene(2);
    }

    public void exitGame()
    {
        Application.Quit();
    }

}
