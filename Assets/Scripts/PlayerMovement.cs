using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody _rb;
    [SerializeField] float _sidewaysMovement = 120f;
    [SerializeField] float _fallDeathHeight = -1f;
    [SerializeField] float _reverseFallDeathHeight = 25.2f;

    PlayerInput playerInput;
    PlayerControl playerContol;

    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        playerContol = new PlayerControl();
        playerContol.Gameplay.Enable();
    }

    void Update() => Input.GetAxisRaw("Horizontal");

    void FixedUpdate()
    {
        Vector2 inputVector = playerContol.Gameplay.PlayerMove.ReadValue<Vector2>();
        _rb.AddForce(_sidewaysMovement * Time.fixedDeltaTime * new Vector3(inputVector.x, 0, inputVector.y), ForceMode.VelocityChange);
        //MovePlayer();
        if (_rb.position.y < _fallDeathHeight || _rb.position.y > _reverseFallDeathHeight) FindObjectOfType<GameManager>().EndGame();
    }

    /*void MovePlayer()
    {
        if(Input.GetAxisRaw("Horizontal") > 0) _rb.AddForce(_sidewaysMovement * Time.fixedDeltaTime, 0, 0, ForceMode.VelocityChange);
        else if(Input.GetAxisRaw("Horizontal") < 0) _rb.AddForce(-_sidewaysMovement * Time.fixedDeltaTime, 0, 0, ForceMode.VelocityChange);        
    }*/
}
