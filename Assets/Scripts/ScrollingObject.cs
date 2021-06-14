using UnityEngine;

namespace GenerationGirl
{
	public class ScrollingObject : MonoBehaviour
	{
		private Rigidbody2D rb2d;

		public float scrollSpeed;

		void Start()
		{
			rb2d = GetComponent<Rigidbody2D>();

			rb2d.velocity = new Vector2(scrollSpeed, 0);
		}

		void Update()
		{
			if (GameManager.instance.isGameOver == true)
			{
				rb2d.velocity = Vector2.zero;
			}
		}
	}
}