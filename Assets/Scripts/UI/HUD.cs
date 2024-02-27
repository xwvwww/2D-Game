using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _coinText;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private Slider _slider;
    [SerializeField] private Health _health;

    void Start()
    {
        _slider.minValue = 0;
        _slider.maxValue = _health.HP;
        _slider.value = _slider.maxValue;
        _playerController.OnCoinChange += ChangeCoinText;
        _health.OnHealthChange += ChangeHealthSlider;
    }

    void Update()
    {
        
    }

    private void ChangeCoinText(int coins)
    {
        _coinText.text = coins.ToString();
    }

    private void ChangeHealthSlider(int hp)
    {
        _slider.value = hp;
    }
}
