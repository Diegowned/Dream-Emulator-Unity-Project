using UnityEngine;

public class FootstepSound : MonoBehaviour
{
    // Declare the audio source and footstep sounds as public variables
    public AudioSource audioSource;
    public AudioClip[] footstepSounds;

    // Declare a public variable for the delay between footstep sounds
    public float footstepDelay = 0.5f;

    // Declare private variables to keep track of the current footstep sound and the time of the last footstep
    private int currentFootstepSound = 0;
    private float lastFootstepTime = 0f;

    // Update is called once per frame
    void Update()
    {
        // Check if the player is moving and the required time has passed since the last footstep
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0 && Time.time - lastFootstepTime > footstepDelay)
        {
            // Play the footstep sound
            audioSource.clip = footstepSounds[currentFootstepSound];
            audioSource.Play();

            // Increment the current footstep sound and wrap around if necessary
            currentFootstepSound++;
            if (currentFootstepSound >= footstepSounds.Length)
            {
                currentFootstepSound = 0;
            }

            // Update the time of the last footstep
            lastFootstepTime = Time.time;
        }
    }
}

