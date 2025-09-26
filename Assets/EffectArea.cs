using UnityEngine;

public class EffectArea : MonoBehaviour
{
    // effect settings 
    [SerializeField] private float radius = 4f;
    [SerializeField] private EffectType effectType;
    [SerializeField] private float repulsionforce = 20f;
    [SerializeField] private float attractionforce = 10f;


    public enum EffectType
    {
        Repulsion,
        Attraction, 
        Destruction
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, radius);

        
    }

    public void ApplyEffect(Particle particle)
    {
        if (particle == null) return;
        Vector3 toParticle = particle.transform.position - transform.position;
        float distance = toParticle.magnitude;

        if (distance > radius)
            return;

        switch (effectType)
        {
            case EffectType.Repulsion:
                particle.ApplyForce(toParticle.normalized * repulsionforce);
                break;
            case EffectType.Attraction:
                particle.ApplyForce(-toParticle.normalized * attractionforce);
                break;
            case EffectType.Destruction:
                GameObject.Destroy(particle.gameObject);
                break;

        }
    }

        void Update()
        {

        }
}

