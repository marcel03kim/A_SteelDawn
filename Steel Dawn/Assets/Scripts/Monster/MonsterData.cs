using UnityEngine;

[CreateAssetMenu(fileName = "New Monster Data", menuName = "ScriptableObjects/MonsterData")]
public class MonsterData : ScriptableObject
{
    public enum MonsterState
    {
        Move,
        Attack,
        Die
    }

    public MonsterState initialState; // 초기 상태를 설정할 수 있는 변수
    public float hp;       // 몬스터 체력
    public float speed;    // 몬스터 속도
    public float power;    // 몬스터 공격력
    public float attackInterval; // 공격 속도
    public GameObject expPrefab; // 경험치 프리팹
    public GameObject goldPrefab; // 골드 프리팹
}
