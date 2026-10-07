using UnityEngine;
using UnityEngine.UI;

public class ButtonWorkAfter : MonoBehaviour
{
    [SerializeField] private Image Paper;
    [SerializeField] private Button thisButton;

    [SerializeField] private Animator animator;

    private void Update()
    {
        if (Paper.enabled == false)
        {//nappi lähtee tomiin vain sitten kuin paperi on poissa
            //Debug.Log("Yay");
            thisButton.interactable = true;
            animator.enabled = true;
        }

    }


    
}
