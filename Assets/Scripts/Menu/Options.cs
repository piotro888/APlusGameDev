using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : MonoBehaviour
{
    public int levels=2;
    public float volume_sounds=1f;
    public float volume_music=1f;
    public bool fullscreen=true;

    private void Awake()
{
  DontDestroyOnLoad(gameObject);
}





}
