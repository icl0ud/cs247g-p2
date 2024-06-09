using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputSceneChange : MonoBehaviour
{
    public string level;
    public Animator anim;
    public SceneInfo sceneInfo;
    public Transform transform;
    private bool playerIsClose;
    private PlayerMovement player;

    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && playerIsClose)
        {
            player.canMove = false;
            sceneInfo.spawnPoint = transform.position;
            anim.SetTrigger("FadeOut");
        }
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(level);
    }
}
