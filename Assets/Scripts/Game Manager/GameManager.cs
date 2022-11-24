using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Player Resource")]
    [SerializeField] private List<CharacterCore> characterList;
    [SerializeField] private int playerGold;
    public bool ready = false;

    public bool startBattle = false;
    
    private int characterToSpawn;
    private float loseCD = 30f;
    private GameObject[] soldierInGame;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        soldierInGame = GameObject.FindGameObjectsWithTag("Player");
        loseCD -= Time.deltaTime;

        if (Input.GetMouseButtonDown(0) && ready)
        {
            if (playerGold < characterList[characterToSpawn].GetComponent<CharacterCore>().gold)
            {
                StartCoroutine(NotEnoughGold(2f));
                
            }
            else
            {
                Spawn();
            }
        }

        if(loseCD <= 0 && soldierInGame.Length <=0 || !HadSoldierAlive() && startBattle)
        {
            Time.timeScale = 0;
            UIController.instance.losrPanel.SetActive(true);
        }

        UIController.instance.playerGold.text = "Current Gold: " + playerGold.ToString() + "g";
    }

    public void StartBattle()
    {
        startBattle = true;
    }

    public void SetCharToSpawn(int i)
    {
        characterToSpawn = i;
    }
    public void Spawn()
    {
        Ray ray = UIController.instance.cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            if(playerGold>= characterList[characterToSpawn].GetComponent<CharacterCore>().gold)
            {
                loseCD = 30f;
                Vector3 point = new Vector3(raycastHit.point.x, raycastHit.point.y + 1, raycastHit.point.z);
                Instantiate(characterList[characterToSpawn], point, Quaternion.Euler(new Vector3(0, -180, 0)));
                playerGold -= characterList[characterToSpawn].GetComponent<CharacterCore>().gold;
            }

            Debug.Log(raycastHit.point);           
            ready = false;
            UIController.instance.readyAlert.SetActive(false);
            UIController.instance.spawnRange.SetActive(false);
            UIController.instance.chooseCharacterBtn.transform.position = new Vector3(UIController.instance.chooseCharacterBtn.transform.position.x, 50f, UIController.instance.chooseCharacterBtn.transform.position.z);
        }
    }

    private IEnumerator NotEnoughGold(float time)
    {
        UIController.instance.readyAlert.GetComponent<Text>().text = "You dont have enough gold!";
        yield return new WaitForSeconds(time);
        ready = false;
        UIController.instance.readyAlert.SetActive(false);
        UIController.instance.spawnRange.SetActive(false);
        UIController.instance.readyAlert.GetComponent<Text>().text = "Click To Spawn";
        UIController.instance.chooseCharacterBtn.transform.position = new Vector3(UIController.instance.chooseCharacterBtn.transform.position.x, 50f, UIController.instance.chooseCharacterBtn.transform.position.z);
    }

    private bool HadSoldierAlive()
    {
        bool allAlive = true;     
        if(soldierInGame.Length <= 0)
        {
            return true;
        }

        foreach (GameObject soldier in soldierInGame)
        {
            soldier.GetComponent<CharacterCore>();
            if(soldier.GetComponent<CharacterCore>().currentHp <= 0)
            {
                allAlive = false;
            }
            else
            {
                return true;
            }
        }
        return allAlive;
    }
}
