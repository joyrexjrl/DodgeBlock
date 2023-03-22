using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    MeshRenderer cubeMeshRenderer;
    [SerializeField] [Range(0f, 1f)] float _lerpTime;
    [SerializeField] Color[] _colors;

    int _colorIndex = 0;
    int _len;
    float _timer = 0f;

    void Awake()
    {
        cubeMeshRenderer = GetComponent<MeshRenderer>();
        _len = _colors.Length;
    }

    void Update()
    {
        cubeMeshRenderer.material.color = Color.Lerp(cubeMeshRenderer.material.color, _colors[_colorIndex], _lerpTime * Time.deltaTime);

        _timer = Mathf.Lerp(_timer, 1f, _lerpTime * Time.deltaTime);
        if(_timer > .9f)
        {
            _timer = 0f;
            _colorIndex++;
            _colorIndex = (_colorIndex >= _len) ? 0 : _colorIndex;
        }
    }
}
