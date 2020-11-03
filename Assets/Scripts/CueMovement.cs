using UnityEngine;

public class CueMovement : MonoBehaviour
{
    [Header("Setup:")]
    [SerializeField] private GameObject _cueCameraView;

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

    //First we create direction vector for velocity, then we create force modifier so we can properly add force from distance of the cursor based on rotation,
    //making it feel more natural, lastly we set up velocity
    private void FixedUpdate()
    {
        Vector3 rotatedVector = Quaternion.AngleAxis(transform.eulerAngles.y, Vector3.up) * Vector3.forward;

        _forceModifier = ((CursorPosition.GetCursorPosition.x - transform.position.x) * rotatedVector.x) + 
            ((CursorPosition.GetCursorPosition.z - transform.position.z) * rotatedVector.z);

        _cueRigidbody.velocity = rotatedVector * Time.deltaTime * _forceModifier * _force;
    }

    private void DisableCueAfterHit()
    {
        _cueCameraView.SetActive(false);
        gameObject.SetActive(false);
    }    
}
