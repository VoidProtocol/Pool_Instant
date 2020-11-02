using UnityEngine;

public class CursorPosition : MonoBehaviour
{
    [Header("Setup:")]
    [SerializeField] private Camera _mainCamera;

    [Header("Settings:")]
    [SerializeField] private float _clippingPlanePosition;

    private static Vector3 _cursorPosition;

    public static Vector3 GetCursorPosition { get { return _cursorPosition; } }

    private void Update()
    {
        _cursorPosition = _mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, _clippingPlanePosition));
    }
}
