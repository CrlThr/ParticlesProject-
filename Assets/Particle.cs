using System.Collections.Generic;
using UnityEngine;

public class Particle : Generator
{
    private float time;
    private float _TimeToLive;

    private Vector3 _direction;
    private float _speed;

    private List<ParticleModule> modules = new();

    public void Init(Vector3 direction, float speed, float timeToLive, Color color)
    {
        time = 0f;

        _direction = direction;
        _speed = speed;
        _TimeToLive = timeToLive;

        // Add Lifecycle module
        var lifecycleModule = new LifecycleModule();
        lifecycleModule.Init(this);
        modules.Add(lifecycleModule);

        // Add Movement module
        ParticleModule movementModule = null;

        // Get selected movement type from parent Generator
        if (transform.parent.TryGetComponent<Generator>(out var generator))
        {
            switch (generator.GetMovementType())
            {
                case Generator.MovementType.Tornado:
                    movementModule = new TornadoMovementModule();
                    break;
                case Generator.MovementType.Linear:
                default:
                    movementModule = new MovementModule();
                    break;
            }
        }

        if (movementModule != null)
        {
            movementModule.Init(this);
            modules.Add(movementModule);
        }


        // Add Visual module
        var visualModule = new VisualModule();
        visualModule.Init(this);
        modules.Add(visualModule);
    }

    public void ApplyForce(Vector3 force)
    {
        transform.position += force * Time.deltaTime;
    }

    void Update()
    {
        // Apply effect areas
        var areas = GameObject.FindObjectsByType<EffectArea>(FindObjectsSortMode.None);
        foreach (var area in areas)
        {
            area.ApplyEffect(this);
        }

        // Update all modules
        foreach (var module in modules)
        {
            module.Update(Time.deltaTime);
        }
    }

    // Let Generator know we were destroyed (for counting / burst mode)
    void OnDestroy()
    {
        if (transform.parent.TryGetComponent<Generator>(out var generator))
        {
            generator.OnParticleDestroyed(this);
        }
    }
}
