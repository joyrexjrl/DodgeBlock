using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    [SerializeField] Transform[] _spawnPoints;
    [SerializeField] GameObject _blockPrefab;
    [SerializeField] GameObject _jumpBlock;
    [SerializeField] GameObject _reverseBlockPrefab;
    [SerializeField] GameObject _reverseJumpBlock;
    [SerializeField] float _timeToSpawn = 2f;
    [SerializeField] float _timeBetweenWaves = 1f;
    [SerializeField] bool _isReverseBlockSpawner = false;

    void FixedUpdate()
    {
        if(Time.time >= _timeToSpawn)
        {
            if (!_isReverseBlockSpawner) SpawnBlocks(_blockPrefab, _jumpBlock);
            else SpawnBlocks(_reverseBlockPrefab, _reverseJumpBlock);
            _timeToSpawn = Time.time + _timeBetweenWaves;
        }
        
    }

    void SpawnBlocks(GameObject blocks, GameObject jumpBlocks)
    {
        int randomNumber = Random.Range(1, 10);
        int randomIndex = Random.Range(0, _spawnPoints.Length);
        if (!_isReverseBlockSpawner)
        {
            for (int i = 0; i < _spawnPoints.Length; i++)
            {
                if (randomIndex != i) Instantiate(blocks, _spawnPoints[i].position, Quaternion.identity);
                if (randomIndex == i && randomNumber <= 3) Instantiate(jumpBlocks, _spawnPoints[i].position, Quaternion.Euler(jumpBlocks.transform.rotation.x - 30, jumpBlocks.transform.position.y - 0.8f, 0));
            }
        }
        else
        {
            for (int i = 0; i < _spawnPoints.Length; i++)
            {
                if (randomIndex != i && _isReverseBlockSpawner) Instantiate(blocks, _spawnPoints[i].position, Quaternion.identity);
                if (randomIndex == i && randomNumber <= 3 && _isReverseBlockSpawner) Instantiate(jumpBlocks, _spawnPoints[i].position, Quaternion.Euler(jumpBlocks.transform.rotation.x + 30, jumpBlocks.transform.position.y + 0.8f, 0));
            }
        }
    }
}
