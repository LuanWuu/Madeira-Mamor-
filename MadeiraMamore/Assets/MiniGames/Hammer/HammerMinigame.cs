using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HammerMinigame : MonoBehaviour
{
    [SerializeField] private ScrpitTablePlayer playerValues;
    [SerializeField] private DatabaseCutscene database;
    [SerializeField] private RaffleQuest raffeQuestScript;
    [SerializeField] private AudioSource sound;
    [SerializeField] private Point pointScript;
    [SerializeField] private Image woodImage;
    [SerializeField] private Sprite[] woodSprites;
    [SerializeField] private GameObject AxeUI;
    [SerializeField] private Animator AxeAnimator;
    [System.NonSerialized]public bool canCut;
    
    private int hit;
    private int breakTree = 0;
    private bool hitTarget;
    private bool canHit = false;
    private GameObject tree;
    private Sprite saveSrpite;

    public void StartMinigame(){
        if(transform.childCount != 0) {
            for(int i = 0; i < transform.childCount; i++) {
                GameObject EnabledTree = transform.GetChild(i).gameObject;
                EnabledTree.SetActive(true);
                EnabledTree.tag = "Tree";
            }
        }
        hit = 0;
        woodImage.sprite = saveSrpite;
        canHit = true;
    }
    public void EnableAxeUI(GameObject target){
        target.tag = "Untagged";
        tree = target;
        playerValues.canMovi = false;
        AxeUI.SetActive(true);
        pointScript.RandomDirection();
    }
    private void Update() {
        if (Input.GetButtonDown("Interactions") && canHit){ 
            if (AxeAnimator != null && AxeAnimator.gameObject.activeSelf){
                AxeAnimator.SetBool("AxeCut", true);
                CheckHit();
            }
        }
    }
    void CheckHit(){
        if(canCut == true){
            hitTarget = true;
        }
        pointScript.ResetPointer();
    }
    public void ChangeScript(){
        if(hitTarget == true){
            woodImage.sprite = woodSprites[hit];
            sound.clip = database.hitWood;
            sound.Play();
            if(hit < 3) {
                hit++;
            }
            if(hit == 3) {
                Invoke("EndGame", 0.5f);
            }
            hitTarget = false;
        }
    }
    void EndGame(){
        sound.clip = database.brokenWood;
        sound.Play();
        Destroy(tree, 0.5f);
        canHit = false;
        playerValues.canMovi = true;
        AxeUI.SetActive(false);
        breakTree++;
        if(transform.childCount != 0) {
            for(int i = 0; i < transform.childCount; i++) {
                GameObject DisabledTree = transform.GetChild(i).gameObject;
                DisabledTree.tag = "Untagged";
            }
        }
        raffeQuestScript.CompleteQuest();
    }
}
