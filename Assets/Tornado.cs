using UnityEngine;

public class TornadoMovementModule : ParticleModule
{
    private float angularSpeed;     
    private float initialRadius;    
    private float radiusGrowthRate; 
    private float verticalSpeedFactor; 
    private float angle;            
    private Transform center;       
    private float time;             
    private float verticalOffset;  

    public override void Init(Particle particle)
    {
        base.Init(particle);

        center = _particle.transform.parent;

        initialRadius = Random.Range(0.5f, 2f);
        radiusGrowthRate = Random.Range(0.5f, 2f);      
        angularSpeed = Random.Range(90f, 360f);       
        verticalSpeedFactor = Random.Range(-1f, 1f);     
        verticalOffset = Random.Range(-0.5f, 0.5f);      
        angle = Random.Range(0f, 360f);                   
        time = 0f;
    }

    public override void Update(float deltaTime)
    {
        time += deltaTime;


        angle += angularSpeed * deltaTime;
        if (angle > 360f) angle -= 360f;


        float radius = initialRadius + radiusGrowthRate * time;

        float height = radius * verticalSpeedFactor + verticalOffset;

        float radians = angle * Mathf.Deg2Rad;

        Vector3 offset = new Vector3(
            Mathf.Cos(radians) * radius,
            height,
            Mathf.Sin(radians) * radius
        );

        _particle.transform.position = center.position + offset;
    }
}
