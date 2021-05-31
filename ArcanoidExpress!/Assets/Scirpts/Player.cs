using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speedPlayer;
    [SerializeField] private int limitMax;
    [SerializeField] private int limitMin;

    private Vector3 moveVec;

    [SerializeField] private int playerLifes;
    [SerializeField] public bool isAlive;

    private BallMovement myRefBall;

    public delegate void PlayerShootBall();
    public delegate void PlayerLosesTheBall();
    public static PlayerShootBall playerReleasesBall;
    public static PlayerLosesTheBall ballRespawn;

    private void Start()
    {
        myRefBall = FindObjectOfType<BallMovement>();
        isAlive = true;
        TriggerLostBall.playerLostBall += RestLife;
    }
    private void OnDisable()
    {
        TriggerLostBall.playerLostBall -= RestLife;
    }
    public void RestLife()
    {
        playerLifes--;

        if (playerLifes <= 0)
        {
            playerLifes = 0;
            if (GameManager.Get() != null)
            {
                GameManager.Get().SetHighScore(GameManager.Get().scorePlayer);
                GameManager.Get().SetStateGame(GameManager.GameState.Lose);
            }
            isAlive = false;
        }
        else
            ballRespawn?.Invoke();
    }
    void MovePlayer()
    {
        moveVec = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);

        if (transform.position.x < limitMax && transform.position.x > limitMin)
            transform.position += moveVec * speedPlayer * Time.deltaTime;

        if (transform.position.x > limitMax)
            transform.position -= new Vector3(0.1f, 0, 0);
        if(transform.position.x < limitMin)
            transform.position += new Vector3(0.1f, 0, 0);
    }
    void InputPlayer()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(myRefBall!= null)
            {
                if(!myRefBall.isMoving)
                    playerReleasesBall?.Invoke();
            }
        }
    }
    void Update()
    {
        InputPlayer();

        MovePlayer();
    }
}
