using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody _rb;
    [SerializeField] float _sidewaysMovement = 120f;
    [SerializeField] float _fallDeathHeight = -1f;

    void Start()
    {
        
    }

    void FixedUpdate()
    {        
        if (Input.GetKey("d"))
        {
            _rb.AddForce(_sidewaysMovement * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey("a"))
        {
            _rb.AddForce(-_sidewaysMovement * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if(_rb.position.y < _fallDeathHeight)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
