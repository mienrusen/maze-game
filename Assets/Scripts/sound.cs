using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    public Image soundImage;
    public Sprite soundOnSprite;
    public Sprite soundOffSprite;
    public AudioClip themeSound;
    private AudioSource audioSource;
    public bool isSoundOn = true;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = themeSound;
        audioSource.Play();
    }

    public void ToggleSound()
    {
        isSoundOn = !isSoundOn;

        if (isSoundOn)
        {
            audioSource.Play();
            soundImage.sprite = soundOnSprite;
        }
        else
        {
            audioSource.Pause();
            soundImage.sprite = soundOffSprite;
        }
    }
}

