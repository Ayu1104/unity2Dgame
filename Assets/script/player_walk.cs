using UnityEngine;
using System.Collections;

public class player_walk : MonoBehaviour {
	protected Animator animator;
	private float directionX = 0;
	private bool walking = false; //歩いているかどうか　初期は止まっているのでfalse

	void Start (){
		animator = GetComponent<Animator> ();
		//animator
	}

	// Update is called once per frame
	void Update ()
	{
		//if (animator) {
						//左右キーの入力
						float h = Input.GetAxisRaw ("Horizontal");
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

						//animatorの値に適用
						animator.SetFloat ("DirectionX", directionX);
						//animator.SetFloat ("DirectionY", directionX);
						//animator.SetFloat ("DirectionY", directionY);
						animator.SetBool ("Walking", walking);

		Debug.Log (directionX);
				//		}
	}
}
