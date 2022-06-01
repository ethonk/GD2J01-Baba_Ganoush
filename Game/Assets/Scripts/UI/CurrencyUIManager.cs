using UnityEngine;
using TMPro;

public class CurrencyUIManager : MonoBehaviour
{
    [Header("UI Components")]
    [SerializeField] private TextMeshProUGUI coinsText;
    
    public void UpdateCurrencyText(int currencyAmount, int test)
    {
        coinsText.text = currencyAmount.ToString();
    }
}
