using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    public Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var playerPowerups = GetComponent<PlayerPowerups>();
        const PlayerPowerups.Abilities push = PlayerPowerups.Abilities.Push;
        if (playerPowerups.IsActive(push) && Input.GetMouseButtonDown(0))
        {
            Vector2 cursorInWorldPos = mainCamera.ScreenToWorldPoint( Input.mousePosition );
            Vector2 playerPos = GetComponent<Transform>().position;
            Vector2 direction = cursorInWorldPos - playerPos;
            direction.Normalize();
            GameObject projectile = (GameObject)Instantiate(playerPowerups.AbilityToGameObject(push), playerPos, Quaternion.identity);
            projectile.GetComponent<Rigidbody2D>().velocity = direction * 1;
        }
    }
}
