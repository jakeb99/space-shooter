using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Player _player;

    private Vector2 direction;
    private Vector3 mousePosition;
    private Vector3 lookDirection;

    public void Start()
    {
        
    }

    private void Update()
    {
        MovePlayer();
        RotatePlayerToMousePos();
        Shoot();
    }

    private void MovePlayer()
    {
        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");

        _player.Move(direction);
    }

    private void RotatePlayerToMousePos()
    {
        mousePosition = Input.mousePosition;
        mousePosition.z = -Camera.main.transform.position.z;   // add main camera offset to mouse position (2d cam is -10 on z axis)
        //convert mouse position to world space

        // destination - orgin = direction
        lookDirection = Camera.main.ScreenToWorldPoint(mousePosition) - transform.position;

        lookDirection = Camera.main.ScreenToWorldPoint(mousePosition) - transform.position;
        _player.Look(lookDirection);
    }

    private void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _player.StartAttack();
        }

        if (Input.GetMouseButtonUp(0))
        {
            _player.StopAttack();
        }
    }

}
