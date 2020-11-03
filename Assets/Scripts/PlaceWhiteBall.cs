using UnityEngine;

public class PlaceWhiteBall : MonoBehaviour
{
    [Header("Setup:")]
    [SerializeField] private GameObject _whiteBall;

    private void OnMouseDown()
    {
        _whiteBall.transform.position = new Vector3(CursorPosition.GetCursorPosition.x, 0.817f, CursorPosition.GetCursorPosition.z);
        _whiteBall.SetActive(true);
        gameObject.SetActive(false);
    }
}
