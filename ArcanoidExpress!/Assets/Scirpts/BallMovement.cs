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

    [SerializeField] private float lenghtRaycast;
    private Vector3 initialScale;

    private Ray rayFromBall;
    private RaycastHit hitBall;

    void Start()
    {
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
        transform.position = startPos.position;
        transform.parent = playerTransform;
        transform.localScale = initialScale;
        directionBall = transform.forward;
    }
    private void UpdateRay()
    {
        rayFromBall = new Ray(transform.position, transform.forward * lenghtRaycast);
        Debug.DrawRay(rayFromBall.origin, rayFromBall.direction * lenghtRaycast, Color.red);
    }
    void MoveBall()
    {
        transform.position += directionBall * speedBall * Time.deltaTime;
    }
    void Update()
    {
        if (isMoving)
            MoveBall();

        RaycastCheckCollision();

        UpdateRay();
    }
    void RaycastCheckCollision()
    {
        if(Physics.Raycast(rayFromBall, out hitBall, lenghtRaycast))
        {
           
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
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
                directionBall = new Vector3(directionBall.x, directionBall.y, -directionBall.z);
        }
    }
}
