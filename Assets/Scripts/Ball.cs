using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public float ballSpeed = 10.0f;

    private Vector2 ballDirection;
    private bool isBallReleased = false;

    public Paddle paddle;
    float mag;
    GameObject Col;
    public Rigidbody2D Rg;

    void Start()
    {
        ballDirection = Vector2.up.normalized;
    }

    void Update()
    {
        if (!isBallReleased)
        {
            Vector3 paddlePosition = GameObject.Find("Paddle").transform.position;

            Vector3 ballPoisition = paddlePosition;
            ballPoisition.y += 0.185f;
            transform.position = ballPoisition;

            if (Input.GetButtonDown("Fire1"))
            {
                isBallReleased = true;
                ballDirection = new Vector2(Random.Range(-1f,1f), 1).normalized;
            }
        }
        else
        {
            transform.Translate(ballDirection*ballSpeed*Time.deltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Col = col.gameObject;
        StartCoroutine(paddle.BallCollisionEnter2D(transform, GetComponent<Rigidbody2D>(), GetComponent<Ball>(), Col, Col.transform, Col.GetComponent<SpriteRenderer>(), Col.GetComponent<Animator>()));
        if (col.gameObject.CompareTag("Wall"))
        {
            ballDirection = Vector2.Reflect(ballDirection, col.contacts[0].normal);
        }
        else if (col.gameObject.CompareTag("Paddle"))
        {
            float hitPoint = col.contacts[0].point.x;
            float paddleCenter = col.transform.position.x;
            float angle = (hitPoint - paddleCenter) * 2.0f;
            ballDirection = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)).normalized;
        }

    }


    void OnTriggerEnter2D(Collider2D col)
    {
        Col = col.gameObject;
        if (Col.CompareTag("TriggerBlock")) paddle.BlockBreak(Col, Col.transform, Col.GetComponent<Animator>());
        
        if  (col.gameObject.CompareTag("Out"))
        {
            isBallReleased = false;

            Vector3 paddlePosition = GameObject.Find("Paddle").transform.position;
        }

    }
}
