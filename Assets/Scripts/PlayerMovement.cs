using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float sidewaysMovement = 120f;
    [SerializeField] float fallDeathHeight = -1f;

    void Start()
    {
        
    }

    void FixedUpdate()
    {        
        if (Input.GetKey("d"))
        {
            rb.AddForce(sidewaysMovement * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(-sidewaysMovement * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if(rb.position.y < fallDeathHeight)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
