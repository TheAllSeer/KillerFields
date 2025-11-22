using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIController : MonoBehaviour
{
    public static UIController instance;

    public Slider explvlSlider;
    public TMP_Text expLvlText;

    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateExperience(int currentExp, int levelExp, int currentLevel)
    {
            explvlSlider.maxValue = levelExp;
            explvlSlider.value = currentExp;
            expLvlText.text = "Level : " + currentLevel;
    }
}
