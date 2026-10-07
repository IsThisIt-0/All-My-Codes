using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StrictTextValidator : MonoBehaviour
{
    public TMP_InputField inputField;
    public string targetText = ""; //the text that is to be written

    [SerializeField] private Button exitButton;
    [SerializeField] private Image bgDone;

    void Start()
    {
        // Set custom validation function
        inputField.onValidateInput += ValidateChar;
    }

    private void Update() 
    {
        if (inputField.text == targetText)
        {
            exitButton.gameObject.SetActive(true);      // Make the button visible/active
            exitButton.interactable = true;             // Make it clickable
            bgDone.gameObject.SetActive(true); 
        }    
    }

    // This runs on each key press
    private char ValidateChar(string text, int charIndex, char addedChar)
    {
        // Reject if the index is already past the allowed string
        if (charIndex >= targetText.Length)
            return '\0'; // Reject input

        // Compare with the target string at this position
        if (addedChar == targetText[charIndex])
        {
            return addedChar; // Accept input
        }
        else
        {
            return '\0'; // Reject character
        }
    }
}

