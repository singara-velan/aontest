using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PopulationAnalyzer.Repositories.UnitOfWork
{
    public interface IUnitOfWork
    {
        IPopulationMockRepository PopulationMockRepository { get; }

        //void Commit();
        //void Dispose();
    }
}
