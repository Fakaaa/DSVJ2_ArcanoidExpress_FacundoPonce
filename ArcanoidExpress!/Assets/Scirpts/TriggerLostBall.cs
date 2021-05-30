using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLostBall : MonoBehaviour
{
    public delegate void PlayerHasLostTheBall();
    public static PlayerHasLostTheBall playerLostBall;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ball")
        {
            playerLostBall?.Invoke();
            Debug.Log("Entro");
        }
    }
}
