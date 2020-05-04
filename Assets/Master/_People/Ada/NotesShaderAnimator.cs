using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesShaderAnimator : MonoBehaviour
{
    public float textureOffset = 0.0F;
    public float audioPos;
    private Material material;
    private AudioSource audioSource;
    float map(float s, float a1, float a2, float b1, float b2)
    {
        return b1 + (s-a1)*(b2-b1)/(a2-a1);
    }

    void Start()
    {
        material = GetComponent<MeshRenderer>().material;
        audioSource = GameObject.Find("Mobius Strip").GetComponent<AudioSource>();
        // Debug.Log("names" + material.GetTexturePropertyNames(List<string> outNames));
    }

    // Update is called once per frame
    void Update()
    {
        audioPos = audioSource.time;
        // hSliderValue = map(audioPos, 0, audioSource.clip.length,0.0F, 1.0F);
        textureOffset = map(audioPos, 0, audioSource.clip.length, 0.0F, -0.98F);
        material.SetTextureOffset("_BaseMap", new Vector2(textureOffset, 0));
    }

}
