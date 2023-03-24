using System.Collections;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] Rigidbody _rb;
    [SerializeField] PlayerMovement _movement;
    [SerializeField] float _jumpForce = 20f;
    [SerializeField] bool _isReversed = false;

    float _xSpin, _ySpin, _zSpin, _spinSpeed;
    bool _isInAir = false;

    void FixedUpdate()
    {
        if (_isInAir)
        {
            StartCoroutine(RandomSpin());
        }
    }

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
                _isInAir = true;
                _rb.AddForce(0, _jumpForce, 0, ForceMode.VelocityChange);
            }
            else
            {
                _isReversed = false;
                _isInAir = true;
                _rb.AddForce(0, -_jumpForce, 0, ForceMode.VelocityChange);
            }            
        }
    }

    IEnumerator RandomSpin()
    {
        _xSpin = Random.Range(0, 360);
        _ySpin = Random.Range(0, 360);
        _zSpin = Random.Range(0, 360);
        _spinSpeed = Random.Range(1, 3) * Time.deltaTime;
        _rb.AddTorque(_xSpin + _spinSpeed, _ySpin + _spinSpeed, _zSpin + _spinSpeed);
        yield return new WaitForSeconds(0.5f);
        _isInAir = false;
    }
}
