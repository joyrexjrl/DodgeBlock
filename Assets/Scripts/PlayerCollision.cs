using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] Rigidbody _rb;
    [SerializeField] PlayerMovement _movement;
    [SerializeField] float _jumpForce = 20f;
    [SerializeField] bool _isReversed = false;

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
            if (!_isReversed)
            {
                _isReversed = true;
                _rb.AddForce(0, _jumpForce, 0, ForceMode.VelocityChange);
            }
            else
            {
                _isReversed = false;
                _rb.AddForce(0, -_jumpForce, 0, ForceMode.VelocityChange);
            }
            
        }
    }
}
