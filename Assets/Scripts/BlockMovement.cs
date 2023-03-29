using UnityEngine;

public class BlockMovement : MonoBehaviour, IPooledObject
{
    [SerializeField] Rigidbody _blockRb;
    [SerializeField] float _blockSpeed = 20f;
    [SerializeField] float _blockKill = -30f;

    ObjectPooler objectPooler;

    void Start()
    {
        objectPooler = ObjectPooler.Instance;
    }

    void LateUpdate()
    {
        _blockRb.velocity = transform.forward * Time.deltaTime * -_blockSpeed;
        if (transform.position.z < _blockKill) objectPooler.ReturnToPool(_blockRb.name, gameObject);
    }

    public void OnObjectSpawn() {}
}
