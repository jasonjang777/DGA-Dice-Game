using System;
using TMPro;

using UnityEngine;
using UnityEngine.UI;

public class GameTotal : MonoBehaviour
{
    private int curr;

    private int nextNumToAdd;
    private Rigidbody dieBody;

    [SerializeField] private TMP_Text totalText;
    [SerializeField] private RollTotal rollTotal;
    // [SerializeField] private GameObject die;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        curr = 0;
        totalText.text = curr.ToString();
        // dieBody = die.GetComponent<Rigidbody>();
    }

    public void UpdateTotal()
    {
        if (rollTotal.getTotal() > 0)
        {
            curr += rollTotal.getTotal();
            rollTotal.Reset();
            totalText.text = curr.ToString();
        }
        
    }

    public void setNextNumToAdd(int num)
    {
        nextNumToAdd = num;
    }
}
