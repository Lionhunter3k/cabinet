﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cabinet.Core.Providers.Results {
    public interface IMoveResult : IFileOperationResult {
        bool AlreadyExists { get; }
    }
}