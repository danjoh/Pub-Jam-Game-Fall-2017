using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicReciver : MonoBehaviour {
    public GameObject source;
    public GameObject mds;
    MysticalDoorScript mdsCtrl;
    public string type;

    private void Start()
    {
        mdsCtrl = mds.GetComponent<MysticalDoorScript>();
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        Magic mag = other.GetComponent<Magic>();
        
        if (mag != null && mag.magicType == type) {
            mdsCtrl.count++;
            Debug.Log(mdsCtrl.count);
            source.SetActive(true);
            DestroyObject(this);
        }
    }
}
