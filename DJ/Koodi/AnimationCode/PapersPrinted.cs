using UnityEngine;
using UnityEngine.UI;

public class PapersPrinted : MonoBehaviour
{
    [SerializeField] private Image Print;
    [SerializeField] private Animator animator;
   

    private void Update()
    {
        if (Print.enabled == true)
        {//tomii vain sitten kuin paperi on poissa
            //Debug.Log("Yay");
            animator.enabled = true;
        }
    }
}
