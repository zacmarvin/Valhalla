using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CampaignSceneManagerScript : MonoBehaviour
{
    [SerializeField]
    Button level1Button;
    [SerializeField]
    Button level2Button;
    [SerializeField]
    Button level3Button;

    [SerializeField]
    Button FreePlayButton;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetString("WonLevel1") == "true")
        {
            level2Button.interactable = true;
        }
        else
        {
            level2Button.interactable = false;
        }

        if (PlayerPrefs.GetString("WonLevel2") == "true")
        {
            level3Button.interactable = true;
        } else
        {
            level3Button.interactable = false;
        }

        if (PlayerPrefs.GetString("WonLevel3") == "true")
        {
            FreePlayButton.interactable = true;
        }
        else
        {
            FreePlayButton.interactable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadLevelScene(int level)
    {
        PlayerPrefs.SetInt("Level", level);
        SceneManager.LoadScene("SetupScene");
    }
}
