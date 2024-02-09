namespace SchoolSystem.Contracts.Requests.Rooms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class GetAllRoomsRequest
    {
        public required int? Capacity { get; init; }
        public required string? Location { get; init; }
    }
}
