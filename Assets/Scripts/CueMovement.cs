using UnityEngine;

public class CueMovement : MonoBehaviour
{
    [Header("Settings:")]
    [SerializeField] private float _force;

    private Rigidbody _cueRigidbody;
    private float _forceModifier;

    private void Awake()
    {
        _cueRigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Score.SubstractScore = 1;
        Score.UpdateScore();
        Invoke("DisableCueAfterHit", 0.1f);
    }

    private void FixedUpdate()
    {
        Vector3 rotatedVector = Quaternion.AngleAxis(transform.eulerAngles.y, Vector3.up) * Vector3.forward;

        _forceModifier = ((CursorPosition.GetCursorPosition.x - transform.position.x) * rotatedVector.x) + 
            ((CursorPosition.GetCursorPosition.z - transform.position.z) * rotatedVector.z);

        _cueRigidbody.velocity = rotatedVector * Time.deltaTime * _forceModifier * _force;
    }

    private void DisableCueAfterHit()
    {
        gameObject.SetActive(false);
    }    
}
