using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ShowQuest : MonoBehaviour
{
    public GameObject questUI;
    public GameObject questUIBackground;
    private int collision = 0;
   // public AudioClip sound;
    public AudioSource audio;
    public static int currentScore;
    public GameObject tire1;
    public GameObject tire2;
    public GameObject tire3;
    public GameObject tire4;
    public GameObject tower;
    public GameObject car;
    public GameObject trashbags;
    public GameObject garbage_man;
    public GameObject mechanic;
    private bool isTriggerExit;
    public GameObject arrowObject;
    private bool isAudioPlayed=false;
    public GameObject levelEnd;


    

    void Start()
    {
        questUI.GetComponent<TMP_Text>().text = "find the missing tires";
        //audio = GetComponent<AudioSource>();
        questUI.SetActive(false);
        
        Arrow_waypoints.target = car.transform;

    }

    void OnTriggerEnter(Collider other)
    {
        questUI.SetActive(true);
        questUIBackground.SetActive(true);
       
        {  if(!isAudioPlayed)   
            audio.Play();
            isAudioPlayed = true;
        }
        

    }
    void OnTriggerExit(Collider other)
    {
        //if(other.gameObject.tag =="Player" )
        {
            
            if(!isTriggerExit)
            
            GlobalScore.currentScore++;
            isTriggerExit = true;
        }
     
    }

    private void Update()
    {
        
        if (GlobalScore.currentScore == 1)
        { questUI.GetComponent<TMP_Text>().text = " ask the citizen if he saw anything";
            Arrow_waypoints.target = tower.transform; }
        if (GlobalScore.currentScore == 2)
        { questUI.GetComponent<TMP_Text>().text = " you have to finish 3 quest to reveal your tires "; }
        if (GlobalScore.currentScore == 3)
        { questUI.GetComponent<TMP_Text>().text = " clear the trashbags in parks ";
            arrowObject.SetActive(false);
        }
        if (GlobalScore.currentScore == 9)
        { questUI.GetComponent<TMP_Text>().text = " bring all the trash to the garbage man ";
            Arrow_waypoints.target = garbage_man.transform;
            arrowObject.SetActive(true);
        }
        if (GlobalScore.currentScore == 10)
        { questUI.GetComponent<TMP_Text>().text = " talk to the garbage man ";
            
        }
        if (GlobalScore.currentScore == 11)
        {
            tire1.SetActive(true);
            tire2.SetActive(true);
            tire3.SetActive(true);
            tire4.SetActive(true);
            questUI.GetComponent<TMP_Text>().text = "find your tires on top of the subway entrances ";
            arrowObject.SetActive(false);
        }

        if (GlobalScore.currentScore == 15)
        { questUI.GetComponent<TMP_Text>().text = " find a mechanic";
            Arrow_waypoints.target = mechanic.transform;
            arrowObject.SetActive(true);
        }
        if (GlobalScore.currentScore == 16)
        { questUI.GetComponent<TMP_Text>().text = " talk to the mechanic"; }
        if (GlobalScore.currentScore == 17)
        {
            //teleporter.SetActive(true);
            questUI.GetComponent<TMP_Text>().text = "drive your car to the ferry";
            Arrow_waypoints.target = car.transform;
            levelEnd.SetActive(true);
        }


    }




}
