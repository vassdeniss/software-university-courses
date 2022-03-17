namespace L01.BinaryTree
{
    using System;
    using System.Collections.Generic;

    public interface IAbstractBinaryTree<T>
    {
        T Value { get; }

        IAbstractBinaryTree<T> LeftChild { get; }

        IAbstractBinaryTree<T> RightChild { get; }

        string AsIndentedPreOrder(int indent);

        IEnumerable<IAbstractBinaryTree<T>> PreOrder();

        IEnumerable<IAbstractBinaryTree<T>> InOrder();

        IEnumerable<IAbstractBinaryTree<T>> PostOrder();

        void ForEachInOrder(Action<T> action);
    }
}
