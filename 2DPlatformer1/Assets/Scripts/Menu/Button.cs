using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Button : MonoBehaviour
{
    [SerializeField] private Vector3 _reductionAmount;
    private TMP_Text text;
    public void OnMouseDown()
    {
        transform.localScale -= _reductionAmount;
    }

    public void OnMouseUp()
    {
        transform.localScale += _reductionAmount;
    }
}
