using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRef : MonoBehaviour
{
    private AudioSource source;
    public AudioClip itemSound;
    public float vol;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    /*Adiciona o som escolhido na colisão */

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Player")
            SoundOnGet();
    }

    void SoundOnGet()
    {
        source.PlayOneShot(itemSound, vol);
        /*Faz o item sumir */
        Destroy(GetComponent<BoxCollider>());
        Destroy(GetComponent<MeshRenderer>());
        Destroy(gameObject, 2);
    }
}
