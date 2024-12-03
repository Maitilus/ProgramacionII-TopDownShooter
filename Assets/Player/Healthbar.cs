using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Slider HealthSlider;
    public Slider EaseHealthSlider;
    public float LerpSpeed;
    public HealthComponent HealthComponent;
    void Start()
    {
        HealthComponent = gameObject.GetComponent<HealthComponent>();
        HealthSlider.maxValue = HealthComponent.MaxHealth;
        EaseHealthSlider.maxValue = HealthComponent.MaxHealth;
    }
    void Update()
    {
        if (HealthSlider.value != HealthComponent.CurrentHealth)
        {
            HealthSlider.value = HealthComponent.CurrentHealth; 
        }
        
        if (HealthSlider.value != EaseHealthSlider.value)
        {
            EaseHealthSlider.value = Mathf.Lerp(EaseHealthSlider.value, HealthComponent.CurrentHealth, LerpSpeed); 
        }
    }
}
