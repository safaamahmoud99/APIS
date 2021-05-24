﻿using AutoMapper;
using BL.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Bases
{
    public class BaseAppService : IDisposable
    {
        protected IUnitOfWork TheUnitOfWork { get; set; }
        protected readonly IMapper Mapper; //MapperConfig.Mapper;
        public BaseAppService(IUnitOfWork theUnitOfWork, IMapper mapper)
        {
            TheUnitOfWork = theUnitOfWork;
            Mapper = mapper;
        }
        public void Dispose()
        {
            TheUnitOfWork.Dispose();
        }
    }
}

