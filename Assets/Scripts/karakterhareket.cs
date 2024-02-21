using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class karakterhareket : MonoBehaviour
{

    private float moveSpeed = 10f;
    public Transform playerCamera;
    public Rigidbody rb;
    public GameObject gameOverPanel;

    public float shrinkSpeed = 0.1f;
    public float regrowSpeed;
    private Vector3 initialScale;
    private Vector3 curScale;
    private bool isMoving = false;
    private bool isCollectingItem = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialScale = transform.localScale;
        gameOverPanel.SetActive(false);
        isCollectingItem = false;
        regrowSpeed = shrinkSpeed * 2f;
    }

    void Update()
    {
        if (transform.localScale.x > 0f && transform.localScale.y > 0f && transform.localScale.z > 0f)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
            rb.freezeRotation = true;

            Move(direction);
        }

        if (isMoving && !isCollectingItem)
        {
            Shrink();
            print("isMoving");
        }

        if (transform.localScale.x <= 0f || transform.localScale.y <= 0f || transform.localScale.z <= 0f)
        {
            GameOver();
            gameOverPanel.SetActive(true);
        }
    }

    void Move(Vector3 direction)
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0f, vertical) * moveSpeed * Time.deltaTime;
        transform.Translate(movement, Space.World);

        isMoving = movement.magnitude > 0;
    }

    public void Shrink()
    {
        transform.localScale -= Vector3.one * shrinkSpeed * Time.deltaTime;
        print("shrink");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CollectibleItem"))
        {
            isCollectingItem = true;
            transform.localScale += Vector3.one * regrowSpeed * Time.deltaTime;
            print("trigger");
        }
        else if (other.CompareTag("Enemy"))
        {
            GameOver();
            gameOverPanel.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("CollectibleItem"))
        {
            isCollectingItem = false;
            Shrink();
        }
    }

    void GameOver()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        Time.timeScale = 0f;
        isMoving = false;
    }
}
