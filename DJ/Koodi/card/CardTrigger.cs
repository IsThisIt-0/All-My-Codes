using UnityEngine;
using UnityEngine.UI;
public class CardTrigger : MonoBehaviour
{
    [SerializeField] private Button exitButton;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Card"))
        {
            Debug.Log("Hello");
            exitButton.gameObject.SetActive(true);      
            exitButton.interactable = true;             
        }
    }


 
}
