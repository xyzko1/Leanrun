using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Infoearth.Application.Web.Utility
{
    public class CNode
    {
        public string Key = string.Empty;

        public string Text = string.Empty;

        public string Icon = string.Empty;

        public string ParentCode = string.Empty;

        public List<CNode> Nodes = new List<CNode>();

        public object Tag;

        public CNode()
        {
        }

        public CNode(string key, string text)
        {
            this.Key = key;
            this.Text = text;
        }

        public bool IsExisitKey(string key)
        {
            CNode cNode = this.Nodes.Find((CNode t) => t.Key == key);
            return cNode != null;
        }

        public CNode GetNode(string key)
        {
            return this.Nodes.Find((CNode t) => t.Key == key);
        }

        public string ToJsonString(string id)
        {
            string hasChildren = "true";
            if (this.Nodes.Count == 0)
                hasChildren = "false";
            string str = "{" + string.Format("\"id\":\"{0}\",\"icons\":\"{1}\",\"checked\":{2},\"state\":\"{3}\",\"key\":\"{4}\",\"text\":\"{5}\",\"complete\":{6},\"hasChildren\":{7},\"complete\":{7},\"isexpand\":{8},\"showcheck\":{9},\"parentnodes\":\"{10}\"", new object[]
			{
				id,
				this.Icon,
				"false",
				string.Empty,
				this.Key,
				this.Text,
                "true",
                hasChildren,
                "false",
                "true",
                this.ParentCode
			});
            if (this.Nodes.Count > 0)
            {
                string text = string.Empty;
                int count = 0;
                foreach (CNode current in this.Nodes)
                {
                    text = text + current.ToJsonString(id + "_" + count) + ",";
                    count++;
                }
                text = text.TrimEnd(new char[]
				{
					','
				});
                str += string.Format(",\"ChildNodes\":{0}", "[" + text + "]");
            }
            return str + "}";
        }
    }
}