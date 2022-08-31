using UnityEngine;

public abstract class Points : MonoBehaviour, Ipoints
{
    protected PointsAdd_NS _pointsAdd_NS;
    [SerializeField]protected PointsSettings _pointsSettings;
    [SerializeField]protected int showPoints;
    public int POINTS { get; protected set; }

    public void SetPoints(int setPoint)
    {
        POINTS += setPoint;
        StaticPointsCalculater.CurentPoints += POINTS;
    }

    void Awake()
    {
        _pointsAdd_NS = new PointsAdd_NS(this, _pointsSettings);
    }
    private void Update()
    {
        ShowPoints();
    }
    protected void ShowPoints()
    {
        showPoints = POINTS;
    }

    public abstract void OnCollisionEnter(Collision col);
    
}
