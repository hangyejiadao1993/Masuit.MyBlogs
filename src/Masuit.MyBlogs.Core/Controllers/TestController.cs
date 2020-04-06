using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Masuit.MyBlogs.Services.Interface;
using Masuit.Tools.Core.Configs;
using Microsoft.AspNetCore.Mvc;

namespace Masuit.MyBlogs.Core.Controllers
{
    public class TestController : Controller
    {

        private IMapper _mapper;
        private ITest _test;
        private IUserInfoService userInfoService;
        public TestController(IMapper mapper, ITest test, IUserInfoService _userInfoService)
        {
            _test = test;
            _mapper = mapper;
            userInfoService = _userInfoService;
        }
        public IActionResult Index()
        {
            return Json("OK");
        }
    }
}