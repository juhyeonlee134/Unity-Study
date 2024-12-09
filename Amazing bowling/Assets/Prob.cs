using UnityEngine;

public class Prob : MonoBehaviour
{
    public const int Score = 5;
    public float _hp = 10f;
    public ParticleSystem _expolosionParticle;

    public void TakeDamage(float damage)
    {
        _hp -= damage;
        if (_hp <= 0)
        {
            ParticleSystem instance = Instantiate(_expolosionParticle, transform.position, transform.rotation);
            AudioSource explosionAudio = instance.GetComponent<AudioSource>();

            explosionAudio.Play();
            Destroy(instance, instance.duration);
            gameObject.SetActive(false);
        }
    }
}
