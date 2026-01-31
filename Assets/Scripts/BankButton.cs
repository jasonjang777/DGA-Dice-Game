using System;
using System.Collections;
using UnityEngine;

public class BankButton : MonoBehaviour
{
    // [SerializeField] private float clickCooldown;
    [SerializeField] private float updateCooldown;
    [SerializeField] private GameObject diceObject;
    [SerializeField] private GameTotal gameTotal;
    // private float nextClickTime;

    [SerializeField] private RollButton rollButton;

    private bool totalUpdatedAlready;

    private bool rolledOnce;

    // private float nextUpdateTime;

    void Start()
    {
        // nextClickTime = 0f;
        // nextUpdateTime = 0f;
        totalUpdatedAlready = false;
        rolledOnce = false;
    }

    public void OnButtonClick()
    {
        if (diceObject.GetComponent<Rigidbody>().angularVelocity 
        == Vector3.zero)
        {
            gameTotal.UpdateTotal();
            rollButton.resetRoll();
        }
    }

    public bool CanBank()
    {
        return diceObject.GetComponent<Rigidbody>().angularVelocity 
        == Vector3.zero;
    }

}
