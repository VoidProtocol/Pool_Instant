using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("Setup:")]
    [SerializeField] private GameObject _cue;
    [SerializeField] private GameObject _whiteBall;
    [SerializeField] private GameObject _cueCameraView;
    [SerializeField] private BallsManager _ballsManager;

    private void Update()
    {
        if (TouchInput.GetIsScreenTouched)
        {
            if (_whiteBall.activeSelf && !_cue.activeSelf && _ballsManager.CheckIfBallsAreStill())
            {
                PositionCue();
                _cue.SetActive(true);
                _cueCameraView.SetActive(true);
            }
        }
        else
        {
            _cue.SetActive(false);
            _cueCameraView.SetActive(false);
        }
    }

    private void PositionCue()
    {
        float cueRotationAngle = Mathf.Atan2(TouchInput.GetTouchPosition.z - _whiteBall.transform.position.z,
            TouchInput.GetTouchPosition.x - _whiteBall.transform.position.x) * Mathf.Rad2Deg +90.0f;

        _cue.transform.position = new Vector3(TouchInput.GetTouchPosition.x, _whiteBall.transform.position.y, TouchInput.GetTouchPosition.z);
        _cue.transform.rotation = Quaternion.Euler(90.0f, 0.0f, cueRotationAngle);
    }
    
    //Restart game, better performance than Unity native restart method
    public void Restart()
    {
        Score.ResetScore();
        _ballsManager.PlaceBalls();
        Score.UpdateScore();
    }
}
