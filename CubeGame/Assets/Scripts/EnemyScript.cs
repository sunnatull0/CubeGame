using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyScript : MonoBehaviour
{
    public float deadPos;
    private TextController textController;
    void Start()
    {
        textController = FindObjectOfType<TextController>();
    }

    void Update()
    {
        if(transform.position.z <= deadPos)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        PlayerMovement playerScript = collision.gameObject.GetComponent<PlayerMovement>();
        if (playerScript)
        {
            textController.GameOver();
        }
    }
}
