using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MunicipalReporterAppProg.Models;

namespace MunicipalReporterAppProg.Services
{
    public static class AppState
    {
        public static readonly List<Issue> Issues = new List<Issue>();
    }
}
