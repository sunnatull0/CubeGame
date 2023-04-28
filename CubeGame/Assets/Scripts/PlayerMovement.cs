using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject bulletPrefab;
    public Transform bulletPos;
    public Animator anim;
    public GameObject reloadImage;
    private AudioSource audioSource;
    private float horizontal;
    public float moveSpeed, bulletSpeed, reloadTime;
    private bool isReady;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        StartCoroutine(Reloading());
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space) && isReady)
        {
            Shooting();
            StartCoroutine(Reloading());
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(horizontal * moveSpeed, rb.velocity.y, rb.velocity.z) * Time.deltaTime;
    }

    void Shooting()
    {
        GameObject doneBullet = Instantiate(bulletPrefab, bulletPos.position, Quaternion.Euler(90, 0, 0));
        doneBullet.GetComponent<Rigidbody>().AddForce(0, 0, bulletSpeed);
        audioSource.pitch = Random.Range(0.8f, 1.2f);
        audioSource.Play();
        anim.SetTrigger("Shooting");
        reloadImage.SetActive(true);
        isReady = false;
    }

    IEnumerator Reloading()
    {
        yield return new WaitForSeconds(reloadTime);
        reloadImage.SetActive(false);
        isReady = true;
    }

    public void ChangeReloadTime(float newreloadtime)
    {
        reloadTime -= newreloadtime;
    }

}
