using UnityEngine;

public class CursorPosition : MonoBehaviour
{
    [Header("Setup:")]
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private Transform _ClipPlaneTransform;

    private static Vector3 _cursorPosition;
    private float _clippingPlanePosition;

    public static Vector3 GetCursorPosition { get { return _cursorPosition; } }

    private void Awake()
    {
        _clippingPlanePosition = _mainCamera.transform.position.y - _ClipPlaneTransform.position.y;
    }

    private void Update()
    {
        _cursorPosition = _mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, _clippingPlanePosition));
    }
}
