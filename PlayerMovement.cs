using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 3;
    [SerializeField] private bool _isPlayerOne;

    private Rigidbody2D _rb2d;
    private KeyCode upInput, downInput;
    private bool _hitTop, _hitBottom;

    private void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        upInput = KeyCode.W;
        downInput = KeyCode.S;
        if (!_isPlayerOne)
        {
            upInput = KeyCode.UpArrow;
            downInput = KeyCode.DownArrow;
        }
    }

    private void Update()
    {
        Vector2 up = new Vector2(0, 1);
        float adjustedDeltaTime = Time.deltaTime * 1000;
        if (Input.GetKey(upInput) && !_hitTop)
        {
            //Move Up
            _rb2d.velocity = up * _speed * adjustedDeltaTime;
        }
        if (Input.GetKey(downInput) && !_hitBottom)
        {
            //Move Down
            _rb2d.velocity = -up * _speed * adjustedDeltaTime;
        }
        if(Input.GetKeyUp(upInput) || Input.GetKeyUp(downInput))
        {
            _rb2d.velocity = Vector2.zero;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("BoundaryTop"))
        {
            //StopMoving
            _rb2d.velocity = Vector2.zero;
            //DisableMovement Up
            _hitTop = true;
        }
        if (collision.collider.CompareTag("BoundaryBottom"))
        {
            //StopMoving
            _rb2d.velocity = Vector2.zero;
            //DisableMovement Down
            _hitBottom = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("BoundaryTop"))
        {
            _hitTop = false;
        }
        if (collision.collider.CompareTag("BoundaryBottom"))
        {
            _hitBottom = false;
        }
    }
}
