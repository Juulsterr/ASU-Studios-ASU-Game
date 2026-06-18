using UnityEngine;
using TMPro;

public class HealthUI : MonoBehaviour
{
    public TMP_Text HealthText;
    public BarP healthBar; // Sleep hier je object met BarP in de Inspector

    void Update()
    {
        HealthText.text = "" + healthBar.Value;
    }
}