using UnityEngine;

public class PlaceWhiteBall : MonoBehaviour
{
    [Header("Setup:")]
    [SerializeField] private GameObject _whiteBall;

    private void Update()
    {
        if (TouchInput.GetIsScreenTouched)
        {
            _whiteBall.transform.position = new Vector3(TouchInput.GetTouchPosition.x, 0.817f, TouchInput.GetTouchPosition.z);
            _whiteBall.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
