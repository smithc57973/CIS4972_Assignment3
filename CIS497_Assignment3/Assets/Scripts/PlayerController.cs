using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, ISubject
{
    private Color currentColor;
    public List<IObserver> observers = new List<IObserver>();
    public bool canChangeColor;
    public GameManager gm;

    public void NotifyObservers()
    {
        foreach (IObserver observer in observers.ToArray())
        {
            observer.UpdateData(currentColor);
        }
    }

    public void RegisterObserver(IObserver observer)
    {
        observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        if (observers.Contains(observer))
        {
            observers.Remove(observer);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        canChangeColor = true;
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canChangeColor && gm.gameStarted && !gm.gameOver)
        {
            ChangeColor();
        }
    }

    public void ChangeColor()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && currentColor != Color.red)
        {
            currentColor = Color.red;
            this.GetComponent<MeshRenderer>().material.color = Color.red;
            canChangeColor = false;
            gm.numChanges--;
            NotifyObservers();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && currentColor != Color.green)
        {
            currentColor = Color.green;
            this.GetComponent<MeshRenderer>().material.color = Color.green;
            canChangeColor = false;
            gm.numChanges--;
            NotifyObservers();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && currentColor != Color.blue)
        {
            currentColor = Color.blue;
            this.GetComponent<MeshRenderer>().material.color = Color.blue;
            canChangeColor = false;
            gm.numChanges--;
            NotifyObservers();
        }
        
    }
}
