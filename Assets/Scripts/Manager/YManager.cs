
using UnityEngine;

public abstract class YManager
{
    public abstract void OnAwake();
    public abstract void OnStart();
}

public interface YTest
{

}

public class TT : MonoBehaviour, YTest
{

}