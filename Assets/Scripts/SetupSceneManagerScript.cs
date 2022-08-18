using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SetupSceneManagerScript : MonoBehaviour
{
    [SerializeField]
    Image meleeImage;
    [SerializeField]
    Image rangedImage;
    [SerializeField]
    Image shieldImage;
    [SerializeField]
    Image polearmImage;
    [SerializeField]
    Image catapultImage;
    [SerializeField]
    Image dualWieldImage;
    [SerializeField]
    Image horsebackImage;
    [SerializeField]
    Image dogImage;
    [SerializeField]
    Image bearImage;
    [SerializeField]
    Image chariotImage;
    [SerializeField]
    Image berserkerImage;
    [SerializeField]
    Image spearImage;

    [SerializeField]
    Sprite friendlyMeleeSprite;
    [SerializeField]
    Sprite friendlyRangedSprite;
    [SerializeField]
    Sprite friendlyShieldSprite;
    [SerializeField]
    Sprite friendlyPolearmSprite;
    [SerializeField]
    Sprite friendlyCatapultSprite;
    [SerializeField]
    Sprite friendlyDualWieldSprite;
    [SerializeField]
    Sprite friendlyHorsebackSprite;
    [SerializeField]
    Sprite friendlyDogSprite;
    [SerializeField]
    Sprite friendlyBearSprite;
    [SerializeField]
    Sprite friendlyChariotSprite;
    [SerializeField]
    Sprite friendlyBerserkerSprite;
    [SerializeField]
    Sprite friendlySpearSprite;

    [SerializeField]
    Button playerBerserkerButton;

    [SerializeField]
    Sprite enemyMeleeSprite;
    [SerializeField]
    Sprite enemyRangedSprite;
    [SerializeField]
    Sprite enemyShieldSprite;
    [SerializeField]
    Sprite enemyPolearmSprite;
    [SerializeField]
    Sprite enemyCatapultSprite;
    [SerializeField]
    Sprite enemyDualWieldSprite;
    [SerializeField]
    Sprite enemyHorsebackSprite;
    [SerializeField]
    Sprite enemyDogSprite;
    [SerializeField]
    Sprite enemyBearSprite;
    [SerializeField]
    Sprite enemyChariotSprite;
    [SerializeField]
    Sprite enemyBerserkerSprite;
    [SerializeField]
    Sprite enemySpearSprite;

    [SerializeField]
    Image unitBackdropImage;

    [SerializeField]
    Image positionA1;
    [SerializeField]
    Image positionA2;
    [SerializeField]
    Image positionA3;
    [SerializeField]
    Image positionA4;
    [SerializeField]
    Image positionA5;
    [SerializeField]
    Image positionA6;
    [SerializeField]
    Image positionA7;
    [SerializeField]
    Image positionA8;

    [SerializeField]
    Image positionB1;
    [SerializeField]
    Image positionB2;
    [SerializeField]
    Image positionB3;
    [SerializeField]
    Image positionB4;
    [SerializeField]
    Image positionB5;
    [SerializeField]
    Image positionB6;
    [SerializeField]
    Image positionB7;
    [SerializeField]
    Image positionB8;

    [SerializeField]
    Image positionC1;
    [SerializeField]
    Image positionC2;
    [SerializeField]
    Image positionC3;
    [SerializeField]
    Image positionC4;
    [SerializeField]
    Image positionC5;
    [SerializeField]
    Image positionC6;
    [SerializeField]
    Image positionC7;
    [SerializeField]
    Image positionC8;

    [SerializeField]
    Image positionD1;
    [SerializeField]
    Image positionD2;
    [SerializeField]
    Image positionD3;
    [SerializeField]
    Image positionD4;
    [SerializeField]
    Image positionD5;
    [SerializeField]
    Image positionD6;
    [SerializeField]
    Image positionD7;
    [SerializeField]
    Image positionD8;

    [SerializeField]
    Image positionE1;
    [SerializeField]
    Image positionE2;
    [SerializeField]
    Image positionE3;
    [SerializeField]
    Image positionE4;
    [SerializeField]
    Image positionE5;
    [SerializeField]
    Image positionE6;
    [SerializeField]
    Image positionE7;
    [SerializeField]
    Image positionE8;

    [SerializeField]
    Image positionF1;
    [SerializeField]
    Image positionF2;
    [SerializeField]
    Image positionF3;
    [SerializeField]
    Image positionF4;
    [SerializeField]
    Image positionF5;
    [SerializeField]
    Image positionF6;
    [SerializeField]
    Image positionF7;
    [SerializeField]
    Image positionF8;

    [SerializeField]
    Image positionG1;
    [SerializeField]
    Image positionG2;
    [SerializeField]
    Image positionG3;
    [SerializeField]
    Image positionG4;
    [SerializeField]
    Image positionG5;
    [SerializeField]
    Image positionG6;
    [SerializeField]
    Image positionG7;
    [SerializeField]
    Image positionG8;

    [SerializeField]
    Image positionH1;
    [SerializeField]
    Image positionH2;
    [SerializeField]
    Image positionH3;
    [SerializeField]
    Image positionH4;
    [SerializeField]
    Image positionH5;
    [SerializeField]
    Image positionH6;
    [SerializeField]
    Image positionH7;
    [SerializeField]
    Image positionH8;

    [SerializeField]
    Button buttonPositionA1;
    [SerializeField]
    Button buttonPositionA2;
    [SerializeField]
    Button buttonPositionA3;
    [SerializeField]
    Button buttonPositionA4;
    [SerializeField]
    Button buttonPositionA5;
    [SerializeField]
    Button buttonPositionA6;
    [SerializeField]
    Button buttonPositionA7;
    [SerializeField]
    Button buttonPositionA8;

    [SerializeField]
    Button buttonPositionB1;
    [SerializeField]
    Button buttonPositionB2;
    [SerializeField]
    Button buttonPositionB3;
    [SerializeField]
    Button buttonPositionB4;
    [SerializeField]
    Button buttonPositionB5;
    [SerializeField]
    Button buttonPositionB6;
    [SerializeField]
    Button buttonPositionB7;
    [SerializeField]
    Button buttonPositionB8;

    [SerializeField]
    Button buttonPositionC1;
    [SerializeField]
    Button buttonPositionC2;
    [SerializeField]
    Button buttonPositionC3;
    [SerializeField]
    Button buttonPositionC4;
    [SerializeField]
    Button buttonPositionC5;
    [SerializeField]
    Button buttonPositionC6;
    [SerializeField]
    Button buttonPositionC7;
    [SerializeField]
    Button buttonPositionC8;

    [SerializeField]
    Button buttonPositionD1;
    [SerializeField]
    Button buttonPositionD2;
    [SerializeField]
    Button buttonPositionD3;
    [SerializeField]
    Button buttonPositionD4;
    [SerializeField]
    Button buttonPositionD5;
    [SerializeField]
    Button buttonPositionD6;
    [SerializeField]
    Button buttonPositionD7;
    [SerializeField]
    Button buttonPositionD8;

    [SerializeField]
    Button buttonPositionE1;
    [SerializeField]
    Button buttonPositionE2;
    [SerializeField]
    Button buttonPositionE3;
    [SerializeField]
    Button buttonPositionE4;
    [SerializeField]
    Button buttonPositionE5;
    [SerializeField]
    Button buttonPositionE6;
    [SerializeField]
    Button buttonPositionE7;
    [SerializeField]
    Button buttonPositionE8;

    [SerializeField]
    Button buttonPositionF1;
    [SerializeField]
    Button buttonPositionF2;
    [SerializeField]
    Button buttonPositionF3;
    [SerializeField]
    Button buttonPositionF4;
    [SerializeField]
    Button buttonPositionF5;
    [SerializeField]
    Button buttonPositionF6;
    [SerializeField]
    Button buttonPositionF7;
    [SerializeField]
    Button buttonPositionF8;

    [SerializeField]
    Button buttonPositionG1;
    [SerializeField]
    Button buttonPositionG2;
    [SerializeField]
    Button buttonPositionG3;
    [SerializeField]
    Button buttonPositionG4;
    [SerializeField]
    Button buttonPositionG5;
    [SerializeField]
    Button buttonPositionG6;
    [SerializeField]
    Button buttonPositionG7;
    [SerializeField]
    Button buttonPositionG8;

    [SerializeField]
    Button buttonPositionH1;
    [SerializeField]
    Button buttonPositionH2;
    [SerializeField]
    Button buttonPositionH3;
    [SerializeField]
    Button buttonPositionH4;
    [SerializeField]
    Button buttonPositionH5;
    [SerializeField]
    Button buttonPositionH6;
    [SerializeField]
    Button buttonPositionH7;
    [SerializeField]
    Button buttonPositionH8;

    [SerializeField]
    GameObject berserkerAlert;

    List<Image> positionImages = new List<Image>();

    enum SelectionState { selected, unselected};

    SelectionState currentSelectionState = SelectionState.unselected;

    Image selectedSwapImage;

    Image selectedNewImage;

    [SerializeField]
    GameObject enemyButton;

    [SerializeField]
    GameObject playerButton;

    int unitsCanPlace = 0;

    int unitsPlaced = 0;


    [SerializeField]
    private TMP_Text unitsLeftText;

    bool playerBerserkerPlaced = false;

    private void Awake()
    {
        if(PlayerPrefs.GetInt("Level") != 0)
        {
            enemyButton.SetActive(false);
            playerButton.SetActive(false);
        } else
        {
            unitsCanPlace = 64;
            unitsLeftText.text = "Units Left: " + unitsCanPlace.ToString();
        }

        if(PlayerPrefs.GetInt("Level") == 1)
        {
            positionD5.sprite = enemyMeleeSprite;
            positionD5.color = new Color(1, 1, 1, 1);
            buttonPositionD5.enabled = false;

            positionE5.sprite = enemyMeleeSprite;
            positionE5.color = new Color(1, 1, 1, 1);
            buttonPositionE5.enabled = false;

            positionD6.sprite = enemyRangedSprite;
            positionD6.color = new Color(1, 1, 1, 1);
            buttonPositionD6.enabled = false;

            positionE6.sprite = enemyRangedSprite;
            positionE6.color = new Color(1, 1, 1, 1);
            buttonPositionE6.enabled = false;

            unitsCanPlace = 3;
            unitsLeftText.text = "Units Left: " + unitsCanPlace.ToString();
        }


        if (PlayerPrefs.GetInt("Level") == 2)
        {
            positionD5.sprite = enemyShieldSprite;
            positionD5.color = new Color(1, 1, 1, 1);
            buttonPositionD5.enabled = false;

            positionE5.sprite = enemyShieldSprite;
            positionE5.color = new Color(1, 1, 1, 1);
            buttonPositionE5.enabled = false;

            positionD6.sprite = enemyMeleeSprite;
            positionD6.color = new Color(1, 1, 1, 1);
            buttonPositionD6.enabled = false;

            positionE6.sprite = enemyMeleeSprite;
            positionE6.color = new Color(1, 1, 1, 1);
            buttonPositionE6.enabled = false;

            positionD7.sprite = enemySpearSprite;
            positionD7.color = new Color(1, 1, 1, 1);
            buttonPositionD7.enabled = false;

            positionE7.sprite = enemySpearSprite;
            positionE7.color = new Color(1, 1, 1, 1);
            buttonPositionE7.enabled = false;
            buttonPositionE6.enabled = false;

            positionC5.sprite = enemyPolearmSprite;
            positionC5.color = new Color(1, 1, 1, 1);
            buttonPositionC5.enabled = false;

            positionF5.sprite = enemyPolearmSprite;
            positionF5.color = new Color(1, 1, 1, 1);
            buttonPositionF5.enabled = false;

            positionB5.sprite = enemyHorsebackSprite;
            positionB5.color = new Color(1, 1, 1, 1);
            buttonPositionB5.enabled = false;

            positionG5.sprite = enemyHorsebackSprite;
            positionG5.color = new Color(1, 1, 1, 1);
            buttonPositionG5.enabled = false;

            positionC6.sprite = enemyDogSprite;
            positionC6.color = new Color(1, 1, 1, 1);
            buttonPositionC6.enabled = false;

            positionF6.sprite = enemyDogSprite;
            positionF6.color = new Color(1, 1, 1, 1);
            buttonPositionF6.enabled = false;


            unitsCanPlace = 8;
            unitsLeftText.text = "Units Left: " + unitsCanPlace.ToString();
        }


        if (PlayerPrefs.GetInt("Level") == 3)
        {
            positionD5.sprite = enemyPolearmSprite;
            positionD5.color = new Color(1, 1, 1, 1);
            buttonPositionD5.enabled = false;

            positionE5.sprite = enemyPolearmSprite;
            positionE5.color = new Color(1, 1, 1, 1);
            buttonPositionE5.enabled = false;

            positionD6.sprite = enemyRangedSprite;
            positionD6.color = new Color(1, 1, 1, 1);
            buttonPositionD6.enabled = false;

            positionE6.sprite = enemyRangedSprite;
            positionE6.color = new Color(1, 1, 1, 1);
            buttonPositionE6.enabled = false;

            positionD7.sprite = enemyChariotSprite;
            positionD7.color = new Color(1, 1, 1, 1);
            buttonPositionD7.enabled = false;

            positionE7.sprite = enemyChariotSprite;
            positionE7.color = new Color(1, 1, 1, 1);
            buttonPositionE7.enabled = false;
            buttonPositionE6.enabled = false;

            positionC5.sprite = enemyShieldSprite;
            positionC5.color = new Color(1, 1, 1, 1);
            buttonPositionC5.enabled = false;

            positionF5.sprite = enemyShieldSprite;
            positionF5.color = new Color(1, 1, 1, 1);
            buttonPositionF5.enabled = false;

            positionB5.sprite = enemyChariotSprite;
            positionB5.color = new Color(1, 1, 1, 1);
            buttonPositionB5.enabled = false;

            positionG5.sprite = enemyChariotSprite;
            positionG5.color = new Color(1, 1, 1, 1);
            buttonPositionG5.enabled = false;

            positionC6.sprite = enemyMeleeSprite;
            positionC6.color = new Color(1, 1, 1, 1);
            buttonPositionC6.enabled = false;

            positionF6.sprite = enemyMeleeSprite;
            positionF6.color = new Color(1, 1, 1, 1);
            buttonPositionF6.enabled = false;

            positionC7.sprite = enemySpearSprite;
            positionC7.color = new Color(1, 1, 1, 1);
            buttonPositionC7.enabled = false;

            positionF7.sprite = enemySpearSprite;
            positionF7.color = new Color(1, 1, 1, 1);
            buttonPositionF7.enabled = false;

            positionA5.sprite = enemyBearSprite;
            positionA5.color = new Color(1, 1, 1, 1);
            buttonPositionA5.enabled = false;

            positionH5.sprite = enemyBerserkerSprite;
            positionH5.color = new Color(1, 1, 1, 1);
            buttonPositionH5.enabled = false;

            positionA6.sprite = enemyDualWieldSprite;
            positionA6.color = new Color(1, 1, 1, 1);
            buttonPositionA6.enabled = false;

            positionH6.sprite = enemyDualWieldSprite;
            positionH6.color = new Color(1, 1, 1, 1);
            buttonPositionH6.enabled = false;

            positionA7.sprite = enemyHorsebackSprite;
            positionA7.color = new Color(1, 1, 1, 1);
            buttonPositionA7.enabled = false;

            positionH7.sprite = enemyHorsebackSprite;
            positionH7.color = new Color(1, 1, 1, 1);
            buttonPositionH7.enabled = false;

            positionA8.sprite = enemyCatapultSprite;
            positionA8.color = new Color(1, 1, 1, 1);
            buttonPositionA8.enabled = false;

            positionH8.sprite = enemyCatapultSprite;
            positionH8.color = new Color(1, 1, 1, 1);
            buttonPositionH8.enabled = false;

            positionG6.sprite = enemyDogSprite;
            positionG6.color = new Color(1, 1, 1, 1);
            buttonPositionG6.enabled = false;

            positionB6.sprite = enemyDogSprite;
            positionB6.color = new Color(1, 1, 1, 1);
            buttonPositionB6.enabled = false;

            positionG7.sprite = enemyHorsebackSprite;
            positionG7.color = new Color(1, 1, 1, 1);
            buttonPositionG7.enabled = false;

            positionB7.sprite = enemyHorsebackSprite;
            positionB7.color = new Color(1, 1, 1, 1);
            buttonPositionB7.enabled = false;

            positionD8.sprite = enemyCatapultSprite;
            positionD8.color = new Color(1, 1, 1, 1);
            buttonPositionD8.enabled = false;

            positionE8.sprite = enemyCatapultSprite;
            positionE8.color = new Color(1, 1, 1, 1);
            buttonPositionE8.enabled = false;



            unitsCanPlace = 24;
            unitsLeftText.text = "Units Left: " + unitsCanPlace.ToString();
        }
    }

    private void Start()
    {
        positionImages.Add(positionA1);
        positionImages.Add(positionA2);
        positionImages.Add(positionA3);
        positionImages.Add(positionA4);
        positionImages.Add(positionA5);
        positionImages.Add(positionA6);
        positionImages.Add(positionA7);
        positionImages.Add(positionA8);
        positionImages.Add(positionB1);
        positionImages.Add(positionB2);
        positionImages.Add(positionB3);
        positionImages.Add(positionB4);
        positionImages.Add(positionB5);
        positionImages.Add(positionB6);
        positionImages.Add(positionB7);
        positionImages.Add(positionB8);
        positionImages.Add(positionC1);
        positionImages.Add(positionC2);
        positionImages.Add(positionC3);
        positionImages.Add(positionC4);
        positionImages.Add(positionC5);
        positionImages.Add(positionC6);
        positionImages.Add(positionC7);
        positionImages.Add(positionC8);
        positionImages.Add(positionD1);
        positionImages.Add(positionD2);
        positionImages.Add(positionD3);
        positionImages.Add(positionD4);
        positionImages.Add(positionD5);
        positionImages.Add(positionD6);
        positionImages.Add(positionD7);
        positionImages.Add(positionD8);
        positionImages.Add(positionE1);
        positionImages.Add(positionE2);
        positionImages.Add(positionE3);
        positionImages.Add(positionE4);
        positionImages.Add(positionE5);
        positionImages.Add(positionE6);
        positionImages.Add(positionE7);
        positionImages.Add(positionE8);
        positionImages.Add(positionF1);
        positionImages.Add(positionF2);
        positionImages.Add(positionF3);
        positionImages.Add(positionF4);
        positionImages.Add(positionF5);
        positionImages.Add(positionF6);
        positionImages.Add(positionF7);
        positionImages.Add(positionF8);
        positionImages.Add(positionG1);
        positionImages.Add(positionG2);
        positionImages.Add(positionG3);
        positionImages.Add(positionG4);
        positionImages.Add(positionG5);
        positionImages.Add(positionG6);
        positionImages.Add(positionG7);
        positionImages.Add(positionG8);
        positionImages.Add(positionH1);
        positionImages.Add(positionH2);
        positionImages.Add(positionH3);
        positionImages.Add(positionH4);
        positionImages.Add(positionH5);
        positionImages.Add(positionH6);
        positionImages.Add(positionH7);
        positionImages.Add(positionH8);
    }

    public void UpdateSelection(Image thisImage)
    {
        if (currentSelectionState == SelectionState.unselected)
        {
            selectedNewImage = null;
            selectedSwapImage = thisImage;

            currentSelectionState = SelectionState.selected;
        }
        else if (currentSelectionState == SelectionState.selected && selectedSwapImage != null)
        {

            Sprite tempSelectedSprite = selectedSwapImage.sprite;

            Sprite tempNewlySelectedSprite = thisImage.sprite;

            thisImage.sprite = tempSelectedSprite;
            selectedSwapImage.sprite = tempNewlySelectedSprite;

            if (thisImage.sprite == null)
            {
                thisImage.color = new Color(0, 0, 0, 0);
            }
            else
            {
                thisImage.color = new Color(1, 1, 1, 1);
            }

            if (selectedSwapImage.sprite == null)
            {
                selectedSwapImage.color = new Color(0, 0, 0, 0);
            }
            else
            {
                selectedSwapImage.color = new Color(1, 1, 1, 1);
            }

            selectedNewImage = null;
            selectedSwapImage = null;

            currentSelectionState = SelectionState.unselected;
        }
        else if (currentSelectionState == SelectionState.selected && selectedNewImage != null)
        {

            if(thisImage.sprite == null)
            {

                unitsPlaced++;

                unitsLeftText.text = "Units Left: " + (unitsCanPlace - unitsPlaced).ToString();
            }

            thisImage.sprite = selectedNewImage.sprite;
            thisImage.color = new Color(1, 1, 1, 1);

            selectedNewImage = null;
            selectedSwapImage = null;

            currentSelectionState = SelectionState.unselected;

            

            if(thisImage.sprite == friendlyBerserkerSprite)
            {
                playerBerserkerButton.interactable = false;
                playerBerserkerPlaced = true;
            }
        }
    }

    public void NewSelection(Image thisImage)
    {
        if (currentSelectionState == SelectionState.unselected && unitsPlaced < unitsCanPlace)
        {
            selectedNewImage = thisImage;

            currentSelectionState = SelectionState.selected;
        }
        else if (currentSelectionState == SelectionState.selected)
        {
            selectedSwapImage = null;
            selectedNewImage = thisImage;
        }
    }

    public void Unselect()
    {
        if(currentSelectionState == SelectionState.selected && selectedSwapImage != null && selectedSwapImage.sprite != null)
        {

            currentSelectionState = SelectionState.unselected;

            if(selectedSwapImage.sprite == friendlyBerserkerSprite)
            {
                playerBerserkerButton.interactable = true;
                playerBerserkerPlaced = false;
            }

            selectedSwapImage.sprite = null;
            selectedSwapImage.color = new Color(0, 0, 0, 0);
            selectedSwapImage = null;

            unitsPlaced--;

            unitsLeftText.text = "Units Left: " + (unitsCanPlace - unitsPlaced).ToString();
        }
    }

    public void SetupPlayerUnits()
    {
        meleeImage.sprite = friendlyMeleeSprite;
        rangedImage.sprite = friendlyRangedSprite;
        shieldImage.sprite = friendlyShieldSprite;
        polearmImage.sprite = friendlyPolearmSprite;
        catapultImage.sprite = friendlyCatapultSprite;
        dualWieldImage.sprite = friendlyDualWieldSprite;
        horsebackImage.sprite = friendlyHorsebackSprite;
        dogImage.sprite = friendlyDogSprite;
        bearImage.sprite = friendlyBearSprite;
        chariotImage.sprite = friendlyChariotSprite;
        berserkerImage.sprite = friendlyBerserkerSprite;
        spearImage.sprite = friendlySpearSprite;

        unitBackdropImage.color = Color.blue;

        if (playerBerserkerPlaced)
        {

            playerBerserkerButton.interactable = false;
        } else
        {

            playerBerserkerButton.interactable = true;
        }
    }

    public void SetupEnemyUnits()
    {
        meleeImage.sprite = enemyMeleeSprite;
        rangedImage.sprite = enemyRangedSprite;
        shieldImage.sprite = enemyShieldSprite;
        polearmImage.sprite = enemyPolearmSprite;
        catapultImage.sprite = enemyCatapultSprite;
        dualWieldImage.sprite = enemyDualWieldSprite;
        horsebackImage.sprite = enemyHorsebackSprite;
        dogImage.sprite = enemyDogSprite;
        bearImage.sprite = enemyBearSprite;
        chariotImage.sprite = enemyChariotSprite;
        berserkerImage.sprite = enemyBerserkerSprite;
        spearImage.sprite = enemySpearSprite;

        unitBackdropImage.color = Color.red;

        playerBerserkerButton.interactable = true;
    }

    public void NextScene()
    {
        if (playerBerserkerButton.interactable)
        {
            berserkerAlert.SetActive(true);
            StartCoroutine(HideAlert());
        } else
        {

            for (int i = 0; i < positionImages.Count; i++)
            {
                if (positionImages[i].sprite != null)
                {
                    string[] positionPrefixArray = positionImages[i].name.Split("Position");
                    string positionPrefix = positionPrefixArray[1];

                    PlayerPrefs.SetString(positionPrefix + "Name", positionImages[i].sprite.name);
                }
                else
                {
                    string[] positionPrefixArray = positionImages[i].name.Split("Position");
                    string positionPrefix = positionPrefixArray[1];

                    PlayerPrefs.SetString(positionPrefix + "Name", "");
                }
            }

            SceneManager.LoadScene("SampleScene");
        }
    }

    IEnumerator HideAlert()
    {
        yield return new WaitForSeconds(5f);
        berserkerAlert.SetActive(false);
    }
}
