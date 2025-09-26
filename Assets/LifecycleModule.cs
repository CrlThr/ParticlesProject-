using UnityEngine;

public class LifecycleModule : ParticleModule
{
    private float time;

    public override void Init(Particle particle)
    {
        base.Init(particle);
    }

    // Update is called once per frame
    public override void Update(float deltaTime)
    {

        time += Time.deltaTime;
        if (time >= 5)//timeToLive
        {
            GameObject.Destroy(_particle.gameObject);
        }
    }
}
