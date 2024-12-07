using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField]
    private Color _toChange;

    private Color _originalColor;
    private MeshRenderer _meshRenderer;

    public bool _isGoal = false;

    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _originalColor = _meshRenderer.material.color;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Goal")
        {
            _isGoal = true;
            _meshRenderer.material.color = _toChange;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Goal")
        {
            _isGoal = false;
            _meshRenderer.material.color = _originalColor;
        }
    }
}
