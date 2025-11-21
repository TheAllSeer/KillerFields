using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class DamageNumberController : MonoBehaviour
{
    
    public static DamageNumberController instance;
    private void Awake()
    {
        instance = this;
    }

    public DamageNumber numberToSpawn;
    public Transform numberCanvas;

    private List<DamageNumber> numberPool = new List<DamageNumber>();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            SpawnDamage(420, new Vector3(4, 3, 0));
        }
    }

    public void SpawnDamage(float damage, Vector3 location)
    {
        int roundedDamage = Mathf.RoundToInt(damage);
        // DamageNumber newDamage = Instantiate(numberToSpawn, location, quaternion.identity, numberCanvas);
        DamageNumber newDamage = GetFromPool();
        newDamage.Setup(roundedDamage);
        newDamage.gameObject.SetActive(true);
        newDamage.transform.position = location;
    }

    public DamageNumber GetFromPool()
    {
        DamageNumber numberToOutput = null;
        if (numberPool.Count == 0)
        {
            numberToOutput = Instantiate(numberToSpawn, numberCanvas);
        }
        else
        {
            numberToOutput = numberPool[0];
            numberPool.RemoveAt(0);
        }

        return numberToOutput;
    }

    public void PlaceInPool(DamageNumber numberToAdd)
    {
        numberToAdd.gameObject.SetActive(false);
        numberPool.Add(numberToAdd);
    }
}
