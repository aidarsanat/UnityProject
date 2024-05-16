using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnFX : MonoBehaviour
{
    public AudioClip hoverFx;
    public AudioSource myFX;
    public AudioClip clickFx;

    public void HoverSound()
    {
        myFX.PlayOneShot(hoverFx);
    }

        public void ClickSound()
    {
        myFX.PlayOneShot(clickFx);
    }
    
}
