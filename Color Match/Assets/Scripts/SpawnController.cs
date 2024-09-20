using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField] private List<GameObject> figurePrefabs;

    [SerializeField] private float _delayPerSecond = 2f;

    private float spawnDelay = 0;

    void Update()
    {
        if (Time.time >= spawnDelay)
        {
            int prefabIndex = Random.Range(0, figurePrefabs.Count);
            GameObject curentFigure = Instantiate<GameObject>(figurePrefabs[prefabIndex], transform.position, Quaternion.identity);
            spawnDelay = Time.time + _delayPerSecond;
        }
    }
}
