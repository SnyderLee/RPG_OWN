using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightManager : MonoBehaviour
{
    public static FightManager Instance { get; private set; }
    [Range(0, 100), SerializeField] private int chanceToEncounter;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
           
           
        }
        else
        {
            Destroy(gameObject);
        }

    }
    public void CheckForEncounter()
    {
        if (Random.Range(0, 100) <= chanceToEncounter) 
        {
           
            Debug.Log("Start Encounter");
        }
        else
        {
            Debug.Log("No Encounter");
        }
    }
}
