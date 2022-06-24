using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePlayer : MonoBehaviour
{
    private ParticleSystem particle;

    private void Start()
    {
        if (GetComponent<ParticleSystem>() == null) return; 
        
        particle = GetComponent<ParticleSystem>();
        particle.Stop();
    }
    
    public void StartParticle()
    {
        particle.Play();
    }

    public void StopParticle()
    {
        particle.Stop();
    }
}
