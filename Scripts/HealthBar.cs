using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    private Image Healthbar;
    public float currentHealth;
    public float MaxHealth = 100;
    Healthsystem unit;
    // Start is called before the first frame update
    void Start()
    {
       
        currentHealth = MaxHealth;
        Healthbar = GetComponent<Image>();
        unit = FindObjectOfType<Healthsystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public void UpdateHealth(float health)
    {
        Debug.Log(health);
        Healthbar.fillAmount = health / MaxHealth;
    }
}
