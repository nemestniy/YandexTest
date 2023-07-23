using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private TextMeshProUGUI text;

    public GameManager test;

    private void Update()
    {
        test = GameManager.Instance;
    }

    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        text.text = GameManager.Instance.Count.ToString();
        GameManager.Instance.CounterWasUpdated += Instance_CounterWasUpdated;
    }

    private void Instance_CounterWasUpdated()
    {
        text.text = GameManager.Instance.Count.ToString();
    }
}
