using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameStore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _spendablePoints;

    float _currencyPoints;
    public float CurrencyPoints
    {
        get { return _currencyPoints; }
        set
        {
            _currencyPoints = value;
            PlayerPrefs.SetFloat("currentScoreForCurrency", value);
            PlayerPrefs.Save();
            UpdateSpendablePointsText();
        }
    }

    void Start()
    {
        if (PlayerPrefs.HasKey("currentScoreForCurrency"))
        {
            _currencyPoints = PlayerPrefs.GetFloat("currentScoreForCurrency");
            UpdateSpendablePointsText();
        }
        else _currencyPoints = 0f;
    }

    void UpdateSpendablePointsText() => _spendablePoints.text = $"Spendable points: {_currencyPoints:0.00}";

    public void PlayGame() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

    public void PurchaseItem(float cost)
    {
        if (_currencyPoints >= cost)
        {
            _currencyPoints -= cost;
            CurrencyPoints = _currencyPoints; // this line updates the PlayerPrefs value
        }
    }
}
