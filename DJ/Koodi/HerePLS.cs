using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class PaperHere : MonoBehaviour
{
    [SerializeField] private Image thisItem;
    [SerializeField] private Button exitButton;
    [SerializeField] private Animator PotAnimator;

     public float requiredTime = 5f;  // Time in seconds required to trigger event
    private float timeInTrigger = 0f;
    private bool isInTrigger = false;
    private bool eventHasTriggered = false;



    void Update()
    {
        if (isInTrigger && !eventHasTriggered)
        {
            timeInTrigger += Time.deltaTime;

            if (timeInTrigger >= requiredTime)
            {
                TriggerEvent();
                eventHasTriggered = true; //Prevents future triggers
                isInTrigger = false;      //Stops timer from running further
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("paper")&& !eventHasTriggered)
        {//laittaa paperin katoamaan
            Debug.Log("Perish");
            thisItem.enabled = false;
        }
        if (other.CompareTag("Coffe"))
        {  //alottaa kahvin kaadon
            isInTrigger = true;
            timeInTrigger = 0f; // Reset timer when entering
            Debug.Log("Entered 2D trigger.");

            PotAnimator.enabled = true;
            

        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Coffe")&& !eventHasTriggered)
        { //lopettaa kahvin kaadon
          //Debug.Log("It's gone");
            isInTrigger = false;
            timeInTrigger = 5f; // Reset if exited before time
            Debug.Log("Player exited trigger zone before time.");
            PotAnimator.Update(0f);
            
            PotAnimator.enabled = false;
            
            
        }
    }
    
     private void TriggerEvent()
    {
        Debug.Log("Event triggered after 5 seconds!");

            exitButton.gameObject.SetActive(true);      // Make the button visible/active
            exitButton.interactable = true;             // Make it clickable
    }
}
