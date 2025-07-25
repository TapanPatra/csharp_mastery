using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamental._02_DataTypes.ClassesTheBasics
{
    public interface IDraggable
    {
        void Drag();
    }

    public interface IDroppable
    {
        void Drop();
    }

    public class Size
    {
        public int Width { get; set; }
        public int Height { get; set; }
    }

    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    public class TextBox : UiControl, IDraggable, IDroppable
    {
        public void Drag()
        {
            throw new NotImplementedException();
        }

        public void Drop()
        {
            throw new NotImplementedException();
        }
    }

    public class UiControl
    {
        public string Id { get; set; }
        public Size Size { get; set; }
        public Position TopLeft { get; set; }

        public virtual void Draw()
        {
        }

        public void Focus()
        {
            Console.WriteLine("Received focus.");
        }
    }

    [TestFixture]
    public class MultipleInheritance
    {
        [Test]
        public void MultipleInheritanceTest()
        {
            
        }
    }
}
