using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] Rigidbody _rb;
    [SerializeField] PlayerMovement _movement;
    [SerializeField] float _jumpForce = 20f;

    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Obstacle")
        {
            _movement.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    void OnTriggerEnter(Collider trigger)
    {
        if (trigger.tag == "JumpBox")
        {
            _rb.AddForce(0, _jumpForce, 0, ForceMode.VelocityChange);
        }
    }
}
