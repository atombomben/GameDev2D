using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtAudio : MonoBehaviour
{
    public AudioSource run;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void HurtSound() {
        run.Play();
    }


}
