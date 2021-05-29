using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
  
  public void startfirstlevel()
    {
        SceneManager.LoadScene(1);
    }

    public void MainMenulevel()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OptionMenu()
    {
        SceneManager.LoadScene("Option Screen");
    }
}
