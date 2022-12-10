using UnityEngine.UI;
using UnityEngine;
using TMPro;


public class HealthUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI healthText;
    public Stats stats;

    private void Start()
    {

    }
    void Update()
    {
        healthText.SetText(stats.health.ToString());
    }
}
