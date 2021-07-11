using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerController : MonoBehaviour{
    public Rigidbody2D player;
    public float speed;
    public float jumpForce;
    public LayerMask ground;
    public bool Jump = false;
    
    public Text coinNum;
    public GameObject keyShow;
    public Transform cellingCheck; 
    public int heart = 3;


    Animator animator;
    public Collider2D coll;
    public Collider2D Uncoll;
    bool checkJump = false;
    bool gotHurt = false;
    bool specialJumpStop = true;


    void Start(){
        animator = GetComponent<Animator>();
        coinNum.text = GameDataManager.coin.ToString();
    }

    void Update(){
        if(!gotHurt){
            animator.SetBool ("Jump", Jump && specialJumpStop);
            Movement();
        }
        heartLife.instance.heartCheck(heart);

        SwitchAnime();
        
    }
        
    void Movement(){
        float horizontalmove = Input.GetAxis("Horizontal");
        float facedside = Input.GetAxisRaw("Horizontal");
        

        if(horizontalmove != 0){
            player.velocity = new Vector2(horizontalmove*speed , player.velocity.y);//horizontalmove*speed*Time.deltaTime
            animator.SetFloat("Speed", 1);
        }
        else{
            animator.SetFloat("Speed", 0);
        }

        if(facedside != 0 ){
            transform.localScale =new Vector3(facedside, 1, 1);
        } 
        /////////////////crouch////////////////
        if(!(Physics2D.OverlapCircle(cellingCheck.position, 0.2f, ground))){
            if(Input.GetButton("crouch")){
                animator.SetBool("crouch", true);
                Uncoll.enabled = false;
            }
            else {  //else if(Input.GetButtonUp("crouch"))
                animator.SetBool("crouch", false);
                Uncoll.enabled = true;
            }
        }
        
        /////////////////Jump//////////////////
        if(Jump && player.velocity.y < 0 ){
            checkJump = true;
        }
        if( !coll.IsTouchingLayers(ground) && player.velocity.y < 0.1f){
            Jump = true;
        }

        if(Input.GetButtonDown("Jump") && coll.IsTouchingLayers(ground) || Input.GetButtonDown("Jump") && !specialJumpStop){
            Jump = true;
            player.AddForce(Vector2.up * jumpForce);
            SoundManager.instance.JumpAudio();
        }
        else if(Jump && coll.IsTouchingLayers(ground) && checkJump || Jump && checkJump && !specialJumpStop){
            Jump = false;
            checkJump = false;
        }

        if(coll.IsTouchingLayers(ground)){
            specialJumpStop = true;
        }
    }

    void SwitchAnime(){
        if(gotHurt){
            if(Mathf.Abs(player.velocity.x) < 0.1f){
                gotHurt = false;
                animator.SetBool ("hit", gotHurt);
            }
        }
    }

    //蒐集硬幣 OR 鑰匙 OR 掉出邊界 OR 旗子
    private void OnTriggerEnter2D ( Collider2D collision ){
        if( collision.tag == "collection"){
            SoundManager.instance.CoinAudio();
            Destroy(collision.gameObject);
            GameDataManager.coin+=1;
            //Debug.Log(GameDataManager.coin);
            coinNum.text = GameDataManager.coin.ToString();
        }
        
        //////////////////鑰匙/////////////////////////
        /*if( collision.tag == "key"){
            SoundManager.instance.KeyAudio();
            //playerController player = gameObject.GetComponent<playerController>();
            Destroy(collision.gameObject);
            keyShow.SetActive(true);
            animator.SetBool ("key", true);
        }*/

        if( collision.tag == "death"){
            heart = 0;
        }

        if( collision.tag == "flag"){
            Menu.instance.WinMenu();
        }

    }

    //敵人 OR 按鈕 OR 鎖
    private void OnCollisionEnter2D ( Collision2D collision ){
        ///////////////敵人/////////////////////
        if(collision.gameObject.tag == "enemy" && !gotHurt){
            AllEnemy enemy = collision.gameObject.GetComponent<AllEnemy>();
            if(checkJump){
                enemy.jumpOn();
                Jump = true;
                player.velocity = new Vector2(player.velocity.x, jumpForce*Time.deltaTime);
                //player.AddForce(Vector2.up * jumpForce);
            }
            else if(transform.position.x < collision.gameObject.transform.position.x ){
                SoundManager.instance.HurtAudio();
                player.velocity = new Vector2(-10, player.velocity.y );
                gotHurt = true;
                animator.SetBool ("hit", gotHurt);
                heart--;
            }
            else if(transform.position.x > collision.gameObject.transform.position.x ){
                SoundManager.instance.HurtAudio();
                player.velocity = new Vector2(+10, player.velocity.y );
                gotHurt = true;
                animator.SetBool ("hit", gotHurt);
                heart--;
            }
        }

        //////////////////按鈕///////////////////////
        if(collision.gameObject.tag == "button"){
            AllButton button = collision.gameObject.GetComponent<AllButton>();
            if(checkJump || Jump){
                button.clickButton();
                Jump = true;
                checkJump = true;
                specialJumpStop = false;
            }

        }

        //////////////////鎖//////////////////////
        /*if(collision.gameObject.tag == "lock"){
            if(animator.GetBool ("key")){
                SoundManager.instance.UnlockAudio();
                Destroy(collision.gameObject);
                keyShow.SetActive(false);
            }
            KeySound unlock = gameObject.GetComponent<KeySound>();
        }*/
        
    } 
}
