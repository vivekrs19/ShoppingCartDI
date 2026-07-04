using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.PaymentProcessors
{
    public interface IRefundProcessor
    {
        void ProcessRefund(double amount);
    }
}
