using UnityEngine;

public class BallHole : MonoBehaviour
{
    [Header("Setup:")]
    [SerializeField] private GameObject _ballPlaceSurface;
    [SerializeField] private BallsManager _ballsManager;
    [SerializeField] private GameController _gameController;


    [Header("Config:")]
    [SerializeField] private int _whiteBallScorePenalty;

    private void OnTriggerEnter(Collider collider)
    {
        collider.gameObject.SetActive(false);
        collider.GetComponent<Rigidbody>().Sleep();

        if (collider.gameObject.CompareTag("WhiteBall"))
        {
            Score.SubstractScore = _whiteBallScorePenalty;
            Score.UpdateScore();
            _ballPlaceSurface.SetActive(true);
        }

        if (_ballsManager.CheckIfAllBallsDisabled())
        {
            _gameController.Restart();
        }
    }
}
