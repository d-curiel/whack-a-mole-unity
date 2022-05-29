using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleSpotController : MonoBehaviour
{
    GameObject mole;
    // Start is called before the first frame update
    void Start()
    {
        mole = null;    
    }

    public void ShowMole(GameObject mole){
        this.mole = mole;
        mole.transform.position = this.transform.position;
        mole.SetActive(true);
    }

    public void HideMole(){
        this.mole = null;
    }

    public bool IsMoleShowing(){
        return mole != null;
    }

    public GameObject GetMole(){
        return mole;
    }
}
