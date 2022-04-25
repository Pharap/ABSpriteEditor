using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

//
//  Copyright (C) 2022 Pharap (@Pharap)
//
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.
//

namespace ABSpriteEditor.Utilities
{
    public static class TreeTraversalHelper
    {
        public static IEnumerable<TreeNode> PreorderEnumerateTreeNodes(TreeView treeView)
        {
            foreach (TreeNode childNode in treeView.Nodes)
                foreach (var result in PreorderEnumerateTreeNodes(childNode))
                    yield return result;
        }

        public static IEnumerable<TreeNode> PreorderEnumerateTreeNodes(TreeNode treeNode)
        {
            yield return treeNode;

            foreach (TreeNode childNode in treeNode.Nodes)
                foreach (var result in PreorderEnumerateTreeNodes(childNode))
                    yield return result;
        }

        public static IEnumerable<TreeNode> PostorderEnumerateTreeNodes(TreeView treeView)
        {
            foreach (TreeNode childNode in treeView.Nodes)
                foreach (var result in PostorderEnumerateTreeNodes(childNode))
                    yield return result;
        }

        public static IEnumerable<TreeNode> PostorderEnumerateTreeNodes(TreeNode treeNode)
        {
            foreach (TreeNode childNode in treeNode.Nodes)
                foreach (var result in PostorderEnumerateTreeNodes(childNode))
                    yield return result;

            yield return treeNode;
        }

        public static IEnumerable<TreeNodeCollection> PreorderEnumerateTreeNodeCollections(TreeView treeView)
        {
            return PreorderEnumerateTreeNodes(treeView).Select(node => node.Nodes);
        }

        public static IEnumerable<TreeNodeCollection> PreorderEnumerateTreeNodeCollections(TreeNode treeNode)
        {
            return PreorderEnumerateTreeNodes(treeNode).Select(node => node.Nodes);
        }

        public static IEnumerable<TreeNodeCollection> PostorderEnumerateTreeNodeCollections(TreeView treeView)
        {
            return PostorderEnumerateTreeNodes(treeView).Select(node => node.Nodes);
        }

        public static IEnumerable<TreeNodeCollection> PostorderEnumerateTreeNodeCollections(TreeNode treeNode)
        {
            return PostorderEnumerateTreeNodes(treeNode).Select(node => node.Nodes);
        }
    }
}
