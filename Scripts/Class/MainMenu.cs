using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class MainMenu : MonoBehaviour, IMainMenu
{
    private MainMenuNS _mainMenuNS;
    [SerializeField] protected Text _bestScore;
    protected float scoreValue;

    public bool ISGAME { get; private set; }

    public bool ISEXIT { get; private set; }

    public bool ISSOUND { get; private set; }
    

    public void SceneChoose(bool isGame, bool isExit)
    {
        ISGAME = isGame;
        ISEXIT = isExit;
    }

    public void SoundVolumeSwitch(bool isSound)
    {
        ISSOUND = isSound;
    }

    void Awake()
    {
        Time.timeScale = 1.0f;
        _mainMenuNS = new MainMenuNS(this);
        if (PlayerPrefs.HasKey("BestScore"))
        {
            scoreValue = PlayerPrefs.GetFloat("BestScore");
            _bestScore.text = scoreValue.ToString();
        }
    }

    
    void Update()
    {
        _mainMenuNS.Tick();
    }
    public abstract void StartGame();
    public abstract void ExitGame();
    
}
