using System.Collections.Generic;
using UnityEngine;

public class ExperienceLevelController : MonoBehaviour
{
    
    public static ExperienceLevelController instance;
    public ExpPickup pickup;

    public List<int> expLevels;
    public int currentLevel = 1;
    public int levelCount = 100;

    void Awake()
    {
        instance = this;
    }

    public int currentExperience;
    void Start()
    {
        while (expLevels.Count < levelCount)
        {
            expLevels.Add(Mathf.CeilToInt(expLevels[expLevels.Count - 1] * 1.1f));
        }
    }

    
    void Update()
    {
        
    }

    public void GetExp(int exp)
    {
        currentExperience += exp;
        if (currentExperience >= expLevels[currentLevel])
        {
            LevelUp();
        }
        UIController.instance.UpdateExperience(currentExperience, expLevels[currentLevel], currentLevel);
    }

    public void SpawnExp(Vector3 position, int expValue)
    {
        Instantiate(pickup, position, Quaternion.identity).expValue = expValue;
    }

    void LevelUp()
    {
        currentExperience -= expLevels[currentLevel];
        currentLevel++;
        if (currentLevel >= expLevels.Count)
        {
            currentLevel = expLevels.Count - 1;
        }

    }
}
