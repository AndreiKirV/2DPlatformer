using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Slider _slider;
    [SerializeField] private Text _text;

    private float _maxHealth = 100;

    private void Start()
    {
        _maxHealth = _player.MaxHealth;
        _slider.DOValue(1, 1);
        _text.text = ($"HP: {_player.Health}.");
    }

    public void ChangeSlider()
    {
        _slider.DOValue(_player.Health/_maxHealth, 1);
        _text.text = ($"HP: {_player.Health}.");
    }
}