using NUnit.Framework;
using L03.MaxHeap;
using System;

[TestFixture]
public class MaxHeapTests
{

    [Test]
    public void Add_SingleElement_TestCount()
    {
        var heap = new MaxHeap<int>();

        heap.Add(3);

        Assert.AreEqual(1, heap.Size);
    }

    [Test]
    public void Add_SingleElement_TestPeek()
    {
        var heap = new MaxHeap<int>();

        heap.Add(3);

        Assert.AreEqual(3, heap.Peek());
    }

    [Test]
    public void Add_MultipleElements_TestCount()
    {
        var heap = new MaxHeap<int>();

        heap.Add(3);
        Assert.AreEqual(1, heap.Size);

        heap.Add(5);
        Assert.AreEqual(2, heap.Size);

        heap.Add(6);
        Assert.AreEqual(3, heap.Size);
    }

    [Test]
    public void Add_MultipleElements_TestPeek()
    {
        var heap = new MaxHeap<int>();

        heap.Add(3);
        Assert.AreEqual(3, heap.Peek());

        heap.Add(5);
        Assert.AreEqual(5, heap.Peek());

        heap.Add(2);
        Assert.AreEqual(5, heap.Peek());

        heap.Add(1);
        Assert.AreEqual(5, heap.Peek());

        heap.Add(7);
        Assert.AreEqual(7, heap.Peek());

        heap.Add(8);
        Assert.AreEqual(8, heap.Peek());
    }

    [Test]
    public void ExtractMax_SingleElement_TestCount()
    {
        var heap = new MaxHeap<int>();

        heap.Add(3);
        heap.Add(5);
        heap.ExtractMax();

        Assert.AreEqual(1, heap.Size);
    }

    [Test]
    public void ExtractMax_SingleElement_TestElement()
    {
        var heap = new MaxHeap<int>();

        heap.Add(3);

        Assert.AreEqual(3, heap.ExtractMax());
    }

    [Test]
    public void ExtractMax_MultipleElements_TestCount()
    {
        var heap = new MaxHeap<int>();

        heap.Add(5);
        heap.Add(3);
        heap.Add(1);

        Assert.AreEqual(5, heap.ExtractMax());
        Assert.AreEqual(3, heap.ExtractMax());
        Assert.AreEqual(1, heap.ExtractMax());
        Assert.AreEqual(0, heap.Size);
    }

    [Test]
    public void ExtractMax_MultipleElements_TestElements()
    {
        var heap = new MaxHeap<int>();

        heap.Add(3);
        heap.Add(5);
        heap.Add(6);
        heap.Add(7);

        Assert.AreEqual(7, heap.ExtractMax());
        Assert.AreEqual(6, heap.ExtractMax());
        Assert.AreEqual(5, heap.ExtractMax());
        Assert.AreEqual(3, heap.ExtractMax());
    }

    [Test]
    public void ExtractMax_EmptyHeap_ShouldThrowException()
    {
        var heap = new MaxHeap<int>();

        Assert.Throws<InvalidOperationException>(() => heap.ExtractMax());
    }
}
