using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Managers.EventManagement;
using TMPro;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class PissedMooJuice : MonoBehaviour
{
    public enum BossMode {Normal, Boss};
    [Header("What type of Moo Juice Enemy is it?")]
    [SerializeField] private BossMode moojuiceMode;
    
    [Header("Objects")] 
    [SerializeField] private List<GameObject> projectiles;  // milk carton  (vision impairment)
                                                            // milk mug     (mobility impairment)
    [Header("Settings")] 
    [SerializeField] private int countProjectile;           // how many instances of thrown projectile.
    [SerializeField] private float cdProjectile;            // how long between each throw.
    [SerializeField] private float spdProjectile;           // how fast the projectile interpolates towards the target
    [SerializeField] private float lifetimeProjectile;      // how long does the projectile exist for?
    
    [Header("Range that the player has to be to interact with Moo Juice")]
    public float range;
    public bool inRange;
    
    private GameObject _player;

    private void Start()
    {
        // Define the player.
        _player = GameObject.Find("Player");
    }

    private void Update()
    {
        if (Vector3.Distance(_player.transform.position, transform.position) <= range && !inRange)
        {
            // Set in range
            inRange = true;
            // Start blasting.
            StartCoroutine(Throw());
        }
        else if (Vector3.Distance(_player.transform.position, transform.position) >= range && inRange)
        {
            inRange = false;
        }
    }

    private IEnumerator Throw()
    {
        yield return new WaitForSeconds(5.0f);
        
        // Play text
        string _name = "Moo Juice";
        string[] _text = {"Hey! Don't ignore me!"};
        GameObject.Find("EVENT_MANAGER").GetComponent<EventManagement>()
            .SetDialogueSentences(_name, _text);
        
        // Spawn based on mode
        switch (moojuiceMode)
        {
            case BossMode.Normal:
                StartCoroutine(SpawnProjectileNormal());
                break;
            case BossMode.Boss:
                StartCoroutine(SpawnProjectileBoss());
                break;
        }

        // Go on cooldown.
        yield return new WaitForSeconds(cdProjectile);
        // Do throw again.
        StartCoroutine(Throw());
    }

    private IEnumerator SpawnProjectileNormal()
    {
        for (int i = 0; i < countProjectile; i++)
        {
            // Do delay
            yield return new WaitForSeconds(0.5f);
        
            // Select a random projectile.
            int projectileIndex = Random.Range(0, projectiles.Count);
            // Define the projectile.
            MooJuiceProjectile projectileObj = Instantiate(projectiles[projectileIndex]).GetComponent<MooJuiceProjectile>();
        
            // Start the projectile.
            projectileObj.transform.position = transform.position;
            projectileObj.StartProjectile(spdProjectile, lifetimeProjectile, _player.transform.position);
        }
    }

    private IEnumerator SpawnProjectileBoss()
    {
        // Create a list of moojuice projectiles
        List<MooJuiceProjectile> mooJuiceProjectiles = new List<MooJuiceProjectile>();
        
        // Start initial spawn
        for (int i = 0; i < countProjectile - 1; i++)
        {
            // Do delay
            yield return new WaitForSeconds(0.5f);
        
            // Select a random projectile.
            int projectileIndex = Random.Range(0, projectiles.Count);
            // Define the projectile and add them to the list.
            MooJuiceProjectile _projectile = Instantiate(projectiles[projectileIndex]).GetComponent<MooJuiceProjectile>();
            _projectile.transform.position = transform.position + new Vector3(0, 3.0f + (2.0f * i), 0);
            mooJuiceProjectiles.Add(_projectile);
        }

        yield return new WaitForSeconds(2.0f);
        // Start all projectiles
        for (int i = 0; i < mooJuiceProjectiles.Count; i++)
        {
            // Get desired position
            Vector3 desiredPosition = _player.transform.position + new Vector3(0, 2.0f * i, 0);
            // Launch projectile
            mooJuiceProjectiles[i].StartProjectile(spdProjectile, lifetimeProjectile, desiredPosition);
        }
    }
}
