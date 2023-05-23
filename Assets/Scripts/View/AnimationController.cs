using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator animc = default;

    private bool _canAnimation = default;
    private void Start()
    {
        _canAnimation = TryGetComponent(out animc);
    }
}
