using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    public TMP_Text frames;

    [SerializeField]
    GameObject enemyPrefab;

    [SerializeField]
    GameObject rangedEnemyPrefab;

    [SerializeField]
    GameObject friendlyPrefab;

    [SerializeField]
    GameObject rangedFriendlyPrefab;

    [SerializeField]
    int enemiesToSpawn;

    [SerializeField]
    int rangedEnemiesToSpawn;

    [SerializeField]
    int frendliesToSpawn;

    [SerializeField]
    int rangedFriendliesToSpawn;

    [SerializeField]
    Vector2 minPoint;

    [SerializeField]
    Vector2 maxPoint;

    public List<GameObject> enemyGameObjects;

    public List<GameObject> friendlyGameObjects;

    public List<Transform> enemyTransforms;

    public List<Transform> friendlyTransforms;

    public List<AIController> enemyControllers;

    public List<AIController> friendlyControllers;

    public List<GameObject> unitPrefabs;

    private void Awake()
    {


        Time.timeScale = 1f;

        List<string> unitPrefabNames = new List<string>();

        for(int i = 0; i < unitPrefabs.Count; i++)
        {
            //TODO Do for rest of them
            if (unitPrefabs[i].name == PlayerPrefs.GetString("A1Name"))
            {
                Instantiate(unitPrefabs[i], new Vector3(-56, -56, 0), Quaternion.identity);
            }
            if (unitPrefabs[i].name == PlayerPrefs.GetString("B1Name"))
            {
                Instantiate(unitPrefabs[i], new Vector3(-40, -56, 0), Quaternion.identity);
            }
            if (unitPrefabs[i].name == PlayerPrefs.GetString("C1Name"))
            {
                Instantiate(unitPrefabs[i], new Vector3(-24, -56, 0), Quaternion.identity);
            }
            if (unitPrefabs[i].name == PlayerPrefs.GetString("D1Name"))
            {
                Instantiate(unitPrefabs[i], new Vector3(-8, -56, 0), Quaternion.identity);
            }
            if (unitPrefabs[i].name == PlayerPrefs.GetString("E1Name"))
            {
                Instantiate(unitPrefabs[i], new Vector3(8, -56, 0), Quaternion.identity);
            }
            if (unitPrefabs[i].name == PlayerPrefs.GetString("F1Name"))
            {
                Instantiate(unitPrefabs[i], new Vector3(24, -56, 0), Quaternion.identity);
            }
            if (unitPrefabs[i].name == PlayerPrefs.GetString("G1Name"))
            {
                Instantiate(unitPrefabs[i], new Vector3(40, -56, 0), Quaternion.identity);
            }
            if (unitPrefabs[i].name == PlayerPrefs.GetString("H1Name"))
            {
                Instantiate(unitPrefabs[i], new Vector3(56, -56, 0), Quaternion.identity);
            }
            if (unitPrefabs[i].name == PlayerPrefs.GetString("A2Name"))
            {
                Instantiate(unitPrefabs[i], new Vector3(-56, -40, 0), Quaternion.identity);
            }
            if (unitPrefabs[i].name == PlayerPrefs.GetString("B2Name"))
            {
                Instantiate(unitPrefabs[i], new Vector3(-40, -40, 0), Quaternion.identity);
            }
            if (unitPrefabs[i].name == PlayerPrefs.GetString("C2Name"))
            {
                Instantiate(unitPrefabs[i], new Vector3(-24, -40, 0), Quaternion.identity);
            }
            if (unitPrefabs[i].name == PlayerPrefs.GetString("D2Name"))
            {
                Instantiate(unitPrefabs[i], new Vector3(-8, -40, 0), Quaternion.identity);
            }
            if (unitPrefabs[i].name == PlayerPrefs.GetString("E2Name"))
            {
                Instantiate(unitPrefabs[i], new Vector3(8, -40, 0), Quaternion.identity);
            }
            if (unitPrefabs[i].name == PlayerPrefs.GetString("F2Name"))
            {
                Instantiate(unitPrefabs[i], new Vector3(24, -40, 0), Quaternion.identity);
            }
            if (unitPrefabs[i].name == PlayerPrefs.GetString("G2Name"))
            {
                Instantiate(unitPrefabs[i], new Vector3(40, -40, 0), Quaternion.identity);
            }
            if (unitPrefabs[i].name == PlayerPrefs.GetString("H2Name"))
            {
                Instantiate(unitPrefabs[i], new Vector3(56, -40, 0), Quaternion.identity);
            }
            if (unitPrefabs[i].name == PlayerPrefs.GetString("A3Name"))
            {
                Instantiate(unitPrefabs[i], new Vector3(-56, -24, 0), Quaternion.identity);
            }
            if (unitPrefabs[i].name == PlayerPrefs.GetString("B3Name"))
            {
                Instantiate(unitPrefabs[i], new Vector3(-40, -24, 0), Quaternion.identity);
            }
            if (unitPrefabs[i].name == PlayerPrefs.GetString("C3Name"))
            {
                Instantiate(unitPrefabs[i], new Vector3(-24, -24, 0), Quaternion.identity);
            }
            if (unitPrefabs[i].name == PlayerPrefs.GetString("D3Name"))
            {
                Instantiate(unitPrefabs[i], new Vector3(-8, -24, 0), Quaternion.identity);
            }
            if (unitPrefabs[i].name == PlayerPrefs.GetString("E3Name"))
            {
                Instantiate(unitPrefabs[i], new Vector3(8, -24, 0), Quaternion.identity);
            }
            if (unitPrefabs[i].name == PlayerPrefs.GetString("F3Name"))
            {
                Instantiate(unitPrefabs[i], new Vector3(24, -24, 0), Quaternion.identity);
            }
            if (unitPrefabs[i].name == PlayerPrefs.GetString("G3Name"))
            {
                Instantiate(unitPrefabs[i], new Vector3(40, -24, 0), Quaternion.identity);
            }
            if (unitPrefabs[i].name == PlayerPrefs.GetString("H3Name"))
            {
                Instantiate(unitPrefabs[i], new Vector3(56, -24, 0), Quaternion.identity);
            }
            if (unitPrefabs[i].name == PlayerPrefs.GetString("A4Name"))
            {
                Instantiate(unitPrefabs[i], new Vector3(-56, -8, 0), Quaternion.identity);
            }
            if (unitPrefabs[i].name == PlayerPrefs.GetString("B4Name"))
            {
                Instantiate(unitPrefabs[i], new Vector3(-40, -8, 0), Quaternion.identity);
            }
            if (unitPrefabs[i].name == PlayerPrefs.GetString("C4Name"))
            {
                Instantiate(unitPrefabs[i], new Vector3(-24, -8, 0), Quaternion.identity);
            }
            if (unitPrefabs[i].name == PlayerPrefs.GetString("D4Name"))
            {
                Instantiate(unitPrefabs[i], new Vector3(-8, -8, 0), Quaternion.identity);
            }
            if (unitPrefabs[i].name == PlayerPrefs.GetString("E4Name"))
            {
                Instantiate(unitPrefabs[i], new Vector3(8, -8, 0), Quaternion.identity);
            }
            if (unitPrefabs[i].name == PlayerPrefs.GetString("F4Name"))
            {
                Instantiate(unitPrefabs[i], new Vector3(24, -8, 0), Quaternion.identity);
            }
            if (unitPrefabs[i].name == PlayerPrefs.GetString("G4Name"))
            {
                Instantiate(unitPrefabs[i], new Vector3(40, -8, 0), Quaternion.identity);
            }
            if (unitPrefabs[i].name == PlayerPrefs.GetString("H4Name"))
            {
                Instantiate(unitPrefabs[i], new Vector3(56, -8, 0), Quaternion.identity);
            }
            if (unitPrefabs[i].name == PlayerPrefs.GetString("A5Name"))
            {
                Instantiate(unitPrefabs[i], new Vector3(-56, 8, 0), Quaternion.identity);
            }
            if (unitPrefabs[i].name == PlayerPrefs.GetString("B5Name"))
            {
                Instantiate(unitPrefabs[i], new Vector3(-40, 8, 0), Quaternion.identity);
            }
            if (unitPrefabs[i].name == PlayerPrefs.GetString("C5Name"))
            {
                Instantiate(unitPrefabs[i], new Vector3(-24, 8, 0), Quaternion.identity);
            }
            if (unitPrefabs[i].name == PlayerPrefs.GetString("D5Name"))
            {
                Instantiate(unitPrefabs[i], new Vector3(-8, 8, 0), Quaternion.identity);
            }
            if (unitPrefabs[i].name == PlayerPrefs.GetString("E5Name"))
            {
                Instantiate(unitPrefabs[i], new Vector3(8, 8, 0), Quaternion.identity);
            }
            if (unitPrefabs[i].name == PlayerPrefs.GetString("F5Name"))
            {
                Instantiate(unitPrefabs[i], new Vector3(24, 8, 0), Quaternion.identity);
            }
            if (unitPrefabs[i].name == PlayerPrefs.GetString("G5Name"))
            {
                Instantiate(unitPrefabs[i], new Vector3(40, 8, 0), Quaternion.identity);
            }
            if (unitPrefabs[i].name == PlayerPrefs.GetString("H5Name"))
            {
                Instantiate(unitPrefabs[i], new Vector3(56, 8, 0), Quaternion.identity);
            }
            if (unitPrefabs[i].name == PlayerPrefs.GetString("A6Name"))
            {
                Instantiate(unitPrefabs[i], new Vector3(-56, 24, 0), Quaternion.identity);
            }
            if (unitPrefabs[i].name == PlayerPrefs.GetString("B6Name"))
            {
                Instantiate(unitPrefabs[i], new Vector3(-40, 24, 0), Quaternion.identity);
            }
            if (unitPrefabs[i].name == PlayerPrefs.GetString("C6Name"))
            {
                Instantiate(unitPrefabs[i], new Vector3(-24, 24, 0), Quaternion.identity);
            }
            if (unitPrefabs[i].name == PlayerPrefs.GetString("D6Name"))
            {
                Instantiate(unitPrefabs[i], new Vector3(-8, 24, 0), Quaternion.identity);
            }
            if (unitPrefabs[i].name == PlayerPrefs.GetString("E6Name"))
            {
                Instantiate(unitPrefabs[i], new Vector3(8, 24, 0), Quaternion.identity);
            }
            if (unitPrefabs[i].name == PlayerPrefs.GetString("F6Name"))
            {
                Instantiate(unitPrefabs[i], new Vector3(24, 24, 0), Quaternion.identity);
            }
            if (unitPrefabs[i].name == PlayerPrefs.GetString("G6Name"))
            {
                Instantiate(unitPrefabs[i], new Vector3(40, 24, 0), Quaternion.identity);
            }
            if (unitPrefabs[i].name == PlayerPrefs.GetString("H6Name"))
            {
                Instantiate(unitPrefabs[i], new Vector3(56, 24, 0), Quaternion.identity);
            }
            if (unitPrefabs[i].name == PlayerPrefs.GetString("A7Name"))
            {
                Instantiate(unitPrefabs[i], new Vector3(-56, 40, 0), Quaternion.identity);
            }
            if (unitPrefabs[i].name == PlayerPrefs.GetString("B7Name"))
            {
                Instantiate(unitPrefabs[i], new Vector3(-40, 40, 0), Quaternion.identity);
            }
            if (unitPrefabs[i].name == PlayerPrefs.GetString("C7Name"))
            {
                Instantiate(unitPrefabs[i], new Vector3(-24, 40, 0), Quaternion.identity);
            }
            if (unitPrefabs[i].name == PlayerPrefs.GetString("D7Name"))
            {
                Instantiate(unitPrefabs[i], new Vector3(-8, 40, 0), Quaternion.identity);
            }
            if (unitPrefabs[i].name == PlayerPrefs.GetString("E7Name"))
            {
                Instantiate(unitPrefabs[i], new Vector3(8, 40, 0), Quaternion.identity);
            }
            if (unitPrefabs[i].name == PlayerPrefs.GetString("F7Name"))
            {
                Instantiate(unitPrefabs[i], new Vector3(24, 40, 0), Quaternion.identity);
            }
            if (unitPrefabs[i].name == PlayerPrefs.GetString("G7Name"))
            {
                Instantiate(unitPrefabs[i], new Vector3(40, 40, 0), Quaternion.identity);
            }
            if (unitPrefabs[i].name == PlayerPrefs.GetString("H7Name"))
            {
                Instantiate(unitPrefabs[i], new Vector3(56, 40, 0), Quaternion.identity);
            }
            if (unitPrefabs[i].name == PlayerPrefs.GetString("A8Name"))
            {
                Instantiate(unitPrefabs[i], new Vector3(-56, 56, 0), Quaternion.identity);
            }
            if (unitPrefabs[i].name == PlayerPrefs.GetString("B8Name"))
            {
                Instantiate(unitPrefabs[i], new Vector3(-40, 56, 0), Quaternion.identity);
            }
            if (unitPrefabs[i].name == PlayerPrefs.GetString("C8Name"))
            {
                Instantiate(unitPrefabs[i], new Vector3(-24, 56, 0), Quaternion.identity);
            }
            if (unitPrefabs[i].name == PlayerPrefs.GetString("D8Name"))
            {
                Instantiate(unitPrefabs[i], new Vector3(-8, 56, 0), Quaternion.identity);
            }
            if (unitPrefabs[i].name == PlayerPrefs.GetString("E8Name"))
            {
                Instantiate(unitPrefabs[i], new Vector3(8, 56, 0), Quaternion.identity);
            }
            if (unitPrefabs[i].name == PlayerPrefs.GetString("F8Name"))
            {
                Instantiate(unitPrefabs[i], new Vector3(24, 56, 0), Quaternion.identity);
            }
            if (unitPrefabs[i].name == PlayerPrefs.GetString("G8Name"))
            {
                Instantiate(unitPrefabs[i], new Vector3(40, 56, 0), Quaternion.identity);
            }
            if (unitPrefabs[i].name == PlayerPrefs.GetString("H8Name"))
            {
                Instantiate(unitPrefabs[i], new Vector3(56, 56, 0), Quaternion.identity);
            }

        }
    }

    private void Update()
    {
        frames.text = Mathf.FloorToInt(1 / Time.deltaTime).ToString();

        if (friendlyGameObjects.Count == 0)
        {
            PlayerPrefs.SetString("WinLoss", "Loss");
            SceneManager.LoadScene("WinLossScene");
        }
        else if (enemyGameObjects.Count == 0) {
            PlayerPrefs.SetString("WinLoss", "Win");
            SceneManager.LoadScene("WinLossScene");
        }
    }

}
