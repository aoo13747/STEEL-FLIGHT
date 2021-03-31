using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public static Vector2 Position;

	public float startMoveSpeed = 5f;
	private float moveSpeed;
	public float moveSmooth = .3f;

	private Rigidbody2D rb;
	private Animator animator;

	Vector2 movement = Vector2.zero;
	Vector2 velocity = Vector2.zero;

	Vector2 mousePos = Vector2.zero;

	private string currentAnimation;

	const string PLAYER_IDLE = "Player_Idel_Animation";
	const string PLAYER_MOVEBACKWARD = "Player_MoveBackward_Animation";
	const string PLAYER_MOVEFORWARD = "Player_MoveForward_Animation";

	// Use this for initialization
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update() {
		movement.x = Input.GetAxisRaw("Horizontal");
		movement.y = Input.GetAxisRaw("Vertical");

		mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

	//transform.localScale = Vector3.one;
		moveSpeed = startMoveSpeed;
	}

	private void FixedUpdate()
	{
		Vector2 desiredVelocity = movement * moveSpeed;
		rb.velocity = Vector2.SmoothDamp(rb.velocity, desiredVelocity, ref velocity, moveSmooth);

		Vector2 lookDir = mousePos - rb.position;
		float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
		rb.rotation = angle;

		Position = rb.position;
		if (movement.x == 0 && movement.y == 0)
        {
			ChangeAnimationState(PLAYER_IDLE);
        }
		if(movement.x < 0 || movement.y > 0 )
        {
			ChangeAnimationState(PLAYER_MOVEFORWARD);
        }
		if (movement.x > 0 || movement.y < 0 )
		{
			ChangeAnimationState(PLAYER_MOVEBACKWARD);
		}
	}
	void ChangeAnimationState(string newAnimation)
	{
		if (currentAnimation == newAnimation) return;

		animator.Play(newAnimation);
		currentAnimation = newAnimation;
	}


}
