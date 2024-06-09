using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip music;
    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = music;
        audioSource.loop = true;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
