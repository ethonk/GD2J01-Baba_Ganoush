using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class MooJuiceProjectile : MonoBehaviour
{
    [Header("Settings - Given by Pissed Moo Juice Script")]
    public float projectileSpeed;       // how fast is the projectile going?
    public float projectileLifetime;    // how long does the projectile exist?
    public Vector3 projectileTarget;    // where is the projectile going?
    public bool exists;                 // does the projectile exist?
    
    private enum ProjectileTypes {Blind, Slow};
    [Header("Projectile Type")]
    [SerializeField] private ProjectileTypes projectileType;

    [Header("Particles")]
    [SerializeField] private GameObject particleEffect;

    private Vector3 normalizedDirection;
    
    private void Update()
    {
        if (exists)
            transform.position = transform.position + normalizedDirection * (projectileSpeed * Time.deltaTime);
    }

    public void StartProjectile(float speed, float lifetime, Vector3 target)
    {
        // Normalized direction
        normalizedDirection = (target - transform.position).normalized;
        
        // Projectile Attributes
        projectileSpeed = speed;
        projectileLifetime = lifetime;
        projectileTarget = target;
        exists = true;
        
        // Start timer.
        StartCoroutine(SelfDestruct());
    }
    
    private IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(projectileLifetime);
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.transform.CompareTag("Player"))
        {
            var newParticle = Instantiate(particleEffect);
            newParticle.transform.SetParent(null);
            newParticle.transform.position = transform.position;
            Destroy(gameObject);
        }
    }
}
