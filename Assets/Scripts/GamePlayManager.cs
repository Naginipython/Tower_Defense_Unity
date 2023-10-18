using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    [SerializeField] Transform[] pos;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float speed = 2;
    float timeBeforeFrame = 0;
    int posNum = 0;
    bool isGameRunning = false;
    GameObject enemy;

    private void Start() {
        //removes point for debugging
        foreach (Transform p in pos) {
            p.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    void Update() {
        if (isGameRunning) {
            //next pos
            if (timeBeforeFrame == 1)
            {
                posNum++;
                timeBeforeFrame = 0;
                if (posNum == pos.Length - 1)
                {
                    Destroy(enemy);
                }
            }

            //move to pos
            float timePassed = Time.deltaTime * speed;
            timeBeforeFrame += timePassed;
            timeBeforeFrame = Mathf.Min(timeBeforeFrame, 1);
            if (enemy != null && posNum != pos.Length - 1)
            {
                enemy.transform.position = Vector2.Lerp(pos[posNum].position, pos[posNum + 1].position, timeBeforeFrame);
            }
        }
    }

    public void StartLevel() {
        isGameRunning = true;
        enemy = Instantiate(enemyPrefab, (Vector2)pos[0].position, Quaternion.identity);
    }
}
