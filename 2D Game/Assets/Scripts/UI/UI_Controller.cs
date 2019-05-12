using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Controller : MonoBehaviour
{
    public Image HP_Bar;
    public Image MP_Bar;
    public Image[] HPBlock;
    public int PlayerHP;
    public int PlayerMaxHP;
    public float PlayerMP;
    public int PlayerMaxMP;

    public GameObject Player;
    public PlayerController PlayerControl;

    public Sprite FilledHeart;
    public Sprite EmptiedHeart;

    public GameObject WinStage;
    public GameObject LoseStage;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");

        if (Player)
        {
            PlayerControl = Player.GetComponent<PlayerController>();
            PlayerMaxHP = PlayerControl.HP;
            PlayerHP = PlayerMaxHP;
        

            PlayerMaxMP = PlayerControl.MaxMP;
            PlayerMP = PlayerMaxMP;

            //PlayerMaxHP = Player.GetComponent<PlayerController>().HP;
            //PlayerHP = PlayerMaxHP;
        }
    }

    // Update is called once per frame
    void Update() {

       // WinStage.SetActive(PlayerControl.IsWon);
        //LoseStage.SetActive(!PlayerControl.isAlive);

    

        PlayerHP = PlayerControl.HP;
        PlayerMP = PlayerControl.MP;

        //HP Bar
        HP_Bar.fillAmount = (float)PlayerHP / PlayerMaxHP;

        //MP Bar
        MP_Bar.fillAmount = (float)PlayerMP / PlayerMaxMP;

        //HP Block
        //for (int i = 0; i < HPBlock.Length; i++)
        //{
        //    if (i < PlayerHP)
        //    {
        //        //For Disappearing Heart
        //        HPBlock[i].enabled = true;

        //        //Change Heart Sprite
        //        HPBlock[i].sprite = FilledHeart;
        //    }
        //    else
        //    {
        //        //For Disappearing Heart
        //        HPBlock[i].enabled = false;

        //        //Change Heart Sprite
        //        HPBlock[i].sprite = EmptiedHeart;
        //    }
        //}
    }
}
