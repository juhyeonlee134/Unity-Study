using Unity.VisualScripting;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private const float LifeTime = 10f;

    public ParticleSystem _explosionParticle;
    public AudioSource _explosionAudio;
    public LayerMask _whatIsProb;

    public const float MaxDamage = 100f;
    public const float ExplosionForce = 1000f;
    public const float ExplosionRadius = 20f;


    private void Start()
    {
        Destroy(gameObject, LifeTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, ExplosionRadius, _whatIsProb);

        foreach (Collider collider in colliders)
        {
            Rigidbody targetRigidbody = collider.GetComponent<Rigidbody>();
            Prob targetProb = collider.GetComponent<Prob>();
            float damage = CalculateDamage(collider.transform.position);

            targetRigidbody.AddExplosionForce(ExplosionForce, transform.position, ExplosionRadius);
            targetProb.TakeDamage(damage);
        }

        _explosionParticle.transform.parent = null;
        _explosionParticle.Play();
        _explosionAudio.Play();

        Destroy(_explosionParticle.gameObject, _explosionParticle.duration);
        Destroy(gameObject);
    }

    private float CalculateDamage(Vector3 targetPosition)
    {
        Vector3 explosionToTarget = targetPosition - transform.position;
        float distance = explosionToTarget.magnitude; // 타깃과 폭발 위치의 거리
        float edgeToCenterDistance = ExplosionRadius - distance; // 폭발 반경으로 부터 얼마나 안쪽에 있는 가
        float damage = MaxDamage * edgeToCenterDistance / ExplosionRadius; // 그 비율에 맞춰서 데미지가 작용

        return Mathf.Max(0, damage); // damage가 음수가 되는 경우, 0으로 맞추어 준다.
    }
}
