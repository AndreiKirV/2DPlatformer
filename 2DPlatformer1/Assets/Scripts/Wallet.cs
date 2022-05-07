using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private Player _player;

    private void Update() 
    {
        GetComponent<Text>().text = $"У вас: {_player.Coints}.";
    }
}
