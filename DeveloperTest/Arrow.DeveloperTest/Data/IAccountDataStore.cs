using Arrow.DeveloperTest.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arrow.DeveloperTest.Data
{
    public interface IAccountDataStore
    {
        IAccount GetAccount(string accountNumber);

        void UpdateAccount(IAccount account);
    }
}
