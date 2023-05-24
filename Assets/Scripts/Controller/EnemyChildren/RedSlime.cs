using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedSlime : EnemyController
{
    protected override void Awake()
    {
        _character_id = (int)GameManager.Character_id.RedSlime;

        base.Awake();
    }
}
