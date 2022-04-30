using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    // Config param
    [SerializeField] PaddleMove paddle1;
    [SerializeField] float xPush = 5;
    [SerializeField] float yPush = 15; 
    [SerializeField] AudioClip[] ballSounds;

    //State
    float sumSpeed, paddleSize, ballXPos, paddleXPos, posGap,
    littlestPartOfPaddle;
    Vector2 paddleToBallVector;
    bool hasStarted = false;
    GameObject playerPaddle;
    float[] newXPushes;

    // Cached component references
    AudioSource myAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        playerPaddle = GameObject.Find("Paddle");
        paddleSize = playerPaddle.GetComponent<BoxCollider2D>().size.x;
        sumSpeed = xPush + yPush + 1;    // we add 1 to not remember 0 pos
        littlestPartOfPaddle = paddleSize / sumSpeed;
        newXPushes = new float[(int)sumSpeed];
        for (int i = 0; i < sumSpeed; i++) 
        {
            newXPushes[i] = (sumSpeed / 2 * -1) + i;
        }
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
            GetComponent<Rigidbody2D>().velocity = new Vector2(xPush, yPush);

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
                ChangeMoveAfterPaddle();
            }

            myAudioSource.PlayOneShot(clip);
        }
    }

    // changing the vector of the ball depending on the position relative to the paddle
    private void ChangeMoveAfterPaddle()
    {
        //find pos of ball and paddle
        ballXPos = transform.position.x;
        paddleXPos = playerPaddle.transform.position.x - (paddleSize/2);
        posGap = ballXPos - paddleXPos;
        // changing the vector of the ball
        for (int i = 0; i < sumSpeed - 1; i++) 
        {
            if (posGap >= 0 + (i * littlestPartOfPaddle) && posGap < littlestPartOfPaddle * (i + 1)) 
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(newXPushes[i], yPush);
            }
        }
    }
}
