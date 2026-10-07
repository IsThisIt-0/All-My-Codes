using UnityEngine;


public class MusicSwitch : MonoBehaviour
{
    
    public AudioSource flipSide;
    public AudioSource normal;
	public GraviticSwitch gravity;
    private GameObject player;

    private void Start()
    {
        flipSide.Play();
        normal.Play();

        normal.volume = 1;
        flipSide.volume = 0;

        player = GameObject.FindWithTag("Player");

    }
	
    private void Update()
    {


        if (gravity.flipped == false)
        {
            normal.volume = 1;
            flipSide.volume = 0;
        }

        else if (gravity.flipped == true)
        {
            normal.volume = 0;
            flipSide.volume = 1;
        }
        if (player.activeInHierarchy == false)
        {

            flipSide.Stop();
            normal.Stop();

        }

    }
    
}

