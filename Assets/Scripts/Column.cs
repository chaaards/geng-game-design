using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GenerationGirl
{
	public class Column : MonoBehaviour
	{
		private void OnTriggerEnter2D(Collider2D collision)
		{
			if (collision.CompareTag("Bird"))
			{
				GameManager.instance.UpdateScore();
			}
		}
	}
}
