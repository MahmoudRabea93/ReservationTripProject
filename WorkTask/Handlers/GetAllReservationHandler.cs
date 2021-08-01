using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WorkTask.Model;
using WorkTask.Queries;

namespace WorkTask.Handlers
{
    public class GetAllReservationHandler : IRequestHandler<GetAllReservationQuery, List<Reservation>>
    {
        private DataBaseContext DB;
        public GetAllReservationHandler(DataBaseContext _DB)
        {
            this.DB = _DB;
        }
        public async Task<List<Reservation>> Handle(GetAllReservationQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(DB.Reservations.ToList());
        }
    }
}
