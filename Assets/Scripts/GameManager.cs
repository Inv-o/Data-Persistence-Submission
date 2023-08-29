using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] TMP_Text nameText;
    [SerializeField] TMP_InputField nameInput;
    [SerializeField] Button startButton;
    public string nameString;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        nameInput.onValueChanged.AddListener(delegate { UpdateName(); });
    }

    IEnumerator NameChanger()
    {
        yield return new WaitForSeconds(0.03f);
        nameString = nameText.text;
    }

    public void UpdateName()
    {
        StartCoroutine(NameChanger());
    }
}
