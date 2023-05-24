using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject player = default;

    private void Start()
    {
        player = GameObject.FindWithTag(GameManager.Character_id.Player.ToString());
    }

    private void Update()
    {
        if (player.transform.position.x >= 0 && player.transform.position.x <= 122)
        {
            transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        }
    }
}
