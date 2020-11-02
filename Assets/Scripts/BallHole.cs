using UnityEngine;

public class BallHole : MonoBehaviour
{
    [Header("Setup:")]
    [SerializeField] private GameObject _ballPlaceSurface;

    [Header("Config:")]
    [SerializeField] private int _whiteBallScorePenalty;

    private void OnTriggerEnter(Collider collider)
    {
        collider.gameObject.SetActive(false);

        if (collider.gameObject.CompareTag("WhiteBall"))
        {
            Score.SubstractScore = _whiteBallScorePenalty;
            Score.UpdateScore();
            _ballPlaceSurface.SetActive(true);
        }
    }
}
