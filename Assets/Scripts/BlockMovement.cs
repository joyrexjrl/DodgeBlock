using UnityEngine;

public class BlockMovement : MonoBehaviour
{
    [SerializeField] Rigidbody blockRb;
    [SerializeField] float blockSpeed = 80;

    void FixedUpdate()
    {
        blockRb.AddForce(0, 0, -blockSpeed * Time.deltaTime, ForceMode.VelocityChange);
        if (transform.position.y < -2f) Destroy(gameObject);
    }
}
