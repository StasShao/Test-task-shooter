using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuMono : MainMenu
{
      
    public override void ExitGame()
    {
        SceneChoose(false, true);
    }

    public override void StartGame()
    {
        SceneChoose(true, false);
      
    }
}
