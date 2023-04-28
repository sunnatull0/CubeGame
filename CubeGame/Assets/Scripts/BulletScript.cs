using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public GameObject bonusEffect;
    private TextController test;
    public float extraScore;
    void Start()
    {
        test = FindObjectOfType<TextController>();
    }

    void Update()
    {
        if (transform.position.z >= 75)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            BonusHit();
            Destroy(collision.gameObject);
        }
        Destroy(gameObject);
    }

    void BonusHit()
    {
        test.AudioPlay();
        test.score += extraScore;
        Instantiate(bonusEffect, transform.position, Quaternion.identity);
    }
}
