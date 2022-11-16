using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    [SerializeField] private GameObject myChar;
    [SerializeField] private Camera cam;
    [SerializeField] private GameObject readyAlert;
    public GameObject winPanel;
    public Slider enemyTowerHp;
    public TowerController enemyTower;
    private bool ready = false;

    private void Start()
    {
        instance = this;
    }
    private void Update()
    {
        enemyTowerHp.value = enemyTower.currentHp;
        enemyTowerHp.maxValue = enemyTower.maxHp;
        if (Input.GetMouseButtonDown(0) && ready)
        {
            SpawnCharacter();
        }
    }
    public void ReadyToSpawn()
    {
        ready = true;
        readyAlert.SetActive(true);
    }

    public void SpawnCharacter()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            Debug.Log(raycastHit.point);
            Vector3  point = new Vector3(raycastHit.point.x, raycastHit.point.y + 1, raycastHit.point.z);
            Instantiate(myChar, point, Quaternion.Euler(new Vector3(0, -180,0)));
            ready = false;
            readyAlert.SetActive(false);
        }
        
    }
}
