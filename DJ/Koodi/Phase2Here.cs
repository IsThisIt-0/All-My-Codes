using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Phase2Here : MonoBehaviour
{
    [SerializeField] private GameObject reader;
    [SerializeField] private float onTime = 0.3f;
    [SerializeField] private float offTime = 0.3f;
    [SerializeField] private Image Paper;

     private Coroutine loopCoroutine;

    void Start()
    {
        loopCoroutine = StartCoroutine(LoopReader());
    }

    private void Update() 
    {
         if (Paper.enabled == false)
        {
            // Stop blinking and make sure reader is off
            if (loopCoroutine != null)
            {
                StopCoroutine(loopCoroutine);
                loopCoroutine = null;
            }
            reader.SetActive(false);
        }
     
    }

    IEnumerator LoopReader()
    {
        while (true)
        {
            reader.SetActive(true);
            yield return new WaitForSeconds(onTime);

            reader.SetActive(false);
            yield return new WaitForSeconds(offTime);
        }
    }
}