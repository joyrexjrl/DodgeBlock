using UnityEngine;

public class BlockMovement : MonoBehaviour, IPooledObject
{
    [SerializeField] Rigidbody _blockRb;
    [SerializeField] float _blockSpeed = 30;
    [SerializeField] float _gravityScale = 2f;
    [SerializeField] bool _isReverseBlock = false;

    public void OnObjectSpawn()
    {
        
    }

    void LateUpdate()
    {
        //_blockRb.AddForce(0, 0, -_blockSpeed * Time.deltaTime, ForceMode.VelocityChange);
        //if (_isReverseBlock) _blockRb.AddForce(Vector3.up * _gravityScale * _blockRb.mass, ForceMode.Force);
        //if (transform.position.y < -2f) Destroy(gameObject);
        //if (transform.position.y > 25f && _isReverseBlock) Destroy(gameObject);
    }
}
