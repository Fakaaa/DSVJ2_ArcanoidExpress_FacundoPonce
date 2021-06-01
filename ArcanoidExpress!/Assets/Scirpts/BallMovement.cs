using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] public bool isMoving;

    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform startPos;
    [SerializeField] private Vector3 directionBall;
    [SerializeField] private float speedBall;

    [SerializeField] private int scoreAmountPerBrickHit;
    [SerializeField] private float lenghtRaycast;
    private Vector3 initialScale;
    private float initialSpeedBall;

    void Start()
    {
        initialSpeedBall = speedBall;
        initialScale = transform.localScale;
        directionBall = transform.forward;
        startPos.position = transform.position;
        transform.parent = playerTransform;
        Player.playerReleasesBall += ReleaseBall;
        Player.ballRespawn += AttachBallToPlayer;
        isMoving = false;
    }
    private void OnDestroy()
    {
        Player.playerReleasesBall -= ReleaseBall;
        Player.ballRespawn -= AttachBallToPlayer;
    }
    void ReleaseBall()
    {
        isMoving = true;
        transform.parent = null;
    }
    void AttachBallToPlayer()
    {
        isMoving = false;
        speedBall = initialSpeedBall;
        transform.position = startPos.position;
        transform.parent = playerTransform;
        transform.localScale = initialScale;
        directionBall = transform.forward;
    }
    void MoveBall()
    {
        transform.position += directionBall * speedBall * Time.deltaTime;
    }
    void Update()
    {
        if (isMoving)
            MoveBall();
    }
    private void OnCollisionEnter(Collision collision)
    {
        speedBall += 0.1f;

        if (collision.collider.CompareTag("Player"))
        {
            Vector3 resultDirection = transform.position - collision.collider.gameObject.transform.position;
            directionBall = resultDirection.normalized;
        }
        else
        {
            if(collision.collider.CompareTag("Wall"))
                directionBall = new Vector3(-directionBall.x, directionBall.y, directionBall.z);
            else
            {
                directionBall = new Vector3(directionBall.x, directionBall.y, -directionBall.z);
                if(!collision.collider.CompareTag("WallTop"))
                {
                    Destroy(collision.collider.gameObject);
                    if (GameManager.Get() != null)
                    {
                        GameManager.Get().SetScore(scoreAmountPerBrickHit);
                        GameManager.Get().BrickDestroyed();
                    }
                }
            }
        }
    }
}
