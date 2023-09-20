using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] AudioClip[] library;
    AudioSource[] audioSource;
    int audioSourceInd = 0;

    private void Awake()
    {
        Instance = this;
        audioSource = GetComponents<AudioSource>();
    }

    public void PlaySound(int x)
    {
        int tmp = AudioSourceCheck();
        if (tmp > audioSource.Length)
            return;
        audioSource[tmp].PlayOneShot(library[x]);
    }

    int AudioSourceCheck()
    {
        for(int i = 0; i < audioSource.Length; i++)
        {
            if (!audioSource[i].isPlaying)
                return i;
        }
        return audioSource.Length+1; //if this returns all audio sources are in use
    }
}
