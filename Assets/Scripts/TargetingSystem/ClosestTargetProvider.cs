using System.Linq;
using UnityEngine;


public class ClosestTargetProvider : MonoBehaviour
{
    [SerializeField] public float radius = 5f;
    [SerializeField] public LayerMask targetLayerMask;

    private Transform transform;

    private void Awake()
    {
        transform = GetComponent<Transform>();
    }

    public T GetTarget<T>() where T : MonoBehaviour
    {
        var allTargets = Physics.OverlapSphere(transform.position, radius, targetLayerMask);

        return allTargets
            .Select(target => target.GetComponent<T>())
            .Where(Component => Component == true) //only if component is existant
            .OrderBy(component => (component.transform.position - transform.position).sqrMagnitude) //order by distance
            .FirstOrDefault(); // gets first object in overlapSphere
    }
}
