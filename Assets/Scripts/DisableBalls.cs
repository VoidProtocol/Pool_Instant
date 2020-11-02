using UnityEngine;

public class DisableBalls : MonoBehaviour
{
    [Header("Setup:")]
    [SerializeField] private GameObject _ballPlaceSurface;

    private void OnTriggerEnter(Collider collider)
    {
        collider.gameObject.SetActive(false);

        if (collider.gameObject.CompareTag("WhiteBall"))
        {
            _ballPlaceSurface.SetActive(true);
        }
    }
}
