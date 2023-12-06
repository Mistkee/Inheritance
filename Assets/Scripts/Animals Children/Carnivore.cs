using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carnivore : Animals
{
    
    protected void Start()
    {
        base.Start();
        food = Food.Meats;
    }

    protected void Update()
    {
        base.Update();
        
    }

    //public void OnTriggerEnter2D(Collider2D collision)
    //{
    //    base.OnTriggerEnter2D(collision);
    //}
    //public void OnTriggerExit2D(Collider2D collision)
    //{
    //    base.OnTriggerExit2D(collision);
    //}
}

