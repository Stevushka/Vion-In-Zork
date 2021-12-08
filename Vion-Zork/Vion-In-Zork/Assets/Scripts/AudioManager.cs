using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource = null;

    [SerializeField]
    private List<AudioClip> Male_Sounds = new List<AudioClip>();

    [SerializeField]
    private List<AudioClip> Female_Sounds = new List<AudioClip>();
}