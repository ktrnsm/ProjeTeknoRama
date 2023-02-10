using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace WEBUI.Models.ShoppingTools
{
    public class Card
    {
        Dictionary<int, CardItem> _myBasket;

        public Card()
        {
            _myBasket = new Dictionary<int, CardItem>();
        }

        public List<CardItem> MyBasket 
        {
            get
            {
                return _myBasket.Values.ToList();
            }
        }
        public void AddToCard(CardItem item)
        {
            if(_myBasket.ContainsKey(item.ID))
            {
                _myBasket[item.ID].Amount += 1;
                return;
            }
            _myBasket.Add(item.ID, item);
        }

        public void RemoveFromCard(int id)
        {
            if (_myBasket[id].Amount>1)
            {
                _myBasket[id].Amount -= 1;
                return;
            }
            _myBasket.Remove(id);
              
        }

        public decimal TotalCost { get
            {
                return _myBasket.Sum(x => x.Value.SubTotal);
            } }

        public int ProductCount()
        {
            return _myBasket.Sum(x => x.Value.Amount);
        }

    }
}