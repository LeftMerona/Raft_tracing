using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    [SerializeField] private Materials item;

    private void Start()
    {
        test1();
    }


    public void test1()
    {
        int id = item.id;
        Debug.Log(id);
    }
}
