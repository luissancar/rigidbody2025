using UnityEngine;
using UnityEngine.UI;

public class StaminaController : MonoBehaviour
{
    public Slider staminaSlider;
    public float staminaMax =100f;
    public float staminaCurrent = 100f;
    public float staminaDrainRate = 10f;
    private bool isSprinting = false;
    private PlayerController playerController;
    
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        staminaCurrent = staminaMax;
        staminaSlider.maxValue = staminaMax;
        staminaSlider.value = staminaCurrent;
        playerController = GetComponent<PlayerController>();
        
        
    }

    public void IncreaseStamina(float amount)
    {
        staminaCurrent += amount;
        if (staminaCurrent>staminaMax)
            staminaCurrent = staminaMax;
    }
    
    
    // Update is called once per frame
    void Update()
    {
        if (playerController.running)
        {
            staminaCurrent-= staminaDrainRate *Time.deltaTime;
        }
        staminaCurrent=Mathf.Clamp(staminaCurrent,0,staminaMax);
        staminaSlider.value = staminaCurrent;
        if (staminaCurrent <= 0f)
        {
            playerController.running = false;
            playerController.SetVelocidadBase();
        }
    }
}
