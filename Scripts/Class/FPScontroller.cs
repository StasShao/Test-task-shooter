using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FPScontroller : MonoBehaviour, Icontroller
{
    private ControllerFPSControllerNS _controllerFPS_NS;
    [SerializeField]protected Rigidbody _fpsRb;
    [SerializeField]protected Transform _camtransform;
    [SerializeField]protected ControllerSettings _controllerSettings;

    public float MOVE { get; private set; }

    public float ROTATE { get; private set; }

    public float STRAFE { get; private set; }

    public bool JUMP { get; private set; }

    public float MOUSE_X { get; private set; }

    public float MOUSE_Y { get; private set; }

    void Awake()
    {
        _controllerFPS_NS = new ControllerFPSControllerNS(_fpsRb, _camtransform , _controllerSettings);
    }

    void Update()
    {
        InputListener();
        _controllerFPS_NS.Tick();
    }
    void FixedUpdate()
    {
        _controllerFPS_NS.FixTick();
    }

    public void Move(float move)
    {
        MOVE = move;
    }

    public void Rotate(float rotate)
    {
        ROTATE = rotate;
    }
    protected abstract void InputListener();

    public void Strafe(float strafe)
    {
        STRAFE = strafe;
    }

    public void Jump(bool jump)
    {
        JUMP = jump;
    }

    public void Rotate(float mouseX, float mouseY)
    {
        MOUSE_Y = mouseY;
        MOUSE_X = mouseX;
    }
}
