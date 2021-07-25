﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Entities.Pagination
{
    public abstract class RequestParam
    {
        const int maxPageSize = 50;
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 10;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }

            set
            { 
                _pageSize = ( value > maxPageSize ) ? maxPageSize : value ;
            }
        }

        public class EmployeeParam : RequestParam
        {

        }
    }
}