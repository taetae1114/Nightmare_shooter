using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Playershoot : MonoBehaviour {
    public float shootRate = 2;
    private float timer = 0;
    private ParticleSystem particlesystem;
    private LineRenderer lineRenderer;
    private int score = 0;
    public Text text;
    public float attack = 30;
	// Use this for initialization
	void Start () {
        particlesystem = this.GetComponentInChildren<ParticleSystem>();
        lineRenderer = this.GetComponent<Renderer>() as LineRenderer;
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer > 1 / shootRate)
        {
            timer-= 1/shootRate;
            shoot();
        }
	
	}


    void shoot()
    {
        GetComponent<Light>().enabled = true;
        particlesystem.Play();
        this.lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, transform.position);
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
        {
            lineRenderer.SetPosition(1, hitInfo.point);
            //判断当前的射击有没有碰撞到敌人
            if (hitInfo.collider.tag == Tags.enemy)
            {
                hitInfo.collider.GetComponent<EnemyHealth>().TakeDamage(attack,hitInfo.point);
                if (hitInfo.collider.GetComponent<EnemyHealth>().hp < 0)
                {
                    score++;
                    text.text = "score:"+score.ToString();
                }
            }

        }
        else
        {
            lineRenderer.SetPosition(1, transform.position + transform.forward * 100);
        }
        GetComponent<AudioSource>().Play();

        Invoke("ClearEffect",0.05f);
    }

    void ClearEffect()
    {
        GetComponent<Light>().enabled = false;
        lineRenderer.enabled = false;
    }


}
