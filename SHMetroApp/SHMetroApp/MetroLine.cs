using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SHMetroApp
{
    public class MetroLine
    {
        //地铁总路线类
        #region 字段

            private string _mName = "";
            private Color _mColor = Color.Black;

        #endregion

        #region 属性

            //获取和设置总线路名称
            public string Name
            {
                get { return _mName; }
                set { _mName = value; }
            }

            //获取和设置总线路在图中的标识颜色
            public Color LineColor
            {
                get { return _mColor; }
                set { _mColor = value; }
            }
        
        #endregion

        #region 方法
 
            //构造函数
            public MetroLine(string name,Color color)
            {
                this.Name = name;
                this.LineColor = color;
            }

            //重载ToString()
            public override string ToString()
            {
                return this.Name;
            }

        #endregion
    }
}
