using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTrigger : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Coin")
        {
            //Debug.Log("Score++");
            GameGameManager.Instance.AddScore();
            Destroy(other.gameObject, 0.02f);
        }

        if (other.gameObject.tag == "Wall")
        {
            Debug.Log("Game Over ");
            Destroy(gameObject, 0.02f);
            GameGameManager.Instance.GameOver();
        }

    }
}
