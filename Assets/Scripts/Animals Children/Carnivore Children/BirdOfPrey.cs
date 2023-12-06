using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdOfPrey : Carnivore
{
    void Start()
    {
        base.Start();
    }


    void Update()
    {
        base.Update();
        if (isMoving)
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y + speed * Time.deltaTime);
        }
        //else
        //{
        //    transform.position = transform.position;
        //}
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        nameText.text = name;
        ageText.text = "" + age;
        if (collision.gameObject.CompareTag("Player"))
        {
            inRange = true;
            informationsPanel.SetActive(true);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inRange = false;
            informationsPanel.SetActive(false);
        }
    }
}
