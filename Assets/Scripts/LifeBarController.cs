using UnityEngine;
using UnityEngine.UI;

public class LifeBarController : MonoBehaviour
{
    #region Fields

    [SerializeField]
    private int minValue;

    [SerializeField]
    private float maxValue;

    [SerializeField]
    private Text text;

    private float lifebarMaxWidth;    

    private float foregroundWidth;
    public float ForegroundWidth
    {
        get { return foregroundWidth; }
        set
        {
            this.value = Mathf.Clamp(value, this.minValue, this.maxValue);
            text.text = this.value.ToString() + "/" + this.maxValue.ToString();
            foregroundWidth = this.value;
            this.foregroundWidth = this.lifebarMaxWidth * this.value / this.maxValue;

            if (this.isRadialLifeBar)
                this.foreground.GetComponent<Image>().fillAmount = this.value / this.maxValue;
            else
                this.foreground.sizeDelta = new Vector2(this.foregroundWidth, this.foreground.sizeDelta.y);
        }
    }

    [SerializeField]
    private float value;

    [SerializeField]
    private RectTransform foreground;

    [SerializeField]
    private bool isWorldLifebar;

    [SerializeField]
    private bool isRadialLifeBar;

    #endregion

    #region MonoBehavior

    private void Awake()
    {
        this.lifebarMaxWidth = this.GetComponent<RectTransform>().sizeDelta.x;

        //force start maximized
        this.ForegroundWidth = this.maxValue;
    }

    private void Update()
    {
        if (this.isWorldLifebar)
            this.transform.LookAt(this.transform.position + Camera.main.transform.rotation * -Vector3.back,
                                  Camera.main.transform.rotation * Vector3.up);
    }

    #endregion

    #region Public Methods

    public void UpdateLifeBar(float value)
    {
        this.ForegroundWidth = value;
    }

    #endregion
}
