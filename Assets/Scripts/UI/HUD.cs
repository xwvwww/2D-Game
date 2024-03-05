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
    [SerializeField] private GameObject _gameOverPanel;

    void Start()
    {
        _slider.minValue = 0;
        _slider.maxValue = _health.HP;
        _slider.value = _slider.maxValue;

        _playerController.OnCoinChange += ChangeCoinText;
        _health.OnHealthChange += ChangeHealthSlider;
        _health.OnDeath += ActiveGameOverPanel;
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

    private void ActiveGameOverPanel()
    {
        if (_gameOverPanel == null)
            return;

        _gameOverPanel.SetActive(true);
    }

    private void OnDisable()
    {
        _playerController.OnCoinChange -= ChangeCoinText;
        _health.OnHealthChange -= ChangeHealthSlider;
        _health.OnDeath -= ActiveGameOverPanel;
    }
}
