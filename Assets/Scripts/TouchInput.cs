using UnityEngine;

public class TouchInput : MonoBehaviour
{
    [Header("Setup:")]
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private Transform _ClipPlaneTransform;

    private float _clippingPlanePosition;
    private Touch _touch;
    private static Vector3 _touchPosition;
    private static bool _isScreenTouched;

    public static Vector3 GetTouchPosition { get { return _touchPosition; } }
    public static bool GetIsScreenTouched { get { return _isScreenTouched; } }


    private void Awake()
    {
        _clippingPlanePosition = _mainCamera.transform.position.y - _ClipPlaneTransform.position.y;
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            _isScreenTouched = true;
            _touch = Input.GetTouch(0);
        }
        else
        {
            _isScreenTouched = false;
        }

        _touchPosition = _mainCamera.ScreenToWorldPoint(new Vector3(_touch.position.x, _touch.position.y, _clippingPlanePosition));
    }
}
