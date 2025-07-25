using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fundamentals
{
    public delegate void FakeEventHandler(string reason);
    public class FakeEventRaiser
    {
        private FakeEventHandler currentHandler = null;

        public void AddHandler(FakeEventHandler handler)
        {
            currentHandler = currentHandler + handler;
        }

        public void RemoveHandler(FakeEventHandler handler)
        {
            currentHandler = currentHandler - handler;
        }

        public void DoSomething(string text)
        {
            FakeEventHandler tmp = currentHandler;
            if(currentHandler != null)
            {
                tmp.Invoke(text);
            }
        }
    }

    public class FakeEventRaiserTest
    {
        private void ReportToConsole(string text)
        {
            Console.WriteLine("Called: {0}", text);
        }

        [Test]
        public void RaiseEvents()
        {
            FakeEventRaiserTest instance = new FakeEventRaiserTest();

            FakeEventHandler handler = new FakeEventHandler(instance.ReportToConsole);

            FakeEventRaiser raiser = new FakeEventRaiser();
            raiser.DoSomething("Not Subscribed");

            raiser.AddHandler(handler);
            raiser.DoSomething("Subscribed");

            raiser.AddHandler(handler);
            raiser.DoSomething("Subscribed twice");

            raiser.RemoveHandler(handler);
            raiser.RemoveHandler(handler);
            raiser.DoSomething("UnSubscribed");


        }
    }

    public delegate void ClickHandler(object sender, EventArgs e);
    public class LongHandEventRaiser
    {
        private ClickHandler currentHandler = null;

        public void OnClick()
        {
            ClickHandler tmp = currentHandler;

            if (tmp != null)
            {
                tmp.Invoke(this, EventArgs.Empty);
            }

        }

        public event ClickHandler Click
        {
            add
            {
                currentHandler += value;
            }

            remove
            {
                currentHandler -= value;
            }
        }


    }

    public class LongHandEventRaiserTest
    {
        private void ReportToConsole(object sender, EventArgs e)
        {
            Console.WriteLine("Report console is Called");
        }

        [Test]
        public void RaiseEvents()
        {

            ClickHandler handler = ReportToConsole;

            var raiser = new LongHandEventRaiser();
            raiser.OnClick();

            raiser.Click += handler;
            raiser.OnClick();

            raiser.Click += handler;
            raiser.OnClick();

            raiser.Click -= handler;
            raiser.Click -= handler;
            raiser.OnClick();


        }
    }

    public class ShortHandEventRaiser
    {
        public void OnClick()
        {
            ClickHandler tmp = Click;

            if (tmp != null)
            {
                tmp.Invoke(this, EventArgs.Empty);
            }

        }
        public event ClickHandler Click;

    }

    public class ShortHandEventRaiserTest
    {
        private void ReportToConsole(object sender, EventArgs e)
        {
            Console.WriteLine("Report console is Called");
        }

        [Test]
        public void RaiseEvents()
        {

            ClickHandler handler = ReportToConsole;

            var raiser = new ShortHandEventRaiser();
            raiser.OnClick();

            raiser.Click += handler;
            raiser.OnClick();

            raiser.Click += handler;
            raiser.OnClick();

            raiser.Click -= handler;
            raiser.Click -= handler;
            raiser.OnClick();


        }
    }
    
}
