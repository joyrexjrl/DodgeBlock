using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    [SerializeField] Transform[] _spawnPoints;
    [SerializeField] GameObject _obstacle;
    [SerializeField] GameObject _reverseObstacle;
    [SerializeField] GameObject _jumpBlock;
    [SerializeField] GameObject _reverseJumpBlock;
    [SerializeField] float _timeToSpawn = 2f;
    [SerializeField] float _timeBetweenWaves = 1f;
    [SerializeField] bool _isReverseBlockSpawner = false;
    ObjectPooler objectPooler;

    public bool _isUsingPooledObjects = false;

    

    void Start()
    {
        objectPooler = ObjectPooler.Instance;
    }

    void FixedUpdate()
    {
        if (!_isReverseBlockSpawner) CallBlock(_obstacle, _jumpBlock);
        else CallBlock(_reverseObstacle, _reverseJumpBlock);
    }

    void CallBlock(GameObject blocks, GameObject jumpBlocks)
    {
        if (Time.time >= _timeToSpawn)
        {
            int randomNumber = Random.Range(1, 10);
            int randomIndex = Random.Range(0, _spawnPoints.Length);

            if (!_isReverseBlockSpawner)
            {
                for (int i = 0; i < _spawnPoints.Length; i++)
                {
                    if (!_isUsingPooledObjects)
                    {
                        if (randomIndex != i) Instantiate(blocks, _spawnPoints[i].position, Quaternion.identity);
                        if (randomIndex == i && randomNumber <= 3) Instantiate(jumpBlocks, _spawnPoints[i].position, Quaternion.identity);
                    }
                    else
                    {
                        if (randomIndex != i) objectPooler.SpawnFromPool("Obstacle", _spawnPoints[i].position, Quaternion.identity);
                        if (randomIndex == i && randomNumber <= 3) objectPooler.SpawnFromPool("JumpObstacle", _spawnPoints[i].position, Quaternion.identity);
                    }
                }
            }
            else
            {
                for (int i = 0; i < _spawnPoints.Length; i++)
                {
                    if (!_isUsingPooledObjects)
                    {
                        if (randomIndex != i && _isReverseBlockSpawner) Instantiate(blocks, _spawnPoints[i].position, Quaternion.identity);
                        if (randomIndex == i && randomNumber <= 3 && _isReverseBlockSpawner) Instantiate(jumpBlocks, _spawnPoints[i].position, Quaternion.identity);
                    }
                    else
                    {
                        if (randomIndex != i && _isReverseBlockSpawner) objectPooler.SpawnFromPool("ReverseObstacle", _spawnPoints[i].position, Quaternion.identity);
                        if (randomIndex == i && randomNumber <= 3 && _isReverseBlockSpawner) objectPooler.SpawnFromPool("ReverseJumpObstacle", _spawnPoints[i].position, Quaternion.identity);
                    }
                }
            }
            _timeToSpawn = Time.time + _timeBetweenWaves;
        }
    }
}
