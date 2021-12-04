using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerups : MonoBehaviour
{
    public enum Abilities {Push}
    public GameObject pushBullet;
    private Dictionary<Abilities, bool> _activeAbilities = new Dictionary<Abilities, bool>();
    private Dictionary<Abilities, GameObject> _abilityGameObjects = new Dictionary<Abilities, GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        _abilityGameObjects[Abilities.Push] = pushBullet;
    }

    public void ActivateAbility(Abilities ability)
    {
        _activeAbilities[ability] = true;
        Debug.Log("Activated Push!");
    }

    public bool IsActive(Abilities ability)
    {
        return _activeAbilities.ContainsKey(ability) && _activeAbilities[ability] == true;
    }

    public GameObject AbilityToGameObject(Abilities ability)
    {
        return _abilityGameObjects[ability];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
