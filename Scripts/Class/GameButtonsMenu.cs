using UnityEngine;

public class GameButtonsMenu : MonoBehaviour
{
    public void RestartGame()
    {
        MenuButtonsGameListener.Restarting();
    }
    public void MainMenuFollowing()
    {
        MenuButtonsGameListener.MainMenuFollow();
    }
    public void ExitGame()
    {
        MenuButtonsGameListener.Exitgame();
    }
  
}
