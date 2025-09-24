using UnityEngine;


public abstract class ParticleModule
{
    protected Particle _particle;
  
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public virtual void Init(Particle particle)
    {
        _particle = particle;
    }

   // Update is called once per frame
    public virtual void Update(float deltaTime)
    {
        
    }
}
