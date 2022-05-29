using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public static GameManager instance;
    private int score;
    private float timeRemaining;
    private float timeLastSpawn = 0f;
    private float timeRemainingMax = 60f;
    private float maxTimeBetweenSpawns = 1f;
    private float minTimeBetweenSpawns = 0.5f;
    private GameObject [] moleSpots = new GameObject[24];
public Texture2D crosshair; 

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start(){
        
     Vector2 cursorOffset = new Vector2(crosshair.width/2, crosshair.height/2);
      Cursor.SetCursor(crosshair, cursorOffset, CursorMode.Auto);
      
        moleSpots = GameObject.FindGameObjectsWithTag("MoleSpot");
        timeRemaining = timeRemainingMax;
        score = 0;
        MainSceneUIManager.instance.setTimeRemaining(timeRemaining.ToString("0"));
        MainSceneUIManager.instance.setScore(this.score.ToString());
    }

    private void FixedUpdate() {
        timeRemaining -= Time.deltaTime;
        timeLastSpawn += Time.deltaTime;
        if (timeRemaining <= 0)
        {
            Debug.Log("Game Over");
            Time.timeScale = 0;
        }else{
            MainSceneUIManager.instance.setTimeRemaining(timeRemaining.ToString("0"));
            if (timeLastSpawn >= Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns))
            {
                timeLastSpawn = 0;
                GameObject mole = MolePool.instance.GetMole();
                if(mole != null){
                    GameObject moleSpot = FindFreeMoleSpot();
                    if(moleSpot != null){
                        moleSpot.GetComponent<MoleSpotController>().ShowMole(mole);
                    }
                }
            }
        }
    }

    private GameObject FindFreeMoleSpot(){
        GameObject moleSpot = moleSpots[Random.Range(0, moleSpots.Length)];
        if(!moleSpot.GetComponent<MoleSpotController>().IsMoleShowing()){
            return moleSpot;
        }
        return null;
    }

    public void ModifyScore(int score){
        this.score += score;
        MainSceneUIManager.instance.setScore(this.score.ToString());
    }

    public void CleanHiddenMole(GameObject mole){
        for(int i = 0; i < moleSpots.Length; i++){
            if(mole == moleSpots[i].GetComponent<MoleSpotController>().GetMole()){
                moleSpots[i].GetComponent<MoleSpotController>().HideMole();
            }
        }
    }

}
