using UnityEngine;


public class PlayerListener : Listener
{
    [SerializeField]private float HP;
    [SerializeField] private GameObject _go;
    [SerializeField] private Transform _cameraT;
    [SerializeField] protected Rigidbody _rbCam;
    [SerializeField] private Animator _anim;
    [SerializeField] private GameObject[] _gameOver;
    [SerializeField] private FPScontrollerMono _plController;
    public override ICalculateHP ICALCUL(ICalculateHP iCalcul)
    {
        return iCalcul;
    }

    public override IHealth IHEALTH(IHealth iHealth)
    {
        return iHealth;
    }

    public override void SetMainHP(float setValue)
    {
        MAIN_HP = setValue;
    }

    public override void Shower()
    {
        _listenerNS.SetHPHEALTH();
        HP = MAIN_HP;
    }

    public override void YourEvent()
    {
       if(HP <= 0)
        {

            foreach (var item in _gameOver)
            {
                item.SetActive(true);
            }
            _cameraT.parent = null;
            _rbCam.isKinematic = false;
            _anim.enabled = false;
            _plController.enabled = false;
        }
        if (Input.GetKey(KeyCode.Escape))
        {
         
                if(!_gameOver[1].activeInHierarchy)
                {
                    for (int i = 1; i < _gameOver.Length; i++)
                    {
                        _gameOver[i].SetActive(true);
                    }
                }else
                {
                    for (int i = 1; i < _gameOver.Length; i++)
                    {
                        _gameOver[i].SetActive(false);
                    }
                }
            
        }
    }
    

}
  
