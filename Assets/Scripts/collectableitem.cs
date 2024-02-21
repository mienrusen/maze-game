using UnityEngine;
using System.Collections;

public class CollectibleItem : MonoBehaviour
{
    private float respawnTime = 10f;
    public AudioClip itemSound;
    private AudioSource audioSource;

    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = itemSound;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponent<Renderer>().enabled = false;
            PlaySound();

            StartCoroutine(RespawnItem(respawnTime));
        }
    }

    IEnumerator RespawnItem(float respawnTime)
    {
        yield return new WaitForSeconds(respawnTime);
        GetComponent<Renderer>().enabled = true;
    }

    public void PlaySound()
    {
        audioSource.Play(); 
    }

    public void StopSound()
    {
        audioSource.Stop();
    }

}

