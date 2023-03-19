using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] PlayerMovement _movement;

    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Obstacle")
        {
            _movement.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
