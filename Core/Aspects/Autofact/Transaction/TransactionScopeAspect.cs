using Castle.DynamicProxy;
using Core.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace Core.Aspects.Autofact
{
    public class TransactionScopeAspect: CacheAspect
    {
        public override void Intercept(IInvocation invocation)
        {
            using(TransactionScope transactionScope = new TransactionScope())
            {
                try
                {
                    invocation.Proceed();
                    transactionScope.Complete();
                }
                catch (System.Exception)
                {
                    transactionScope.Dispose();
                    throw;
                }
            }
        }
    }
}
