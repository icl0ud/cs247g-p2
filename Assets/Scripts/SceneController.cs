using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneController : MonoBehaviour
{
    public string level;
    public TextMeshProUGUI levelText;

    private void Start()
    {
        if (levelText != null)
        {
            levelText.text = level;
        }
    }

    public void OpenScene()
    {
        SceneManager.LoadScene(level);
    }
}
