using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationEvent : MonoBehaviour
{

    //TODO:AnimationEventを使わないで実装する
    public void FinDeathAnimation()
    {
        gameObject.SetActive(false);
    }

    public void FinVictoryAnimation()
    {
        GameObject.FindWithTag(GameManager.GameObject_tag_name.GameController.ToString()).GetComponent<StageManager>().StageClear();
    }
}
