using System;

namespace L02.GraphicEditor
{
    public class GraphicEditor
    {
        public void DrawShape(IShape shape)
        {
            Console.WriteLine(shape.Draw());
        }
    }
}
