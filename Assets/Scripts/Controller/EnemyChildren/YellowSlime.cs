using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowSlime : EnemyController
{
    protected override void Awake()
    {
        _character_id = (int)GameManager.Character_id.YellowSlime;

        base.Awake();
    }
}
