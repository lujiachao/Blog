﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Model
{
    /// <summary>
    /// layui的树形菜单的节点模型
    /// </summary>
    public class TreeNode_LayUI : BaseModel
    {
        public string name { set; get; }
        public bool spread { set; get; }
        public List<TreeNode_LayUI> children { set; get; }
        public int pid { set; get; }
    }
}
