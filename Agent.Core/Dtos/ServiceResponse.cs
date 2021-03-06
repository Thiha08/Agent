﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Agent.Core.Dtos
{
    public class ServiceResponse
    {
        public bool Success { get; set; }

        public string Message { get; set; }
    }

    public class ServiceResponse<T> : ServiceResponse
    {
        public T Data { get; set; }
    }
}
