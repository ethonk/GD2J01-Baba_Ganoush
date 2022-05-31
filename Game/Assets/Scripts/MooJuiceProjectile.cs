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

    private void Update()
    {
        if (exists)
            transform.position = Vector3.Lerp(transform.position, projectileTarget, (projectileSpeed * Time.deltaTime));
    }

    public void StartProjectile(float speed, float lifetime, Vector3 target)
    {
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
    private void OnCollisionEnter(Collision collision)
    {
    }
}