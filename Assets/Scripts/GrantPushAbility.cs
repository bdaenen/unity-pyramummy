using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrantPushAbility : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Pickup(other.GetComponent<PlayerPowerups>());
            Destroy(gameObject);
        }
    }

    void Pickup(PlayerPowerups other)
    {
        other.ActivateAbility(PlayerPowerups.Abilities.Push);
    }
}
