using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speedPlayer;
    [SerializeField] private int limitMax;
    [SerializeField] private int limitMin;

    private Vector3 moveVec;
    

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
    void Update()
    {
        MovePlayer();
    }
}
