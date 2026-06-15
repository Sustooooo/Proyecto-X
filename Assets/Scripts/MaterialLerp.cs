using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class MaterialLerp : MonoBehaviour
{
    public float start = 0f;
    public AnimationCurve curveIn;
    public AnimationCurve curveOut;
    public float target = 1f;
    public float duration = 2f;
    public bool outCurve;


    private MaterialPropertyBlock propertyBlock;
    [SerializeField] private string attributeRef;
    [SerializeField] private Renderer rend;

    private int attributeID;
    //genero un ID para el atributo expuesto
    void Start()
    {
        attributeID = Shader.PropertyToID(attributeRef);
        rend.material.SetFloat(attributeRef, 0f);
        propertyBlock = new MaterialPropertyBlock();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            StartCoroutine(AnimateCycle());
        }
    }
    
    IEnumerator AnimateCycle()
    {

        yield return StartCoroutine(ErodeLogic(start, target, duration, curveIn));

        if (outCurve) //outCurve == true
        {
          yield return new WaitForSeconds(3f);

          yield return StartCoroutine(ErodeLogic(target, start, duration, curveOut));

        }
    }

    IEnumerator ErodeLogic(float start, float target, float duration, AnimationCurve curve)
    {
        float elapsed = 0f;
        float lerpValue;

        while (elapsed < duration)
        {
            lerpValue = Mathf.Lerp(start, target, curve.Evaluate(elapsed / duration));

            rend.GetPropertyBlock(propertyBlock);
            propertyBlock.SetFloat(attributeID, lerpValue);
            rend.SetPropertyBlock(propertyBlock);

            elapsed += Time.deltaTime; //elapsed = elapsed + Time.deltaTime;
            yield return null;
        } 
        lerpValue = target;

        rend.GetPropertyBlock(propertyBlock);
        propertyBlock.SetFloat(attributeID, lerpValue);
        rend.SetPropertyBlock(propertyBlock);

        yield return null;
    }



}
