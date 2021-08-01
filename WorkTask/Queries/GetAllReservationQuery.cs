using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkTask.Mapper;
using WorkTask.Model;

namespace WorkTask.Queries
{
    public class GetAllReservationQuery:IRequest<List<Reservation>>
    {
    }
}
