using UnityEngine;
using UnityEngine.UI;

public class GradientFromFill : MonoBehaviour
{
    [SerializeField] private Gradient gradient;

    private Image image;

    private void Start()
    {
        image = GetComponent<Image>();
    }

    private void Update()
    {
        Apply();
    }

    //ContectMenu adds an item to the right-click menu of the component
    [ContextMenu("Apply")]
    public void Apply() 
    {
        if (image == null) { image = GetComponent<Image>(); }

        image.color = gradient.Evaluate(image.fillAmount);
    }

    private void OnValidate()
    {
        Apply();
    }
}
