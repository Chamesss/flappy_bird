using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject pipe;
    [SerializeField] private float spawnRate = 3;
    [SerializeField] private float heightOffset = 10;
    
    private float _timer = 0;
    void Start()
    {
        SpawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if (_timer < spawnRate)
        {
            _timer += Time.deltaTime;
        }
        else
        {
            SpawnPipe();
            _timer = 0;
        }
    }

    void SpawnPipe()
    {
        var lowestPoint = transform.position.y - heightOffset;
        var highestPoint = transform.position.y + heightOffset;
        
        var random = Random.Range(lowestPoint, highestPoint);
        
        Instantiate(pipe, new Vector3(transform.position.x, random, 0), transform.rotation);
    }
}
