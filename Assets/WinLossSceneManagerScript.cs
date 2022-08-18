using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class WinLossSceneManagerScript : MonoBehaviour
{
    [SerializeField]
    private TMP_Text m_Text;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetString("WinLoss") == "Win")
        {
            m_Text.text = "You Won!";
            PlayerPrefs.SetString("WonLevel" + PlayerPrefs.GetInt("Level").ToString(), "true");
        } else if (PlayerPrefs.GetString("WinLoss") == "Loss")
        {
            m_Text.text = "You Lost!";
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GoToCampaignScene()
    {
        SceneManager.LoadScene("CampaignScene");
    }
}
