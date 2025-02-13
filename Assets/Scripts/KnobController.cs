using UnityEngine;

public class KnobController : MonoBehaviour
{
    public Material highlightMaterial;
    public Material defaultMaterial;
    private Renderer knobRenderer;
    [SerializeField] private GameObject needlePivot;
    private bool isControlNotActive = true;
    private int[] angles = {0, 50, 120, 230, 300};
    private int anglesIndex = 0;

    public MultimetrConroller multimetr;
    void Start()
    {
        knobRenderer = GetComponent<Renderer>();
    }

    private void OnMouseEnter()
    {
        knobRenderer.material = highlightMaterial;
        isControlNotActive = false;
    }

    private void OnMouseExit()
    {
        knobRenderer.material = defaultMaterial; 
        isControlNotActive = true;
    }

    void Update()
    {
        if (isControlNotActive || Input.GetAxis("Mouse ScrollWheel") == 0f) return;
        multimetr.SwitchMode((Input.GetAxis("Mouse ScrollWheel") > 0f ? 1 : -1));
        anglesIndex = (Input.GetAxis("Mouse ScrollWheel") > 0f ? (anglesIndex + 1) : (anglesIndex - 1 + angles.Length)) % angles.Length;
        needlePivot.transform.localRotation *= Quaternion.Euler(0, angles[anglesIndex] - needlePivot.transform.localRotation.eulerAngles.y, 0);
    }
}
