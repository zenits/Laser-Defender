using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Wave config", fileName = "new Wave config")]
public class WaveConfigSO : ScriptableObject
{

    [SerializeField] Transform pathPrefab;
    [SerializeField] List<GameObject> enemyPrefabs;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float timeBetweenenemySpawns = 1f;
    [SerializeField] float spawTimeVariance = 0f;
    [SerializeField] float minimumSpawnTime = 0.2f;



    public Transform GetStartingWaypoint()
    {
        return pathPrefab.GetChild(0);
    }
    public List<Transform> GetWaypoints()
    {
        List<Transform> result = new List<Transform>();
        foreach (Transform child in pathPrefab)
        {
            result.Add(child);
        }
        return result;
    }

    public float GetMoveSpeed() { return moveSpeed; }
    public int GetEnemyCount() { return enemyPrefabs.Count; }
    public GameObject GetEnemyPrefab(int index)
    {
        if (index >= 0 && index < GetEnemyCount())
            return enemyPrefabs[index];
        else
            return new GameObject();
    }

    public float GetRandomSpawnTime()
    {
        float spawnTime = Random.Range(timeBetweenenemySpawns - spawTimeVariance, timeBetweenenemySpawns + spawTimeVariance);
        return Mathf.Clamp(spawnTime, minimumSpawnTime, float.MaxValue);
    }
}
