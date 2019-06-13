using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentSpawner : MonoBehaviour
{
    public GameObject spawnPrefab;
    public float spawnRate = 1f;
    public float radius = 25f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn(spawnPrefab));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Spawn(GameObject prefab)
    {
        Vector3 point =  GetRandomPointOnTerrain();
        Instantiate(prefab, point, Quaternion.identity);
        yield return new WaitForSeconds(1f / spawnRate);
        StartCoroutine(Spawn(prefab));
    }
    public Vector3 GetRandomPointOnTerrain()
    {
        Vector3 randomPoint = transform.position + Random.insideUnitSphere * radius;
        //NavMeshHit hit;
        //NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas);

        randomPoint.y = Terrain.activeTerrain.SampleHeight(randomPoint);
        return randomPoint;
    }
}
