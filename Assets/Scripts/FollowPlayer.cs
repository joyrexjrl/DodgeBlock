using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] Transform _player;
    [SerializeField] Vector3 _offset;
    [SerializeField] float _minY = 2f;
    [SerializeField] float _maxY = 23f;
    [SerializeField] float _yLerpSpeed = 10f;

    void LateUpdate()
    {
        Vector3 targetPosition = transform.position;
        targetPosition.y = Mathf.Clamp(_player.position.y, _minY, _maxY) + _offset.y;
        transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, targetPosition.y, Time.deltaTime * _yLerpSpeed), transform.position.z);
        transform.position = new Vector3(_offset.x + _player.position.x, transform.position.y, _offset.z + _player.position.z);
        //transform.position = _player.position + _offset;
    }
}
