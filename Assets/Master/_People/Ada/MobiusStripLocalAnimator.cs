using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobiusStripLocalAnimator : MonoBehaviour
{
    
    private AudioSource audioSource;
    private float formIZRotation;
    // private float formIZRotation0;


    float map(float s, float a1, float a2, float b1, float b2)
    {
        return b1 + (s-a1)*(b2-b1)/(a2-a1);
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GameObject.Find("Mobius Strip").GetComponent<AudioSource>();
        // formIZRotation0 = GetComponent<Transform>().localEulerAngles.z;
    }

    // Update is called once per frame
    void Update()
    {
        formIZRotation = map(audioSource.time, 0, audioSource.clip.length, 0, 720.0F);
        this.transform.localEulerAngles = new Vector3(0,0,formIZRotation);
    }
}
