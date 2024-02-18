using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObjectMoveByDrag : MonoBehaviour
{
    [SerializeField] List<GameObject> particleVFXs;

    private Vector3 startPos;
    private Transform target;

    private void Start()
    {
       //transform.rotation = new Quaternion(0,0,Random.Range(0,360),0);
    }

    private void OnEnable()
    {
        startPos = transform.position;
    }

    public void PickUp()
    {
        //transform.rotation = new Quaternion(0,0,0,0);
    }

    public void CheckOnMouseUp()
    {
        //transform.position = startPos;
        if (target)
        {
            Target tg = target.GetComponent<Target>();
            if (tg != null)
            {
                if (tg.type == "")
                {
                    tg.SetChild(GetComponent<SpriteRenderer>().sprite);
                    transform.gameObject.SetActive(false);
                    GameManager.Instance.GetCurLevel().RemoveObject(gameObject);
                    Destroy(gameObject);
                }
                else
                {
                    if (tg.type == GetComponent<SpriteRenderer>().sprite.name)
                    {
                        var kq = target.GetComponent<Target>().SetChild(GetComponent<SpriteRenderer>().sprite);
                        if (kq)
                        {
                            tg.Reset();
                            GameObject explosion = Instantiate(particleVFXs[Random.Range(0,particleVFXs.Count)], transform.position, transform.rotation);
                            Destroy(explosion, .75f);
                        }
                        transform.gameObject.SetActive(false);
                        GameManager.Instance.GetCurLevel().RemoveObject(gameObject);
                        Destroy(gameObject);
                    }
                    else
                    {
                        transform.position = startPos;
                    }
                }
            }
            else
            {
                transform.position = startPos;
            }
        }
        else
        {
            transform.position = startPos;
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "target")
        {
            target = collision.transform;
        }
    }
    
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "target")
        {
            target = null;
        }
    }
}
