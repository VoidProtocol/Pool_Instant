using System.Collections.Generic;
using UnityEngine;

public class BallsManager : MonoBehaviour
{
    [Header("Settings:")]
    [SerializeField] private Vector3 _whiteBallPosition;
    [SerializeField] private Vector3 _CenterBallPosition;
    [SerializeField] private List<GameObject> _balls;

    private float _xDistance = 0.059f;
    private float _zDistance = 0.052f;

    private void Start()
    {
        foreach (Transform ball in transform)
        {
            _balls.Add(ball.gameObject);
        }

        PlaceBalls();
    }

    //Place balls in a triangle shape
    public void PlaceBalls()
    {
        int xRows = 5;
        int zRows = 5;
        int count = 1;

        _balls[0].transform.position = _whiteBallPosition;
        _balls[0].SetActive(true);

        Vector3 ballPos = new Vector3(_CenterBallPosition.x + _xDistance * 2.0f, _CenterBallPosition.y, _CenterBallPosition.z + _zDistance * 2.0f);

        for (int i = 0; i < xRows; i++)
        {
            for (int j = 0; j < zRows; j++)
            {
                _balls[count].transform.position = ballPos;
                _balls[count].SetActive(true);

                ballPos = new Vector3(ballPos.x - _xDistance, ballPos.y, ballPos.z);
                count++;
            }

            ballPos = new Vector3(-ballPos.x - _xDistance * 1.5f, ballPos.y, ballPos.z - _zDistance);
            zRows--;
        }
    }

    public bool CheckIfBallsAreStill()
    {
        foreach (GameObject ball in _balls)
        {
            if (!ball.GetComponent<Rigidbody>().IsSleeping())
            {
                return false;
            }
        }

        return true;
    }

    public bool CheckIfAllBallsDisabled()
    {
        foreach (GameObject ball in _balls)
        {
            if (ball.activeSelf && !ball.CompareTag("WhiteBall"))
            {
                return false;
            }
        }

        return true;
    }
}
