using UnityEngine;

public class BatW6 : MonoBehaviour
{
    public Transform cat;       // 猫（玩家）
    public float speed = 3f;    // 移动速度
    private bool isChasing = false;

    void Update()
    {
        if (isChasing && cat != null)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                cat.position,
                speed * Time.deltaTime
            );
        }
    }

    public void StartChasing() => isChasing = true;
    public void StopChasing() => isChasing = false;
}
