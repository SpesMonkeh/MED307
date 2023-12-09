using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DoorBehavior : MonoBehaviour
{
    [SerializeField] private int _signLeft;
    [SerializeField] private TextMeshProUGUI _signCount;
    private SceneChanger SceneChanger;

    private void Start()
    {
        _signCount.text = "Du har " + _signLeft + " tegn tilbage at finde";
        SceneChanger = GameObject.Find("GameManager").GetComponent<SceneChanger>();
    }

    public void UpdateSignCount(int signAmount)
    {
        _signLeft -= signAmount;
        _signCount.text = "Du har " + _signLeft + " tegn tilbage at finde";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out PlayerBehavior playerObj) is false)
            return;
        _signCount.gameObject.SetActive(true);
        if (_signLeft==0)
        {
            SceneChanger.ChangeScene("PuzzleScene");
        }
        
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out PlayerBehavior playerObj) is false)
            return;
        _signCount.gameObject.SetActive(false);
        
    }
}
