using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodySetpointsMono : Points
{
    public override void OnCollisionEnter(Collision col)
    {
        _pointsAdd_NS.OnCollisionEnter(col);
    }
}
