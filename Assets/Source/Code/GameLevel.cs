using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLevel : MonoBehaviour
{
    public List<GameObject> gameObjectsPoint;
    private bool canCheck = true;
    public void OnEnable()
    {
        canCheck = true;
        var lists = FindObjectsOfType<ObjectMoveByDrag>(false);
        foreach (var tr in lists)
        {
            if (tr.gameObject.activeSelf)
            {
                gameObjectsPoint.Add(tr.gameObject);
            }

        }
    }

    public void RemoveObject(GameObject obj)
    {
        gameObjectsPoint.Remove(obj);
        
    }

    public void CheckLevelUp()
    {
        if (canCheck)
        {
            if (gameObjectsPoint.Count == 0)
            {
                GameManager.Instance.CheckLevelUp();
                canCheck = false;
            }
        }
    }
}
