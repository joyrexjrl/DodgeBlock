using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] Transform _player;
    [SerializeField] Vector3 _offset;
    [SerializeField] float _minY = 2f;
    [SerializeField] float _maxY = 23f;
    [SerializeField] float _yLerpSpeed = 10f;

    [SerializeField] float _rotationSpeed = 1f;
    [SerializeField] float _initialXRotation = 0f;

    private float _targetXRotation;
    private float _previousYPosition;

    void Start()
    {
        _targetXRotation = _initialXRotation;
        _previousYPosition = transform.position.y;
    }

    void LateUpdate()
    {
        Vector3 targetPosition = transform.position;
        targetPosition.y = Mathf.Clamp(_player.position.y, _minY, _maxY) + _offset.y;

        transform.position = new Vector3(_offset.x + _player.position.x, transform.position.y, _offset.z + _player.position.z);

        // Check if Y position has changed
        if (transform.position.y != _previousYPosition)
        {
            // Calculate target rotation based on new Y position
            float t = Mathf.InverseLerp(_minY, _maxY, transform.position.y);
            _targetXRotation = Mathf.Lerp(_initialXRotation, -_initialXRotation, t);
            _previousYPosition = transform.position.y;
        }

        // Lerp camera position towards target
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * _yLerpSpeed);

        // Check if Y position has changed again (after position has been updated)
        if (transform.position.y != targetPosition.y)
        {
            // Update X rotation based on player's X movement
            float xMovement = _player.position.x - transform.position.x;
            _targetXRotation += xMovement * _rotationSpeed;
        }

        // Set camera rotation to target rotation
        transform.rotation = Quaternion.Euler(_targetXRotation, 0f, 0f);
    }

    /*void LateUpdate()
    {
        Vector3 targetPosition = transform.position;
        targetPosition.y = Mathf.Clamp(_player.position.y, _minY, _maxY) + _offset.y;
        
        transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, targetPosition.y, Time.deltaTime * _yLerpSpeed), transform.position.z);
        transform.position = new Vector3(_offset.x + _player.position.x, transform.position.y, _offset.z + _player.position.z);
    }*/
}
