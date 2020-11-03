using UnityEngine;

public class PlaceWhiteBall : MonoBehaviour
{
    [Header("Setup:")]
    [SerializeField] private GameObject _whiteBall;

    private Collider _coll;

    private void Awake()
    {
        _coll = GetComponent<Collider>();
    }

    private void Update()
    {
        if (TouchInput.GetIsScreenTouched && Mathf.Abs(TouchInput.GetTouchPosition.x) <= Mathf.Abs(_coll.bounds.size.x / 2.0f) && 
            Mathf.Abs(TouchInput.GetTouchPosition.z) <= Mathf.Abs(_coll.bounds.size.z / 2.0f))
        {
            _whiteBall.transform.position = new Vector3(TouchInput.GetTouchPosition.x, 0.817f, TouchInput.GetTouchPosition.z);
            _whiteBall.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
