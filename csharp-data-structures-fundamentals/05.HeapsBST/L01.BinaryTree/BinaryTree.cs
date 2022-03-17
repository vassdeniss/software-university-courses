namespace L01.BinaryTree
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
    {
        public BinaryTree(T element, IAbstractBinaryTree<T> left, IAbstractBinaryTree<T> right)
        {
            Value = element;
            LeftChild = left;
            RightChild = right;
        }

        public T Value { get; private set; }

        public IAbstractBinaryTree<T> LeftChild { get; private set; }

        public IAbstractBinaryTree<T> RightChild { get; private set; }

        public string AsIndentedPreOrder(int indent)
        {
            StringBuilder sb = new StringBuilder();
            PreOrderDfs(sb, indent, this);
            return sb.ToString();
        }

        private void PreOrderDfs(StringBuilder sb, int indent, IAbstractBinaryTree<T> binaryTree)
        {
            sb.Append(new string(' ', indent)).AppendLine(binaryTree.Value.ToString());

            if (binaryTree.LeftChild != null)
            {
                PreOrderDfs(sb, indent + 2, binaryTree.LeftChild);
            }

            if (binaryTree.RightChild != null)
            {
                PreOrderDfs(sb, indent + 2, binaryTree.RightChild);
            }
        }

        public void ForEachInOrder(Action<T> action)
        {
            ForEachInOrder(action, this);
        }

        private void ForEachInOrder(Action<T> action, IAbstractBinaryTree<T> binaryTree)
        {
            if (binaryTree.LeftChild != null)
            {
                ForEachInOrder(action, binaryTree.LeftChild);
            }

            action(binaryTree.Value);

            if (binaryTree.RightChild != null)
            {
                ForEachInOrder(action, binaryTree.RightChild);
            }
        }

        public IEnumerable<IAbstractBinaryTree<T>> InOrder()
        {
            List<IAbstractBinaryTree<T>> list = new List<IAbstractBinaryTree<T>>();

            if (LeftChild != null)
            {
                list.AddRange(LeftChild.InOrder());
            }

            list.Add(this);

            if (RightChild != null)
            {
                list.AddRange(RightChild.InOrder());
            }

            return list;
        }

        public IEnumerable<IAbstractBinaryTree<T>> PostOrder()
        {
            List<IAbstractBinaryTree<T>> list = new List<IAbstractBinaryTree<T>>();

            if (LeftChild != null)
            {
                list.AddRange(LeftChild.PostOrder());
            }

            if (RightChild != null)
            {
                list.AddRange(RightChild.PostOrder());
            }

            list.Add(this);

            return list;
        }

        public IEnumerable<IAbstractBinaryTree<T>> PreOrder()
        {
            List<IAbstractBinaryTree<T>> list = new List<IAbstractBinaryTree<T>>();

            list.Add(this);

            if (LeftChild != null)
            {
                list.AddRange(LeftChild.PreOrder());
            }

            if (RightChild != null)
            {
                list.AddRange(RightChild.PreOrder());
            }

            return list;
        }
    }
}
