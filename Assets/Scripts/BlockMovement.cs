using UnityEngine;

public class BlockMovement : MonoBehaviour
{
    [SerializeField] Rigidbody _blockRb;
    [SerializeField] float _blockSpeed = 80;

    void FixedUpdate()
    {
        _blockRb.AddForce(0, 0, -_blockSpeed * Time.deltaTime, ForceMode.VelocityChange);
        if (transform.position.y < -2f) Destroy(gameObject);
    }
}
