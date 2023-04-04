using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody _rb;
    [SerializeField] float _sidewaysMovement = 120f;
    [SerializeField] float _fallDeathHeight = -1f;
    [SerializeField] float _reverseFallDeathHeight = 25.2f;

    PlayerControl playerContol;

    void Awake() => playerContol = new PlayerControl();

    void OnEnable() => playerContol.Gameplay.Enable();

    void OnDisable() => playerContol.Gameplay.Disable();

    void FixedUpdate()
    {
        Vector2 inputVector = playerContol.Gameplay.PlayerMove.ReadValue<Vector2>();
        _rb.AddForce(_sidewaysMovement * Time.fixedDeltaTime * new Vector3(inputVector.x, 0, inputVector.y), ForceMode.VelocityChange);
        if (_rb.position.y < _fallDeathHeight || _rb.position.y > _reverseFallDeathHeight) FindObjectOfType<GameManager>().EndGame();
    }
}
