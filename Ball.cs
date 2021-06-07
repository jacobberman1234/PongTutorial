using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    private Rigidbody2D _rb2d;

    private void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        GameManager.instance.currentBall = this.gameObject;
    }

    private void Start()
    {
        NewBall();
    }

    private void AddForce(Vector2 force)
    {
        _rb2d.velocity = force;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 newVelocity = _rb2d.velocity;
        Rigidbody2D player = collision.collider.GetComponent<Rigidbody2D>();
        //Collide with player
        if (player)
        {
            newVelocity.x *= -1;
            newVelocity.y = player.velocity.y + Random.Range(-_speed, _speed);
        }
        else
        {
            newVelocity.y *= -1;
        }
        AddForce(newVelocity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PointZone"))
        {
            GameManager.instance.AddPoint(collision.GetComponent<PointZone>().player);
        }
        GameManager.instance.ResetBoard();
    }

    public void NewBall()
    {
        Vector2 initialDirection = Vector2.one * _speed;
        //Force Added in a random direction
        int randomDirection = Random.Range(0, 2);
        if (randomDirection != 0)
            initialDirection.x *= -1;
        initialDirection.y = Random.Range(-_speed, _speed);
        AddForce(initialDirection);
    }
}
