using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PlayerMovementRN))]
public class PlayerInputRN : MonoBehaviour
{
    private PlayerMovementRN _movement;

    private void Start()
    {
        _movement = GetComponent<PlayerMovementRN>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            _movement.TryMoveUp();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            _movement.TryMoveDown();
        }
    }
}
