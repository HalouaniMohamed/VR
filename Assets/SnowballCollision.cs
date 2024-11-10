using UnityEngine;

public class SnowballCollision : MonoBehaviour
{
    public GameUI gameUI;
    public AudioSource audioSource;
    public AudioClip hitSound;

    private void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Mascot"))
        {
            PlayHitSound();

            gameUI.RegisterSnowballHit();
            Destroy(gameObject);
        }
    }

    private void PlayHitSound()
    {
        if (audioSource != null && hitSound != null)
        {
            audioSource.PlayOneShot(hitSound);
        }
        else
        {
            Debug.LogWarning("audio error");
        }
    }
}
