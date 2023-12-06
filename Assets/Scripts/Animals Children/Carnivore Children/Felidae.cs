using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Felidae : Carnivore
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
            transform.position = new Vector2(transform.position.x + speed*Time.deltaTime, transform.position.y);
        }

        if (tiredness > 0f && !isSleeping)
        {
            tiredness -= age * 0.5f * Time.deltaTime;
            sleepBar.fillAmount = tiredness / 100f;
        }
        else if (tiredness <= 0f)
        {
            isSleeping = true;
            state = State.Sleep;
            ChangeBehaviour();
        }
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
