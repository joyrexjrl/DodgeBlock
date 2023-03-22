using UnityEngine;

public class BlockMovement : MonoBehaviour
{
    [SerializeField] Rigidbody _blockRb;
    [SerializeField] float _blockSpeed = 80;
    [SerializeField] float _gravityScale = 2f;
    [SerializeField] bool _isReverseBlock = false;

    void FixedUpdate()
    {
        _blockRb.AddForce(0, 0, -_blockSpeed * Time.deltaTime, ForceMode.VelocityChange);
        if (_isReverseBlock) _blockRb.AddForce(Vector3.up * _gravityScale * _blockRb.mass, ForceMode.Force);
        if (transform.position.y < -2f) Destroy(gameObject);
        if (transform.position.y > 25f && _isReverseBlock) Destroy(gameObject);
    }
}
