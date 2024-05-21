using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel_Ref : MonoBehaviour
{
    public int sceneBuildIndex;

    private void OnTriggerEnter2D(Collider2D other) {

        if (other.CompareTag("Player")) {
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        }
    }
}
