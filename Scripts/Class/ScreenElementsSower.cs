using UnityEngine;
using UnityEngine.UI;

public class ScreenElementsSower : MonoBehaviour
{
    [SerializeField] protected Text CurentPoints;
    [SerializeField] protected Text BesttPoints;

    private void Start()
    {
        StaticPointsCalculater.Begin();
    }

    void Update()
    {
        StaticPointsCalculater.ConvertText(CurentPoints, BesttPoints);
      
    }
}
