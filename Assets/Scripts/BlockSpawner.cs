using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] GameObject blockPrefab;

    // Start is called before the first frame update
    void Start()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        for(int i = 0; i < spawnPoints.Length; i++)
        {
            if(randomIndex != i)
            {
                Instantiate(blockPrefab, spawnPoints[i].position, Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
