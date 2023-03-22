using UnityEngine;

public class ReverseGravity : MonoBehaviour
{
    [SerializeField] float _reverseThreshold = 12.5f;
    [SerializeField] float _gravityScale = 1.5f;

    Rigidbody _rb;
    bool _isGravityReversed = false;

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (transform.position.y > _reverseThreshold && !_isGravityReversed)
        {
            _isGravityReversed = true;
            _rb.useGravity = false;
            _rb.velocity = new Vector3(_rb.velocity.x, _gravityScale, _rb.velocity.z);
        }else if(transform.position.y <= _reverseThreshold && _isGravityReversed)
        {
            _isGravityReversed = false;
            _rb.useGravity = true;
            _rb.velocity = new Vector3(_rb.velocity.x, -_gravityScale, _rb.velocity.z);
        }

        if (_isGravityReversed) _rb.AddForce(Vector3.up * _gravityScale * _rb.mass, ForceMode.Force);
    }
}
