using UnityEngine;

public class BlockMovement : MonoBehaviour, IPooledObject
{
    [SerializeField] Rigidbody _blockRb;
    [SerializeField] float _blockSpeed = 20;
    [SerializeField] float _gravityScale = 2f;
    [SerializeField] bool _isReverseBlock = false;

    float _blockKill = -30f;

    public void OnObjectSpawn()
    {

    }

    void LateUpdate()
    {
        MoveTheBlock();
    }

    void MoveTheBlock()
    {
        _blockRb.AddForce(0, 0, -_blockSpeed * Time.deltaTime, ForceMode.VelocityChange);
        //if (_isReverseBlock) _blockRb.AddForce(Vector3.up * _gravityScale * _blockRb.mass, ForceMode.Force);
        //if (transform.position.z < _blockKill) Destroy(gameObject);    
    }
}
