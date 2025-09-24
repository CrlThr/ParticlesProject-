using UnityEngine;

public class VisualModule : ParticleModule
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Init(Particle particle)//, Color color)
    {
        base.Init(particle);

        _particle.GetComponent<MeshRenderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
    }

    // Update is called once per frame
    public override void Update(float deltaTime)
    {

    }
}
