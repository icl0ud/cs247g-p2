using UnityEngine;
using UnityEngine.Playables;
 
public class CutSceneTrigger : MonoBehaviour
{
    public PlayableDirector timeline;
    private bool playerIsClose;


    void Start()
    {
        timeline.Stop();
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
            timeline.Stop();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && playerIsClose)
        {
            timeline.Play();
        }
    }
}