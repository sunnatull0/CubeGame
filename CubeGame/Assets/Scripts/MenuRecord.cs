using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuRecord : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI recordText;
    [SerializeField] private GameObject On;
    [SerializeField] private GameObject Off;
    bool isPaused = false;
    void Start()
    {
        recordText.text = "RECORD: " + (int)PlayerPrefs.GetFloat("Record");
    }

    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }

    public void SoundManage()
    {
        if (!isPaused)
        {
            AudioListener.pause = true;
            On.SetActive(false);
            Off.SetActive(true);
            isPaused = true;
        }
        else if (isPaused)
        {
            AudioListener.pause = false;
            On.SetActive(true);
            Off.SetActive(false);
            isPaused = false;
        }
    }

}
