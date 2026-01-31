using System;
using System.Collections;
using UnityEngine;

public class RollButton : MonoBehaviour
{
    private static WaitForSeconds _waitForSeconds1 = new WaitForSeconds(1);

    // [SerializeField] private float clickCooldown;
    [SerializeField] private float updateCooldown;
    [SerializeField] private GameObject diceObject;
    [SerializeField] private RollTotal rollTotal;
    // private float nextClickTime;

    private bool totalUpdatedAlready;

    private bool rolledOnce;

    private float nextUpdateTime;

    private RandomForce diceRandomForce;
    private RandomTorque diceRandomTorque;

    void Start()
    {
        // nextClickTime = 0f;
        nextUpdateTime = 0f;
        diceRandomForce = diceObject.GetComponent<RandomForce>();
        diceRandomTorque = diceObject.GetComponent<RandomTorque>();
        totalUpdatedAlready = false;
        rolledOnce = false;
    }

    void Update()
    {
        if (rolledOnce && !totalUpdatedAlready && diceObject.GetComponent<Rigidbody>().angularVelocity 
        == Vector3.zero && Time.time >= nextUpdateTime)
        {
            rollTotal.UpdateTotal();
            totalUpdatedAlready = true;
            nextUpdateTime = Time.time + updateCooldown;
        }
        // } else if (totalUpdatedAlready && diceObject.GetComponent<Rigidbody>().angularVelocity 
        // != Vector3.zero)
        // {
        //     totalUpdatedAlready = false;
        // }
    }

    public void OnButtonClick()
    {
        if (diceObject.GetComponent<Rigidbody>().angularVelocity 
        == Vector3.zero)
        {
            totalUpdatedAlready = false;
            diceRandomForce.ApplyForce();
            diceRandomTorque.ApplyTorque();
            StartCoroutine(UpdateButtonRolled());
            // nextClickTime = Time.time + clickCooldown;
            // totalUpdatedAlready = false;
        }
    }
    
    public void resetRoll()
    {
        rolledOnce = false;
    }

    public bool CanRollAgain()
    {
        return diceObject.GetComponent<Rigidbody>().angularVelocity 
        == Vector3.zero;
    }

    IEnumerator UpdateButtonRolled()
    {
        yield return _waitForSeconds1;
        rolledOnce = true;
    }
}
