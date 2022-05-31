using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PissedMooJuice : MonoBehaviour
{
    [Header("Objects")] 
    [SerializeField] private List<GameObject> projectiles;  // milk carton  (vision impairment)
                                                            // milk mug     (mobility impairment)
    [Header("Settings")] 
    [SerializeField] private int countProjectile;           // how many instances of thrown projectile.
    [SerializeField] private float cdProjectile;            // how long between each throw.
    [SerializeField] private float spdProjectile;           // how fast the projectile interpolates towards the target
    [SerializeField] private float lifetimeProjectile;      // how long does the projectile exist for?

    private GameObject _player;

    private void Start()
    {
        _player = GameObject.Find("Player");
        
        StartCoroutine(Throw());
    }

    private IEnumerator Throw()
    {
        // Spawn consecutively.
        StartCoroutine(SpawnProjectile());
        
        // Go on cooldown.
        yield return new WaitForSeconds(cdProjectile);
        // Do throw again.
        StartCoroutine(Throw());
    }

    private IEnumerator SpawnProjectile()
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
}
