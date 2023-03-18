using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float sidewaysMovement = 120f;

    void Start()
    {
        
    }

    void FixedUpdate()
    {        
        if (Input.GetKey("d"))
        {
            rb.AddForce(sidewaysMovement * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(-sidewaysMovement * Time.deltaTime, 0, 0);
        }
    }
}
