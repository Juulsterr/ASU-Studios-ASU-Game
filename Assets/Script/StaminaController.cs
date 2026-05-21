using UnityEngine;
using UnityEngine.UI;

public class StaminaController : MonoBehaviour
{
[Header("Stamina Main Parameters")]
    public float stamina = 100f;
    [SerializeField] private float maxStamina = 50f;
    [HideInInspector] public bool hasRegenerated = true;
    [HideInInspector] public bool weAreSprinting = false;

    [Header("Stamina Regen Paraneters")]
    [Range(0, 50)] [SerializeField] private float StaminaDrain = 0.5f;
    [Range(0, 50)] [SerializeField] private float staminaRegen = 0.5f;

    [Header("Stamina UI Elemenst")]
    [SerializeField] private Image staminaProgressUI = null;
    [SerializeField] private CanvasGroup sliderCanvasGroup = null;
    
    [Header("Player Movement")]
    public float moveSpeed = 2.5f;
    public float sprintSpeed = 5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!weAreSprinting)
        {
            if(stamina <= maxStamina - 0.01)
            {
                UpdateStamina(1);
                stamina += staminaRegen * Time.deltaTime;

                if(stamina >= maxStamina)
                {
                    moveSpeed = 2.5f;
                    sliderCanvasGroup.alpha = 0;
                    hasRegenerated = true;
                }
            }

        } 
    }
    public void Sprinting()
    {
       if (hasRegenerated)
        {
            weAreSprinting = true;
            stamina -= StaminaDrain * Time.deltaTime;
            UpdateStamina(1);

            if(stamina <= 0)
            {
                hasRegenerated = false;
                moveSpeed = 2f;
                sliderCanvasGroup.alpha = 0;
            }
        }
    }

    void UpdateStamina(int value)
    {
        staminaProgressUI.fillAmount = stamina / maxStamina;

        if(value == 0)
        {
            sliderCanvasGroup.alpha = 0;
        }
        else
        {
            sliderCanvasGroup.alpha = 1;
        }
    }
}
