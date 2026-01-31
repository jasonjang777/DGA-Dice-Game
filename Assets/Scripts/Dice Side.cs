using TMPro;
using UnityEngine;

/// <summary>
/// Sets the dice text to the number side this represents
/// </summary>
public class DiceSide : MonoBehaviour
{
    // SerializeField allows us to set a value through the Unity Editor
    [SerializeField] int diceSide;
    [SerializeField] TMP_Text diceText;
    [SerializeField] RollTotal rollTotal;

    // [SerializeField] TMP_Text totalText;

    // Rigidbody parentDie;

    // private void Start()
    // {
    //     parentDie = transform.parent.gameObject.GetComponent<Rigidbody>();
    // }

    private void OnTriggerEnter(Collider other)
    {
        // If the gameobject has the Floor tag
        if (other.CompareTag("Floor"))
        {
            // Set the diceText to the diceSide
            diceText.text = diceSide.ToString();
            // // Update total if die has stopped moving
            // if (parentDie.angularVelocity == Vector3.zero)
            // {
            //     int currTotal = int.Parse(totalText.text);
            //     currTotal = diceSide == 1 ? 0 : currTotal + diceSide;
            //     totalText.text = currTotal.ToString();
            // }
            rollTotal.setNextNumToAdd(diceSide);
        }
    }

}
