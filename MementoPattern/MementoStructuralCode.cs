using System;

namespace ST2001681076
{
    public class Originator
    {
        private string state;

        public Memento CreateMemento()
        {
            return new Memento(state);
        }

        public void SetMemento(Memento memento)
        {
            this.state = memento.GetState();
        }
    }

    public class Memento
    {
        private string state;

        public Memento(string state)
        {
            this.state = state;
        }

        public string GetState()
        {
            return state;
        }
    }

    public class Caretaker
    {
        public Memento Memento { get; set; }
    }
}

