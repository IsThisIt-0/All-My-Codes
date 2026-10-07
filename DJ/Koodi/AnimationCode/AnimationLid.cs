using UnityEngine;
using UnityEngine.UI;

public class AnimationLid : MonoBehaviour
{
    [SerializeField] private Image Paper;
    [SerializeField] private Animator animator;
   

    private void Update()
    {
        if (Paper.enabled == false)
        {//tomii vain sitten kuin paperi on poissa
            //Debug.Log("Yay");
            animator.enabled = true;
        }
    }
}
