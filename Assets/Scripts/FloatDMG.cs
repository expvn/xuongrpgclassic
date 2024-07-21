using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class FloatDMG : MonoBehaviour
{
    public static FloatDMG instance;

    public List<SetShowDMG> gameObjects;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        foreach (Transform item in transform)
        {
            gameObjects.Add(item.GetComponent<SetShowDMG>());            
        }
    }

    public void ShowDMG(int dmg, Vector3 pos)
    {
        var getOne = gameObjects.FirstOrDefault(x => !x.gameObject.activeSelf);
        if (getOne != null)
        {
            getOne.setDMG(dmg);
            getOne.transform.position = pos;
            getOne.gameObject.SetActive(true);
            StartCoroutine(delay(getOne.gameObject));
        }
    }

    IEnumerator delay(GameObject gameObject)
    {
        yield return new WaitForSeconds(1.5f);
        gameObject.SetActive(false);
    }
}
