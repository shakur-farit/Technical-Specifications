using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;
    private Queue<Vector2> points = new Queue<Vector2>();

    //bool showPath = true;

    private int coins;

    public Text coinsText;

    public Button reloadButten;
    public Button winButton;

    public GameObject explosion;


    private void Start()
    {
        Time.timeScale = 1f;
        reloadButten.gameObject.SetActive(false);
        winButton.gameObject.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            points.Enqueue(mouse);

        }

        if (points.Count != 0)
        {

            Vector3 target = points.Peek();

            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
            if (transform.position == target)
            {
                points.Dequeue();
            }
        }

        GameObject go = GameObject.FindWithTag("Coin");
        if(go == null)
        {
            winButton.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
        
     }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            coins++;
            Destroy(collision.gameObject);
            coinsText.text = coins.ToString();
        }

        if (collision.CompareTag("Hole"))
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
            reloadButten.gameObject.SetActive(true);
        }
    }

    //private void OnDrawGizmos()
    //{
    //    if (showPath == false || points.Count == 0)
    //        return;


    //    var e = points.GetEnumerator();
    //    e.MoveNext();

    //    Vector2 prevPoint = e.Current;
    //    Gizmos.DrawLine(transform.position, prevPoint);
    //    Gizmos.DrawWireSphere(prevPoint, 0.2f);

    //    while (e.MoveNext())
    //    {
    //        Gizmos.DrawLine(prevPoint, e.Current);
    //        Gizmos.DrawWireSphere(e.Current, 0.2f);

    //        prevPoint = e.Current;
    //    }
    //}
}

