using CRUD.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD.Core
{
    public class BaseController : Controller
    {
        private UnitOfWork _unitOfWork;

        public UnitOfWork UnitOfWork
        {
            get { return _unitOfWork ?? (_unitOfWork = new UnitOfWork()); }
        }
    }
}