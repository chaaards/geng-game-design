using UnityEngine;

namespace GenerationGirl
{
	public class RepeatingBackground : MonoBehaviour
	{
		public float groundHorizontalLength;

		private void Update()
		{
			if (transform.position.x < -groundHorizontalLength)
			{
				RepositionBackground();
			}
		}

		private void RepositionBackground()
		{
			Vector2 groundOffSet = new Vector2(groundHorizontalLength * 2f, 0);

			transform.position = (Vector2)transform.position + groundOffSet;
		}
	}
}