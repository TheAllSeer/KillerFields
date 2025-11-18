using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    public Transform sprite;
    public float speed;
    public float minSize, maxSize;
    private float activeSize;
    void Start()
    {
        activeSize = maxSize;
        speed = speed * Random.Range(.75f, 1.25f);
    }

    // this entire script exists because it's heavy to create an animation controller for each enemy. 
    // find a way to create it in the game you want to make. either make simpler enemies, or make less, or idk.    
    void Update()
    {
        sprite.localScale = Vector3.MoveTowards(sprite.localScale, Vector3.one * activeSize, speed * Time.deltaTime);
        if (sprite.localScale.x == activeSize)
        {
            if (activeSize == maxSize)
            {
                activeSize = minSize; 
            }
            else
            {
                activeSize = maxSize;
            }
        }
    }
}
