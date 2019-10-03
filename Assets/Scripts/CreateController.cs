using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateController : SingletionMonoBehaviour<CreateController>
{
    [SerializeField]
    private ColorNumberController color;
    [SerializeField]
    private NumberTextController number;

    public T Spawn<T>(T Object, Transform parent , Vector3 Pos ) where T : MonoBehaviour
    {
        T object_ = Instantiate<T>(Object, parent);
        object_.transform.localPosition = Pos;
        return object_;
    }
    public ColorNumberController create(Transform parent)
    {
        return Spawn(color, parent , Vector3.zero);
    }
    public NumberTextController createNumberInTexture( Vector3 Postion, Transform parent)
    {
        return Spawn(number, parent, Postion);
    }
}
