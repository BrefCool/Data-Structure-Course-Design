using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SHMetroApp
{
    public class MetroPathCollection
    {
        #region 字段

            private Dictionary<string, Dictionary<string, MetroPath>> _shortestPathCollection = new Dictionary<string, Dictionary<string, MetroPath>>();
        
        #endregion

        #region 方法

            public MetroPath getShortestPathCollection(string nodeName1, string nodeName2)
            {
                if (_shortestPathCollection.ContainsKey(nodeName1))
                {
                    if (_shortestPathCollection[nodeName1].ContainsKey(nodeName2))
                        return _shortestPathCollection[nodeName1][nodeName2];
                    else
                        return null;
                }

                if (_shortestPathCollection.ContainsKey(nodeName2))
                {
                    if (_shortestPathCollection.ContainsKey(nodeName1))
                        return _shortestPathCollection[nodeName2][nodeName1];
                    else
                        return null;
                }

                return null;
            }

            public void addShortestPathCollection(MetroPath newPath)
            {
                MetroPath tmpPath = getShortestPathCollection(newPath.startNode.ToString(),newPath.endNode.ToString());
                if (tmpPath == null)
                {
                    if (_shortestPathCollection.ContainsKey(newPath.startNode.ToString()))
                    {
                        _shortestPathCollection[newPath.startNode.ToString()].Add(newPath.endNode.ToString(), newPath);
                    }
                    else
                    {
                        Dictionary<string, MetroPath> tmpD = new Dictionary<string, MetroPath>();
                        tmpD.Add(newPath.endNode.Name, newPath);
                        _shortestPathCollection.Add(newPath.startNode.Name, tmpD);
                    }
                }
                else
                {
                    tmpPath.changeLinks(newPath);
                    tmpPath.totalWeight = newPath.totalWeight;
                }
            }
        
        #endregion
    }
}
