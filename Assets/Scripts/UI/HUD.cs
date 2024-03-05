using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _coinText;
    [SerializeField] private TextMeshProUGUI _coinTextGameOver;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private Slider _slider;
    [SerializeField] private Health _health;
    [SerializeField] private GameObject _gameOverPanel;

    private GameObject _coinBar;
    private GameObject _healthBar;


    private void Awake()
    {
        _coinBar = transform.Find("Coin Bar").gameObject;
        _healthBar = transform.Find("Health Bar").gameObject;
    }

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
        
        _coinBar.SetActive(false);
        _healthBar.SetActive(false);
        _coinTextGameOver.text = _coinText.text;
    }

    private void OnDisable()
    {
        _playerController.OnCoinChange -= ChangeCoinText;
        _health.OnHealthChange -= ChangeHealthSlider;
        _health.OnDeath -= ActiveGameOverPanel;
    }
}
