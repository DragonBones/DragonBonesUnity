using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.Viperstudio.Geom;
using UnityEngine;

namespace DragonBones
{
    class TweenCache
    {
        private static TweenCache instance;

		private Dictionary<String, Dictionary<String, Dictionary<String, List<Matrix>>>> amartureList = new Dictionary<string, Dictionary<string, Dictionary<string, List<Matrix>>>>();
        //private Dictionary<String, Dictionary<String, List<Matrix>>> tweenList = new Dictionary<string, Dictionary<string, List<Matrix>>>();

        public static TweenCache GetInstance()
        {
            if (instance == null)
            {
                instance = new TweenCache();
            }
            return instance;
        }

		public bool hasCachedAnimation(String amartureName, String animationName)
		{
			if(amartureList.ContainsKey(amartureName))
			{
				if(amartureList[amartureName].ContainsKey(animationName))
				{
					return true;
				}
			}
			return false;
		}

        public Matrix GetGlobalTransformByProgress(String amartureName, String animationName, String timelineName,  float progress)
        {
            Matrix matrix = new Matrix();
			int timelineLength = amartureList[amartureName][animationName][timelineName].Count;
            int position = (int)(timelineLength * progress);
           
			List<Matrix> timeline = amartureList[amartureName][animationName][timelineName];
			//if(timelineName == "man-head")
			//	Debug.logger.Log(position + "  " + timeline[position].A+ "  " + timeline[position].B+ "  " + timeline[position].C+ "  " +  timeline[position].D);
            return timeline[position];
        } 

        public void AddGlobalTransform(String amartureName, String animationName, String timelineName, Matrix transformMatrix )
        {
			if(amartureList.ContainsKey(amartureName))
            {
				Dictionary<string, Dictionary<string, List<Matrix>>> animationList = amartureList[amartureName];
				if(animationList.ContainsKey(animationName))
				{
					Dictionary<string, List<Matrix>> timelineList = animationList[animationName];
					if(timelineList.ContainsKey(timelineName))
					{
						List<Matrix> timeline = timelineList[timelineName];
						timeline.Add(new Matrix(transformMatrix.A, transformMatrix.B, transformMatrix
							.C, transformMatrix.D, transformMatrix.Tx, transformMatrix.Ty));
						if(timelineName == "head")
							Debug.logger.Log(timeline.Count + "  " + transformMatrix.A+ "  " + transformMatrix.B+ "  " + transformMatrix.C+ "  " +  transformMatrix.D);
						

					}
					else
					{
						timelineList.Add(timelineName, new List<Matrix>());
						AddGlobalTransform(amartureName, animationName, timelineName, transformMatrix);
					}
				}
				else
				{
					animationList.Add(animationName, new Dictionary<string, List<Matrix>>());
					AddGlobalTransform(amartureName, animationName, timelineName, transformMatrix);
				}
            }
            else
            {
				amartureList.Add(amartureName, new  Dictionary<string, Dictionary<string, List<Matrix>>>());
				AddGlobalTransform(amartureName, animationName, timelineName, transformMatrix);
            }
        }
			
    }
}
