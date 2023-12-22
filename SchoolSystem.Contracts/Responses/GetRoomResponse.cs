﻿namespace SchoolSystem.Contracts.Responses
{
    public class GetRoomResponse
    {
        public required int Id { get; init; }
        public required int Capacity { get; init; }
        public required string Location { get; init; }
        public required string Name { get; init; }
    }
}
