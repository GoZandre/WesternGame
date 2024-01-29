using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleActivator : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem _particleSystem;

    public void ActivateParticle()
    {
        _particleSystem.Play();
    }
}
