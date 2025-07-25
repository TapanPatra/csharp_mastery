using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamental._02_DataTypes.Events
{
    public class ButtonUsingDelegate
    {
        public delegate void ClickHandler(object sender, EventArgs e);

        private ClickHandler click;

        protected void OnClick()
        {
            if(click!= null)
            {
                click(this, EventArgs.Empty);
            }
        }

        public void AddClick(ClickHandler clickHandler)
        {
            click += clickHandler;
        }
        public void RemoveClick(ClickHandler clickHandler)
        {
            click -= clickHandler;
        }

        public void SimulateClick()
        {
            OnClick();
        }
    }

    public class Button
    {
        public delegate void ClickHandler(object sender, EventArgs e);

        public event ClickHandler Click;

        protected void OnClick()
        {
            if (Click != null)
            {
                Click(this, EventArgs.Empty);
            }
        }

        public void SimulateClick()
        {
            OnClick();
        }
    }

    [TestFixture]
    public class ButtonTest
    {
      
        public void ButtonHandler(object sender, EventArgs e)
        {
            Console.WriteLine("Button Clicked");
        }

        [Test]
        public void ButtonClickTestUsingDelegate()
        {
            ButtonUsingDelegate button = new ButtonUsingDelegate();
            button.AddClick(ButtonHandler);
            button.SimulateClick();
            button.RemoveClick(ButtonHandler);
        }

        [Test]
        public void ButtonClickTestUsingEvent()
        {
            Button button = new Button();
            button.Click += ButtonHandler ;
            button.SimulateClick();
            button.Click -= ButtonHandler;
        }
    }
}
