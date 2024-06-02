using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public float speed = 5f;

    void Start()
    {
       
        GameObject playerObject = GameObject.Find("Корабль");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        else
        {
            Debug.LogWarning("Игровой объект 'корабль' не найден!");
        }
    }


    void Update()
    {
        if (player == null)
            return;

      
        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 2f);

  
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}
