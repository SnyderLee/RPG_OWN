using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatsManager: MonoBehaviour
{
    public static CharacterStatsManager Instance { get; private set; }
    [SerializeField] private int ExperiencePoints;
    [SerializeField] private int Level;
    [SerializeField] private int Health;
    [SerializeField] private int MaxHealth;
    private Dictionary<string, bool> equipment;
    private Dictionary<string, int> items;


    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;


        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        {
            Destroy(gameObject);
        }
    }
    private void Load()
    {
        // Load character stats from a file or database
        // For example, using PlayerPrefs:
        ExperiencePoints = 0;
        Level = 1;
        Health = 100;
        MaxHealth = 100;

        equipment = new Dictionary<string, bool>();
        items = new Dictionary<string, int>();
    }
}
