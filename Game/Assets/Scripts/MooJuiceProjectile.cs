using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Managers.EventManagement;
using UnityEngine;

public class MooJuiceProjectile : MonoBehaviour
{
    [Header("References")] [SerializeField]
    private EventManagement eventManagement;

    [Header("Settings - Given by Pissed Moo Juice Script")]
    public float projectileSpeed;       // how fast is the projectile going?
    public float projectileLifetime;    // how long does the projectile exist?
    public Vector3 projectileTarget;    // where is the projectile going?
    public bool exists;                 // does the projectile exist?
    
    [Header("Projectile Type")]
    [SerializeField] private GlobalEnums.ProjectileTypes projectileType;

    [Header("Particles")]
    [SerializeField] private GameObject particleEffect;

    private Vector3 normalizedDirection;

    private void Start()
    {
        eventManagement = GameObject.Find("EVENT_MANAGER").GetComponent<EventManagement>();
    }
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
            // if not already debuffed, apply debuff...
            if (!eventManagement.isDebuffed)
            {
                // start debuff end timer
                eventManagement.StartDebuff();

                // apply correct debuff
                switch (projectileType)
                {
                    case GlobalEnums.ProjectileTypes.Blind:
                        eventManagement.ApplyDebuffVision();
                        break;
                    case GlobalEnums.ProjectileTypes.Slow:
                        eventManagement.SpeedDebuffApplied();   // invoke event for speed.
                        col.GetComponent<PlayerMovement>().ApplyDebuffSpeed();
                        break;
                }
            }
            
            // set particle explosion effect
            var newParticle = Instantiate(particleEffect);
            newParticle.transform.SetParent(null);
            newParticle.transform.position = transform.position;

            // destroy projectile
            Destroy(gameObject);
        }
    }
}
