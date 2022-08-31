using UnityEngine;
[CreateAssetMenu(menuName ="ControllerSettings",fileName ="ControllerSettings/Data")]
public class ControllerSettings : ScriptableObject
{
    [SerializeField] [Range(0.0f, 1000.0f)] private float moveForce;
    [SerializeField] [Range(0.0f, 1000.0f)] private float rotateForce;
    [SerializeField] [Range(0.0f, 1000.0f)] private float strafeForce;
    [SerializeField] [Range(0.0f, 1000.0f)] private float jumpForce;
    [SerializeField] [Range(0.0f, 1000.0f)] private float rayGroundCheckDist;
    [SerializeField] private LayerMask rayGchmask;
    [SerializeField] private Color rayGchColor;
    public float MoveForce { get { return moveForce; } }
    public float RotateForce { get { return rotateForce; } }
    public float StrafeForce { get { return strafeForce; } }
    public float JumpForce { get { return jumpForce; } }
    public float RayGroundCheckDist { get { return rayGroundCheckDist; } }
    public LayerMask RayGrCheckMask { get { return rayGchmask; } }
    public Color RayGrCheckColor { get { return rayGchColor; } }
}
