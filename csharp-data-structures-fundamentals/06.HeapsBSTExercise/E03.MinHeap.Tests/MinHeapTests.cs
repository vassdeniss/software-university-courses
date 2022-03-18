using E03.MinHeap;
using NUnit.Framework;
using System;

public class MinHeapTests
{
    [Test]
    public void Add_SingleElement_TestCount()
    {
        var heap = new MinHeap<int>();

        heap.Add(3);

        Assert.AreEqual(1, heap.Count);
    }

    [Test]
    public void Add_SingleElement_TestPeek()
    {
        var heap = new MinHeap<int>();

        heap.Add(3);

        Assert.AreEqual(3, heap.Peek());
    }

    [Test]
    public void Add_MultipleElements_TestCount()
    {
        var heap = new MinHeap<int>();

        heap.Add(3);
        Assert.AreEqual(1, heap.Count);

        heap.Add(5);
        Assert.AreEqual(2, heap.Count);

        heap.Add(6);
        Assert.AreEqual(3, heap.Count);
    }

    [Test]
    public void Add_MultipleElements_TestPeek()
    {
        var heap = new MinHeap<int>();

        heap.Add(8);
        Assert.AreEqual(8, heap.Peek());

        heap.Add(7);
        Assert.AreEqual(7, heap.Peek());

        heap.Add(3);
        Assert.AreEqual(3, heap.Peek());

        heap.Add(1);
        Assert.AreEqual(1, heap.Peek());

        heap.Add(5);
        Assert.AreEqual(1, heap.Peek());

        heap.Add(2);
        Assert.AreEqual(1, heap.Peek());
    }

    [Test]
    public void ExtractMin_SingleElement_TestCount()
    {
        var heap = new MinHeap<int>();

        heap.Add(3);
        heap.Add(5);
        heap.ExtractMin();

        Assert.AreEqual(1, heap.Count);
    }

    [Test]
    public void ExtractMin_SingleElement_TestElement()
    {
        var heap = new MinHeap<int>();

        heap.Add(3);

        Assert.AreEqual(3, heap.ExtractMin());
    }

    [Test]
    public void ExtractMin_MultipleElements_TestCount()
    {
        var heap = new MinHeap<int>();

        heap.Add(5);
        heap.Add(3);
        heap.Add(1);

        Assert.AreEqual(1, heap.ExtractMin());
        Assert.AreEqual(3, heap.ExtractMin());
        Assert.AreEqual(5, heap.ExtractMin());
        Assert.AreEqual(0, heap.Count);
    }

    [Test]
    public void ExtractMin_MultipleElements_TestElements()
    {
        var heap = new MinHeap<int>();

        heap.Add(3);
        heap.Add(5);
        heap.Add(6);
        heap.Add(7);

        Assert.AreEqual(3, heap.ExtractMin());
        Assert.AreEqual(5, heap.ExtractMin());
        Assert.AreEqual(6, heap.ExtractMin());
        Assert.AreEqual(7, heap.ExtractMin());
    }

    [Test]
    public void ExtractMin_LargeNumberOfOrderedElements_ReturnsCorrectElements()
    {
        var heap = new MinHeap<int>();

        heap.Add(1);
        heap.Add(2);
        heap.Add(3);
        heap.Add(7);
        heap.Add(6);
        heap.Add(5);
        heap.Add(4);
        heap.Add(15);
        heap.Add(14);
        heap.Add(13);
        heap.Add(12);
        heap.Add(11);
        heap.Add(10);
        heap.Add(9);
        heap.Add(8);

        Assert.AreEqual(1, heap.ExtractMin());
        Assert.AreEqual(2, heap.ExtractMin());
        Assert.AreEqual(3, heap.ExtractMin());
        Assert.AreEqual(4, heap.ExtractMin());
        Assert.AreEqual(5, heap.ExtractMin());
        Assert.AreEqual(6, heap.ExtractMin());
        Assert.AreEqual(7, heap.ExtractMin());
        Assert.AreEqual(8, heap.ExtractMin());
        Assert.AreEqual(9, heap.ExtractMin());
        Assert.AreEqual(10, heap.ExtractMin());
        Assert.AreEqual(11, heap.ExtractMin());
        Assert.AreEqual(12, heap.ExtractMin());
        Assert.AreEqual(13, heap.ExtractMin());
        Assert.AreEqual(14, heap.ExtractMin());
        Assert.AreEqual(15, heap.ExtractMin());
    }

    [Test]
    public void ExtractMin_EmptyHeap_ShouldThrowException()
    {
        var heap = new MinHeap<int>();

        Assert.Throws<InvalidOperationException>(() => heap.ExtractMin());
    }
}
