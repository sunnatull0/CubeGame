using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constraints : MonoBehaviour
{
    [SerializeField] private TextController textController;
    private void OnTriggerEnter(Collider other)
    {
        textController.GameOver();
    }
}
