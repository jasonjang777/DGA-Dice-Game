using TMPro;

using UnityEngine;
using UnityEngine.UI;

public class RollTotal : MonoBehaviour
{
    private int curr;

    private int nextNumToAdd;
    private Rigidbody dieBody;

    [SerializeField] private TMP_Text rollText;
    // [SerializeField] private GameObject die;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        curr = 0;
        rollText.text = curr.ToString();
        // dieBody = die.GetComponent<Rigidbody>();
    }

    public void UpdateTotal()
    {
        curr = nextNumToAdd == 1 ? 0 : curr + nextNumToAdd;
        rollText.text = curr.ToString();
    }

    public void Reset()
    {
        curr = 0;
        rollText.text = curr.ToString();
    }

    public void setNextNumToAdd(int num)
    {
        nextNumToAdd = num;
    }

    public int getTotal()
    {
        return curr;
    }
}
