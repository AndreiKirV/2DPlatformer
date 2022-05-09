using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Coin _coin;
    [SerializeField] private int _amountOfCoins;
    [SerializeField] private float _delay;

    private void Start()
    {
        StartCoroutine(Spawn());
    }
    
    private IEnumerator Spawn()
    {
        var waiting = new WaitForSeconds(_delay);

        for (int i = 0; i < _amountOfCoins;)
        {
                Instantiate(_coin, transform.position, Quaternion.identity);
                i++;
                yield return waiting;  
        }        
    }
}