using UnityEngine;


public class MovementModule : ParticleModule
{

    private Vector3 direction; 
    private float speed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Init( Particle particle)// float speed)
    {
        base.Init(particle);

        direction = Random.onUnitSphere;
        speed = Random.Range(1f, 10f);
    }

    // Update is called once per frame
    public override void Update(float deltaTime)
    {
       base.Update(deltaTime);
       _particle.transform.position += direction * speed * deltaTime;
    }
}
