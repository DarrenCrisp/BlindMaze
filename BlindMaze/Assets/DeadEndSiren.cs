using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadEndSiren : MonoBehaviour {
    private AudioSource siren;
    private void Start()
    {
        siren = GetComponent<AudioSource>();
    }
    //private void OnTriggerStay(Collider other)
    //{
    //    siren.Play();
    //}
    private void OnTriggerEnter(Collider other)
    {
        siren.Play();
    }
    private void OnTriggerExit(Collider other)
    {
        siren.Stop();
    }

}
