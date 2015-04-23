using UnityEngine;
using System.Collections;

public class player_walk : MonoBehaviour {
	protected Animator animator;
	private float directionX = 0;
	private bool walking = false; //歩いているかどうか　初期は止まっているのでfalse
	public bool jumping = false; //ジャンプ
	public float jumppower = 500;
	//public Vector3 vec3;
	//public float coefficient;   // 空気抵抗係数

	void Start (){
		animator = GetComponent<Animator> ();
		//animator
	}

	// Update is called once per frame
	void Update ()
	{
		//rigidbody.AddForce(-coefficient * rigidbody.velocity);
		if (animator) {
						//左右キーの入力
						float h = Input.GetAxisRaw ("Horizontal"); //キーの入力を取得
						walking = true; //歩いているとき

						if (h > 0) { //右が入力されているとき
								directionX = 1;
						} else if (h < 0) { //左が入力されているとき
								directionX = -1;
						} else { //キー入力が無いとき　h==0のとき
								walking = false;
						}

						if (walking) { //walkingがtureのとき＝歩いているとき
								transform.Translate (new Vector2 (directionX,0) * Time.deltaTime * 2.0f);
						}
						if(!jumping){
							if (Input.GetKeyDown (KeyCode.Space)) {
								jumping = true;
								rigidbody.AddForce(
								Vector3.up*jumppower,
								ForceMode.Force);
						
									}
						}

						//animatorの値に適用
						animator.SetFloat ("DirectionX", directionX);
						Debug.Log (directionX);
						//animator.SetFloat ("DirectionY", directionX);
						//animator.SetFloat ("DirectionY", directionY);
						animator.SetBool ("Walking", walking);
						animator.SetBool ("Jumping", jumping);

						}


	}
	
	void OnCollisionEnter(Collision col){
		jumping = false;
	}

}
