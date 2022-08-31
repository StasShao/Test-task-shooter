using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadSetpointsMono : Points
{
    public override void OnCollisionEnter(Collision col)
    {
        _pointsAdd_NS.OnCollisionEnter(col);
    }
}
