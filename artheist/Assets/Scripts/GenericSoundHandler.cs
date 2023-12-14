using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class GenericSoundHandler : MonoBehaviour
{
    public AudioClip impactSoundClip;
    private void OnCollisionEnter(Collision collision)
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(impactSoundClip);
    }
}
