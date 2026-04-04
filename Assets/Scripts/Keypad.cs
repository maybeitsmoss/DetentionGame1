using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class Keypad : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI Ans;

   private string Answer = "6967";
   //make string public after testing + add a randomizer


    void Start()
    {
        //keypad canvas UI is disabled 
        //call the function onUnlock
    }

    public void Number(int number)
    {
        if(Ans.text.Length < 4)
        {
           Ans.text += number.ToString();
        }
    }

    public void Enter()
    {
        if (Ans.text == Answer)
        {
           Ans.text = "UNLOCKED"; 
           //call unlock function here
        }
        else
        {
            Ans.text = "INVALID";
            StartCoroutine(KeypadReset());
        }
    }

    public IEnumerator KeypadReset()
    {
        yield return new WaitForSeconds(2);
        Ans.text = "";
    }
}
