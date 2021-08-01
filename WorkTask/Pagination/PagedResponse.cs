using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkTask.Mapper;
using WorkTask.Model;

namespace WorkTask.Pagination
{
    public class PagedResponse<T> : Response<T>
    {
        private IList<ReservationDTO> reservations;

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
     
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }
        public PagedResponse(T data, int pageNumber, int pageSize,int totalRecords,int totalPages)
        {
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
            this.Data = data;
            this.TotalRecords = totalRecords;
            this.TotalPages = totalPages;
            this.Message = null;
            this.Succeeded = true;
            this.Errors = null;
        }


        public PagedResponse(IList<ReservationDTO> reservations)
        {
            this.reservations = reservations;
        }
    }
}
