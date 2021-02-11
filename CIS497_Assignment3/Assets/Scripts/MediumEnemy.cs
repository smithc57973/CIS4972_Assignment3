using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumEnemy : Enemy, IObserver
{
    void Start()
    {
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        pc.RegisterObserver(this);
        chance = 70;
    }

    override public void UpdateData(Color c)
    {
        int r = Random.Range(0, 100);
        if (r < chance)
        {
            currentColor = c;
            this.GetComponent<MeshRenderer>().material.color = currentColor;
        }
        else
        {
            currentColor = RandomColor();
            this.GetComponent<MeshRenderer>().material.color = currentColor;
        }

        pc.canChangeColor = true;
        if (currentColor != c)
        {
            Debug.Log("Wrong color");
            pc.RemoveObserver(this);
            //Destroy(this.gameObject);//For some reason the enemies won't get notified
            this.GetComponent<MeshRenderer>().material.color = Color.black;
        }
    }
}
