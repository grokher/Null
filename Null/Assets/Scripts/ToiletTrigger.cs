using UnityEngine;

public class ToiletTrigger : MonoBehaviour
{
    public AudioSource flushSound; // Drag your Audio Source here
    public KeyCode triggerKey = KeyCode.E; // Key to trigger the flush

    void Update()
    {
        // Check if the key is pressed
        if (Input.GetKeyDown(triggerKey))
        {
            if (!flushSound.isPlaying)
            {
                flushSound.Play(); // Play the sound
                Debug.Log("Flushing!");
            }
        }
    }
}