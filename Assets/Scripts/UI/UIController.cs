using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject myChar;
    [SerializeField] private Transform spawnPoint;

    public void SpawnCharacter()
    {
        Instantiate(myChar, spawnPoint.position, spawnPoint.rotation);
    }
}
