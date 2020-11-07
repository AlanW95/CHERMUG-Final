using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

//////////////////////////////////////////////////<summary>//////////////////////////////////////////////////// 
///                                   University of the West of Scotland                                    ///
///                               -------------------------------------------                               ///  
/// Script is attached to the Manager GameObject in the NameEntry scene.                                    ///
///                                                                                                         ///
//////////////////////////////////////////////////</summary>///////////////////////////////////////////////////

public class NameEntry : MonoBehaviour
{
    public InputField name;
    public Text nameField;
    public GameObject textWarning, nameCanvas;
    private int character;
    
    // Start is called before the first frame update
    void Start()
    {
        textWarning.SetActive(false);
        nameField.text = PlayerPrefs.GetString("name");
    }

    public void NextNameEntered()
    {
        if (name.text == "")
        {
            StartCoroutine(TextWarning());
        }
        else
        {
            PlayerPrefs.SetString("name", name.text);
            SceneManager.LoadScene("MainMenu");
        }
    }

    IEnumerator TextWarning()
    {
        textWarning.SetActive(true);

        yield return new WaitForSeconds(4);
        textWarning.SetActive(false);
    }
}
