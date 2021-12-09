using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource = null;

    public List<AudioClip> Male_Sounds = new List<AudioClip>();

    public List<AudioClip> Female_Sounds = new List<AudioClip>();
}