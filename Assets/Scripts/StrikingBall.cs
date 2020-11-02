using UnityEngine;

public class StrikingBall : MonoBehaviour
{
    [Header("Setup:")]
    [SerializeField] private GameObject _cue;
    [SerializeField] private GameObject _whiteBall;

    private void OnMouseDown()
    {
        PositionCue();
        _cue.SetActive(true);
    }

    private void OnMouseUp()
    {
        _cue.SetActive(false);
    }

    private void PositionCue()
    {
        float cueRotationAngle = Mathf.Atan2(CursorPosition.GetCursorPosition.z - _whiteBall.transform.position.z, 
            CursorPosition.GetCursorPosition.x - _whiteBall.transform.position.x) * Mathf.Rad2Deg +90.0f;

        _cue.transform.position = new Vector3(CursorPosition.GetCursorPosition.x, _whiteBall.transform.position.y, CursorPosition.GetCursorPosition.z);
        _cue.transform.rotation = Quaternion.Euler(90.0f, 0.0f, cueRotationAngle);
    }    
}
