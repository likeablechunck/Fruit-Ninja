using UnityEngine;
using System.Collections;

public class NormalGameMusic : MonoBehaviour
{
    public AudioSource audio1;

    bool isPlaying;

    void Start()
    {
        isPlaying = false;
    }

    // Use this for initialization
    void Update()
    {
        if (!audio1.isPlaying)
        {
            audio1.Play();
        }
    }
}
