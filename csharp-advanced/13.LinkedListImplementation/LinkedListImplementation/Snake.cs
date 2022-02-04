using System;

namespace LinkedListImplementation
{
    public class Snake
    {
        public Snake()
        {
            SnakeElements = new CustomLinkedList<SnakeElement>();
        }

        public CustomLinkedList<SnakeElement> SnakeElements { get; set; }

        public void MoveSnake(Direction direction)
        {
            Node<SnakeElement> snakeHead = SnakeElements.Head;
            Node<SnakeElement> newHead = new Node<SnakeElement>(new SnakeElement()
            {
                Position = new Position(snakeHead.Value.Position),
                Character = snakeHead.Value.Character
            });

            SnakeElements.AddHead(newHead);
            SnakeElements.RemoveTail();

            if (direction == Direction.Right) newHead.Value.Position.Col++;
            if (direction == Direction.Left) newHead.Value.Position.Col--;
            if (direction == Direction.Up) newHead.Value.Position.Row--;
            if (direction == Direction.Down) newHead.Value.Position.Row++;

            GameUtils.SnakeField = GameUtils.InitialiseSnakeField();
        }
    }
}
