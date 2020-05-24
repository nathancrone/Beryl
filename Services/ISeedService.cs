using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Beryl.Services
{
    public interface ISeedService
    {
        void SeedUsers();
        void SeedRedirects();
    }
}