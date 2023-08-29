using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    [SerializeField] Button startButton;
    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(delegate { LoadMain(); });
    }

    public void LoadMain()
    {
        SceneManager.LoadScene(1);
    }
}
