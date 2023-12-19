using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    [SerializeField] private AudioSource audioSource;

    public AudioClip gameSceneAudioClip; // Assign your GameScene audio clip in the inspector
    private float gameSceneVolume = 0.2f;
    private float defaultVolume = 1.0f; // Adjust the default volume as needed

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Start playing the music when the scene starts
        audioSource.Play();

        // Check if the current scene is "GameScene" and adjust the volume
        if (SceneManager.GetActiveScene().name == "GameScene")
        {
            AdjustVolumeForGameScene();
        }
    }

    void Update()
    {
        // Check if the current scene is "GameScene" and adjust the volume if true
        if (SceneManager.GetActiveScene().name == "GameScene")
        {
            AdjustVolumeForGameScene();
        }
    }

    public void ChangeMasterVolume(float value)
    {
        AudioListener.volume = value;
    }

    public void ToggleMusic()
    {
        audioSource.mute = !audioSource.mute;
    }

    private void AdjustVolumeForGameScene()
    {
        // Adjust the volume to the specified value for the GameScene
        audioSource.volume = gameSceneVolume;
    }
}