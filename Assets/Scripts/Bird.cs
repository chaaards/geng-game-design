using System;
using UnityEngine;

namespace GenerationGirl
{
	public class Bird : MonoBehaviour
	{
		private bool isDead;
		private Animator anim;
		private Rigidbody2D rb2d;

		public float flapForce;

		private void Awake()
		{
			isDead = false;
			anim = GetComponent<Animator>();
			rb2d = GetComponent<Rigidbody2D>();
		}

		private void Update()
		{
			if (Input.GetMouseButtonDown(0))
			{
				Flap();
			}
		}

		private void Flap()
		{
			if (isDead)
				return;

			anim.SetTrigger("Flap");
			rb2d.velocity = Vector2.zero;
			rb2d.AddForce(new Vector2(0, flapForce));
		}

		private void Die()
		{
			anim.SetTrigger("Die");
			isDead = true;
			rb2d.velocity = Vector2.zero;
			GameManager.instance.MarkAsGameOver();
		}

		private void OnCollisionEnter2D(Collision2D collision)
		{
			Die();
		}
	}
}
