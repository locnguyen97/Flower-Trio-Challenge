using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public string type;

    public int child;

    private void OnEnable()
    {
        child = 1;
        for (int i = 1; i < 4; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
        GetComponent<BoxCollider2D>().enabled = true;
        type = "";
    }

    public bool SetChild(Sprite spr)
    {
        transform.GetChild(child).gameObject.SetActive(true);
        transform.GetChild(child).GetComponent<SpriteRenderer>().sprite = spr;
        type = spr.name;
        child++;
        return child == 4;
    }

    public void Reset()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        Invoke(nameof(Rs),0.3f);
    }

    void Rs()
    {
        child = 1;
        for (int i = 1; i < 4; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
        GetComponent<BoxCollider2D>().enabled = true;
        type = "";
        GameManager.Instance.GetCurLevel().CheckLevelUp();
    }
}
