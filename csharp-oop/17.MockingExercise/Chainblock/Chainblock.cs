using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Chainblock.Contracts;

namespace Chainblock
{
    public class Chainblock : IChainblock
    {
        private readonly Dictionary<int, ITransaction> transactions;

        public Chainblock()
        {
            transactions = new Dictionary<int, ITransaction>();
        }

        public int Count => transactions.Count;

        public void Add(ITransaction tx)
        {
            if (!transactions.ContainsKey(tx.Id))
            {
                transactions.Add(tx.Id, tx);
            }
        }

        public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
        {
            if (!transactions.ContainsKey(id))
            {
                throw new ArgumentException("Transaction not found!");
            }

            transactions[id].Status = newStatus;
        }   

        public bool Contains(ITransaction tx) => transactions.ContainsKey(tx.Id);

        public bool Contains(int id) => transactions.ContainsKey(id);

        public IEnumerable<ITransaction> GetAllInAmountRange(double lo, double hi)
        {
            return transactions.Values.Where(x => x.Amount >= lo && x.Amount <= hi);
        }

        public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById()
        {
            return transactions.Values.OrderByDescending(x => x.Amount).ThenBy(x => x.Id);
        }

        public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
        {
            List<string> transactions = new List<string>();

            List<ITransaction> filtered = this.transactions.Values.Where(x => x.Status == status).ToList();
            foreach (ITransaction tx in filtered)
            {
                if (!transactions.Contains(tx.To))
                {
                    transactions.Add(tx.To);
                }
            }

            if (transactions.Count == 0)
            {
                throw new InvalidOperationException("Did not find people who recieved transactions with this status!");
            }

            return transactions;
        }

        public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
        {
            List<string> transactions = new List<string>();
            
            List<ITransaction> filtered = this.transactions.Values.Where(x => x.Status == status).ToList();
            foreach (ITransaction tx in filtered)
            {
                if (!transactions.Contains(tx.From))
                {
                    transactions.Add(tx.From);
                }
            }

            if (transactions.Count == 0)
            {
                throw new InvalidOperationException("Did not find people who sent transactions with this status!");
            }

            return transactions;
        }

        public ITransaction GetById(int id)
        {
            if (!transactions.ContainsKey(id))
            {
                throw new InvalidOperationException("Transaction does not exist!");
            }

            return transactions[id];
        }

        public IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
        {
            List<ITransaction> transactions = this.transactions.Values
                .Where(x => x.To == receiver && x.Amount >= lo && x.Amount < hi).ToList();

            if (transactions.Count == 0)
            {
                throw new InvalidOperationException("Did not find transactions recieved from this reciever!");
            }

            return transactions.OrderByDescending(x => x.Amount).ThenBy(x => x.Id);
        }

        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            List<ITransaction> transactions = this.transactions.Values.Where(x => x.To == receiver).ToList();

            if (transactions.Count == 0)
            {
                throw new InvalidOperationException("Did not find transactions recieved from this reciever!");
            }

            return transactions.OrderByDescending(x => x.Amount).ThenBy(x => x.Id);
        }

        public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
        {
            List<ITransaction> transactions = this.transactions.Values
                .Where(x => x.From == sender && x.Amount > amount).ToList();

            return transactions.OrderByDescending(x => x.Amount);
        }

        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            List<ITransaction> transactions = this.transactions.Values.Where(x => x.From == sender).ToList();

            if (transactions.Count == 0)
            {
                throw new InvalidOperationException("Did not find transactions sent from this sender!");
            }

            return transactions.OrderByDescending(x => x.Amount);
        }

        public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
        {
            List<ITransaction> transactions = this.transactions.Values.Where(x => x.Status == status).ToList();

            if (transactions.Count == 0)
            {
                throw new InvalidOperationException("Did not find transactions with this status!");
            }

            return transactions.OrderByDescending(x => x.Amount);
        }

        public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
        {
            List<ITransaction> transactions = this.transactions.Values
                .Where(x => x.Status == status && x.Amount <= amount).ToList();

            return transactions.OrderByDescending(x => x.Amount);
        }

        public IEnumerator<ITransaction> GetEnumerator()
        {
            foreach (int key in transactions.Keys)
            {
                yield return transactions[key];
            }
        }

        public void RemoveTransactionById(int id)
        {
            if (!transactions.ContainsKey(id))
            {
                throw new InvalidOperationException("Transaction does not exist!");
            }

            transactions.Remove(id);
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
