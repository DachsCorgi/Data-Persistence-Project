using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField inputField;

    [SerializeField]
    private  TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    private void Start()
    {
        scoreText.text = $"Best Score: {RecordManager.Instance.highestUser} : {RecordManager.Instance.highestScore}";
    }
    public void StartGame()
    {
        string name = inputField.text;
        if (name.Trim().Length > 0)
        {
            RecordManager.Instance.UpdateRecord(name, 0);
            SceneManager.LoadScene(1);
        }
        
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }


}