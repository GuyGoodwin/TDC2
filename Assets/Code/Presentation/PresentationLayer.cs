using System.Collections;
using UnityEngine;

namespace TDC2.Presentation
{
    public class PresentationLayer : MonoBehaviour
    {
        protected static PresentationLayer singleton;

        protected ScreenBase currentScreen;

        [SerializeField] protected Transform screenAnchor;
        [SerializeField] protected Transform hudAnchor;

        void Start ()
        {
            singleton = this;
        }

        IEnumerator screenTransitionProc(GameObject destination)
        {
            if(currentScreen != null)
            {
                currentScreen.BeginTransitionOut();
                while(!currentScreen.closeFlag)
                {
                    yield return null;
                }
            }
            currentScreen = GameObject.Instantiate(destination,screenAnchor,false).GetComponent<ScreenBase>();
        }
    }

    public abstract class ScreenBase : MonoBehaviour
    {
        public abstract bool closeFlag {  get; }
        public abstract void BeginTransitionOut();
    }
}