using UnityEngine;
using System.Collections;

public class player_walk : MonoBehaviour {
    //我们团队没有人会画画。你可以联系我q631126452@qq.com
	protected Animator anim;
	public float  horizontal; //歩いているかどうか　初期は止まっているのでfalse
    public bool isRightArrow = false, isLeftArrow = false;//记录按下的水平轴
    public bool isRightSide = true;//是否面相右边
    public bool isGround = false;//是否在地面
    private float xWalkMoveSpeed = 0.05f;//X轴移动速度
    private Transform groundCheck;//检测是否在地面辅助物体
    public float xJumpForce = 100f,yJumpForce=300f;//跳跃力
    Rigidbody2D rigid;//玩家的2D刚体
    void Start (){
		anim = GetComponent<Animator> ();
        groundCheck = transform.Find("groundCheck");
        rigid = GetComponent<Rigidbody2D>();
        //animator
    }

	// Update is called once per frame
	void Update ()
	{
        isRightArrow = isLeftArrow = false;
		horizontal = Input.GetAxisRaw ("Horizontal");
        if (horizontal > 0f) isRightArrow = true;
        else if (horizontal < 0f) isLeftArrow = true;
        anim.SetBool("walk", isRightArrow || isLeftArrow);
        if(Input.GetKeyDown(KeyCode.Space))//如果按下Space
        {
         if(isGround)//如果是在地面
            {
                rigid.AddForce(new Vector2(0f, yJumpForce));
                if(isRightArrow)
                {
                    rigid.AddForce(new Vector2(xJumpForce, 0f));
                }
                else if(isLeftArrow)
                {
                    rigid.AddForce(new Vector2(-xJumpForce, 0f));
                }
            }   
        }
	}
    void FixedUpdate()
    {
        CheckGround();//检查地面
        CheckSide();//检查面相
        CheckWalk();//检查行走
    }
    void CheckGround()
    {
        if(groundCheck!=null)
        {
            isGround=Physics2D.Linecast(groundCheck.position, transform.position, 1 << LayerMask.NameToLayer("ground"));
        }
        else
        {
            Debug.Log("检测地面辅助对象为空！");
        }
    }
    void CheckWalk()
    {
        if(isRightArrow)
        {
            Vector3 v3 = transform.position;
            transform.position = new Vector3(v3.x + xWalkMoveSpeed,v3.y, v3.z);
        } else if(isLeftArrow)
        {
            Vector3 v3 = transform.position;
            transform.position = new Vector3(v3.x - xWalkMoveSpeed,v3.y, v3.z);
        }
    }
    void CheckSide()
    {
        if(isRightArrow && !isRightSide)
        {
            Vector3 v3 = transform.localScale;
            transform.localScale = new Vector3(v3.x * -1, v3.y, v3.z);
            isRightSide = true;
        }
        else if(isLeftArrow && isRightSide)
        {
            Vector3 v3 = transform.localScale;
            transform.localScale = new Vector3(v3.x * -1, v3.y, v3.z);
            isRightSide = false;
        }
    }
}
