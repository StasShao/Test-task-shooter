using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPScontrollerMono : FPScontroller
{
    private float m;
    private float s;
    private float _mouseX;
    private float _mouseY;
    protected override void InputListener()
    {
        m = Input.GetAxis("Vertical");
        s = Input.GetAxis("Horizontal");
        _mouseX = Input.GetAxis("Mouse X");
        _mouseY = Input.GetAxis("Mouse Y");
        Move(m);
        Strafe(s);
        Rotate(_mouseX, _mouseY);
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump(true);
        }

        
    }
}
