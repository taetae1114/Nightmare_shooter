using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MusicControl : MonoBehaviour
{
    public AudioSource asound;
    public Slider sd;
    public Toggle tg;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Con_sound()
    {
        asound.volume = sd.value;
    }
    public void Con_play()
    {
        if (tg.isOn)
        {
            asound.Play();
        }
        else
        {
            asound.Pause();
        }
    }
}
