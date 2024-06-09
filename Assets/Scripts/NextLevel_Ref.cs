using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel_Ref : MonoBehaviour
{
    public int sceneBuildIndex;
    public Animator anim;
    public SceneInfo sceneInfo;
    private PlayerMovement player;

    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();

        if (!sceneInfo.spawnDefault)
        {
            player.canMove = false;
            if (sceneInfo.hasVisited)
            {
                player.transform.position = sceneInfo.spawnPoint;
            }
            else
            {
                sceneInfo.hasVisited = true;
                sceneInfo.spawnPoint = player.transform.position;
            }
            player.canMove = true;
        }

        anim.SetTrigger("FadeIn");
        player.canMove = true;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            player.canMove = false;
            sceneInfo.spawnPoint = player.transform.position;
            sceneInfo.spawnPoint.x -= 0.5f;
            anim.SetTrigger("FadeOut");
        }
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
    }
}
