using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ChangeHealth(int amount, int currentHP, int maxHP)
    {
        currentHP = Mathf.Clamp(currentHP + amount, 0, maxHP);
    }
}
