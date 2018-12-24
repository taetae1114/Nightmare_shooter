﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Playerhealth : MonoBehaviour {
    public float hp = 100;
    public float smoothing = 5;
    private AudioSource audio;
    public AudioClip su;

    public Text tips;
    private Animator anim;
    private PlayerMove playerMove;
    private SkinnedMeshRenderer bodyRenderer;
    private Playershoot playerShoot;





    void Awake(){
        anim=this.GetComponent<Animator>();
        this.playerMove = this.GetComponent<PlayerMove>();
        this.bodyRenderer = transform.Find("Player").GetComponent<Renderer>() as SkinnedMeshRenderer;
        playerShoot = this.GetComponentInChildren<Playershoot>();
        audio = this.GetComponent<AudioSource>();
    }



    void Update(){
       /* if(Input.GetMouseButtonDown(0)){
            print("-30");
            TakeDamage(30);
        }*/

        bodyRenderer.material.color = Color.Lerp(bodyRenderer.material.color, Color.white, smoothing * Time.deltaTime);
    }



    public void TakeDamage(float damage)
    {
        if (hp <= 0) { return; }
        this.hp -= damage;
        bodyRenderer.material.color = Color.red;

        if (this.hp <= 0)
        {
            anim.SetBool("Dead", true);
            Dead();
        }
    }

    void Dead()
    {
        this.playerMove.enabled = false;
        this.playerShoot.enabled = false;
        tips.text = "GAME OVER!";
        audio.clip = su;
        audio.Play();
        
    }
}
