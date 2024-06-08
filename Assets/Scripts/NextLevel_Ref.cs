using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel_Ref : MonoBehaviour
{
    public int sceneBuildIndex;
    public Animator anim;

    private void OnTriggerEnter2D(Collider2D other) {

        if (other.CompareTag("Player")) {
            anim.SetTrigger("FadeOut");
        }
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
    }
}
