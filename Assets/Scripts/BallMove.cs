using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    // Config param
    [SerializeField] PaddleMove paddle1;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float speed = 1f;

        //State
    const int expandedAngle = 180;
    private float paddleSize;
    float ballXPos, paddleXPos, posGap;
    Vector2 paddleToBallVector;
    bool hasStarted = false;
    float[] newXPushes;

    // Cached component references
    AudioSource myAudioSource;
    private Rigidbody2D _rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            LockOnPaddle();
            LaunchOnMouseClick();
        }
    }

    // its ball starting position
    private void LockOnPaddle()
    {
        Vector2 paddlePos =
            new Vector2(paddle1.transform.position.x,
                paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    //wait click and move ball after that
    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            _rigidbody2D.velocity = new Vector2(0, speed);
        }
    }

    // play sound when ball touch something
    // change pos when touch the paddle
    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioClip clip =
            ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
        if (hasStarted)
        {
            if (collision.gameObject.tag == "Paddle")
            {
                ChangeMoveAfterPaddle(collision.gameObject);
            }

            myAudioSource.PlayOneShot(clip);
        }
    }

    // changing the vector of the ball depending on the position relative to the paddle
    private void ChangeMoveAfterPaddle(GameObject playerPaddle)
    {
        paddleSize = playerPaddle.GetComponent<BoxCollider2D>().size.x;
        ballXPos = transform.position.x;
        paddleXPos = playerPaddle.transform.position.x - (paddleSize / 2);
        posGap = paddleXPos - ballXPos;
        float startingAngle = (-1 * expandedAngle) - ((posGap / paddleSize) * expandedAngle);
        Debug.Log(startingAngle);
        _rigidbody2D.velocity = new Vector2(Mathf.Sin(startingAngle), Mathf.Cos(startingAngle)) * speed;
    }
}
