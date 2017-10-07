using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic : MonoBehaviour {

    // Use this for initialization

    public string magicType;

    GameObject mh;

    PlayerController pc;

    string opposite () {
        if (magicType == "fire") {
            return "water";
        } else if (magicType == "water") {
            return "fire";
        } else if (magicType == "air") {
            return "earth";
        } else if (magicType == "earth") {
            return "air";
        } else if (magicType == "light") {
            return "dark";
        } else if (magicType == "dark") {
            return "light";
        } else if (magicType == "life") {
            return "death";
        } else if (magicType == "death") {
            return "life";
        }
        return "";
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (mh.GetComponent<Collider2D>().Equals(other)) {
            pc.currentMagic = opposite();
        }
    }

    private void OnTriggerExit2D()
    {
        pc.currentMagic = "";
    }


    void Start () {
        mh = GameObject.Find("MagicHand");
        pc = GameObject.Find("Player").GetComponent<PlayerController>();
    }
}
