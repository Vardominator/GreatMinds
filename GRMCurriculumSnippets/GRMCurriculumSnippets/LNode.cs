using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRMCurriculumSnippets
{
    class LNode<T>
    {

        LNode<T> next;
        LNode<T> prev;
        T val;

        public LNode<T> Next { get { return next; } set { next = value; } }
        public LNode<T> Prev { get { return prev; } set { prev = value; } }

        public T Val { get { return val; } set { val = value; } }

        public LNode()
        {
            next = null;
            prev = null;
        }

        public LNode(T value)
        {
            this.val = value;
            next = null;
            prev = null;
        }

    }
}
