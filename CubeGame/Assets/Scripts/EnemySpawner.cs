using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float delayEnemy;
    void Start()
    {
        StartCoroutine(Waiting());
    }

    void EnemyTest()
    {
        Instantiate(enemyPrefab, new Vector3(Random.Range(-5.5f, 5.5f), 0.75f, 75f), Quaternion.identity);
    }

    IEnumerator EnemySpawning()
    {
        while (true)
        {
            Instantiate(enemyPrefab, new Vector3(Random.Range(-5.5f, 5.5f), 0.75f, 75f), Quaternion.Euler(90, 0, 0));
            yield return new WaitForSeconds(delayEnemy);
        }
    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(1.7f);
        StartCoroutine(EnemySpawning());
    }

    public void ChangeDelayEnemy(float newDelayEnemy)
    {
        delayEnemy -= newDelayEnemy;
    }

}
