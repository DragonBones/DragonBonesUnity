using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.Viperstudio.Geom;

namespace DragonBones
{
    class TweenCache
    {
        private static TweenCache instance;

        private Dictionary<String, Dictionary<String, Dictionary<String, List<Matrix>>>> animationList = new Dictionary<string, Dictionary<string, Dictionary<string, List<Matrix>>>>();
        //private Dictionary<String, Dictionary<String, List<Matrix>>> tweenList = new Dictionary<string, Dictionary<string, List<Matrix>>>();

        public static TweenCache GetInstance()
        {
            if (instance == null)
            {
                instance = new TweenCache();
            }

            return instance;
        }

        public Matrix GetGlobalTransformByProgress(String amartureName, String animationName, String timelineName,  float progress)
        {
            Matrix matrix = new Matrix();
            int timelineLength = animationList[amartureName][animationName][timelineName].Count;
            int position = (int)(timelineLength * progress);
            List<Matrix> timeline = animationList[amartureName][animationName][timelineName];
            return timeline[position];
        } 

        public void AddGlobalTransformByProgress(String amartureName, String animationName, String timelineName, Matrix transformMatrix )
        {
            if(animationList.ContainsKey(amartureName))
            {

            }
            else
            {
                animationList.Add(amartureName, new  Dictionary<string, Dictionary<string, List<Matrix>>>());
            }
            //Dictionary<String, Dictionary<String, List<Matrix>>> tweenList = new Dictionary<string, Dictionary<string, List<Matrix>>>()
            //Dictionary<String, Dictionary<String, List<Matrix>>> tweenList = new Dictionary<string, Dictionary<string, List<Matrix>>>()
            //animationList.Add
        }


    }
}
