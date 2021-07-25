using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Financial_assistant.Controllers.BaseControllers
{
    public abstract class BaseController : ControllerBase
    {
        public IMapper Mapper { get; }
        protected BaseController(IMapper mapper)
        {
            Mapper = mapper;
        }
    }
}
