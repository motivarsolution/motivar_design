using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqliteDB.Model;

namespace SqliteDB.Controller
{
    public class QueueTransaction
    {
        private readonly Queue<TransactionAccountModel> queue = new Queue<TransactionAccountModel>();
        public event EventHandler Enqueued;
        public event EventHandler Dequeued;
        protected virtual void OnEnqueued()
        {
            if (Enqueued != null)
                Enqueued(this, EventArgs.Empty);
        }
        protected virtual void OnDequeued()
        {
            if (Dequeued != null)
                Dequeued(this, EventArgs.Empty);
        }
        public virtual void Enqueue(TransactionAccountModel item)
        {
            queue.Enqueue(item);
            OnEnqueued();
        }
        public int Count
        {
            get
            {
                return queue.Count;
            }
        }
        public virtual TransactionAccountModel Dequeue()
        {
            TransactionAccountModel item = queue.Dequeue();
            OnDequeued();
            return item;
        }

    }
}
