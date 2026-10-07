using UnityEngine;
using UnityEngine.UI;
public class IsItThere : MonoBehaviour
{
    [SerializeField] private Image isThisHere;
    [SerializeField] private Image thisGone;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("paper"))
        {
            Debug.Log("HERE");

        }
    }
     private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("paper"))
        {


            thisGone.enabled = false;

        }
        
        if (other.CompareTag("Coffe"))
        {
            thisGone.enabled = false;
        }
    }
}
