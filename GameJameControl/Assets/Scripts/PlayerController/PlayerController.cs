﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class PlayerController : Singleton<PlayerController>
{
    public float moveSpeed;
    private Vector2 m_Move;



    public void OnMove(InputAction.CallbackContext context)
    public int health = 3;
    // Start is called before the first frame update
    void Start()
    {
        m_Move = context.ReadValue<Vector2>();
    }

    public void Update()
    {

        Move(m_Move);
    }

    private void Move(Vector2 direction)
    {
        if (direction.sqrMagnitude < 0.01)
            return;
        var scaledMoveSpeed = moveSpeed * Time.deltaTime;
        // For simplicity's sake, we just keep movement in a single plane here. Rotate
        // direction according to world Y rotation of player.
        var move = Quaternion.Euler(0, transform.eulerAngles.y, 0) * new Vector3(direction.x, 0, direction.y);
        transform.position += move * scaledMoveSpeed;
    }

    private void DodgeRoll()
    {
        
    }
}
