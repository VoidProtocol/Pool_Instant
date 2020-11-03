using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("Setup:")]
    [SerializeField] private GameObject _cue;
    [SerializeField] private GameObject _whiteBall;
    [SerializeField] private GameObject _cueCameraView;
    [SerializeField] private BallsManager _ballsManager;

    private void OnMouseDown()
    {
        if (_whiteBall.activeSelf && _ballsManager.CheckIfBallsAreStill())
        {
            PositionCue();
            _cue.SetActive(true);
            _cueCameraView.SetActive(true);
        }
    }

    private void OnMouseUp()
    {
        _cue.SetActive(false);
        _cueCameraView.SetActive(false);
    }

    private void PositionCue()
    {
        float cueRotationAngle = Mathf.Atan2(CursorPosition.GetCursorPosition.z - _whiteBall.transform.position.z, 
            CursorPosition.GetCursorPosition.x - _whiteBall.transform.position.x) * Mathf.Rad2Deg +90.0f;

        _cue.transform.position = new Vector3(CursorPosition.GetCursorPosition.x, _whiteBall.transform.position.y, CursorPosition.GetCursorPosition.z);
        _cue.transform.rotation = Quaternion.Euler(90.0f, 0.0f, cueRotationAngle);
    }    
}
