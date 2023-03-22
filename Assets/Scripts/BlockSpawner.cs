using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    [SerializeField] Transform[] _spawnPoints;
    [SerializeField] GameObject _jumpBlock;
    [SerializeField] GameObject _reverseJumpBlock;
    [SerializeField] float _timeToSpawn = 2f;
    [SerializeField] float _timeBetweenWaves = 1f;
    [SerializeField] bool _isReverseBlockSpawner = false;

    ObjectPooler objectPooler;

    void Awake()
    {
        objectPooler = ObjectPooler.Instance;
    }

    void FixedUpdate()
    {
        if(Time.time >= _timeToSpawn)
        {
            int randomNumber = Random.Range(1, 10);
            int randomIndex = Random.Range(0, _spawnPoints.Length);

            if (!_isReverseBlockSpawner)
            {
                for (int i = 0; i < _spawnPoints.Length; i++)
                {
                    if (randomIndex != i) objectPooler.SpawnFromPool("Obstacle", _spawnPoints[i].position, Quaternion.identity); //Instantiate(blocks, _spawnPoints[i].position, Quaternion.identity);
                    if (randomIndex == i && randomNumber <= 3) objectPooler.SpawnFromPool("JumpObstacle", _spawnPoints[i].position, Quaternion.Euler(_jumpBlock.transform.rotation.x - 30, _jumpBlock.transform.position.y - 0.8f, 0)); //Instantiate(jumpBlocks, _spawnPoints[i].position, Quaternion.Euler(jumpBlocks.transform.rotation.x - 30, jumpBlocks.transform.position.y - 0.8f, 0));
                }
            }
            else
            {
                for (int i = 0; i < _spawnPoints.Length; i++)
                {
                    if (randomIndex != i && _isReverseBlockSpawner) objectPooler.SpawnFromPool("ReverseObstacle", _spawnPoints[i].position, Quaternion.identity); //Instantiate(blocks, _spawnPoints[i].position, Quaternion.identity);
                    if (randomIndex == i && randomNumber <= 3 && _isReverseBlockSpawner) objectPooler.SpawnFromPool("ReverseJumpObstacle", _spawnPoints[i].position, Quaternion.Euler(_reverseJumpBlock.transform.rotation.x + 30, _reverseJumpBlock.transform.position.y + 0.8f, 0)); //Instantiate(jumpBlocks, _spawnPoints[i].position, Quaternion.Euler(jumpBlocks.transform.rotation.x + 30, jumpBlocks.transform.position.y + 0.8f, 0));
                }
            }

            _timeToSpawn = Time.time + _timeBetweenWaves;
        }        
    }
}
