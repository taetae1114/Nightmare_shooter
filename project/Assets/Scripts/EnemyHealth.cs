using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {
    public float hp = 100;
    private EnemyMove move;
    private Animator anim;
    private NavMeshAgent agent;
    private CapsuleCollider capsuleCollider;
    private ParticleSystem particleSystem;
    public AudioClip dealthClip;
    private EnemyAttack enemyAttack;
    
    
	// Use this for initialization

    void Awake()
    {
        anim = this.GetComponent<Animator>();
        agent = this.GetComponent<NavMeshAgent>();
        move = this.GetComponent<EnemyMove>();
        capsuleCollider = this.GetComponent<CapsuleCollider>();
        particleSystem = this.GetComponentInChildren<ParticleSystem>();
        enemyAttack = this.GetComponentInChildren<EnemyAttack>();
    }
	public void TakeDamage(float damage,Vector3 hitPoint){
        if(this.hp<=0) return ;
        GetComponent<AudioSource>().Play();
        particleSystem.transform.position = hitPoint;
        particleSystem.Play();
        this.hp-=damage;
        if(this.hp<=0){
            Dead();
        }
    }

    void Update()
    {
        if (this.hp <= 0)
        {
            transform.Translate(Vector3.down * Time.deltaTime * 0.5f);
           if (transform.position.y <= -10)
                Destroy(this.gameObject);
        }
    }

    //用这个方法处理敌人死后的后事
	void Dead(){
        anim.SetBool("Dead", true);
        agent.enabled = false;
        move.enabled = false;
        capsuleCollider.enabled = false;
        AudioSource.PlayClipAtPoint(dealthClip, transform.position, 1.5f);
        enemyAttack.enabled = false;

        
        
    }
	
}
