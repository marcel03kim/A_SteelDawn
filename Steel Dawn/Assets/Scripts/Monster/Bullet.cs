using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f; // 총알 속도
    public float power; // 총알의 공격력
    private Vector2 direction; // 총알의 방향

    private void Update()
    {
        // 총알이 발사된 방향으로 이동
        transform.Translate(direction * speed * Time.deltaTime);
        Destroy(gameObject, 10f); // 10초 후에 총알 파괴
    }

    // 방향 설정 메서드
    public void SetDirection(Vector2 newDirection)
    {
        direction = newDirection; 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // 플레이어에게 데미지를 주는 로직 추가
            Player player = collision.GetComponent<Player>();
            if (player != null)
            {
                player.currentHp -= power; // 플레이어 체력 감소
            }

            // 총알이 충돌한 후 파괴
            Destroy(gameObject);
        }
    }
}
