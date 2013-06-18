using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GkwCn.Framework.Events;

namespace GkwCn.Framework.Data
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        void Execute();
        UnitOfWorkScope OpenUnitOfWorkScope();
        bool IsAutoDispose { get; set; }
    }
}
