using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    [SerializeField] private int myChar;
    [SerializeField] public Camera cam;
    [SerializeField] public GameObject readyAlert;
    [SerializeField] public GameObject spawnRange;
    [SerializeField] public GameObject chooseCharacterBtn;
    [SerializeField] public GameObject fightBtn;
    [SerializeField] public Text playerGold;

    public GameObject winPanel;
    public GameObject losrPanel;
    public Slider enemyTowerHp;
    public TowerController enemyTower;
    

    private void Start()
    {
        instance = this;
    }
    private void Update()
    {
        enemyTowerHp.value = enemyTower.currentHp;
        enemyTowerHp.maxValue = enemyTower.maxHp;

    }

    public void StartBattle()
    {
        GameManager.instance.StartBattle();
        fightBtn.SetActive(false);
    }
    public void ReadyToSpawn(int i)
    {
        GameManager.instance.ready = true;
        readyAlert.SetActive(true);
        spawnRange.SetActive(true);
        GameManager.instance.SetCharToSpawn(i);
        chooseCharacterBtn.transform.position = new Vector3(chooseCharacterBtn.transform.position.x, -90f, chooseCharacterBtn.transform.position.z);
    }

}
