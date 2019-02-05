using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

    private GameObject target;

    public GameObject No1;
    public GameObject No2;
    public GameObject No3;
    public GameObject No4;
    public GameObject No5;
    public GameObject No6;
    public GameObject No7;

    void Start ()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update () {
        if (target.GetComponent<playerScript>().Items[0]==1)
        {
            No1.GetComponent<Image>().color = Color.white;
        }
        if (target.GetComponent<playerScript>().Items[1] == 1)
        {
            No2.GetComponent<Image>().color = Color.white;
        }
        if (target.GetComponent<playerScript>().Items[2] == 1)
        {
            No3.GetComponent<Image>().color = Color.white;
        }
        if (target.GetComponent<playerScript>().Items[3] == 1)
        {
            No4.GetComponent<Image>().color = Color.white;
        }
        if (target.GetComponent<playerScript>().Items[4] == 1)
        {
            No5.GetComponent<Image>().color = Color.white;
        }
        if (target.GetComponent<playerScript>().Items[5] == 1)
        {
            No6.SetActive(false);
            No7.SetActive(true);
        }
    }
}
