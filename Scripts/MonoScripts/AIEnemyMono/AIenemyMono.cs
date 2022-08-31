using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIenemyMono : AIenemy
{
    protected override void ListenerInput()
    {
            FollowTarget(true);
    }
    
}
