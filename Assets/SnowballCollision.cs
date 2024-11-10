using UnityEngine;

public class SnowballCollision : MonoBehaviour
{
    public GameUI gameUI;
    public AudioSource audioSource; // Reference to the AudioSource component
    public AudioClip hitSound;      // Sound effect clip

    private void Start()
    {
        // Ensure the AudioSource is assigned, if not, try to get it from the current GameObject
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Mascot"))
        {
            // Play the sound effect when the snowball hits the mascot
            PlayHitSound();

            // Register the hit in the GameUI and destroy the snowball
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
            Debug.LogWarning("AudioSource or hitSound not set up properly.");
        }
    }
}
