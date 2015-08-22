using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SHMetroApp
{
    class MetroPathCollection
    {
        #region 字段

            private Dictionary<string, Dictionary<string, MetroPath>> _shortestPathCollection;
        
        #endregion

        #region 方法

            public MetroPath getShortestPathCollection(string nodeName1, string nodeName2)
            {
                MetroPath path = _shortestPathCollection["nodeName1"]["nodeName2"];
                if (path != null)
                    return path;
                else
                    return _shortestPathCollection["nodeName2"]["nodeName1"];
            }

            public void addShortestPathCollection(MetroPath newPath)
            {
                if(_shortestPathCollection[newPath.startNode.Name][newPath.endNode.Name] == null &&
                   _shortestPathCollection[newPath.endNode.Name][newPath.startNode.Name] == null)
                {
                    Dictionary<string, MetroPath> tmpD = new Dictionary<string, MetroPath>();
                    tmpD.Add(newPath.endNode.Name, newPath);
                    _shortestPathCollection.Add(newPath.startNode.Name, tmpD);
                }
            }
        
        #endregion
    }
}
