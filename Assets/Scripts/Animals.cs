using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Animals : MonoBehaviour
{
    [SerializeField] protected string name;
    [SerializeField] protected int age;
    [SerializeField] protected float speed;
    
    protected enum Food {Meats, Plants, Everything}
    protected enum State {Move, Chill, Sleep, Eat}

    
    protected float eatingSatisfaction, thrist, tiredness;

    protected Collider2D collision;
    protected Food food;
    [SerializeField]protected State state;
    protected bool isMoving, isSleeping, isEating, inRange;
    protected int seafood = 25, meat = 40, berries = 15, vegetables = 40, foodValue;
    protected TextMeshProUGUI nameText, ageText, foodText;
    protected Image foodBar, waterBar, sleepBar;
    protected GameObject informationsPanel;

    protected void Awake()
    {
        nameText = GameObject.Find("Name").GetComponent<TextMeshProUGUI>();
        ageText = GameObject.Find("Age").GetComponent<TextMeshProUGUI>();
        foodText = GameObject.Find("Like").GetComponent<TextMeshProUGUI>();
        foodBar = GameObject.Find("Food Bar").GetComponent<Image>();
        waterBar = GameObject.Find("Water Bar").GetComponent<Image>();
        sleepBar = GameObject.Find("Sleep Bar").GetComponent<Image>();
        informationsPanel = GameObject.Find("Informations");
    }
    protected void Start()
    {
        informationsPanel.SetActive(false);
        eatingSatisfaction = 100f;
        thrist = 100f;
        tiredness = 100f;
        ChangeBehaviour();
    }

    protected void Update()
    {
        //if (eatingSatisfaction > 0)
        //{
        //    eatingSatisfaction -=  speed*10*Time.deltaTime;
        //    foodBar.fillAmount = eatingSatisfaction / 100f;
        //}

        //if (tiredness > 0f && !isSleeping)
        //{
        //    tiredness -= age * 0.5f * Time.deltaTime;
        //    sleepBar.fillAmount = tiredness / 100f;
        //}
        //else if (tiredness <=0f)
        //{
        //    isSleeping = true;
        //    state = State.Sleep;
        //    ChangeBehaviour();
        //}

        if (inRange)
        {
            if (Input.GetKey(KeyCode.Alpha1))
            {
                state = State.Eat;
                isEating = true;
                switch (food)
                {
                    case Food.Meats:
                        foodValue = seafood;
                        ChangeBehaviour();
                        break;
                    case Food.Plants:
                        Debug.Log("Can't eat this.");
                        break;
                    case Food.Everything:
                        foodValue = seafood;
                        ChangeBehaviour();
                        break;
                }
            }
            else if (Input.GetKey(KeyCode.Alpha2))
            {
                state = State.Eat;
                isEating = true;
                switch (food)
                {
                    case Food.Meats:
                        foodValue = meat;
                        ChangeBehaviour();
                        break;
                    case Food.Plants:
                        Debug.Log("Can't eat this.");
                        break;
                    case Food.Everything:
                        foodValue = meat;
                        ChangeBehaviour();
                        break;
                }
            }
            else if (Input.GetKey(KeyCode.Alpha3))
            {
                state = State.Eat;
                isEating = true;
                switch (food)
                {
                    case Food.Meats:
                        Debug.Log("Can't eat this."); 
                        break;
                    case Food.Plants:
                        foodValue = berries;
                        ChangeBehaviour();
                        break;
                    case Food.Everything:
                        foodValue = berries;
                        ChangeBehaviour();
                        break;
                }
            }
            else if (Input.GetKey(KeyCode.Alpha4))
            {
                state = State.Eat;
                isEating = true;
                switch (food)
                {
                    case Food.Meats:
                        Debug.Log("Can't eat this.");
                        break;
                    case Food.Plants:
                        foodValue = vegetables;
                        ChangeBehaviour();
                        break;
                    case Food.Everything:
                        foodValue = vegetables;
                        ChangeBehaviour();
                        break;
                }
            }
        }

        
    }

    public void ChangeBehaviour()
    {
        if (!isSleeping)
        {
            int rnd = UnityEngine.Random.Range(1, 101);
            if (rnd >= 65)
            {
                state = State.Move;
            }
            else
            {
                state = State.Chill;
            }
        }
        else { state = state; }

        switch (state)
        {
            case State.Move:
                Moving();
                break;
            case State.Chill:
                Chilling();
                break;
            case State.Eat:
                Eating(foodValue);
                break;
            case State.Sleep:
                StartCoroutine(Sleeping());
                break;
        }
    }
        
    public void Moving()
    {
        speed = -1 * speed;
        isMoving = true;
        Invoke("ChangeBehaviour", 5f);
    }
    public void Chilling()
    {
        isMoving = false;
        Invoke("ChangeBehaviour", 5f);
    }
    public IEnumerator Sleeping()
    {
        tiredness = 100f;
        Debug.Log("I'm sleeping");
        isMoving = false;
        yield return new WaitForSeconds(7f);
        isSleeping = false;
        ChangeBehaviour();
    }
    public int Eating(int foodValue)
    {
        isMoving = false;
        isEating = false;
        eatingSatisfaction += foodValue;
        if (eatingSatisfaction > 100f)
        {
            eatingSatisfaction = 100f;
        }
        state = State.Move;
        Invoke("ChangeBehaviour", 5f);
        return foodValue;
        

    }

    //public void OnTriggerEnter2D(Collider2D collision)
    //{
    //    nameText.text = name;
    //    ageText.text = "" + age;
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        inRange = true;
    //        informationsPanel.SetActive(true);
    //    }
    //}

    //public void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        inRange = false;
    //        informationsPanel.SetActive(false);
    //    }
    //}
}
