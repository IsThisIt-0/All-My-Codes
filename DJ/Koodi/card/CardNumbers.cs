using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CardNumbers : MonoBehaviour
{
    public Text screenCode;
    public Text inputCode;
    public int codeLength = 4;
    public float codeResetTime = 3f;

    [SerializeField] private Image fakeCard;
    [SerializeField]private Image realCard;
    
    private bool isResetting = false;

    private void OnEnable()
    {
        string code = string.Empty;

        for (int i = 0; i < codeLength; i++)
        {
            code += Random.Range(1, 5);
        }

        screenCode.text = code;
        inputCode.text = string.Empty;

        
    }

    public void ButtonClick(int number)
    {
        if (isResetting) return;

        inputCode.text += number;

        if (inputCode.text == screenCode.text)
        {
            if (inputCode.text.Length == codeLength)
            {
                realCard.gameObject.SetActive(true); 
                fakeCard.gameObject.SetActive(false);
                inputCode.text = "Now the card";
            }

            
            StartCoroutine(ResetCode());
        }
        else if (inputCode.text.Length >= codeLength)
        {
            inputCode.text = "No... that's not right...";
            StartCoroutine(ResetCode());
        }
    }

    private IEnumerator ResetCode()
    {
        isResetting = true;
        yield return new WaitForSeconds(codeResetTime);
        inputCode.text = "";
        isResetting = false;

        
    }

 
}
