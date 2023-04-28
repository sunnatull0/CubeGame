using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public float delay;
    void Start()
    {
        StartCoroutine(ObstaclesSpawn());
    }

    IEnumerator ObstaclesSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            Instantiate(obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)], new Vector3( Random.Range(-3f, 3f), 0.75f,75f), Quaternion.identity);
        }
    }

    public void ChangeDelay(float newDelay)
    {
        delay -= newDelay;
    }

}
