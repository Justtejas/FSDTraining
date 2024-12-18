﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalPatterns.ObserverPattern
{
    public interface IInvestor
    {
        void Update(Stock stock);
    }
    public class Stock
    {
        private string _symbol;
        private double _price;
        private List<IInvestor> _investors = new List<IInvestor>();
        public Stock(string symbol, double price)
        {
            _symbol = symbol;
            _price = price;
        }

        public string Symbol { get { return _symbol; } }
        public double Price { get { return _price; } set
            {
                if (_price != value)
                {
                    _price = value;
                    Notify();
                }
            }
        }

        public void Attach(IInvestor investor)
        {
            _investors.Add(investor);
        }
        public void Detach(IInvestor investor)
        {
            _investors.Remove(investor);
        }
        public void Notify()
        {
            foreach (var investor in _investors)
            {
                investor.Update(this);
            }
        }
    }
   public class Investor : IInvestor
    {
        private string _name;
        private Stock _stock;
        public Investor (string name)
        {
            _name = name;
        }
        public void Update(Stock stock)
        {
            _stock = stock;
            Console.WriteLine($"Notified {_name} of {stock.Symbol}'s price changed to {stock.Price}");
        }
    } 
}
