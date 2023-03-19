using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    [SerializeField] Transform[] _spawnPoints;
    [SerializeField] GameObject _blockPrefab;
    [SerializeField] GameObject _jumpBlock;
    [SerializeField] float _timeToSpawn = 2f;
    [SerializeField] float _timeBetweenWaves = 1f;
    

    void FixedUpdate()
    {
        if(Time.time >= _timeToSpawn)
        {
            SpawnBlocks();
            _timeToSpawn = Time.time + _timeBetweenWaves;
        }
        
    }

    void SpawnBlocks()
    {
        int randomNumber = Random.Range(1, 10);
        int randomIndex = Random.Range(0, _spawnPoints.Length);
        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            if (randomIndex != i)
            {                
                Instantiate(_blockPrefab, _spawnPoints[i].position, Quaternion.identity);
            }
            if(randomIndex == i && randomNumber <= 3)
            {
                Instantiate(_jumpBlock, _spawnPoints[i].position, Quaternion.identity);
            }
        }
    }
}
