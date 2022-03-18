namespace E02.LowestCommonAncestor
{
    using System;

    public interface IAbstractBinaryTree<T> where T : IComparable<T>
    {
        T Value { get; }

        BinaryTree<T> LeftChild { get; }

        BinaryTree<T> RightChild { get; }

        BinaryTree<T> Parent { get; }

        T FindLowestCommonAncestor(T first, T second);
    }
}
