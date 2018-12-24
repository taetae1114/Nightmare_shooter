using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {
    public float speed = 1;
    public new Rigidbody rigidbody;
    private Animator anim;
    private int groundLayerIndex = -1;
	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody>();
        anim = this.GetComponent<Animator>();
        groundLayerIndex = LayerMask.GetMask("Ground");
    }
	
	// Update is called once per frame


    void OnTriggerEnter(Collider collider){
    
        if (collider.tag == "door")
        {
            rigidbody.MovePosition(new Vector3(0, 0, 150));
        }
    }

	void Update () {
        //控制移动
       float h= Input.GetAxis("Horizontal");
       float v = Input.GetAxis("Vertical");

      // transform.Translate(new Vector3(h, 0, v)*speed*Time.deltaTime);
       rigidbody.MovePosition(transform.position + new Vector3(h, 0, v) * speed * Time.deltaTime);
        //动画
       if (h != 0 || v != 0)
       {
           anim.SetBool("Move", true);
       }
       else
       {
           anim.SetBool("Move", false);
       }
        //转向
       Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
       RaycastHit hitInfo;
       if (Physics.Raycast(ray, out hitInfo, 200, groundLayerIndex))
       {
           Vector3 target = hitInfo.point;
           target.y = transform.position.y;
           transform.LookAt(target);
       }


        

	}
}
