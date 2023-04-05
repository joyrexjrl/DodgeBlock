using System.Threading.Tasks;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] Rigidbody _rb;
    [SerializeField] PlayerMovement _movement;
    [SerializeField] float _sparkOffsetAmount = 0.1f;
    [SerializeField] float _jumpForce = 20f;
    [SerializeField] bool _isReversed = false;
    ObjectPooler objectPooler;

    float _xSpin, _ySpin, _zSpin, _spinSpeed;
    bool _isInAir = false;

    void Start() => objectPooler = ObjectPooler.Instance;

    void FixedUpdate()
    {
        if (_isInAir) RandomSpin();
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Obstacle")
        {            
            _movement.enabled = false;
            SpawnSpark(collision);
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    void SpawnSpark(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];
        Vector3 offset = contact.normal * _sparkOffsetAmount;
        Vector3 spawnPos = contact.point + offset;

        int numContacts = collision.contacts.Length;
        if (numContacts > 1)
        {
            ContactPoint contact2 = collision.contacts[numContacts - 1];
            Vector3 offset2 = contact2.normal * _sparkOffsetAmount;
            Vector3 spawnPos2 = contact2.point + offset2;
            spawnPos = (spawnPos + spawnPos2) / 2f;
        }

        spawnPos.y += (_isReversed) ? -0.5f : 0.5f;

        objectPooler.SpawnFromPool("SparksParticle", spawnPos, Quaternion.identity);
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

    async void RandomSpin()
    {
        _xSpin = Random.Range(0, 360);
        _ySpin = Random.Range(0, 360);
        _zSpin = Random.Range(0, 360);
        _spinSpeed = Random.Range(1, 3) * Time.deltaTime;
        _rb.AddTorque(_xSpin + _spinSpeed, _ySpin + _spinSpeed, _zSpin + _spinSpeed);
        await Task.Yield();
        _isInAir = false;
    }
}
