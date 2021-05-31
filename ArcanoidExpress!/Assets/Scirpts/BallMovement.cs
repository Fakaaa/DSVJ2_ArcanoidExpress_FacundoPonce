using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] public bool isMoving;

    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform startPos;

    void Start()
    {
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
        transform.parent = playerTransform;
        transform.position = startPos.position;
    }
    //void Update()
    //{
    //    
    //}
}
