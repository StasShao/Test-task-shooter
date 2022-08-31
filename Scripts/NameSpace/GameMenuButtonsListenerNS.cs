using UnityEngine.SceneManagement;
using UnityEngine;

public static class MenuButtonsGameListener
{
    public static void Restarting()
    {
        SceneManager.LoadScene(1);
    }
    public static void MainMenuFollow()
    {
        SceneManager.LoadScene(0);
    }
    public static void Exitgame()
    {
        Application.Quit();
    }

}
//=================================================================================================================================================
