using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    private AudioSource goal;
    private void Start()
    {
        goal = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        print("Goal");
        goal.Play();
    }
}
