using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GkwCn.Framework.Commands
{
    public interface ICommandExecuter<in T> where T : ICommand
    {
        object Execute(T cmd);
    }
}
