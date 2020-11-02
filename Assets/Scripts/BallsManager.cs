using System.Collections.Generic;
using UnityEngine;

public class BallsManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> Balls;

    private void Start()
    {
        foreach (Transform ball in transform)
        {
            Balls.Add(ball.gameObject);
        }
    }

    public bool CheckIfBallsAreStill()
    {
        foreach (GameObject ball in Balls)
        {
            if (!ball.GetComponent<Rigidbody>().IsSleeping())
            {
                return false;
            }
        }

        return true;
    }    
}
