using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageSwitcher : MonoBehaviour
{
    public Image unmutedImage; // Drag the unmuted image component here in the Unity Inspector
    public Image mutedImage;   // Drag the muted image component here in the Unity Inspector

    private bool isMuted = false;

    public void ToggleMute()
    {
        isMuted = !isMuted;

        if (isMuted)
        {
            // Set muted image
            unmutedImage.gameObject.SetActive(false);
            mutedImage.gameObject.SetActive(true);
            // Add logic to mute audio here if needed
        }
        else
        {
            // Set unmuted image
            unmutedImage.gameObject.SetActive(true);
            mutedImage.gameObject.SetActive(false);
            // Add logic to unmute audio here if needed
        }
    }
}