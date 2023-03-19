using UnityEngine;
using UnityEngine.Pool;

public class BlockSpawner : MonoBehaviour
{
    [SerializeField] Transform[] _spawnPoints;
    [SerializeField] GameObject _blockPrefab;
    [SerializeField] float _timeToSpawn = 2f;
    [SerializeField] float _timeBetweenWaves = 1f;

    ObjectPool<GameObject> _pool;

    void Update()
    {
        
    }

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
        int randomIndex = Random.Range(0, _spawnPoints.Length);
        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            if (randomIndex != i)
            {
                Instantiate(_blockPrefab, _spawnPoints[i].position, Quaternion.identity);
            }
        }
    }
}
