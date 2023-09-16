using System.Collections;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class ToolTipSystem : MonoBehaviour {
    
    public static ToolTipSystem instance;
    [SerializeField] private ToolTip tooltip;

    private void Awake() {
        instance = this;
        tooltip.gameObject.transform.DOScale(0, 0);
    }

    public IEnumerator Show(string content, string header = "") {
        tooltip.SetText(content,header); 
        tooltip.gameObject.SetActive(true); 
        tooltip.gameObject.transform.DOScale(1, 0.1f);
        yield break;
    }

    public IEnumerator Hide() {
        tooltip.gameObject.transform.DOScale(0, 0.1f);
        tooltip.gameObject.SetActive(false);
        yield break;
    }
}
