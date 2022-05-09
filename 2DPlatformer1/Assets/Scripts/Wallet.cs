using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private Player _player;

    private Text _text;

    private void Start() 
    {
        _text = GetComponent<Text>();
    }

    private void Update() 
    {
       _text.text = $"У вас: {_player.Coins}.";
    }
}
